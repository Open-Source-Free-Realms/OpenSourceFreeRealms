using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using Gateway.Player;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway.GameManager
{
    public class MountManager
    {

        public static void HandleMountBasePacket(SOEClient client, SOEReader reader)
        {
            var OpCode = reader.ReadByte();
            var GUID = reader.ReadHostInt32();

            switch (OpCode)
            {
                case (byte)MountBasePackets.PacketMountSpawn:
                    LoginManager._log.Info($"HandleMountBasePacket SubOpCode: {OpCode}");
                    SendPacketMountResponse(client, GUID);
                    break;

                case (byte)MountBasePackets.PacketDismountRequest:
                    LoginManager._log.Info($"HandleMountBasePacket SubOpCode: {OpCode}");
                    SendPacketDismountResponse(client);
                    break;

                default:
                    var data = reader.ReadToEnd();
                    LoginManager._log.Info($"HandleMountBasePacket SubOpCode: {OpCode}\n{BitConverter.ToString(data).Replace("-", "")}");
                    break;
            }
        }

        public static void SendPacketMountResponse(SOEClient soeClient, int guid)
        {
            var player = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);
            var mount = player.mounts.Find(x => x.MountNumber == guid);

            mount.MountGUID = LoginManager.RandomGUID();

            var addMount = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            addMount.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addMount.AddHostUInt64(mount.MountGUID);
            addMount.AddHostInt32(mount.MountName);
            addMount.AddHostInt32(mount.MountModel);
            addMount.AddBoolean(false);
            addMount.AddHostInt32(408679);
            addMount.AddHostInt32(13951728);
            addMount.AddHostInt32(1);
            addMount.AddFloat(1.0f);

            addMount.AddFloat(player.position[0]);
            addMount.AddFloat(player.position[1]);
            addMount.AddFloat(player.position[2]);
            addMount.AddFloat(1.0f);

            addMount.AddFloat(player.rotation[0]);
            addMount.AddFloat(player.rotation[1]);
            addMount.AddFloat(player.rotation[2]);
            addMount.AddFloat(0.0f);

            addMount.AddHostInt32(1);
            addMount.AddHostInt32(0); // CharacterAttachmentDataCount
            addMount.AddHostInt32(1);

            addMount.AddASCIIString(mount.MountTextureType);
            addMount.AddASCIIString(mount.MountTexture);
            addMount.AddHostInt32(mount.MountColor);
            addMount.AddBoolean(true);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddASCIIString(""); // Custom Name
            addMount.AddBoolean(true); // NameDisabled
            addMount.AddHostInt32(0);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddHostInt32(0);
            addMount.AddBoolean(false);
            addMount.AddFloat(0.0f);
            addMount.AddBoolean(false);
            addMount.AddHostInt32(100);
            addMount.AddHostInt32(-1);
            addMount.AddHostInt32(-1);
            addMount.AddHostInt32(-1);
            addMount.AddBoolean(false);
            addMount.AddBoolean(false);
            addMount.AddHostInt32(-1);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);

            addMount.AddHostInt32(0); // EffectTagsCount

            addMount.AddBoolean(false);
            addMount.AddHostInt32(0);
            addMount.AddBoolean(false);
            addMount.AddBoolean(false);
            addMount.AddBoolean(false);
            addMount.AddBoolean(false);

            addMount.AddHostInt32(1); // UnknownStruct2
            addMount.AddASCIIString("");
            addMount.AddASCIIString("");
            addMount.AddHostInt32(0);
            addMount.AddASCIIString("");

            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);

            addMount.AddHostInt32(0);
            addMount.AddHostInt32(-1);
            addMount.AddHostInt32(mount.MountIcon);
            addMount.AddBoolean(true);
            addMount.AddHostInt64(0);
            addMount.AddHostInt32(2);
            addMount.AddFloat(0.0f);

            addMount.AddHostInt32(0); // Target

            addMount.AddHostInt32(0); // CharacterVariables

            addMount.AddHostInt32(0);
            addMount.AddFloat(0.0f);

            addMount.AddFloat(0.0f); // Unknown54, float[4]
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);

            addMount.AddHostInt32(0);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddFloat(0.0f);
            addMount.AddASCIIString("");
            addMount.AddASCIIString("");
            addMount.AddASCIIString("");
            addMount.AddBoolean(false);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(0);
            addMount.AddHostInt32(3442);
            addMount.AddFloat(0.0f);
            addMount.AddHostInt32(0);

            BroadcastManager.BroadcastToPlayers(addMount.GetRaw());

            var mountResponse = new SOEWriter((ushort)BasePackets.MountBasePacket, true);

            mountResponse.AddByte((byte)MountBasePackets.PacketMountResponse);

            mountResponse.AddHostInt64(player.playerGUID);
            mountResponse.AddHostUInt64(mount.MountGUID); // MountGuid
            mountResponse.AddHostInt32(0);
            mountResponse.AddHostInt32(1); // Queue Position
            mountResponse.AddHostInt32(1);
            mountResponse.AddHostInt32(46);
            mountResponse.AddHostInt32(0);

            BroadcastManager.BroadcastToPlayers(mountResponse.GetRaw());
            if (mount.MountName == 442674)
            {
                var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
                updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);
                updatePacketUpdateStat.AddHostInt64(player.playerGUID);
                // CharacterStat Count
                updatePacketUpdateStat.AddHostInt32(9);

                updatePacketUpdateStat.AddHostInt32(2);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(12.5f);

                updatePacketUpdateStat.AddHostInt32(59);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(12f);

                updatePacketUpdateStat.AddHostInt32(60);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(6f);

                updatePacketUpdateStat.AddHostInt32(61);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(22f);

                updatePacketUpdateStat.AddHostInt32(62);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(0.75f);

                updatePacketUpdateStat.AddHostInt32(63);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(3f);

                updatePacketUpdateStat.AddHostInt32(64);
                updatePacketUpdateStat.AddHostInt32(0);
                updatePacketUpdateStat.AddHostInt32(1);

                updatePacketUpdateStat.AddHostInt32(67);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(4f);

                updatePacketUpdateStat.AddHostInt32(68);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(5f);

                LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());
            }
            else if (mount.AbleToFly == true)
            {
                var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
                updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);
                updatePacketUpdateStat.AddHostInt64(player.playerGUID);
                updatePacketUpdateStat.AddHostInt32(8);

                updatePacketUpdateStat.AddHostInt32(2);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(12.5f);

                updatePacketUpdateStat.AddHostInt32(59);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(8f);

                updatePacketUpdateStat.AddHostInt32(60);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(2f);

                updatePacketUpdateStat.AddHostInt32(61);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(18f);

                updatePacketUpdateStat.AddHostInt32(62);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(0.75f);

                updatePacketUpdateStat.AddHostInt32(63);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(4f);

                updatePacketUpdateStat.AddHostInt32(64);
                updatePacketUpdateStat.AddHostInt32(0);
                updatePacketUpdateStat.AddHostInt32(1);

                updatePacketUpdateStat.AddHostInt32(67);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(4f);

                LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());
            }
            else if (guid == 1023)
            {
                var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
                updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);
                updatePacketUpdateStat.AddHostInt64(player.playerGUID);

                // CharacterStat Count
                updatePacketUpdateStat.AddHostInt32(1);

                updatePacketUpdateStat.AddHostInt32(2);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(0f);

                LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());
            }
            else
            {
                var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);
                updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);
                updatePacketUpdateStat.AddHostInt64(player.playerGUID);

                // CharacterStat Count
                updatePacketUpdateStat.AddHostInt32(1);

                updatePacketUpdateStat.AddHostInt32(2);
                updatePacketUpdateStat.AddHostInt32(1);
                updatePacketUpdateStat.AddFloat(12.5f);

                LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());
            }
        }
        public static void SendPacketDismountResponse(SOEClient soeClient)
        {

            var player = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);
            var disMount = new SOEWriter((ushort)BasePackets.MountBasePacket, true);
            disMount.AddByte((byte)MountBasePackets.PacketDismountResponse);

            disMount.AddHostInt64(player.playerGUID);
            disMount.AddHostInt32(46);

            BroadcastManager.BroadcastToPlayers(disMount.GetRaw());

            var updatePacketUpdateStat = new SOEWriter((ushort)BasePackets.BaseClientUpdatePacket, true);

            updatePacketUpdateStat.AddHostUInt16((byte)BaseClientUpdatePackets.ClientUpdatePacketUpdateStat);

            updatePacketUpdateStat.AddHostInt64(player.playerGUID);

            // CharacterStat Count
            updatePacketUpdateStat.AddHostInt32(3);

            updatePacketUpdateStat.AddHostInt32(2);
            updatePacketUpdateStat.AddHostInt32(1);
            updatePacketUpdateStat.AddFloat(8f);

            updatePacketUpdateStat.AddHostInt32(64);
            updatePacketUpdateStat.AddHostInt32(0);
            updatePacketUpdateStat.AddHostInt32(0);

            updatePacketUpdateStat.AddHostInt32(68);
            updatePacketUpdateStat.AddHostInt32(1);
            updatePacketUpdateStat.AddFloat(0f);

            LoginManager.SendTunneledClientPacket(soeClient, updatePacketUpdateStat.GetRaw());

            var mount = player.mounts.FirstOrDefault(x => x.MountGUID != 0);

            if (mount == null)
                return;

            var removeMount = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            removeMount.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketRemovePlayer);

            removeMount.AddHostUInt16(1);
            removeMount.AddHostUInt64(mount.MountGUID); // MountGuid

            removeMount.AddBoolean(false);
            removeMount.AddHostInt32(0);
            removeMount.AddHostInt32(0);
            removeMount.AddHostInt32(46);
            removeMount.AddHostInt32(1000);

            BroadcastManager.BroadcastToPlayers(removeMount.GetRaw());
            mount.MountGUID = 0;
        }
    }
}
