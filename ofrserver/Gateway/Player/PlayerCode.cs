using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using Gateway.MapChat;
using log4net;
using static Gateway.Login.ClientPcData;

namespace Gateway.Player
{
    public static class PlayerCode
    {

        public static ILog _log;
        public static SOEServer _server;

        public static void SendPlayerUpdateItemDefinitions(SOEClient soeClient)
        {
            var playerUpdateItemDefinitions = new SOEWriter();

            playerUpdateItemDefinitions.AddHostInt32(LoginManager.ClientItemDefinitions.Count);

            foreach (var clientItemDefinition in LoginManager.ClientItemDefinitions)
            {
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Id);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.NameId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.DescriptionId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.IconData.Id);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.IconData.TintId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Tint);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Unknown5);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Cost);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Class);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ProfileOverride);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Slot);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.NoTrade);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.NoSale);
                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.ModelName);
                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.TextureAlias);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.GenderUsage);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Type);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.CategoryId);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.MembersOnly);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.NonMiniGame);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.WeaponTrailEffectId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.CompositeEffectId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.PowerRating);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.MinProfileRank);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.Rarity);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ActivatableAbilityId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.PassiveAbilityId);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.SingleUse);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.MaxStackSize);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.IsTintable);
                playerUpdateItemDefinitions.AddASCIIString(clientItemDefinition.TintAlias);
                playerUpdateItemDefinitions.AddBoolean(clientItemDefinition.ForceDisablePreview);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.MemberDiscount);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.VipRankRequired);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.RaceSetId);
                playerUpdateItemDefinitions.AddHostInt32(clientItemDefinition.ClientEquipReqSetId);
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

            LoginManager.SendTunneledClientPacket(soeClient, basePlayerUpdate.GetRaw());
        }


        public static void SendSelfToClient(SOEClient soeClient, ClientPcDatas pcData)
        {
            var rawBytes = ReadFromPcData(pcData);

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

            LoginManager.SendTunneledClientPacket(soeClient, baseClientUpdate.GetRaw());
        }

        public static void SendEncounterOverworldCombat(SOEClient soeClient)
        {
            var baseEncounter = new SOEWriter((ushort)BasePackets.BaseEncounterPacket, true);

            baseEncounter.AddHostUInt16((ushort)BaseEncounterPackets.EncounterOverworldCombatPacket);

            baseEncounter.AddHostUInt32(0);
            baseEncounter.AddHostUInt32(0);
            baseEncounter.AddBoolean(true);

            LoginManager.SendTunneledClientPacket(soeClient, baseEncounter.GetRaw());
        }

     



        

        public static void HandlePlayerUpdatePacketCameraUpdate(SOEReader reader)
        {
            var Unknown = reader.ReadHostUInt64();
            float[] Camera = new float[4];
            for (var i = 0; i < Camera.Length; i++)
                Camera[i] = reader.ReadSingle();

            //LoginManager.log.Info($"HandlePlayerUpdatePacketCameraUpdate: " +
            //    $"Front: {Camera[3]} " +
            //    $"Back: {Camera[1]}");
        }

    }
}
