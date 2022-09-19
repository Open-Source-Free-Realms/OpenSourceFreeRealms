﻿using log4net;
using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Player;
using Gateway.MapChat;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Gateway.Login
{
    public static class LoginManager
    {
        private static ILog _log;

        public static SOEServer _server;

        public static List<ClientItemDefinition> ClientItemDefinitions;
        public static List<PointOfInterestDefinition> PointOfInterestDefinitions;
        public static ClientPcData.ClientPcDatas PlayerData;

        public static void Start(SOEServer soeServer = null)
        {
            _server = soeServer ?? Gateway.Server;

            _log = _server.Logger.GetLogger("LoginManager");

            _log.Info("Service constructed");

            ClientItemDefinitions = new List<ClientItemDefinition>();
            PointOfInterestDefinitions = new List<PointOfInterestDefinition>();
            PlayerData = new ClientPcData.ClientPcDatas();

            if(File.Exists(@"..\ofrserver\Customize\ClientItemDefinitions.json"))
                ClientItemDefinitions = JsonConvert.DeserializeObject<List<ClientItemDefinition>>(File.ReadAllText(@"..\ofrserver\Customize\ClientItemDefinitions.json"));

            if (File.Exists(@"..\ofrserver\Customize\PointOfInterestDefinitions.json"))
                PointOfInterestDefinitions = JsonConvert.DeserializeObject<List<PointOfInterestDefinition>>(File.ReadAllText(@"..\ofrserver\Customize\PointOfInterestDefinitions.json"));
            
            if (File.Exists(@"..\ofrserver\Customize\PacketSendSelfToClient.json"))
                PlayerData = JsonConvert.DeserializeObject<ClientPcData.ClientPcDatas>(File.ReadAllText(@"..\ofrserver\Customize\PacketSendSelfToClient.json"));
        }

        [SOEMessageHandler("PacketLogin", (ushort)ClientGatewayBasePackets.PacketLogin, "CGAPI_527")]
        public static void HandleLoginRequest(SOEClient soeClient, SOEMessage message)
        {
            PlayerCode.SendEncounterOverworldCombat(soeClient);
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

               /* case (ushort)BasePackets.BaseQuickChatPacket:
                    break;*/

                case (ushort)BasePackets.BaseInventoryPacket:
                    HandleInventoryPacket(soeClient, reader);
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
            PC.SendPlayerUpdatePacketAddPc(soeClient);
            UpdateStats.SendClientUpdatePacketHitpoints(soeClient);
            UpdateStats.SendClientUpdatePacketMana(soeClient);
            UpdateStats.SendAbilityPacketSetDefinition(soeClient);
            UpdateStats.SendClientUpdatePacketAddEffectTag(soeClient);
            SendPacketLoadWelcomeScreen(soeClient);
            Map.SendObjectiveTargetUpdatePacket(soeClient);
            Map.SendPacketPOIChangeMessage(soeClient);
            //SendClientBeginZoning(soeClient);
            SendTunneledClientPacket(soeClient, StringToByteArray(/* AdventurersJournalInfoPacket */"D1000100000004000000010000000100000025D24D00FFD14D00798A000000000000F400000060D74D0002000000020000000BBF060000D24D003C250000000000000500000039C106000300000003000000AD0D00005108000042250000000000000800000061D74D000400000004000000B10D00003DC106003925000000000000010000003EC106000A0000000100000001000000010000000100000068BF06001300000014AD000016AD000027D24D000000000000000000020000000200000001000000020000002F4900001300000014AD000017AD000028D24D0000000000000000000300000003000000010000000300000025D24D001300000014AD000015AD000029D24D000000000000000000040000000400000002000000010000005E1C00001300000014AD00008DAF00000DBF0600000000000000000005000000050000000200000002000000C38B06001300000014AD00008EAF00000EBF06000000000000000000060000000600000002000000030000000CBF06001300000014AD000091AF00000FBF06000000000000000000070000000700000002000000040000004C1100001300000014AD00008FAF000010BF0600000000000000000008000000080000000300000001000000FFD84D001300000014AD0000D3B0000000D94D0000000000000000000900000009000000030000000200000001D94D001300000014AD0000D4B0000002D94D0000000000000000000A0000000A0000000400000001000000FFC006001300000014AD000020B200003FC1060000000000000000003A000000D209000001000000D209000002000000D109000001000000D109000001000000D909000002000000D909000002000000DE09000002000000DE09000007000000DA09000002000000DA09000003000000DB09000002000000DB09000004000000DC09000002000000DC09000005000000DD09000002000000DD09000006000000E109000003000000E109000003000000E009000003000000E009000002000000DF09000003000000DF09000001000000060A000003000000060A000005000000E209000003000000E209000004000000BD09000004000000BD09000006000000BC09000004000000BC09000005000000BB09000004000000BB09000004000000BA09000004000000BA09000003000000B909000004000000B909000002000000EA09000004000000EA09000001000000C209000005000000C209000006000000C109000005000000C109000005000000C009000005000000C009000004000000BF09000005000000BF09000003000000BE09000005000000BE09000002000000E309000005000000E309000001000000C609000006000000C609000004000000C509000006000000C509000003000000C409000006000000C409000002000000C309000006000000C309000001000000C709000006000000C709000005000000E509000007000000E509000007000000E409000007000000E409000001000000C809000007000000C809000002000000CC09000007000000CC09000006000000CB09000007000000CB09000005000000C909000007000000C909000003000000CA09000007000000CA09000004000000140A000008000000140A000005000000120A000008000000120A000003000000130A000008000000130A000004000000110A000008000000110A000002000000100A000008000000100A000001000000190A000009000000190A00000A000000180A000009000000180A000009000000170A000009000000170A000008000000160A000009000000160A000007000000150A000009000000150A000006000000280A000009000000280A00000B000000230A00000A000000230A000006000000220A00000A000000220A0000050000001F0A00000A0000001F0A0000040000001E0A00000A0000001E0A000003000000240A00000A000000240A0000070000001C0A00000A0000001C0A000001000000270A00000A000000270A00000A000000260A00000A000000260A000009000000250A00000A000000250A0000080000001D0A00000A0000001D0A0000020000001000000001000000010000000100000001000000030A0000BFD34D00C0D34D000FA900000EA900000000000002000000020000000100000002000000040A0000C3D34D00C4D34D0017A9000016A900000000000003000000030000000100000003000000050A0000C7D34D00C8D34D0009A9000008A9000000000000040000000400000001000000040000000C0A0000E4D44D00E5D44D0011A9000010A9000000000000050000000500000001000000050000000D0A0000E8D44D00E9D44D001BA900001AA9000000000000060000000600000001000000060000001B0A000083D64D0084D64D0013A9000012A900000000000010000000100000000200000001000000080A0000D4D44D00D5D44D0029A9000028A900000000000011000000110000000200000002000000090A0000D8D44D00D9D44D0017A9000016A9000000000000120000001200000002000000030000000A0A0000DCD44D00DDD44D0009A9000008A9000000000000130000001300000002000000040000000B0A0000E0D44D00E1D44D000FA900000EA9000000000000140000001400000002000000050000000E0A0000ECD44D00EDD44D000DA900000CA9000000000000150000001500000002000000060000000F0A0000F0D44D00F1D44D0013A9000012A9000000000000200000002000000003000000020000002A0A0000E3C10600E9C1060017A9000016A9000000000000230000002300000003000000050000002D0A0000E6C10600ECC106000FA900000EA9000000000000240000002400000003000000060000002E0A0000E7C10600EDC1060029A9000028A900000000000025000000250000000400000001000000200A00000000000000000000000000000000000000000000"));
            SendTunneledClientPacket(soeClient, StringToByteArray(/* AdventurersJournalQuestUpdatePacket */"D1000200000000000000"));
            SendPacketZoneDoneSendingInitialData(soeClient);
            PlayerCode.SendClientUpdatePacketDoneSendingPreloadCharacters(soeClient);
            SendPacketMOTD(soeClient);
            SendTunneledClientPacket(soeClient, StringToByteArray("2300170022000000F01500000000C03F"));
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
            packet.AddASCIIString("Welcome, this is a test build and anything seen here will be subject to change or break! If you happen to stumble across and aren't in our discord, please join. https://discord.gg/bd4junaw"); //Message

            SendTunneledClientPacket(soeClient, packet.GetRaw());
        }

        private static void HandleInventoryPacket(SOEClient client, SOEReader reader)
        {

            var OpCode = reader.ReadHostUInt16();
            var GUID = reader.ReadHostInt32();

            switch (OpCode)
            {
                case (ushort)BaseInventoryPackets.InventoryPacketEquipByGuid:
                    var clientItem = PlayerData.ClientItems.Find(cItem => cItem.Guid == GUID);
                    var clientItemDef = ClientItemDefinitions.Find(cItemDef => cItemDef.Id == clientItem.Definition);

                    var tint = clientItem.Tint;

                    var packet = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
                    packet.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketEquipItemChange);
                    packet.AddHostInt64(PlayerData.PlayerGUID);
                    packet.AddHostInt32(clientItem.Guid);
                    packet.AddASCIIString(clientItemDef.ModelName);
                    packet.AddASCIIString(clientItemDef.TextureAlias);
                    packet.AddASCIIString(clientItemDef.TintAlias);
                    
                    if (tint == 0)
                    {
                        packet.AddHostInt32(clientItemDef.IconData.TintId);
                    }
                    else
                    {
                        packet.AddHostInt32(tint);
                    }
                    
                    packet.AddHostInt32(clientItemDef.CompositeEffectId);
                    packet.AddHostInt32(clientItemDef.Slot);
                    
                    packet.AddHostInt32(0); //item stat def?
                    packet.AddHostInt32(clientItemDef.Class);
                    packet.AddHostInt32(0);

                    SendTunneledClientPacket(client, packet.GetRaw());
                    SendClientUpdatePacketEquipItem(client, clientItem.Guid);
                    break;

                default:
                    break;
            }
        }

        private static void HandleUpdateFlairEffect(SOEClient client, int guid, int effectid)
        {
            var clientItem = PlayerData.ClientItems.Find(cItem => cItem.Guid == guid);
            var clientItemDef = ClientItemDefinitions.Find(cItemDef => cItemDef.Id == clientItem.Definition);

            var packet = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            packet.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketSlotCompositeEffectOverride);
            packet.AddHostUInt64((ulong)PlayerData.PlayerGUID);
            packet.AddHostInt32(clientItemDef.Slot);
            packet.AddHostUInt32((uint)effectid);

            SendTunneledClientPacket(client, packet.GetRaw());

        }

        private static void SendClientUpdatePacketEquipItem(SOEClient client, int guid)
        {
            var clientItem = PlayerData.ClientItems.Find(cItem => cItem.Guid == guid);
            var clientItemDef = ClientItemDefinitions.Find(cItemDef => cItemDef.Id == clientItem.Definition);

            var tint = clientItem.Tint;

            var packet = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
            packet.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketEquipItem);
            packet.AddHostInt32(clientItem.Guid);
            packet.AddASCIIString(clientItemDef.ModelName);
            packet.AddASCIIString(clientItemDef.TextureAlias);
            packet.AddASCIIString(clientItemDef.TintAlias);

            if (tint == 0)
            {
                packet.AddHostInt32(clientItemDef.IconData.TintId);
            }
            else
            {
                packet.AddHostInt32(tint);
            }

            packet.AddHostInt32(clientItemDef.CompositeEffectId);
            packet.AddHostInt32(clientItemDef.Slot);
            packet.AddHostInt32(0); // item stat def?
            packet.AddHostInt32(clientItemDef.Class);
            packet.AddBoolean(clientItemDef.MembersOnly);

            SendTunneledClientPacket(client, packet.GetRaw());

        }

        private static void HandlePacketZoneTeleportRequest(SOEClient soeClient, SOEReader reader)
        {
            var zone = reader.ReadHostInt32();

            _log.Info($"HandlePacketZoneTeleportRequest Zone: {zone}");

            var pointOfInterestDefinition = PointOfInterestDefinitions.FirstOrDefault(x => x.Id == zone);

            if (pointOfInterestDefinition is null)
                return;

            var soeWriter = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);

            soeWriter.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketUpdateLocation);

            soeWriter.AddFloat(pointOfInterestDefinition.X);
            soeWriter.AddFloat(pointOfInterestDefinition.Y);
            soeWriter.AddFloat(pointOfInterestDefinition.Z);
            soeWriter.AddFloat(pointOfInterestDefinition.Heading);

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
                    _log.Info($"HandleTunneledClientPacket OpCode: {opCode}\n{BitConverter.ToString(data).Replace("-", "")}");
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