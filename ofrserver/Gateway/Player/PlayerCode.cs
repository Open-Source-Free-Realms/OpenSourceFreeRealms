using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gateway.Player
{
    internal class PlayerCode
    {
        public static void SendPlayerUpdateItemDefinitions(SOEClient soeClient)
        {
            var clientItemDefinitions = JsonConvert.DeserializeObject<List<ClientItemDefinition>>(File.ReadAllText(@"..\ofrserver\Customize\ClientItemDefinitions.json"));

            var playerUpdateItemDefinitions = new SOEWriter();

            playerUpdateItemDefinitions.AddHostInt32(clientItemDefinitions.Count);

            foreach (var clientItemDefinition in clientItemDefinitions)
            {
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown2);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown3);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.IconData.Icon);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.IconData.Unknown2);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown4);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown5);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown6);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.JobGUID);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown8);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Category);

                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.CannotTrade);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.CannotResell);

                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.ModelBase);
                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.ModelTexture);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.GenderLocked);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.CategoryLocked);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown16);

                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.MembersOnly);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.Unknown18);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown19);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown20);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown21);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown22);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.TextColor);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown24);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown25);

                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.Unknown26);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown27);

                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.Unknown28);

                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.ModelColor);

                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.Unknown30);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown31);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown32);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown33);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown34);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ResellValue);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown36);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown37);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown38);

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ClientItemStatDefinitions.Count);

                foreach (var clientItemStatDefinition in clientItemDefinition.ClientItemStatDefinitions)
                {
                    playerUpdateItemDefinitions.AddHostInt32(clientItemStatDefinition.Key);

                    playerUpdateItemDefinitions.AddHostInt32(clientItemStatDefinition.Value.Unknown);
                    playerUpdateItemDefinitions.AddHostInt32(clientItemStatDefinition.Value.Unknown2);
                    playerUpdateItemDefinitions.AddHostInt32(clientItemStatDefinition.Value.Unknown3);
                    playerUpdateItemDefinitions.AddBoolean(clientItemStatDefinition.Value.Unknown4);
                }

                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ItemAbilityEntries.Count);

                foreach (var itemAbilityEntry in clientItemDefinition.ItemAbilityEntries)
                {
                    playerUpdateItemDefinitions.AddHostInt32(itemAbilityEntry.Unknown);
                    playerUpdateItemDefinitions.AddHostInt32(itemAbilityEntry.Unknown2);
                    playerUpdateItemDefinitions.AddHostInt32(itemAbilityEntry.Unknown3);
                    playerUpdateItemDefinitions.AddHostInt32(itemAbilityEntry.Unknown4);
                }
            }

            var rawBytes = playerUpdateItemDefinitions.GetRaw();

            var basePlayerUpdate = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            basePlayerUpdate.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketItemDefinitions);

            basePlayerUpdate.AddHostInt32(rawBytes.Length);

            basePlayerUpdate.AddBytes(rawBytes);

            rawBytes = basePlayerUpdate.GetRaw();

            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostInt32(rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }


        public static void SendSelfToClient(SOEClient soeClient)
        {

            var SendSelfToClientData = ClientPcData.ReadFromJSON(@"..\ofrserver\Customize\PacketSendSelfToClient.json");

            var rawBytes = SendSelfToClientData;

            var sendSelfToClient = new SOEWriter((ushort)BasePackets.PacketSendSelfToClient, true);

            sendSelfToClient.AddHostUInt32((uint)rawBytes.Length);

            sendSelfToClient.AddBytes(rawBytes);

            rawBytes = sendSelfToClient.GetRaw();

            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostUInt32((uint)rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }

        public static void SendClientUpdatePacketDoneSendingPreloadCharacters(SOEClient soeClient)
        {
            var baseClientUpdate = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);

            baseClientUpdate.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketDoneSendingPreloadCharacters);

            baseClientUpdate.AddBoolean(false);

            var rawBytes = baseClientUpdate.GetRaw();

            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostUInt32((uint)rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }

        public static void SendEncounterOverworldCombat(SOEClient soeClient)
        {
            var baseEncounter = new SOEWriter((ushort)BasePackets.BaseEncounterPacket, true);

            baseEncounter.AddHostUInt16((ushort)BaseEncounterPackets.EncounterOverworldCombatPacket);

            baseEncounter.AddHostUInt32(0);
            baseEncounter.AddHostUInt32(0);
            baseEncounter.AddBoolean(true);

            var rawBytes = baseEncounter.GetRaw();

            var tunneledClient = new SOEWriter((ushort)ClientGatewayBasePackets.PacketTunneledClientPacket, true);

            tunneledClient.AddBoolean(true);
            tunneledClient.AddHostUInt32((uint)rawBytes.Length);

            tunneledClient.AddBytes(rawBytes);

            soeClient.SendMessage(tunneledClient.GetFinalSOEMessage(soeClient));
        }
    }
}
