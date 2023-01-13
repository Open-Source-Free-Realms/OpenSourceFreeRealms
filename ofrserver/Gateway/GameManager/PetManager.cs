using Gateway.Login;
using Gateway.Player;
using SOE;
using SOE.Core;
using SOE.Interfaces;
using System;

namespace Gateway.GameManager
{
    internal class PetManager
    {
        public static void HandlePetBasePacket(SOEClient soeClient, SOEReader reader)
        {
            var subOpcode = reader.ReadByte();
            LoginManager._log.Info("HandlePetBasePacket");
            switch (subOpcode)
            {
                case (byte)PetBasePackets.PetSummonRecallPacket:
                    {
                        int petId = reader.ReadHostInt32();
                        byte petStatus = reader.ReadByte();
                        LoginManager._log.Info($"PetSummonRecallPacket OpCode: {subOpcode} petID {petId} petStatus {petStatus}\n");

                        if (petStatus == 1)
                        {
                            HandleActivatePet(soeClient, petId);

                        }
                        else
                        {
                            HandleDeactivatePet(soeClient);
                        }
                    }
                    break;
                default:
                    var data = reader.ReadToEnd();

                    LoginManager._log.Info($"PetSummonRecallPacket OpCode: 53 {subOpcode}\n{BitConverter.ToString(data).Replace("-", "")}");
                    break;

            }
        }

        public static void SendPlayerUpdatePacketRemovePlayer(SOEClient soeClient, PlayerCharacter player)
        {
            var removePet = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);

            removePet.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketRemovePlayer);

            removePet.AddHostUInt16(1);
            removePet.AddHostUInt64(player.activePet.PetGUID);

            removePet.AddBoolean(false);
            removePet.AddHostInt32(0);
            removePet.AddHostInt32(0);
            removePet.AddHostInt32(46);
            removePet.AddHostInt32(1000);

            BroadcastManager.BroadcastToPlayers(removePet.GetRaw());
        }

        public static void HandleDeactivatePet(SOEClient soeClient)
        {

            var player = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);
            if (player != null)
            {
                SendPetDeactivatePacket(soeClient);
                SendPlayerUpdatePacketRemovePlayer(soeClient, player);
                player.activePet.PetGUID = 0;
                player.activePet.PetId = 0;

            }
        }


        public static void SendPetDeactivatePacket(SOEClient soeClient)
        {
            var petActiveData = new SOEWriter((ushort)BasePackets.PetBasePacket, true);
            petActiveData.AddByte((byte)PetBasePackets.PetActivePacket);
            petActiveData.AddHostInt32(0);
            petActiveData.AddHostUInt64(0);
            LoginManager.SendTunneledClientPacket(soeClient, petActiveData.GetRaw());
        }

        public static void HandleActivatePet(SOEClient soeClient, int petId)
        {

            var player = LoginManager.PlayerCharacters.Find(x => x.client == soeClient);
            if (player != null)
            {
                var newGUID = GUIDManager.createNewGUID();
                var activePet = player.activePet;
                activePet.PetId = petId;
                activePet.PetGUID = newGUID;

                for (int i = 0; i < player.position.Length; i++)
                {
                    activePet.Position[i] = player.position[i];
                }
                for (int i = 0; i < player.rotation.Length; i++)
                {
                    activePet.Rotation[i] = player.rotation[i];
                }

                var petData = player.pets.Find(x => x.PetId == petId);

                SendPlayerUpdatePacketAddNpc(soeClient, player, petData, activePet);
                SendPetActivePacket(soeClient, activePet);
                SendPetStatusPacket(soeClient, petData, activePet);
                SendPlayerUpdatePacketUpdateOwner(soeClient, activePet);
                PlayerUpdatePacketPlayCompositeEffect(soeClient, player);
                SendPlayerUpdatePacketUpdateCharacterState(soeClient, activePet);
            }
        }

        public static void SendPlayerUpdatePacketUpdateCharacterState(SOEClient soeClient, ActivePet activePet)
        {
            var data = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            data.AddByte((byte)BasePlayerUpdatePackets.PlayerUpdatePacketUpdateCharacterState);
            data.AddBoolean(false);
            data.AddHostUInt64(activePet.PetGUID);
            data.AddHostInt32(1);
            LoginManager.SendTunneledClientPacket(soeClient, data.GetRaw());
        }

        public static void SendPlayerUpdatePacketUpdateOwner(SOEClient soeClient, ActivePet activePet)
        {
            var data = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            data.AddByte((byte)BasePlayerUpdatePackets.PlayerUpdatePacketUpdateOwner);
            data.AddBoolean(false);
            data.AddHostUInt64(activePet.PetGUID);
            data.AddHostInt32(0);
            data.AddBoolean(false);
            LoginManager.SendTunneledClientPacket(soeClient, data.GetRaw());
        }

        public static void SendPetStatusPacket(SOEClient soeClient, ClientPcData.UnknownPetStruct petData, ActivePet activePet)
        {
            var data = new SOEWriter((ushort)BasePackets.PetBasePacket, true);
            data.AddByte((byte)PetBasePackets.PetStatusPacket);
            data.AddHostInt32(activePet.PetId);
            data.AddFloat(petData.Food);
            data.AddFloat(petData.Groom);
            data.AddFloat(petData.Exercise);
            data.AddFloat(petData.Happiness);

            LoginManager.SendTunneledClientPacket(soeClient, data.GetRaw());

        }

        public static void SendPetActivePacket(SOEClient soeClient, ActivePet activePet)
        {
            var petActiveData = new SOEWriter((ushort)BasePackets.PetBasePacket, true);
            petActiveData.AddByte((byte)PetBasePackets.PetActivePacket);
            petActiveData.AddHostInt32(activePet.PetId);
            petActiveData.AddHostUInt64(activePet.PetGUID);

            LoginManager.SendTunneledClientPacket(soeClient, petActiveData.GetRaw());
        }

        public static void SendPlayerUpdatePacketAddNpc(SOEClient soeClient, PlayerCharacter player, ClientPcData.UnknownPetStruct petData, ActivePet activePet)
        {
            var addPet = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addPet.AddByte((byte)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addPet.AddBoolean(false);
            addPet.AddHostUInt64(activePet.PetGUID);
            addPet.AddHostInt32(petData.Unknown10); // Name ID 
            addPet.AddHostInt32(petData.ModelId);
            addPet.AddBoolean(false);
            addPet.AddHostInt32(408679);
            addPet.AddHostInt32(13951728);
            addPet.AddHostInt32(1);
            addPet.AddFloat(1.0f);

            addPet.AddFloat(player.position[0] + 2.5f);
            addPet.AddFloat(player.position[1]);
            addPet.AddFloat(player.position[2]);
            addPet.AddFloat(1.0f);

            addPet.AddFloat(player.rotation[0]);
            addPet.AddFloat(player.rotation[1]);
            addPet.AddFloat(player.rotation[2]);
            addPet.AddFloat(0f);

            addPet.AddHostInt32(1);
            addPet.AddHostInt32(1); // CharacterAttachmentDataCount

            addPet.AddASCIIString("pet_dog_<descriptor>_head_racehelmet.adr");
            addPet.AddASCIIString("racecardriver-blackgoggles-P");
            addPet.AddASCIIString("dyetint");
            addPet.AddHostInt32(1);
            addPet.AddHostInt32(1);
            addPet.AddHostInt32(1);

            addPet.AddHostInt32(1);

            addPet.AddASCIIString("");
            addPet.AddASCIIString(petData.TextureAlias);
            addPet.AddHostInt32(0);
            addPet.AddBoolean(true);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddASCIIString(""); // Custom Name
            addPet.AddBoolean(false); // NameDisabled
            addPet.AddHostInt32(0);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddHostInt32(0);
            addPet.AddBoolean(false);
            addPet.AddFloat(0.0f);
            addPet.AddBoolean(false);
            addPet.AddHostInt32(100);
            addPet.AddHostInt32(-1);
            addPet.AddHostInt32(-1);
            addPet.AddHostInt32(-1);
            addPet.AddBoolean(false);
            addPet.AddBoolean(false);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);

            addPet.AddHostInt32(0); // EffectTagsCount

            addPet.AddBoolean(false);
            addPet.AddHostInt32(0);
            addPet.AddBoolean(false);
            addPet.AddBoolean(false);
            addPet.AddBoolean(false);
            addPet.AddBoolean(false);

            addPet.AddHostInt32(0); // UnknownStruct2
            addPet.AddHostInt32(0);
            addPet.AddASCIIString("");
            addPet.AddASCIIString("");
            addPet.AddHostInt32(0);
            addPet.AddASCIIString("");

            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);

            addPet.AddHostInt32(-1);
            addPet.AddHostInt32(petData.IconId);
            addPet.AddBoolean(true);
            addPet.AddHostInt64(0);
            addPet.AddHostInt32(2);
            addPet.AddFloat(0.0f);

            addPet.AddHostInt32(0); // Target

            addPet.AddHostInt32(0); // CharacterVariables

            addPet.AddHostInt32(0);
            addPet.AddFloat(0.0f);

            addPet.AddFloat(0.0f); // Unknown54, float[4]
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);

            addPet.AddHostInt32(0);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddFloat(0.0f);
            addPet.AddASCIIString("");
            addPet.AddASCIIString("");
            addPet.AddASCIIString("");
            addPet.AddBoolean(false);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(8);
            addPet.AddHostInt32(0);
            addPet.AddHostInt32(0);
            addPet.AddFloat(0.0f);
            addPet.AddHostInt32(0);

            BroadcastManager.BroadcastToPlayers(addPet.GetRaw());

        }
        public static void PlayerUpdatePacketPlayCompositeEffect(SOEClient soeClient, PlayerCharacter player)
        {
            var activePet = player.activePet;
            LoginManager._log.Info("PlayerUpdatePacketPlayCompositeEffect");
            var soeWriter = new SOEWriter((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketPlayCompositeEffect, true);
            soeWriter.AddHostUInt64(activePet.PetGUID);
            soeWriter.AddHostUInt32(34);
            soeWriter.AddHostUInt32(9546096);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(46);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(0);
            soeWriter.AddHostUInt32(1065353216);
            soeWriter.AddByte(1);

            BroadcastManager.BroadcastToPlayers(soeWriter.GetRaw());
        }

        public static void UpdatePosition(SOEClient soeClient, PlayerCharacter player)
        {
            var pet = player.activePet;
            if (pet.PetGUID != 0)
            {

                for (var i = 0; i < player.position.Length; i++)
                    player.activePet.Position[i] = player.position[i];

                for (var i = 0; i < player.rotation.Length; i++)
                    player.activePet.Rotation[i] = player.rotation[i];
                player.activePet.PetState = 0;
                SendUpdatePosition(soeClient, player);
                
            }
        }
        public static void SendUpdatePosition(SOEClient soeClient, PlayerCharacter player)
        {
            var activePet = player.activePet;
            if (activePet.PetGUID != 0)
            {
                var petData = player.pets.Find(x => x.PetId == activePet.PetId);
                var soeWriter = new SOEWriter((ushort)BasePackets.PlayerUpdatePacketUpdatePosition, true);
                soeWriter.AddHostUInt64(activePet.PetGUID);

                for (var i = 0; i < 3; i++)
                    soeWriter.AddFloat(activePet.Position[i] + 2.5f);

                for (var i = 0; i < 3; i++)
                    soeWriter.AddFloat(activePet.Position[i] - 2.5f);

                soeWriter.AddByte((byte)activePet.PetState);
                soeWriter.AddByte(0);


                BroadcastManager.BroadcastToPlayers(soeWriter.GetRaw());
            }
        }
    }
}


