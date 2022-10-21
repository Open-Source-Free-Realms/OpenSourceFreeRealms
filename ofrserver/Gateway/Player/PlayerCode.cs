using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using Gateway.MapChat;
using log4net;

namespace Gateway.Player
{
    public static class PlayerCode
    {
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


        public static void SendSelfToClient(SOEClient soeClient)
        {

            var SendSelfToClientData = ClientPcData.ReadFromJSON(@"..\ofrserver\Customize\PacketSendSelfToClient.json");

            var rawBytes = SendSelfToClientData;

            var sendSelfToClient = new SOEWriter((ushort)BasePackets.PacketSendSelfToClient, true);

            sendSelfToClient.AddHostUInt32((uint)rawBytes.Length);

            sendSelfToClient.AddBytes(rawBytes);

            LoginManager.SendTunneledClientPacket(soeClient, sendSelfToClient.GetRaw());

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

        public static void HandlePlayerUpdatePacketUpdatePosition(SOEClient soeClient, SOEReader reader)
        {
            var PlayerGUID = reader.ReadHostUInt64();
            float[] Position = new float[3];
            for (var i = 0; i < Position.Length; i++)
                Position[i] = reader.ReadSingle();
            float[] Rotation = new float[3];
            for (var i = 0; i < Rotation.Length; i++)
                Rotation[i] = reader.ReadSingle();
            byte CharacterState = reader.ReadByte();
            byte Unknown = reader.ReadByte();


            LoginManager.log.InfoFormat($"{LoginManager.PlayerData.FirstName}{LoginManager.PlayerData.LastName} -> GUID: {PlayerGUID} State: {CharacterState} " +
                $"Position X: {Position[0]} " +
                $"Position Y: {Position[1]} " +
                $"Position Z: {Position[2]} " +
                $"Rotation X: {Rotation[0]} " +
                $"Rotation Y: {Rotation[1]} " +
                $"Rotation Z: {Rotation[2]} " );

            var poiChange = new SOEWriter((byte)BasePackets.PacketPOIChangeMessage, true);

            if (Map.inBlackspore(Position))
            {
                poiChange.AddHostInt32(3500); // NameId
                poiChange.AddHostInt32(2); //ZoneId
                poiChange.AddHostInt32(290); //AreaId
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.inSanctuary(Position))
            {
                poiChange.AddHostInt32(3499); // NameId
                poiChange.AddHostInt32(5); //ZoneId
                poiChange.AddHostInt32(290); //AreaId
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.inSeaside(Position))
            {
                poiChange.AddHostInt32(3501); // NameId
                poiChange.AddHostInt32(6); //ZoneId
                poiChange.AddHostInt32(290); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.MerryValeMagnitude(Position) < 290.0)
            {
                poiChange.AddHostInt32(3961); // NameId
                poiChange.AddHostInt32(4); //ZoneId
                poiChange.AddHostInt32(290); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.inShroudedGlade(Position) < 200.0)
            {
                poiChange.AddHostInt32(3502); // NameId
                poiChange.AddHostInt32(7); //ZoneId
                poiChange.AddHostInt32(290); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.inSnowhill(Position))
            {
                poiChange.AddHostInt32(3961); // NameId
                poiChange.AddHostInt32(8); //ZoneId
                poiChange.AddHostInt32(290); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.inWugachug(Position))
            {
                poiChange.AddHostInt32(3505); // NameId
                poiChange.AddHostInt32(9); //ZoneId
                poiChange.AddHostInt32(290); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }

            if (Map.SunstoneValleyMagnitude(Position) < 600.0)
            {
                poiChange.AddHostInt32(74159); // NameId
                poiChange.AddHostInt32(10); //ZoneId
                poiChange.AddHostInt32(1178); //Unsure
                LoginManager.SendTunneledClientPacket(soeClient, poiChange.GetRaw());
            }
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
