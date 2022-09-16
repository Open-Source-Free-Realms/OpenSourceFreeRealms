using log4net;
using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Player;
using Gateway.MapChat;
using System;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using static Gateway.Login.ClientPcData;

namespace Gateway.Login
{
    public static class LoginManager
    {
        private static ILog _log;

        public static SOEServer _server;

        public static List<ClientItemDefinition> ClientItemDefinitions;
        public static List<PointOfInterestDefinition> PointOfInterestDefinitions;

        public static void Start(SOEServer soeServer = null)
        {
            _server = soeServer ?? Gateway.Server;

            _log = _server.Logger.GetLogger("LoginManager");

            _log.Info("Service constructed");

            ClientItemDefinitions = new List<ClientItemDefinition>();
            PointOfInterestDefinitions = new List<PointOfInterestDefinition>();

            if(File.Exists(@"..\ofrserver\Customize\ClientItemDefinitions.json"))
                ClientItemDefinitions = JsonConvert.DeserializeObject<List<ClientItemDefinition>>(File.ReadAllText(@"..\ofrserver\Customize\ClientItemDefinitions.json"));

            if (File.Exists(@"..\ofrserver\Customize\PointOfInterestDefinitions.json"))
                PointOfInterestDefinitions = JsonConvert.DeserializeObject<List<PointOfInterestDefinition>>(File.ReadAllText(@"..\ofrserver\Customize\PointOfInterestDefinitions.json"));
        }

        [SOEMessageHandler("PacketLogin", (ushort)ClientGatewayBasePackets.PacketLogin, "CGAPI_527")]
        public static void HandleLoginRequest(SOEClient soeClient, SOEMessage message)
        {
            //PlayerCode.SendEncounterOverworldCombat(soeClient);
            soeClient.SendMessage(new SOEWriter(new SOEMessage((ushort)ClientGatewayBasePackets.PacketClientIsHosted, StringToByteArray("0700"))).GetFinalSOEMessage(soeClient));
            SendLoginReply(soeClient);
            SendInitializationParameters(soeClient);
            SendZoneDetails(soeClient);
            SendClientGameSettings(soeClient);
            SendAnnouncementData(soeClient);
            PlayerCode.SendPlayerUpdateItemDefinitions(soeClient);
            PlayerCode.SendSelfToClient(soeClient);
        }

        public static void SendLoginReply(SOEClient soeClient)
        {
            var loginReply = new SOEWriter((ushort)ClientGatewayBasePackets.PacketLoginReply, true);

            loginReply.AddBoolean(true);

            SendTunneledClientPacket(soeClient, loginReply.GetRaw());
        }

        public static void SendInitializationParameters(SOEClient soeClient)
        {
            var initializationParameters = new SOEWriter((ushort)BasePackets.PacketInitializationParameters, true);

            initializationParameters.AddNullTerminatedString("live");

            SendTunneledClientPacket(soeClient, initializationParameters.GetRaw());
        }

        public static void SendZoneDetails(SOEClient soeClient)
        {
            var zoneDetails = new SOEWriter((ushort)BasePackets.PacketSendZoneDetails, true);

            zoneDetails.AddASCIIString("FabledRealms");
            zoneDetails.AddHostUInt32(2);
            zoneDetails.AddBoolean(false);
            zoneDetails.AddBoolean(false);
            zoneDetails.AddASCIIString("");
            zoneDetails.AddBoolean(false);
            zoneDetails.AddHostUInt32(0);
            zoneDetails.AddHostUInt32(5);
            zoneDetails.AddBoolean(false);
            zoneDetails.AddBoolean(false);

            SendTunneledClientPacket(soeClient, zoneDetails.GetRaw());
        }

        public static void SendClientGameSettings(SOEClient soeClient)
        {
            var clientGameSettings = new SOEWriter((ushort)BasePackets.PacketClientGameSettings, true);

            clientGameSettings.AddHostUInt32(4);
            clientGameSettings.AddHostUInt32(7);
            clientGameSettings.AddHostUInt32(268);
            clientGameSettings.AddBoolean(true);
            clientGameSettings.AddFloat(1.0f);

            SendTunneledClientPacket(soeClient, clientGameSettings.GetRaw());
        }

        public static void SendAnnouncementData(SOEClient soeClient)
        {
            var announcementData = new SOEWriter();

            const uint announcementCount = 1;

            announcementData.AddHostUInt32(announcementCount);

            for (var i = 0; i < announcementCount; i++)
            {
                announcementData.AddHostUInt32(139);
                announcementData.AddHostUInt32(1);
                announcementData.AddHostUInt32(47736);
                announcementData.AddHostUInt32(5103267);
                announcementData.AddHostUInt32(0);
                announcementData.AddHostUInt32(1911);
                announcementData.AddASCIIString("Exit");
                announcementData.AddASCIIString("Param");
                announcementData.AddHostUInt32(0);
                announcementData.AddHostUInt32(0);
                announcementData.AddHostUInt32(0);
                announcementData.AddASCIIString("");
            }

            var rawBytes = announcementData.GetRaw();

            var announcementBase = new SOEWriter((ushort)BasePackets.AnnouncementBasePacket, true);

            announcementBase.AddByte((byte)AnnouncementBasePackets.AnnouncementDataSendPacket);

            announcementBase.AddBytes(rawBytes);

            SendTunneledClientPacket(soeClient, announcementBase.GetRaw());
        }

        [SOEMessageHandler("PacketTunneledClientPacket", (ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, "CGAPI_527")]
        public static void HandleTunneledClientPacket(SOEClient soeClient, SOEMessage soeMessage)
        {
            SOEReader reader = new SOEReader(soeMessage);

            var unknown = reader.ReadBoolean();
            var length = reader.ReadHostInt32();

            var opCode = reader.ReadHostUInt16();

            switch (opCode)
            {
                case (ushort)BasePackets.PacketClientIsReady:
                    HandlePacketClientIsReady(soeClient);
                    break;

                case (ushort)BasePackets.PacketZoneTeleportRequest:
                    HandlePacketZoneTeleportRequest(soeClient, reader);
                    break;

                case (ushort)BasePackets.PacketGameTimeSync:
                    HandlePacketGameTimeSync(soeClient, reader);
                    break;

                case (ushort)BasePackets.PlayerUpdatePacketUpdatePosition:
                    HandlePlayerUpdatePacketUpdatePosition(soeClient, reader);
                    break;

                default:
                    var data = reader.ReadToEnd();
                    _log.Info($"HandleTunneledClientPacket OpCode: {opCode}\n{BitConverter.ToString(data).Replace("-", "")}");
                    break;
            }
        }

        private static void HandlePacketClientIsReady(SOEClient soeClient)
        {
            Chat.SendQuickChatPacket(soeClient);
            Map.SendPacketPointOfInterestDefinitionReply(soeClient);
            NPC.SendPlayerUpdatePacketAddNpc(soeClient);

            UpdateStats.SendClientUpdatePacketHitpoints(soeClient);
            UpdateStats.SendClientUpdatePacketMana(soeClient);
            UpdateStats.SendAbilityPacketSetDefinition(soeClient);
            UpdateStats.SendClientUpdatePacketAddEffectTag(soeClient);
            SendPacketLoadWelcomeScreen(soeClient);
            //Map.SendObjectiveTargetUpdatePacket(soeClient);
            //Map.SendPacketPOIChangeMessage(soeClient);
            //SendClientBeginZoning(soeClient);
            SendTunneledClientPacket(soeClient, StringToByteArray(/* AdventurersJournalInfoPacket */"D1000100000004000000010000000100000025D24D00FFD14D00798A000000000000F400000060D74D0002000000020000000BBF060000D24D003C250000000000000500000039C106000300000003000000AD0D00005108000042250000000000000800000061D74D000400000004000000B10D00003DC106003925000000000000010000003EC106000A0000000100000001000000010000000100000068BF06001300000014AD000016AD000027D24D000000000000000000020000000200000001000000020000002F4900001300000014AD000017AD000028D24D0000000000000000000300000003000000010000000300000025D24D001300000014AD000015AD000029D24D000000000000000000040000000400000002000000010000005E1C00001300000014AD00008DAF00000DBF0600000000000000000005000000050000000200000002000000C38B06001300000014AD00008EAF00000EBF06000000000000000000060000000600000002000000030000000CBF06001300000014AD000091AF00000FBF06000000000000000000070000000700000002000000040000004C1100001300000014AD00008FAF000010BF0600000000000000000008000000080000000300000001000000FFD84D001300000014AD0000D3B0000000D94D0000000000000000000900000009000000030000000200000001D94D001300000014AD0000D4B0000002D94D0000000000000000000A0000000A0000000400000001000000FFC006001300000014AD000020B200003FC1060000000000000000003A000000D209000001000000D209000002000000D109000001000000D109000001000000D909000002000000D909000002000000DE09000002000000DE09000007000000DA09000002000000DA09000003000000DB09000002000000DB09000004000000DC09000002000000DC09000005000000DD09000002000000DD09000006000000E109000003000000E109000003000000E009000003000000E009000002000000DF09000003000000DF09000001000000060A000003000000060A000005000000E209000003000000E209000004000000BD09000004000000BD09000006000000BC09000004000000BC09000005000000BB09000004000000BB09000004000000BA09000004000000BA09000003000000B909000004000000B909000002000000EA09000004000000EA09000001000000C209000005000000C209000006000000C109000005000000C109000005000000C009000005000000C009000004000000BF09000005000000BF09000003000000BE09000005000000BE09000002000000E309000005000000E309000001000000C609000006000000C609000004000000C509000006000000C509000003000000C409000006000000C409000002000000C309000006000000C309000001000000C709000006000000C709000005000000E509000007000000E509000007000000E409000007000000E409000001000000C809000007000000C809000002000000CC09000007000000CC09000006000000CB09000007000000CB09000005000000C909000007000000C909000003000000CA09000007000000CA09000004000000140A000008000000140A000005000000120A000008000000120A000003000000130A000008000000130A000004000000110A000008000000110A000002000000100A000008000000100A000001000000190A000009000000190A00000A000000180A000009000000180A000009000000170A000009000000170A000008000000160A000009000000160A000007000000150A000009000000150A000006000000280A000009000000280A00000B000000230A00000A000000230A000006000000220A00000A000000220A0000050000001F0A00000A0000001F0A0000040000001E0A00000A0000001E0A000003000000240A00000A000000240A0000070000001C0A00000A0000001C0A000001000000270A00000A000000270A00000A000000260A00000A000000260A000009000000250A00000A000000250A0000080000001D0A00000A0000001D0A0000020000001000000001000000010000000100000001000000030A0000BFD34D00C0D34D000FA900000EA900000000000002000000020000000100000002000000040A0000C3D34D00C4D34D0017A9000016A900000000000003000000030000000100000003000000050A0000C7D34D00C8D34D0009A9000008A9000000000000040000000400000001000000040000000C0A0000E4D44D00E5D44D0011A9000010A9000000000000050000000500000001000000050000000D0A0000E8D44D00E9D44D001BA900001AA9000000000000060000000600000001000000060000001B0A000083D64D0084D64D0013A9000012A900000000000010000000100000000200000001000000080A0000D4D44D00D5D44D0029A9000028A900000000000011000000110000000200000002000000090A0000D8D44D00D9D44D0017A9000016A9000000000000120000001200000002000000030000000A0A0000DCD44D00DDD44D0009A9000008A9000000000000130000001300000002000000040000000B0A0000E0D44D00E1D44D000FA900000EA9000000000000140000001400000002000000050000000E0A0000ECD44D00EDD44D000DA900000CA9000000000000150000001500000002000000060000000F0A0000F0D44D00F1D44D0013A9000012A9000000000000200000002000000003000000020000002A0A0000E3C10600E9C1060017A9000016A9000000000000230000002300000003000000050000002D0A0000E6C10600ECC106000FA900000EA9000000000000240000002400000003000000060000002E0A0000E7C10600EDC1060029A9000028A900000000000025000000250000000400000001000000200A00000000000000000000000000000000000000000000"));
            SendTunneledClientPacket(soeClient, StringToByteArray(/* AdventurersJournalQuestUpdatePacket */"D1000200000000000000"));
            SendPacketZoneDoneSendingInitialData(soeClient);
            PlayerCode.SendClientUpdatePacketDoneSendingPreloadCharacters(soeClient);
            SendPacketMOTD(soeClient);

            foreach (SOEClient otherClient in _server.ConnectionManager.Clients)
            {
                //if (soeClient == otherClient) continue;
                SendPlayerUpdatePacketAddPc(soeClient, otherClient.GetClientID());
                SendPlayerUpdatePacketAddPc(otherClient, soeClient.GetClientID());
            }
        }

        public static void SendPacketLoadWelcomeScreen(SOEClient soeClient)
        {
            SendTunneledClientPacket(soeClient, StringToByteArray(/* PacketLoadWelcomeScreen */"5D000103000000291800002A1800002B1800002C1800002D1800002E18000006000000080000004D4D4D444F4E55546F2006007E200600A1030000000000000C000000424552525943555043414B456D2006007C200600AB0300000000000008000000534B454C4554414C453E06004CAA0100830D0000040000006E6176790C000000535452415742455252494553463E060094A90100710D000008000000636F6E63726574650600000046524F474759473E0600450C0000EA040000000000000800000053414E4457494348483E06007E090000B503000000000000F42C020063000000"));
        }

        public static void SendClientBeginZoning(SOEClient soeClient)
        {
            SOEWriter beginZoning = new SOEWriter((ushort)BasePackets.PacketClientBeginZoning, true);
            beginZoning.AddASCIIString("FabledRealms");
            beginZoning.AddHostUInt32(2u);
            beginZoning.AddFloat(-1414.643433f); // X
            beginZoning.AddFloat(-27.634825f); // Y
            beginZoning.AddFloat(351.556366f); // Z
            beginZoning.AddFloat(0f);
            for (uint num = 0u; num < 4; num++)
            {
                beginZoning.AddHostUInt32(20 * num);
            }
            beginZoning.AddASCIIString("FabledRealms");
            beginZoning.AddBoolean(false);
            beginZoning.AddByte(2);
            beginZoning.AddHostUInt32(16u);
            beginZoning.AddHostUInt32(4u);
            beginZoning.AddHostUInt32(5u);
            beginZoning.AddBoolean(false);
            beginZoning.AddBoolean(false);

            SendTunneledClientPacket(soeClient, beginZoning.GetRaw());
        }

        public static void SendPacketZoneDoneSendingInitialData(SOEClient soeClient)
        {
            var zoneDoneSendingInitialData = new SOEWriter((ushort)BasePackets.PacketZoneDoneSendingInitialData, true);

            SendTunneledClientPacket(soeClient, zoneDoneSendingInitialData.GetRaw());
        }

        public static void SendPacketMOTD(SOEClient soeClient)
        {
            var packet = new SOEWriter((ushort)BasePackets.PacketMOTD, true);

            packet.AddASCIIString("Welcome to OSFR!"); //MOTD title
            packet.AddASCIIString("Welcome, this is 100% a test build and anything seen here will be subject to change or break! If you happen to stumble across and aren't in our discord please join :) https://discord.gg/bd4junaw -OSFR"); //Message

            SendTunneledClientPacket(soeClient, packet.GetRaw());
        }

        private static void HandlePacketZoneTeleportRequest(SOEClient soeClient, SOEReader reader)
        {
            var zone = reader.ReadHostInt32();

            _log.Info($"HandlePacketZoneTeleportRequest Zone: {zone}");

            var pointOfInterestDefinition = PointOfInterestDefinitions.FirstOrDefault(x => x.GUID == zone);

            if (pointOfInterestDefinition is null)
                return;

            var soeWriter = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);

            soeWriter.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketUpdateLocation);

            soeWriter.AddFloat(pointOfInterestDefinition.PositionX);
            soeWriter.AddFloat(pointOfInterestDefinition.PositionY);
            soeWriter.AddFloat(pointOfInterestDefinition.PositionZ);
            soeWriter.AddFloat(1.0f);

            soeWriter.AddFloat(0.0f);
            soeWriter.AddFloat(0.0f);
            soeWriter.AddFloat(0.0f);
            soeWriter.AddFloat(0.0f);

            soeWriter.AddBoolean(true);
            soeWriter.AddByte(1);

            SendTunneledClientPacket(soeClient, soeWriter.GetRaw());
        }

        private static void HandlePacketGameTimeSync(SOEClient soeClient, SOEReader reader)
        {
            var time = reader.ReadHostUInt64();
            var unknown2 = reader.ReadHostUInt32();
            var unknown3 = reader.ReadBoolean();

            _log.Info($"HandlePacketGameTimeSync Time: {time}, Unknown2: {unknown2}, Unknown3: {unknown3} ");

            var soeWriter = new SOEWriter((ushort)BasePackets.PacketGameTimeSync, true);

            soeWriter.AddHostInt64(DateTimeOffset.Now.ToUnixTimeSeconds());
            soeWriter.AddHostInt32(0);
            soeWriter.AddBoolean(true);

            SendTunneledClientPacket(soeClient, soeWriter.GetRaw());
        }

        public static void SendTunneledClientPacket(SOEClient soeClient, byte[] rawBytes)
        {
            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostUInt32((uint)rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }

        [SOEMessageHandler("PacketTunneledClientWorldPacket", (ushort)ClientGatewayBasePackets.PacketTunneledClientWorldPacket, "CGAPI_527")]
        public static void HandleTunneledClientWorldPacket(SOEClient soeClient, SOEMessage soeMessage)
        {
            SOEReader reader = new SOEReader(soeMessage);

            var unknown = reader.ReadBoolean();
            var length = reader.ReadHostInt32();

            var opCode = reader.ReadHostUInt16();

            switch (opCode)
            {
                case (ushort)BasePackets.BaseCommandPacket:
                    HandleBaseCommandPacket(soeClient, reader);
                    break;

                default:
                    var data = reader.ReadToEnd();
                    _log.Info($"HandleTunneledClientWorldPacket OpCode: {opCode}\n{BitConverter.ToString(data).Replace("-", "")}");
                    break;
            }
        }

        public static void HandleBaseCommandPacket(SOEClient soeClient, SOEReader reader)
        {
            var opCode = reader.ReadHostUInt16();

            switch (opCode)
            {
                case (ushort)BaseCommandPackets.CommandPacketFriendsPositionRequest:
                    HandleCommandPacketFriendsPositionRequest(soeClient);
                    break;

                default:
                    var data = reader.ReadToEnd();
                    _log.Info($"HandleBaseCommandPacket OpCode: {opCode}\n{BitConverter.ToString(data).Replace("-", "")}");
                    break;
            }
        }

        public static void HandleCommandPacketFriendsPositionRequest(SOEClient soeClient)
        {
            /* var soeWriter = new SOEWriter((ushort)BasePackets.PlayerUpdatePacketUpdatePosition, true);

            soeWriter.AddHostInt64(5427660847725618161); // Guid

            // Position
            soeWriter.AddFloat(-1597.2408f); // X
            soeWriter.AddFloat(-42.257397f); // Y
            soeWriter.AddFloat(-456.4496f); // Z

            // Camera Rotation
            soeWriter.AddFloat(-0.8758389f);
            soeWriter.AddFloat(0.0f);
            soeWriter.AddFloat(0.48260355f);

            soeWriter.AddByte(2); // 2 - Player
            soeWriter.AddByte(0);

            SendTunneledClientPacket(soeClient, soeWriter.GetRaw()); */
        }

        private static void SendPlayerUpdatePacketAddPc(SOEClient target, long playerGUID)
        {
            string fileName = "Fallback";
            if (File.Exists($@"..\ofrserver\Customize\PacketSendSelfToClient\{playerGUID}.json"))
            {
                fileName = playerGUID.ToString();
            }

            var clientPcData = JsonConvert.DeserializeObject<ClientPcDatas>(File.ReadAllText($@"..\ofrserver\Customize\PacketSendSelfToClient\{fileName}.json"), new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            var addPc = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            addPc.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddPc);
            addPc.AddInt64(playerGUID); // Player GUID

            addPc.AddHostInt32(0); // Unknown Zero 1
            addPc.AddHostInt32(0); // Unknown Zero 2
            addPc.AddHostInt32(0); // Unknown Zero 3

            addPc.AddASCIIString(clientPcData.FirstName);
            addPc.AddASCIIString(clientPcData.LastName);

            addPc.AddHostInt32(1); // Unknown 1
            addPc.AddHostInt32(408679); // Unknown 2
            addPc.AddHostInt32(13951728); // Unknown 3
            addPc.AddHostInt32(1); // Unknown 4

            Random random = new Random();
            for (var i = 0; i < clientPcData.PlayerPosition.Length; i++) // Position
                addPc.AddFloat(clientPcData.PlayerPosition[i]);

            for (var i = 0; i < 4; i++) // Rotation
                addPc.AddFloat(0.0f);

            List<(int, ProfileItem)> profileItems = clientPcData.ClientPcProfiles[0].Items; // 0 means adventurer
            List<ClientItemDefinition> equippedItems = new List<ClientItemDefinition>();
            foreach ((int, ProfileItem) item in profileItems)
            {
                int itemGuid = item.Item2.ItemGUID;
                ClientItemDefinition itemDefintion = ClientItemDefinitions.Find(x => (x.Unknown == itemGuid));
                if (itemDefintion != null)
                    equippedItems.Add(itemDefintion);
            }

            for (var i = 0; i < equippedItems.Count; i++)
            {
                ClientItemDefinition item = equippedItems[i];
                if (i == 0)
                    addPc.AddHostInt32(equippedItems.Count);
                else
                    addPc.AddHostInt32(i);
                addPc.AddASCIIString(item.ModelBase);
                addPc.AddASCIIString(item.ModelTexture);
                addPc.AddASCIIString(item.ModelColor);
                addPc.AddHostInt64(item.IconData.IconColor);
            }

            addPc.AddHostInt32(equippedItems.Count + 1);
            addPc.AddASCIIString(clientPcData.PlayerHead);
            addPc.AddASCIIString(clientPcData.PlayerHair);
            addPc.AddHostInt32(clientPcData.HairColor);
            addPc.AddHostInt32(clientPcData.EyeColor);
            addPc.AddHostInt32(1); // Color for HumanBeardsPixieWings, which is one of the unknowns.
            addPc.AddASCIIString(clientPcData.Skintone);
            addPc.AddASCIIString(clientPcData.FacePaint);
            addPc.AddASCIIString(clientPcData.HumanBeardsPixieWings);

            // "Normal" from "Ani"
            // 000000410001000000000001000000AA2805285500D82FFF28DD0701000000000000000000000000000000000000000200000002000000EF0100000200000000000000000000000000C842100E000000B11674BFD9E8524B7E0A0000F20E00000000000000000000000000000000000000000000000000000001012700000059EE0000170000000000000000000000000000000000000000C15DD1798C9C534BC8020000C80200000100000000000000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF000000000000000055559540000000000000000000000000

            // "Rizan"
            // 0000004100010000000000010000000E4F2DF7E604F0F0E84BDD077800000000000000000000000000000000000000000000000000000000000000FFFFFFFFFFFFFFFF00000000000000007DD20740000000000000000000000000

            // John
            // 00000041010100000000000100000044402DF7AC0BF0F0E84BDD070100000000000000000000000000000000000000010000000200000059EE000017000000000000000000000000000000000000000011968EB0E2F1534B3E0100003E0100000100000000000000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF0000000000000000FAA40F40000000000000000000000000

            // "Normal" from "Sir Edwards"
            // 0000004100010000000000010000002951557C2913887B0042DD070100000000000000000000000000000000000000010000000200000059EE0000170000000000000000000000000000000000000000513959474185524B94000000940000000100000000000000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000

            // Sareh
            // 0000004100010000000000010000000E4F2DF7E604F0F0E84BDD070100000000000000000000000000000000000000000000000000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000

            // "Street fighter with dark aura" from "DRAGONMASTER SHERLOCK"
            // 000000410001000000000000000000010000003D00000001000000C3CB0100000000000200000002000000EF0100000200000000000000000000000000C842100E000000513959474185524B4B810100FB000000000000000000000000000000000000000000000000000000000101050000002CC3000002000000000000000000000000000000FE06000000513959474185524B67000000FB0000000100000081140000000000000000000000000000000000000001010000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000

            // gabriella earthlydream "The Sniper Extraordinaire"
            // 00000041010100000000000000000001000000000000000000000000000000000000000200000002000000EF0100000200000000000000000000000000C842100E000000614FDA8378CF534BE9030000E90300000000000000000000000000000000000000000000000000000001010300000059EE0000170000000000000000000000000000000000000000614FDA8378CF534B0B0000000B00000001000000000000000000000000000000000000000000000000000112000000308175000000000001000000000000001D000000CDCC8C40000000000000000000000000

            // David - Revived Effect
            // 000000410001000000000001000000494BBD67130060605A4BDD0701000000000000000000000000000000000000000400000002000000EF0100000200000000000000000000000000C842100E000000B10373BB545C534BD6010000D60100000000000000000000000000000000000000000000000000000001010300000059EE0000170000000000000000000000000000000000000000B10373BB545C534BD6010000D601000001000000000000000000000000000000000000000000000000000104000000340B00000200000000000000000000000000C842100E000000B10373BB545C534BD6010000D601000001000000A20F00000000000000000000000000000000000000000105000000350B000008000000000000000000000000000000100E000000B10373BB545C534BD6010000D601000001000000A20F0000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF000000001900000000000000000000000000000000000000

            // Unorthodox
            // 000000410001000000000001000000C048C990BD0014977D48DD07010000000600000003000000BB380000000000000100000002000000EF0100000200000000000000000000000000C842100E000000A1AE55254314534B6A0A00006A0A00000000000000000000000000000000000000000000000000000001010000000000000000FFFFFFFFFFFFFFFF000000000000000000000000000000000000000000000000

            // Wendy Snowydream
            // 0000004100010000000000010000002643FDCF0C0120C82A42DD07780000003D00000001000000C3CB0100000000000400000002000000EF0100000200000000000000000000000000C842100E000000A1ED10AD7CE6524B61000000610000000000000000000000000000000000000000000000000000000001010300000059EE0000170000000000000000000000000000000000000000A1ED10AD7CE6524B610000006100000001000000000000000000000000000000000000000000000000000104000000340B00000200000000000000000000000000C842100E000000A1ED10AD7CE6524B610000006100000001000000A20F00000000000000000000000000000000000000000105000000350B000008000000000000000000000000000000100E000000A1ED10AD7CE6524B610000006100000001000000A20F0000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000

            byte[] otherUnknownBytes = StringToByteArray("0000004100010000000000010000002951557C2913887B0042DD070100000000000000000000000000000000000000010000000200000059EE0000170000000000000000000000000000000000000000513959474185524B94000000940000000100000000000000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000");
            addPc.AddBytes(otherUnknownBytes);

            _log.Debug($"AddPc: {BitConverter.ToString(addPc.GetRaw()).Replace("-", "")}");

            SendTunneledClientPacket(target, addPc.GetRaw());
        }

        public static void HandlePlayerUpdatePacketUpdatePosition(SOEClient soeClient, SOEReader reader)
        {
            long PlayerGUID = reader.ReadUInt64();

            float[] PlayerPosition = new float[4];
            for (var i = 0; i < PlayerPosition.Length; i++)
                PlayerPosition[i] = reader.ReadSingle();

            float[] PlayerOrientation = new float[4];
            for (var i = 0; i < PlayerOrientation.Length; i++)
                PlayerOrientation[i] = reader.ReadSingle();

            byte PlayerState = reader.ReadByte();
            byte unknown = reader.ReadByte();

            var soeWriter = new SOEWriter((ushort)BasePackets.PlayerUpdatePacketUpdatePosition, true);


            soeWriter.AddInt64(soeClient.GetClientID()); // PlayerGUID

            for (var i = 0; i < PlayerPosition.Length; i++)
                soeWriter.AddFloat(PlayerPosition[i]);

            for (var i = 0; i < PlayerOrientation.Length; i++)
                soeWriter.AddFloat(PlayerOrientation[i]);

            soeWriter.AddByte(PlayerState);
            soeWriter.AddByte(unknown);

            foreach (SOEClient otherClient in _server.ConnectionManager.Clients)
            {
                //if (soeClient == otherClient) continue;
                SendTunneledClientPacket(otherClient, soeWriter.GetRaw());
                _log.Info($"HandlePlayerUpdatePacketUpdatePosition {soeClient.GetClientID()} -> {otherClient.GetClientID()}");
            }

            //_log.Info($"HandlePlayerUpdatePacketUpdatePosition:\n\t- PlayerGUID: {PlayerGUID}\n\t- PlayerPosition:\n\t\tX: {PlayerPosition[0]}\n\t\tY: {PlayerPosition[1]}\n\t\tZ: {PlayerPosition[2]}\n\t- PlayerOrientation:\n\t\tX: {PlayerOrientation[0]}\n\t\tY: {PlayerOrientation[1]}\n\t\tZ: {PlayerOrientation[2]}\n\t- PlayerState: {PlayerState}\n\t- Unknown: {unknown}");
        }

        public static void SendTunneledClientWorldPacket(SOEClient soeClient, byte[] rawBytes)
        {
            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientWorldPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostUInt32((uint)rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }

        public static byte[] StringToByteArray(string hex)
        {
            byte[] array = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return array;
        }
    }
}