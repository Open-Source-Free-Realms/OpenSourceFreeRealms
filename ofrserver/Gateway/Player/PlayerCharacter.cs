using Gateway.GameManager;
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
    public class PlayerCharacter : IDisposable
    {
        private static SOEServer _server = Gateway.Server;
        private static ILog _log = _server.Log;
        private static Random _random = new Random();

        public readonly SOEClient client;
        public readonly uint playerGUID;

        public float[] position;
        public float[] rotation;
        public byte characterState;
        public byte unknown;

        public float[] lastBroadcastedPosition;
        public int lastBroadcastedTime;

        public List<PacketMountInfo> mounts;

        public ClientPcDatas CharacterData;

        public List<UnknownPetStruct> pets;

        public ActivePet activePet;



        public PlayerCharacter(SOEClient soeClient, ClientPcDatas characterData)
        {
            client = soeClient;
            playerGUID = (uint)characterData.PlayerGUID;

            position = new float[3];
            for (int i = 0; i < position.Length; i++)
                position[i] = characterData.PlayerPosition[i];

            rotation = new float[3];
            for (int i = 0; i < rotation.Length; i++)
                rotation[i] = characterData.CameraRotation[i];

            characterState = 0x00;
            unknown = 0x00;

            lastBroadcastedPosition = new float[3];
            for (int i = 0; i < lastBroadcastedPosition.Length; i++)
                lastBroadcastedPosition[i] = 0;

            lastBroadcastedTime = 0;
            mounts = new List<PacketMountInfo>();
            for (int i = 0; i < characterData.Mounts.Count; i++)
            {
                mounts.Add(characterData.Mounts[i]);
            }

            pets = characterData.Pets;
            activePet = new ActivePet();

            CharacterData = characterData;
        }

        public void Dispose()
        {
            _log.Debug($"Attempting to dispose of \"{CharacterData.FirstName} {CharacterData.LastName}\"");

            var removePlayer = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            removePlayer.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketRemovePlayer);

            removePlayer.AddBoolean(false);
            removePlayer.AddBoolean(false);
            removePlayer.AddHostUInt64(playerGUID); // Player GUID

            BroadcastManager.BroadcastToPlayers(removePlayer.GetRaw());
        }

        public void SpawnPcFor(SOEClient target)
        {
            _log.Debug($"Attempting to spawn \"{CharacterData.FirstName} {CharacterData.LastName}\" (#{client.GetClientID()}) for Client #{target.GetClientID()}");

            var addPc = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            addPc.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddPc);
            addPc.AddHostUInt64(playerGUID); // Player GUID

            addPc.AddHostInt32(0); // DisplayInformation.Unknown1
            addPc.AddHostInt32(0); // DisplayInformation.Unknown2
            addPc.AddHostInt32(0); // DisplayInformation.Unknown3

            addPc.AddASCIIString(CharacterData.FirstName);
            addPc.AddASCIIString(CharacterData.LastName);

            addPc.AddHostInt32(CharacterData.PlayerModel);
            addPc.AddHostInt32(408679); // Unknown3
            addPc.AddHostInt32(13951728); // MountGUID
            addPc.AddHostInt32(1); // Unknown5

            for (var i = 0; i < position.Length; i++) // Position
                addPc.AddFloat(position[i]);
            addPc.AddFloat(1.0f);

            for (var i = 0; i < rotation.Length; i++) // Rotation
                addPc.AddFloat(rotation[i]);
            addPc.AddFloat(0.0f);

            var clientPcProfile = CharacterData.ClientPcProfiles.Find(x => x.JobGUID == CharacterData.Class);
            if (clientPcProfile == null)
                return;
            List<ClientItemDefinition> equippedItems = new List<ClientItemDefinition>();
            foreach ((int, ProfileItem) item in clientPcProfile.Items)
            {
                int itemGUID = item.Item2.ItemGUID;

                var clientItem = CharacterData.ClientItems.Find(x => x.Guid == itemGUID);

                if (clientItem == null)
                    continue;

                ClientItemDefinition itemDefintion = LoginManager.ClientItemDefinitions.Find(x => x.Id == clientItem.Definition);

                if (itemDefintion != null)
                {
                    if (clientItem.Tint != 0)
                        itemDefintion.IconData.TintId = clientItem.Tint;

                    equippedItems.Add(itemDefintion);
                }
            }

            addPc.AddHostInt32(equippedItems.Count);
            for (var i = 0; i < equippedItems.Count; i++)
            {
                ClientItemDefinition item = equippedItems[i];
                addPc.AddASCIIString(item.ModelName);
                addPc.AddASCIIString(item.TextureAlias);
                addPc.AddASCIIString(item.TintAlias);
                addPc.AddHostInt32(item.IconData.TintId);
                addPc.AddHostInt32(item.CompositeEffectId);
                addPc.AddHostInt32(item.Slot);
            }

            addPc.AddASCIIString(CharacterData.PlayerHead);
            addPc.AddASCIIString(CharacterData.PlayerHair);
            addPc.AddHostInt32(CharacterData.HairColor);
            addPc.AddHostInt32(CharacterData.EyeColor);
            addPc.AddHostInt32(0); // Unknown12
            addPc.AddASCIIString(CharacterData.Skintone);
            addPc.AddASCIIString(CharacterData.FacePaint);
            addPc.AddASCIIString(CharacterData.HumanBeardsPixieWings);

            addPc.AddHostInt32(1090519040); // Unknown16
            addPc.AddBoolean(false); // Unknown17

            addPc.AddBoolean(true); // Unknown18
            addPc.AddBoolean(false); // Unknown19

            addPc.AddHostInt32(0); // Unknown20

            addPc.AddHostInt32(0); // GuildGUID Count
            // TODO: Guilds

            addPc.AddHostInt32(CharacterData.Class); // Class

            addPc.AddHostInt32(0); // PlayerTitle.GUID
            addPc.AddHostInt32(0); // PlayerTitle.Unknown2
            addPc.AddHostInt32(0); // PlayerTitle.NameId
            addPc.AddHostInt32(0); // PlayerTitle.MountGUID

            addPc.AddHostInt32(CharacterData.EffectTags.Count); // EffectTagCount
            foreach ((int, ClientEffectTag) effectTag in CharacterData.EffectTags)
            {
                addPc.AddHostInt32(effectTag.Item2.Unknown); // EffectTag.PetId
                addPc.AddHostInt32(effectTag.Item2.Unknown2); // EffectTag.Unknown2
                addPc.AddHostInt32(effectTag.Item2.Unknown3); // EffectTag.Unknown3

                addPc.AddHostInt32(effectTag.Item2.Unknown4); // EffectTag.MountGUID
                addPc.AddHostInt32(effectTag.Item2.Unknown5); // EffectTag.Unknown5
                addPc.AddHostInt32(effectTag.Item2.Unknown6); // EffectTag.Unknown6
                addPc.AddHostInt32(effectTag.Item2.Unknown7); // EffectTag.Unknown7

                addPc.AddBoolean(effectTag.Item2.Unknown8); // EffectTag.Unknown8

                addPc.AddHostInt64(effectTag.Item2.Unknown9); // EffectTag.Unknown9
                addPc.AddHostInt32(effectTag.Item2.Unknown10); // EffectTag.Unknown10, Stored as long, epoch time?
                addPc.AddHostInt32(effectTag.Item2.Unknown11); // EffectTag.Unknown11, Stored as long, epoch time?

                addPc.AddHostInt32(effectTag.Item2.Unknown12); // EffectTag.Unknown12
                addPc.AddHostInt32(effectTag.Item2.Unknown13); // EffectTag.Unknown13
                addPc.AddHostInt64(effectTag.Item2.Unknown14); // EffectTag.Unknown14
                addPc.AddHostInt32(effectTag.Item2.Unknown15); // EffectTag.Unknown15
                addPc.AddHostInt32(effectTag.Item2.Unknown16); // EffectTag.Unknown16

                addPc.AddBoolean(effectTag.Item2.Unknown17); // EffectTag.Unknown17
                addPc.AddBoolean(effectTag.Item2.Unknown18); // EffectTag.Unknown18
                addPc.AddBoolean(effectTag.Item2.Unknown19); // EffectTag.Unknown19
            }

            addPc.AddHostInt64(0); // Unknown22
            addPc.AddHostInt32(-1); // Unknown23
            addPc.AddHostInt32(-1); // Unknown24
            addPc.AddFloat(0); // Unknown25
            addPc.AddHostInt32(0); // Character Animation
            addPc.AddFloat(0); // Unknown27
            addPc.AddHostInt32(0); // Unknown28
            addPc.AddHostInt32(0); // Unknown29
            addPc.AddHostInt32(0); // Unknown30

            LoginManager.SendTunneledClientPacket(target, addPc.GetRaw());
        }

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


        private double Magnitude(float[] pos0, float[] pos1)
        {
            return Math.Sqrt(
                Math.Pow(pos1[0] - pos0[0], 2) +
                Math.Pow(pos1[1] - pos0[1], 2) +
                Math.Pow(pos1[2] - pos0[2], 2)
            );
        }

        public void SendPacketChat(SOEClient sender, ushort messageType, ulong guid1, ulong guid2, string message, string targetFirst, string targetLast)
        {
            var packetChat = new SOEWriter((ushort)BasePackets.BaseChatPacket, true);
            packetChat.AddHostUInt16((ushort)BaseChatPackets.PacketChat);

            packetChat.AddHostUInt16(messageType);
            packetChat.AddHostUInt64(playerGUID); // Sender's Character GUID
            packetChat.AddHostUInt64(guid2);

            for (int i = 0; i < 3; i++)
                packetChat.AddHostInt32(0);
            packetChat.AddASCIIString(CharacterData.FirstName);
            packetChat.AddASCIIString(CharacterData.LastName);

            for (int i = 0; i < 3; i++)
                packetChat.AddHostInt32(0);
            packetChat.AddASCIIString(targetFirst);
            packetChat.AddASCIIString(targetLast);

            packetChat.AddASCIIString(message);

            for (var i = 0; i < position.Length; i++) // Position
                packetChat.AddFloat(position[i]);
            packetChat.AddFloat(1.0f);


            packetChat.AddHostUInt64(0);
            packetChat.AddHostUInt32(2);
            if (messageType == 8)
                packetChat.AddHostUInt32(0);

            List<SOEClient> Clients = _server.ConnectionManager.Clients;

            PlayerCharacter targetCharacter = LoginManager.PlayerCharacters.Find(x => x.CharacterData.FirstName == targetFirst && x.CharacterData.LastName == targetLast);
            if (messageType == 1)
            {
                if (targetCharacter != null) return; // player disconnected, don't leak
                Clients = new List<SOEClient>();
                Clients.Add(sender);
                Clients.Add(targetCharacter.client);
            }
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i] == null) continue;
                SOEClient otherClient = Clients[i];
                PlayerCharacter otherCharacter = LoginManager.PlayerCharacters.Find(x => x.client == otherClient);
                if (otherCharacter == null) continue;
                if (Magnitude(position, otherCharacter.position) <= 50.0)
                    LoginManager.SendTunneledClientPacket(otherClient, packetChat.GetRaw());
            }

            if (message == "boombox1")
            {
                var GUID = LoginManager.RandomGUID();
                var placeBoombox1 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
                placeBoombox1.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox1.AddHostUInt64(GUID);
                placeBoombox1.AddHostInt32(3472364);
                placeBoombox1.AddHostInt32(2217);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddHostInt32(408679);
                placeBoombox1.AddHostInt32(13951728);
                placeBoombox1.AddHostInt32(1);
                placeBoombox1.AddFloat(1.0f);

                placeBoombox1.AddFloat(position[0] + 2);
                placeBoombox1.AddFloat(position[1]);
                placeBoombox1.AddFloat(position[2]);
                placeBoombox1.AddFloat(1.0f);

                placeBoombox1.AddFloat(rotation[0]);
                placeBoombox1.AddFloat(rotation[1]);
                placeBoombox1.AddFloat(rotation[2]);
                placeBoombox1.AddFloat(0.0f);

                placeBoombox1.AddHostInt32(2100);
                placeBoombox1.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox1.AddHostInt32(1);

                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddBoolean(true);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddASCIIString(""); // Custom Name
                placeBoombox1.AddBoolean(true); // NameDisabled
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddHostInt32(100);
                placeBoombox1.AddHostInt32(-1);
                placeBoombox1.AddHostInt32(-1);
                placeBoombox1.AddHostInt32(-1);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddHostInt32(-1);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);

                placeBoombox1.AddHostInt32(0); // EffectTagsCount

                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddBoolean(false);

                placeBoombox1.AddHostInt32(1); // UnknownStruct2
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddASCIIString("");

                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);

                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(-1);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddBoolean(true);
                placeBoombox1.AddHostInt64(0);
                placeBoombox1.AddHostInt32(2);
                placeBoombox1.AddFloat(0.0f);

                placeBoombox1.AddHostInt32(0); // Target

                placeBoombox1.AddHostInt32(0); // CharacterVariables

                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddFloat(0.0f);

                placeBoombox1.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);

                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddASCIIString("");
                placeBoombox1.AddBoolean(false);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(0);
                placeBoombox1.AddHostInt32(3442);
                placeBoombox1.AddFloat(0.0f);
                placeBoombox1.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox1.GetRaw());
            }

            if (message == "boombox2")
            {
                var GUID = LoginManager.RandomGUID();
                var placeBoombox2 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
                placeBoombox2.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox2.AddHostUInt64(GUID);
                placeBoombox2.AddHostInt32(3472364);
                placeBoombox2.AddHostInt32(2201);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddHostInt32(408679);
                placeBoombox2.AddHostInt32(13951728);
                placeBoombox2.AddHostInt32(1);
                placeBoombox2.AddFloat(1.0f);

                placeBoombox2.AddFloat(position[0] + 2);
                placeBoombox2.AddFloat(position[1]);
                placeBoombox2.AddFloat(position[2]);
                placeBoombox2.AddFloat(1.0f);

                placeBoombox2.AddFloat(rotation[0]);
                placeBoombox2.AddFloat(rotation[1]);
                placeBoombox2.AddFloat(rotation[2]);
                placeBoombox2.AddFloat(0.0f);

                placeBoombox2.AddHostInt32(2100);
                placeBoombox2.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox2.AddHostInt32(1);

                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddBoolean(true);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddASCIIString(""); // Custom Name
                placeBoombox2.AddBoolean(true); // NameDisabled
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddHostInt32(100);
                placeBoombox2.AddHostInt32(-1);
                placeBoombox2.AddHostInt32(-1);
                placeBoombox2.AddHostInt32(-1);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddHostInt32(-1);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);

                placeBoombox2.AddHostInt32(0); // EffectTagsCount

                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddBoolean(false);

                placeBoombox2.AddHostInt32(1); // UnknownStruct2
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddASCIIString("");

                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);

                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(-1);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddBoolean(true);
                placeBoombox2.AddHostInt64(0);
                placeBoombox2.AddHostInt32(2);
                placeBoombox2.AddFloat(0.0f);

                placeBoombox2.AddHostInt32(0); // Target

                placeBoombox2.AddHostInt32(0); // CharacterVariables

                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddFloat(0.0f);

                placeBoombox2.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);

                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddASCIIString("");
                placeBoombox2.AddBoolean(false);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(0);
                placeBoombox2.AddHostInt32(3442);
                placeBoombox2.AddFloat(0.0f);
                placeBoombox2.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox2.GetRaw());
            }

            if (message == "boombox3")
            {
                var GUID = LoginManager.RandomGUID();
                var placeBoombox3 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
                placeBoombox3.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox3.AddHostUInt64(GUID);
                placeBoombox3.AddHostInt32(3472364);
                placeBoombox3.AddHostInt32(1062);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddHostInt32(408679);
                placeBoombox3.AddHostInt32(13951728);
                placeBoombox3.AddHostInt32(1);
                placeBoombox3.AddFloat(1.0f);

                placeBoombox3.AddFloat(position[0] + 2);
                placeBoombox3.AddFloat(position[1]);
                placeBoombox3.AddFloat(position[2]);
                placeBoombox3.AddFloat(1.0f);

                placeBoombox3.AddFloat(rotation[0]);
                placeBoombox3.AddFloat(rotation[1]);
                placeBoombox3.AddFloat(rotation[2]);
                placeBoombox3.AddFloat(0.0f);

                placeBoombox3.AddHostInt32(2100);
                placeBoombox3.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox3.AddHostInt32(1);

                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddBoolean(true);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddASCIIString(""); // Custom Name
                placeBoombox3.AddBoolean(true); // NameDisabled
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddHostInt32(100);
                placeBoombox3.AddHostInt32(-1);
                placeBoombox3.AddHostInt32(-1);
                placeBoombox3.AddHostInt32(-1);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddHostInt32(-1);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);

                placeBoombox3.AddHostInt32(0); // EffectTagsCount

                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddBoolean(false);

                placeBoombox3.AddHostInt32(1); // UnknownStruct2
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddASCIIString("");

                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);

                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(-1);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddBoolean(true);
                placeBoombox3.AddHostInt64(0);
                placeBoombox3.AddHostInt32(2);
                placeBoombox3.AddFloat(0.0f);

                placeBoombox3.AddHostInt32(0); // Target

                placeBoombox3.AddHostInt32(0); // CharacterVariables

                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddFloat(0.0f);

                placeBoombox3.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);

                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddASCIIString("");
                placeBoombox3.AddBoolean(false);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(0);
                placeBoombox3.AddHostInt32(3442);
                placeBoombox3.AddFloat(0.0f);
                placeBoombox3.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox3.GetRaw());
            }

            if (message == "boombox4")
            {
                var GUID = LoginManager.RandomGUID();

                var placeBoombox4 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

                placeBoombox4.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox4.AddHostUInt64(GUID);
                placeBoombox4.AddHostInt32(827348);
                placeBoombox4.AddHostInt32(1661);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddHostInt32(408679);
                placeBoombox4.AddHostInt32(13951728);
                placeBoombox4.AddHostInt32(1);
                placeBoombox4.AddFloat(1.0f);

                placeBoombox4.AddFloat(position[0] + 2);
                placeBoombox4.AddFloat(position[1]);
                placeBoombox4.AddFloat(position[2]);
                placeBoombox4.AddFloat(1.0f);

                placeBoombox4.AddFloat(rotation[0]);
                placeBoombox4.AddFloat(rotation[1]);
                placeBoombox4.AddFloat(rotation[2]);
                placeBoombox4.AddFloat(0.0f);

                placeBoombox4.AddHostInt32(2100);
                placeBoombox4.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox4.AddHostInt32(1);

                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddBoolean(true);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddASCIIString(""); // Custom Name
                placeBoombox4.AddBoolean(true); // NameDisabled
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddHostInt32(100);
                placeBoombox4.AddHostInt32(-1);
                placeBoombox4.AddHostInt32(-1);
                placeBoombox4.AddHostInt32(-1);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddHostInt32(-1);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);

                placeBoombox4.AddHostInt32(0); // EffectTagsCount

                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddBoolean(false);

                placeBoombox4.AddHostInt32(1); // UnknownStruct2
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddASCIIString("");

                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);

                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(-1);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddBoolean(true);
                placeBoombox4.AddHostInt64(0);
                placeBoombox4.AddHostInt32(2);
                placeBoombox4.AddFloat(0.0f);

                placeBoombox4.AddHostInt32(0); // Target

                placeBoombox4.AddHostInt32(0); // CharacterVariables

                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddFloat(0.0f);

                placeBoombox4.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);

                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddASCIIString("");
                placeBoombox4.AddBoolean(false);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(0);
                placeBoombox4.AddHostInt32(3442);
                placeBoombox4.AddFloat(0.0f);
                placeBoombox4.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox4.GetRaw());
            }

            if (message == "boombox5")
            {
                var GUID = LoginManager.RandomGUID();

                var placeBoombox5 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

                placeBoombox5.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox5.AddHostUInt64(GUID);
                placeBoombox5.AddHostInt32(54878);
                placeBoombox5.AddHostInt32(1936);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddHostInt32(408679);
                placeBoombox5.AddHostInt32(13951728);
                placeBoombox5.AddHostInt32(1);
                placeBoombox5.AddFloat(1.0f);

                placeBoombox5.AddFloat(position[0] + 2);
                placeBoombox5.AddFloat(position[1]);
                placeBoombox5.AddFloat(position[2]);
                placeBoombox5.AddFloat(1.0f);

                placeBoombox5.AddFloat(rotation[0]);
                placeBoombox5.AddFloat(rotation[1]);
                placeBoombox5.AddFloat(rotation[2]);
                placeBoombox5.AddFloat(0.0f);

                placeBoombox5.AddHostInt32(2100);
                placeBoombox5.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox5.AddHostInt32(1);

                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddBoolean(true);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddASCIIString(""); // Custom Name
                placeBoombox5.AddBoolean(true); // NameDisabled
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddHostInt32(100);
                placeBoombox5.AddHostInt32(-1);
                placeBoombox5.AddHostInt32(-1);
                placeBoombox5.AddHostInt32(-1);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddHostInt32(-1);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);

                placeBoombox5.AddHostInt32(0); // EffectTagsCount

                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddBoolean(false);

                placeBoombox5.AddHostInt32(1); // UnknownStruct2
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddASCIIString("");

                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);

                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(-1);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddBoolean(true);
                placeBoombox5.AddHostInt64(0);
                placeBoombox5.AddHostInt32(2);
                placeBoombox5.AddFloat(0.0f);

                placeBoombox5.AddHostInt32(0); // Target

                placeBoombox5.AddHostInt32(0); // CharacterVariables

                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddFloat(0.0f);

                placeBoombox5.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);

                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddASCIIString("");
                placeBoombox5.AddBoolean(false);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(0);
                placeBoombox5.AddHostInt32(3442);
                placeBoombox5.AddFloat(0.0f);
                placeBoombox5.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox5.GetRaw());
            }

            if (message == "boombox6")
            {
                var GUID = LoginManager.RandomGUID();

                var placeBoombox6 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

                placeBoombox6.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox6.AddHostUInt64(GUID);
                placeBoombox6.AddHostInt32(2475);
                placeBoombox6.AddHostInt32(1973);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddHostInt32(408679);
                placeBoombox6.AddHostInt32(13951728);
                placeBoombox6.AddHostInt32(1);
                placeBoombox6.AddFloat(1.0f);

                placeBoombox6.AddFloat(position[0] + 2);
                placeBoombox6.AddFloat(position[1]);
                placeBoombox6.AddFloat(position[2]);
                placeBoombox6.AddFloat(1.0f);

                placeBoombox6.AddFloat(rotation[0]);
                placeBoombox6.AddFloat(rotation[1]);
                placeBoombox6.AddFloat(rotation[2]);
                placeBoombox6.AddFloat(0.0f);

                placeBoombox6.AddHostInt32(2100);
                placeBoombox6.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox6.AddHostInt32(1);

                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddBoolean(true);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddASCIIString(""); // Custom Name
                placeBoombox6.AddBoolean(true); // NameDisabled
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddHostInt32(100);
                placeBoombox6.AddHostInt32(-1);
                placeBoombox6.AddHostInt32(-1);
                placeBoombox6.AddHostInt32(-1);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddHostInt32(-1);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);

                placeBoombox6.AddHostInt32(0); // EffectTagsCount

                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddBoolean(false);

                placeBoombox6.AddHostInt32(1); // UnknownStruct2
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddASCIIString("");

                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);

                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(-1);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddBoolean(true);
                placeBoombox6.AddHostInt64(0);
                placeBoombox6.AddHostInt32(2);
                placeBoombox6.AddFloat(0.0f);

                placeBoombox6.AddHostInt32(0); // Target

                placeBoombox6.AddHostInt32(0); // CharacterVariables

                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddFloat(0.0f);

                placeBoombox6.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);

                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddASCIIString("");
                placeBoombox6.AddBoolean(false);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(0);
                placeBoombox6.AddHostInt32(3442);
                placeBoombox6.AddFloat(0.0f);
                placeBoombox6.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox6.GetRaw());
            }

            if (message == "boombox7")
            {
                var GUID = LoginManager.RandomGUID();

                var placeBoombox7 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

                placeBoombox7.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
                placeBoombox7.AddHostUInt64(GUID);
                placeBoombox7.AddHostInt32(3482);
                placeBoombox7.AddHostInt32(3794);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddHostInt32(408679);
                placeBoombox7.AddHostInt32(13951728);
                placeBoombox7.AddHostInt32(1);
                placeBoombox7.AddFloat(1.0f);

                placeBoombox7.AddFloat(position[0] + 2);
                placeBoombox7.AddFloat(position[1]);
                placeBoombox7.AddFloat(position[2]);
                placeBoombox7.AddFloat(1.0f);

                placeBoombox7.AddFloat(rotation[0]);
                placeBoombox7.AddFloat(rotation[1]);
                placeBoombox7.AddFloat(rotation[2]);
                placeBoombox7.AddFloat(0.0f);

                placeBoombox7.AddHostInt32(2100);
                placeBoombox7.AddHostInt32(0); // CharacterAttachmentDataCount
                placeBoombox7.AddHostInt32(1);

                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddBoolean(true);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddASCIIString(""); // Custom Name
                placeBoombox7.AddBoolean(true); // NameDisabled
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddHostInt32(100);
                placeBoombox7.AddHostInt32(-1);
                placeBoombox7.AddHostInt32(-1);
                placeBoombox7.AddHostInt32(-1);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddHostInt32(-1);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);

                placeBoombox7.AddHostInt32(0); // EffectTagsCount

                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddBoolean(false);

                placeBoombox7.AddHostInt32(1); // UnknownStruct2
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddASCIIString("");

                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);

                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(-1);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddBoolean(true);
                placeBoombox7.AddHostInt64(0);
                placeBoombox7.AddHostInt32(2);
                placeBoombox7.AddFloat(0.0f);

                placeBoombox7.AddHostInt32(0); // Target

                placeBoombox7.AddHostInt32(0); // CharacterVariables

                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddFloat(0.0f);

                placeBoombox7.AddFloat(0.0f); // Unknown54, float[4]
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);

                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddASCIIString("");
                placeBoombox7.AddBoolean(false);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(0);
                placeBoombox7.AddHostInt32(3442);
                placeBoombox7.AddFloat(0.0f);
                placeBoombox7.AddHostInt32(0);

                BroadcastManager.BroadcastToPlayers(placeBoombox7.GetRaw());

                var setAnimation = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
                setAnimation.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketSetAnimation);
                setAnimation.AddHostInt64(sender.GetClientID());
                setAnimation.AddHostInt32(3530);
                setAnimation.AddHostInt32(0);
                setAnimation.AddByte(2);

                BroadcastManager.BroadcastToPlayers(setAnimation.GetRaw());
            }
        }

        public void SendQuickChatSendChatToChannelPacket(SOEClient sender, int commandId, short channelId, long guildGuid)
        {
            var senderCharacter = LoginManager.PlayerCharacters.Find(x => x.client == sender);

            if (senderCharacter == null)
                return;

            foreach (var soeClient in _server.ConnectionManager.Clients)
            {
                var playerCharacter = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);

                if (playerCharacter == null)
                    continue;

                if (Magnitude(position, playerCharacter.position) > 200.0f && soeClient != sender)
                    continue;

                var quickChatPacket = new SOEWriter((ushort)BasePackets.BaseQuickChatPacket, true);

                quickChatPacket.AddHostUInt16((ushort)BaseQuickChatPackets.QuickChatSendChatToChannelPacket);

                quickChatPacket.AddHostInt32(commandId);
                quickChatPacket.AddHostInt64(senderCharacter.playerGUID);

                // UnknownStruct3
                quickChatPacket.AddHostInt32(senderCharacter.CharacterData.Unknown24);
                quickChatPacket.AddHostInt32(senderCharacter.CharacterData.Unknown25);
                quickChatPacket.AddHostInt32(senderCharacter.CharacterData.Unknown26);
                quickChatPacket.AddASCIIString(senderCharacter.CharacterData.FirstName);
                quickChatPacket.AddASCIIString(senderCharacter.CharacterData.LastName);

                quickChatPacket.AddHostInt16(channelId);
                quickChatPacket.AddHostInt32(0);
                quickChatPacket.AddHostInt64(guildGuid);

                LoginManager.SendTunneledClientPacket(soeClient, quickChatPacket.GetRaw());
            }
        }

    }
}