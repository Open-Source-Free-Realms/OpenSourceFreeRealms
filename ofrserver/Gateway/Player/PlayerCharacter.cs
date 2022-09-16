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
    internal class PlayerCharacter
    {
        private static SOEServer _server = Gateway.Server;
        private static ILog _log = _server.Log;

        public readonly SOEClient client;
        public readonly uint playerGUID;

        public float[] position;
        public float[] rotation;
        public byte characterState;
        public byte unknown;

        protected float[] lastBroadcastedPosition;
        protected int lastBroadcastedTime;

        protected ClientPcDatas CharacterData;

        public PlayerCharacter(SOEClient soeClient, ClientPcDatas characterData)
        {
            client = soeClient;
            playerGUID = (uint)characterData.PlayerGUID;

            position = new float[3];
            for (int i = 0; i < position.Length; i++)
                position[i] = 0;

            rotation = new float[3];
            for (int i = 0; i < rotation.Length; i++)
                rotation[i] = 0;

            characterState = 0x00;
            unknown = 0x00;

            lastBroadcastedPosition = new float[3];
            for (int i = 0; i < lastBroadcastedPosition.Length; i++)
                lastBroadcastedPosition[i] = 0;

            lastBroadcastedTime = 0;

            CharacterData = characterData;

            foreach (SOEClient otherClient in _server.ConnectionManager.Clients)
            {
                if (client == otherClient) continue;
                SpawnPcFor(otherClient);
            }
        }

        ~PlayerCharacter()
        {
            // TODO: Send Remove PC packet
        }

        public void SpawnPcFor(SOEClient target)
        {
            var addPc = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            addPc.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddPc);
            addPc.AddHostUInt64(playerGUID); // Player GUID

            addPc.AddHostInt32(0); // Unknown Zero 1
            addPc.AddHostInt32(0); // Unknown Zero 2
            addPc.AddHostInt32(0); // Unknown Zero 3

            addPc.AddASCIIString(CharacterData.FirstName);
            addPc.AddASCIIString(CharacterData.LastName);

            addPc.AddHostInt32(1); // Unknown 1
            addPc.AddHostInt32(408679); // Unknown 2
            addPc.AddHostInt32(13951728); // Unknown 3
            addPc.AddHostInt32(1); // Unknown 4

            for (var i = 0; i < CharacterData.PlayerPosition.Length; i++) // Position
                addPc.AddFloat(CharacterData.PlayerPosition[i]); // TODO: fix for current position

            for (var i = 0; i < 4; i++) // Rotation
                addPc.AddFloat(0.0f);

            List<(int, ProfileItem)> profileItems = CharacterData.ClientPcProfiles[0].Items; // 0 means adventurer
            List<ClientItemDefinition> equippedItems = new List<ClientItemDefinition>();
            foreach ((int, ProfileItem) item in profileItems)
            {
                int itemGuid = item.Item2.ItemGUID;
                ClientItemDefinition itemDefintion = LoginManager.ClientItemDefinitions.Find(x => (x.Unknown == itemGuid));
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
            addPc.AddASCIIString(CharacterData.PlayerHead);
            addPc.AddASCIIString(CharacterData.PlayerHair);
            addPc.AddHostInt32(CharacterData.HairColor);
            addPc.AddHostInt32(CharacterData.EyeColor);
            addPc.AddHostInt32(1); // Unknown 5
            addPc.AddASCIIString(CharacterData.Skintone);
            addPc.AddASCIIString(CharacterData.FacePaint);
            addPc.AddASCIIString(CharacterData.HumanBeardsPixieWings);

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

            byte[] otherUnknownBytes = LoginManager.StringToByteArray("0000004100010000000000010000002951557C2913887B0042DD070100000000000000000000000000000000000000010000000200000059EE0000170000000000000000000000000000000000000000513959474185524B94000000940000000100000000000000000000000000000000000000000000000000010000000000000000FFFFFFFFFFFFFFFF00000000000000000000A040000000000000000000000000");
            addPc.AddBytes(otherUnknownBytes);

            LoginManager.SendTunneledClientPacket(target, addPc.GetRaw());
        }

        public void BroadcastPlayerUpdatePacketUpdatePosition()
        {
            var soeWriter = new SOEWriter((ushort)BasePackets.PlayerUpdatePacketUpdatePosition, true);
            soeWriter.AddHostUInt64(playerGUID);

            for (var i = 0; i < position.Length; i++)
                soeWriter.AddFloat(position[i]);

            for (var i = 0; i < rotation.Length; i++)
                soeWriter.AddFloat(rotation[i]);

            soeWriter.AddByte(characterState);
            soeWriter.AddByte(unknown);

            foreach (SOEClient otherClient in _server.ConnectionManager.Clients)
            {
                if (client == otherClient) continue;
                LoginManager.SendTunneledClientPacket(otherClient, soeWriter.GetRaw());
            }
        }
    }
}
