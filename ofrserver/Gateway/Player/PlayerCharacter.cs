using Gateway.Login;
using log4net;
using Newtonsoft.Json;
using SOE;
using SOE.Core;
using SOE.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static Gateway.Login.ClientPcData;

namespace Gateway.Player
{
    public class PlayerCharacter
    {
        public readonly SOEClient client;
        public readonly ulong playerGUID;

        public float[] position;
        public float[] rotation;
        public byte characterState;
        public byte unknown;

        public float[] lastBroadcastedPosition;
        public int lastBroadcastedTime;

        public ClientPcDatas CharacterData;

        public void SendPlayerUpdatePacketUpdatePosition(SOEClient soeClient)
        {
            var soeWriter = new SOEWriter((ushort)BasePackets.PlayerUpdatePacketUpdatePosition, true);
            soeWriter.AddHostUInt64(playerGUID);

            for (var i = 0; i < 3; i++)
                soeWriter.AddFloat(position[i]);

            for (var i = 0; i < 3; i++)
                soeWriter.AddFloat(rotation[i]);

            soeWriter.AddByte(characterState);
            soeWriter.AddByte(unknown);

            LoginManager.SendTunneledClientPacket(soeClient, soeWriter.GetRaw());
        }
    }
}