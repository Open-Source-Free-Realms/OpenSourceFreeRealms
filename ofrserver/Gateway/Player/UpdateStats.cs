using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;



namespace Gateway.Player
{
    internal class UpdateStats
    {
        public static void SendClientUpdatePacketHitpoints(SOEClient soeClient)
        {
            var updateHP = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
            updateHP.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketHitpoints);
            updateHP.AddHostInt32(400);
            updateHP.AddHostInt32(400);
            LoginManager.SendTunneledClientPacket(soeClient, updateHP.GetRaw());
        }

        public static void SendClientUpdatePacketMana(SOEClient soeClient)
        {
            var updateMP = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
            updateMP.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketMana);
            updateMP.AddHostInt32(100);
            updateMP.AddHostInt32(100);
            updateMP.AddBoolean(true);
            LoginManager.SendTunneledClientPacket(soeClient, updateMP.GetRaw());
        }

        public static void SendClientUpdatePacketAddEffectTag(SOEClient soeClient)
        {
            var addEffectTag = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
            addEffectTag.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketAddEffectTag);

            addEffectTag.AddHostUInt16((ushort)BaseClientUpdatePackets.ClientUpdatePacketAddEffectTag);
            LoginManager.SendTunneledClientPacket(soeClient, LoginManager.StringToByteArray(/* ClientUpdatePacketAddEffectTag */"26001000020000005500000002000000EF0100000200000000000000000000000000C842100E00000091CA73956ACC524B0000000000000000000000000000000000000000000000000000000000000000000101A61C000000AE1000000C010000"));
            LoginManager.SendTunneledClientPacket(soeClient, LoginManager.StringToByteArray(/* ClientUpdatePacketAddEffectTag */"26001000040000005500000004000000350B000008000000000000000000000000000000100E00000091CA73956ACC524B000000000000000001000000A20F000000000000000000000000000000000000000001272D00000054B80600DB070000"));
        }

        public static void SendAbilityPacketSetDefinition(SOEClient soeClient)
        {
            //var setDefinition = new SOEWriter((ushort)BasePackets.BaseAbilityPacket, true);
            //setDefinition.AddHostUInt16((ushort)BaseAbilityPackets.AbilityPacketSetDefinition);
            LoginManager.SendTunneledClientPacket(soeClient, LoginManager.StringToByteArray(/* AbilityPacketSetDefinition */"2400050001000000080000000000000000000000000000000000000000000000000000000000000000000000"));

        }
            public static void SendUpdatePacketUpdateStat(SOEClient soeClient)
            {
                var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
                var player = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);
                updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);

                updatePacketUpdateStat.AddHostInt64(player.playerGUID);

                // CharacterStat Count
                updatePacketUpdateStat.AddHostInt32(3);

                // Movement Speed
                updatePacketUpdateStat.AddHostInt32(2);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(8f);

                // Health Refill
                updatePacketUpdateStat.AddHostInt32(4);
                updatePacketUpdateStat.AddHostInt32(0);
                updatePacketUpdateStat.AddFloat(1);

                // Energy Refill
                updatePacketUpdateStat.AddHostInt32(6);
                updatePacketUpdateStat.AddHostInt32(0);
                updatePacketUpdateStat.AddFloat(1);

                LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());
            }
        }
    }
