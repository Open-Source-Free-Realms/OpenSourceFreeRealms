using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;


namespace Gateway.GameManager
{
    internal class NPCManager
    {
        public static void SendPlayerUpdatePacketAddNpc(SOEClient soeClient)
        {
            var penguinBert = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            penguinBert.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            penguinBert.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            penguinBert.AddHostInt32(432135); // Name ID
            penguinBert.AddHostInt32(21); // Model ID
            penguinBert.AddBoolean(false); // Unknown4
            penguinBert.AddHostInt32(408679); // Unknown5
            penguinBert.AddHostInt32(13951728); // Unknown6
            penguinBert.AddHostInt32(1); // Unknown7
            penguinBert.AddFloat(1.0f); // Unknown8

            // Position
            penguinBert.AddFloat(199.0173f);
            penguinBert.AddFloat(29.82868f);
            penguinBert.AddFloat(440.0971f);
            penguinBert.AddFloat(1.0f);

            //Rotation
            penguinBert.AddFloat(0.8144693f);
            penguinBert.AddFloat(0f);
            penguinBert.AddFloat(-0.5802067f);
            penguinBert.AddFloat(0f);

            penguinBert.AddHostInt32(1); // Unknown11

            penguinBert.AddHostInt32(0); // CharacterAttachmentDataCount
            penguinBert.AddHostInt32(1); // Unknown12

            penguinBert.AddASCIIString(""); // TextureAlias
            penguinBert.AddASCIIString(""); // TintAlias
            penguinBert.AddHostInt32(0); // TintId
            penguinBert.AddBoolean(true); // Unknown16
            penguinBert.AddFloat(0f); // Unknown17
            penguinBert.AddHostInt32(0); // Unknown18
            penguinBert.AddHostInt32(0); // Unknown19
            penguinBert.AddASCIIString("Bert"); // Custom Name
            penguinBert.AddBoolean(false); // NameDisabled
            penguinBert.AddHostInt32(0); // Unknown22
            penguinBert.AddFloat(0.0f); // Unknown23
            penguinBert.AddFloat(0.0f); // Unknown24
            penguinBert.AddHostInt32(0); // Unknown25
            penguinBert.AddBoolean(false); // Unknown26
            penguinBert.AddFloat(0.0f); // Unknown27
            penguinBert.AddBoolean(false); // Unknown28
            penguinBert.AddHostInt32(100); // Unknown29
            penguinBert.AddHostInt32(-1); // Unknown
            penguinBert.AddHostInt32(-1); // Unknown
            penguinBert.AddHostInt32(-1); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddHostInt32(-1); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddHostInt32(0); // Unknown

            penguinBert.AddHostInt32(0); // EffectTagsCount

            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddBoolean(false); // Unknown

            penguinBert.AddHostInt32(0); // UnknownStruct2
            penguinBert.AddASCIIString("");
            penguinBert.AddASCIIString("");
            penguinBert.AddHostInt32(0);
            penguinBert.AddASCIIString("");

            penguinBert.AddFloat(0.0f);
            penguinBert.AddFloat(0.0f);
            penguinBert.AddFloat(0.0f);
            penguinBert.AddFloat(0.0f);

            penguinBert.AddHostInt32(0);
            penguinBert.AddHostInt32(-1);
            penguinBert.AddHostInt32(0);
            penguinBert.AddBoolean(true);
            penguinBert.AddHostUInt64(0);
            penguinBert.AddHostInt32(2);
            penguinBert.AddFloat(0.0f);

            penguinBert.AddHostInt32(0); // Target

            penguinBert.AddHostInt32(0); // CharacterVariables

            penguinBert.AddHostInt32(0);
            penguinBert.AddFloat(0.0f);

            penguinBert.AddFloat(0.0f); // Unknown54, float[4]
            penguinBert.AddFloat(0.0f);
            penguinBert.AddFloat(0.0f);
            penguinBert.AddFloat(0.0f);

            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddFloat(0.0f); // Unknown
            penguinBert.AddFloat(0.0f); // Unknown
            penguinBert.AddFloat(0.0f); // Unknown
            penguinBert.AddASCIIString(""); // Unknown
            penguinBert.AddASCIIString(""); // Unknown
            penguinBert.AddASCIIString(""); // Unknown
            penguinBert.AddBoolean(false); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddHostInt32(8); // Unknown
            penguinBert.AddHostInt32(0); // Unknown
            penguinBert.AddHostInt32(3442); // Unknown
            penguinBert.AddFloat(0.0f); // Unknown
            penguinBert.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, penguinBert.GetRaw());

            var penguinErnie = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            penguinErnie.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            penguinErnie.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            penguinErnie.AddHostInt32(432135); // Name ID
            penguinErnie.AddHostInt32(31); // Model ID
            penguinErnie.AddBoolean(false); // Unknown4
            penguinErnie.AddHostInt32(408679); // Unknown5
            penguinErnie.AddHostInt32(13951728); // Unknown6
            penguinErnie.AddHostInt32(1); // Unknown7
            penguinErnie.AddFloat(1.0f); // Unknown8

            // Position
            penguinErnie.AddFloat(197.8869f);
            penguinErnie.AddFloat(29.81658f);
            penguinErnie.AddFloat(438.2278f);
            penguinErnie.AddFloat(1.0f);

            //Rotation
            penguinErnie.AddFloat(0.815826f);
            penguinErnie.AddFloat(0f);
            penguinErnie.AddFloat(-0.5782975f);
            penguinErnie.AddFloat(0f);

            penguinErnie.AddHostInt32(1); // Unknown11

            penguinErnie.AddHostInt32(0); // CharacterAttachmentDataCount
            penguinErnie.AddHostInt32(1); // Unknown12

            penguinErnie.AddASCIIString(""); // TextureAlias
            penguinErnie.AddASCIIString(""); // TintAlias
            penguinErnie.AddHostInt32(0); // TintId
            penguinErnie.AddBoolean(true); // Unknown16
            penguinErnie.AddFloat(0f); // Unknown17
            penguinErnie.AddHostInt32(0); // Unknown18
            penguinErnie.AddHostInt32(0); // Unknown19
            penguinErnie.AddASCIIString("Ernie"); // Custom Name
            penguinErnie.AddBoolean(false); // NameDisabled
            penguinErnie.AddHostInt32(0); // Unknown22
            penguinErnie.AddFloat(0.0f); // Unknown23
            penguinErnie.AddFloat(0.0f); // Unknown24
            penguinErnie.AddHostInt32(0); // Unknown25
            penguinErnie.AddBoolean(false); // Unknown26
            penguinErnie.AddFloat(0.0f); // Unknown27
            penguinErnie.AddBoolean(false); // Unknown28
            penguinErnie.AddHostInt32(100); // Unknown29
            penguinErnie.AddHostInt32(-1); // Unknown
            penguinErnie.AddHostInt32(-1); // Unknown
            penguinErnie.AddHostInt32(-1); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddHostInt32(-1); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown

            penguinErnie.AddHostInt32(0); // EffectTagsCount

            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddBoolean(false); // Unknown

            penguinErnie.AddHostInt32(0); // UnknownStruct2
            penguinErnie.AddASCIIString("");
            penguinErnie.AddASCIIString("");
            penguinErnie.AddHostInt32(0);
            penguinErnie.AddASCIIString("");

            penguinErnie.AddFloat(0.0f);
            penguinErnie.AddFloat(0.0f);
            penguinErnie.AddFloat(0.0f);
            penguinErnie.AddFloat(0.0f);

            penguinErnie.AddHostInt32(0);
            penguinErnie.AddHostInt32(-1);
            penguinErnie.AddHostInt32(0);
            penguinErnie.AddBoolean(true);
            penguinErnie.AddHostUInt64(0);
            penguinErnie.AddHostInt32(2);
            penguinErnie.AddFloat(0.0f);

            penguinErnie.AddHostInt32(0); // Target

            penguinErnie.AddHostInt32(0); // CharacterVariables

            penguinErnie.AddHostInt32(0);
            penguinErnie.AddFloat(0.0f);

            penguinErnie.AddFloat(0.0f); // Unknown54, float[4]
            penguinErnie.AddFloat(0.0f);
            penguinErnie.AddFloat(0.0f);
            penguinErnie.AddFloat(0.0f);

            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddFloat(0.0f); // Unknown
            penguinErnie.AddFloat(0.0f); // Unknown
            penguinErnie.AddFloat(0.0f); // Unknown
            penguinErnie.AddASCIIString(""); // Unknown
            penguinErnie.AddASCIIString(""); // Unknown
            penguinErnie.AddASCIIString(""); // Unknown
            penguinErnie.AddBoolean(false); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddHostInt32(8); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown
            penguinErnie.AddHostInt32(3442); // Unknown
            penguinErnie.AddFloat(0.0f); // Unknown
            penguinErnie.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, penguinErnie.GetRaw());

            var candiIvy = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            candiIvy.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            candiIvy.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            candiIvy.AddHostInt32(9455); // Name ID
            candiIvy.AddHostInt32(45); // Model ID
            candiIvy.AddBoolean(false); // Unknown4
            candiIvy.AddHostInt32(408679); // Unknown5
            candiIvy.AddHostInt32(13951728); // Unknown6
            candiIvy.AddHostInt32(1); // Unknown7
            candiIvy.AddFloat(1.0f); // Unknown8

            // Position
            candiIvy.AddFloat(229.5881f);
            candiIvy.AddFloat(24.11596f);
            candiIvy.AddFloat(399.0901f);
            candiIvy.AddFloat(1.0f);

            //Rotation
            candiIvy.AddFloat(-0.9070207f);
            candiIvy.AddFloat(0f);
            candiIvy.AddFloat(-0.9070207f);
            candiIvy.AddFloat(0f);

            candiIvy.AddHostInt32(0); // Unknown11

            candiIvy.AddHostInt32(0); // CharacterAttachmentDataCount
            candiIvy.AddHostInt32(1); // Unknown12

            candiIvy.AddASCIIString(""); // TextureAlias
            candiIvy.AddASCIIString(""); // TintAlias
            candiIvy.AddHostInt32(0); // TintId
            candiIvy.AddBoolean(true); // Unknown16
            candiIvy.AddFloat(-0.1f); // Unknown17
            candiIvy.AddHostInt32(0); // Unknown18
            candiIvy.AddHostInt32(0); // Unknown19
            candiIvy.AddASCIIString("Candi Ivy"); // Custom Name
            candiIvy.AddBoolean(false); // NameDisabled
            candiIvy.AddHostInt32(0); // Unknown22
            candiIvy.AddFloat(0.0f); // Unknown23
            candiIvy.AddFloat(0.0f); // Unknown24
            candiIvy.AddHostInt32(0); // Unknown25
            candiIvy.AddBoolean(false); // Unknown26
            candiIvy.AddFloat(0.0f); // Unknown27
            candiIvy.AddBoolean(false); // Unknown28
            candiIvy.AddHostInt32(100); // Unknown29
            candiIvy.AddHostInt32(-1); // Unknown
            candiIvy.AddHostInt32(-1); // Unknown
            candiIvy.AddHostInt32(-1); // Unknown
            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddHostInt32(-1); // Unknown
            candiIvy.AddHostInt32(0); // Unknown
            candiIvy.AddHostInt32(0); // Unknown

            candiIvy.AddHostInt32(0); // EffectTagsCount

            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddHostInt32(0); // Unknown
            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddBoolean(false); // Unknown
            candiIvy.AddBoolean(false); // Unknown

            candiIvy.AddHostInt32(0); // UnknownStruct2
            candiIvy.AddASCIIString("");
            candiIvy.AddASCIIString("");
            candiIvy.AddHostInt32(0);
            candiIvy.AddASCIIString("");

            candiIvy.AddFloat(0.0f);
            candiIvy.AddFloat(0.0f);
            candiIvy.AddFloat(0.0f);
            candiIvy.AddFloat(0.0f);

            candiIvy.AddHostInt32(0);
            candiIvy.AddHostInt32(-1);
            candiIvy.AddHostInt32(0);
            candiIvy.AddBoolean(true);
            candiIvy.AddHostUInt64(0);
            candiIvy.AddHostInt32(2);
            candiIvy.AddFloat(0.0f);

            candiIvy.AddHostInt32(0); // Target

            candiIvy.AddHostInt32(0); // CharacterVariables

            candiIvy.AddHostInt32(0);
            candiIvy.AddFloat(0.0f);

            candiIvy.AddFloat(0.0f); // Unknown54, float[4]
            candiIvy.AddFloat(0.0f);
            candiIvy.AddFloat(0.0f);
            candiIvy.AddFloat(0.0f);

            candiIvy.AddHostInt32(0); // Unknown
            candiIvy.AddFloat(0.0f); // Unknown
            candiIvy.AddFloat(0.0f); // Unknown
            candiIvy.AddFloat(0.0f); // Unknown
            candiIvy.AddASCIIString(""); // Unknown
            candiIvy.AddASCIIString(""); // Unknown
            candiIvy.AddASCIIString(""); // Unknown
            candiIvy.AddBoolean(true); // Unknown
            candiIvy.AddHostInt32(4); // Unknown
            candiIvy.AddHostInt32(3); // Unknown
            candiIvy.AddHostInt32(7); // Unknown
            candiIvy.AddHostInt32(8); // Unknown
            candiIvy.AddHostInt32(1); // Unknown
            candiIvy.AddHostInt32(3442); // Unknown
            candiIvy.AddFloat(0.0f); // Unknown
            candiIvy.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, candiIvy.GetRaw());

            var chipnumbWing = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            chipnumbWing.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            chipnumbWing.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            chipnumbWing.AddHostInt32(320984); // Name ID
            chipnumbWing.AddHostInt32(1585); // Model ID
            chipnumbWing.AddBoolean(false); // Unknown4
            chipnumbWing.AddHostInt32(408679); // Unknown5
            chipnumbWing.AddHostInt32(13951728); // Unknown6
            chipnumbWing.AddHostInt32(1); // Unknown7
            chipnumbWing.AddFloat(1.0f); // Unknown8

            // Position
            chipnumbWing.AddFloat(132.0866f);
            chipnumbWing.AddFloat(22.74185f);
            chipnumbWing.AddFloat(391.9723f);
            chipnumbWing.AddFloat(1.0f);

            //Rotation
            chipnumbWing.AddFloat(0.02617325f);
            chipnumbWing.AddFloat(0f);
            chipnumbWing.AddFloat(-0.9996574f);
            chipnumbWing.AddFloat(0f);

            chipnumbWing.AddHostInt32(0); // Unknown11

            chipnumbWing.AddHostInt32(0); // CharacterAttachmentDataCount
            chipnumbWing.AddHostInt32(1); // Unknown12

            chipnumbWing.AddASCIIString(""); // TextureAlias
            chipnumbWing.AddASCIIString(""); // TintAlias
            chipnumbWing.AddHostInt32(0); // TintId
            chipnumbWing.AddBoolean(true); // Unknown16
            chipnumbWing.AddFloat(-0.1f); // Unknown17
            chipnumbWing.AddHostInt32(0); // Unknown18
            chipnumbWing.AddHostInt32(0); // Unknown19
            chipnumbWing.AddASCIIString("Chip Numbwing"); // Custom Name
            chipnumbWing.AddBoolean(false); // NameDisabled
            chipnumbWing.AddHostInt32(0); // Unknown22
            chipnumbWing.AddFloat(0.0f); // Unknown23
            chipnumbWing.AddFloat(0.0f); // Unknown24
            chipnumbWing.AddHostInt32(0); // Unknown25
            chipnumbWing.AddBoolean(false); // Unknown26
            chipnumbWing.AddFloat(0.0f); // Unknown27
            chipnumbWing.AddBoolean(false); // Unknown28
            chipnumbWing.AddHostInt32(100); // Unknown29
            chipnumbWing.AddHostInt32(-1); // Unknown
            chipnumbWing.AddHostInt32(-1); // Unknown
            chipnumbWing.AddHostInt32(-1); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddHostInt32(-1); // Unknown
            chipnumbWing.AddHostInt32(0); // Unknown
            chipnumbWing.AddHostInt32(0); // Unknown

            chipnumbWing.AddHostInt32(0); // EffectTagsCount

            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddHostInt32(0); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown
            chipnumbWing.AddBoolean(false); // Unknown

            chipnumbWing.AddHostInt32(0); // UnknownStruct2
            chipnumbWing.AddASCIIString("");
            chipnumbWing.AddASCIIString("");
            chipnumbWing.AddHostInt32(0);
            chipnumbWing.AddASCIIString("");

            chipnumbWing.AddFloat(0.0f);
            chipnumbWing.AddFloat(0.0f);
            chipnumbWing.AddFloat(0.0f);
            chipnumbWing.AddFloat(0.0f);

            chipnumbWing.AddHostInt32(0);
            chipnumbWing.AddHostInt32(-1);
            chipnumbWing.AddHostInt32(0);
            chipnumbWing.AddBoolean(true);
            chipnumbWing.AddHostUInt64(0);
            chipnumbWing.AddHostInt32(3);
            chipnumbWing.AddFloat(0.0f);

            chipnumbWing.AddHostInt32(0); // Target

            chipnumbWing.AddHostInt32(0); // CharacterVariables

            chipnumbWing.AddHostInt32(0);
            chipnumbWing.AddFloat(0.0f);

            chipnumbWing.AddFloat(0.0f); // Unknown54, float[4]
            chipnumbWing.AddFloat(0.0f);
            chipnumbWing.AddFloat(0.0f);
            chipnumbWing.AddFloat(0.0f);

            chipnumbWing.AddHostInt32(0); // Unknown
            chipnumbWing.AddFloat(0.0f); // Unknown
            chipnumbWing.AddFloat(0.0f); // Unknown
            chipnumbWing.AddFloat(0.0f); // Unknown
            chipnumbWing.AddASCIIString(""); // Unknown
            chipnumbWing.AddASCIIString(""); // Unknown
            chipnumbWing.AddASCIIString(""); // Unknown
            chipnumbWing.AddBoolean(true); // Unknown
            chipnumbWing.AddHostInt32(4); // Unknown
            chipnumbWing.AddHostInt32(3); // Unknown
            chipnumbWing.AddHostInt32(7); // Unknown
            chipnumbWing.AddHostInt32(8); // Unknown
            chipnumbWing.AddHostInt32(1); // Unknown
            chipnumbWing.AddHostInt32(3442); // Unknown
            chipnumbWing.AddFloat(0.0f); // Unknown
            chipnumbWing.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, chipnumbWing.GetRaw());

            var snowballPile = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            snowballPile.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            snowballPile.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            snowballPile.AddHostInt32(3499); // Name ID
            snowballPile.AddHostInt32(1757); // Model ID
            snowballPile.AddBoolean(true); // Unknown4
            snowballPile.AddHostInt32(408679); // Unknown5
            snowballPile.AddHostInt32(13951728); // Unknown6
            snowballPile.AddHostInt32(1); // Unknown7
            snowballPile.AddFloat(1.0f); // Unknown8

            // Position
            snowballPile.AddFloat(111.6560f);
            snowballPile.AddFloat(22.03696f);
            snowballPile.AddFloat(373.9081f);
            snowballPile.AddFloat(1.0f);

            //Rotation
            snowballPile.AddFloat(0f);
            snowballPile.AddFloat(0f);
            snowballPile.AddFloat(0f);
            snowballPile.AddFloat(0f);

            snowballPile.AddHostInt32(0); // Unknown11

            snowballPile.AddHostInt32(0); // CharacterAttachmentDataCount
            snowballPile.AddHostInt32(1); // Unknown12

            snowballPile.AddASCIIString(""); // TextureAlias
            snowballPile.AddASCIIString(""); // TintAlias
            snowballPile.AddHostInt32(0); // TintId
            snowballPile.AddBoolean(true); // Unknown16
            snowballPile.AddFloat(0f); // Unknown17
            snowballPile.AddHostInt32(0); // Unknown18
            snowballPile.AddHostInt32(0); // Unknown19
            snowballPile.AddASCIIString(""); // Custom Name
            snowballPile.AddBoolean(true); // NameDisabled
            snowballPile.AddHostInt32(0); // Unknown22
            snowballPile.AddFloat(0.0f); // Unknown23
            snowballPile.AddFloat(0.0f); // Unknown24
            snowballPile.AddHostInt32(0); // Unknown25
            snowballPile.AddBoolean(false); // Unknown26
            snowballPile.AddFloat(0.0f); // Unknown27
            snowballPile.AddBoolean(false); // Unknown28
            snowballPile.AddHostInt32(100); // Unknown29
            snowballPile.AddHostInt32(-1); // Unknown
            snowballPile.AddHostInt32(-1); // Unknown
            snowballPile.AddHostInt32(-1); // Unknown
            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddHostInt32(-1); // Unknown
            snowballPile.AddHostInt32(0); // Unknown
            snowballPile.AddHostInt32(0); // Unknown

            snowballPile.AddHostInt32(0); // EffectTagsCount

            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddHostInt32(0); // Unknown
            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddBoolean(false); // Unknown
            snowballPile.AddBoolean(false); // Unknown

            snowballPile.AddHostInt32(0); // UnknownStruct2
            snowballPile.AddASCIIString("");
            snowballPile.AddASCIIString("");
            snowballPile.AddHostInt32(0);
            snowballPile.AddASCIIString("");

            snowballPile.AddFloat(0.0f);
            snowballPile.AddFloat(0.0f);
            snowballPile.AddFloat(0.0f);
            snowballPile.AddFloat(0.0f);

            snowballPile.AddHostInt32(0);
            snowballPile.AddHostInt32(-1);
            snowballPile.AddHostInt32(0);
            snowballPile.AddBoolean(true);
            snowballPile.AddHostUInt64(0);
            snowballPile.AddHostInt32(2);
            snowballPile.AddFloat(0.0f);

            snowballPile.AddHostInt32(0); // Target

            snowballPile.AddHostInt32(0); // CharacterVariables

            snowballPile.AddHostInt32(0);
            snowballPile.AddFloat(0.0f);

            snowballPile.AddFloat(0.0f); // Unknown54, float[4]
            snowballPile.AddFloat(0.0f);
            snowballPile.AddFloat(0.0f);
            snowballPile.AddFloat(0.0f);

            snowballPile.AddHostInt32(0); // Unknown
            snowballPile.AddFloat(0.0f); // Unknown
            snowballPile.AddFloat(0.0f); // Unknown
            snowballPile.AddFloat(0.0f); // Unknown
            snowballPile.AddASCIIString(""); // Unknown
            snowballPile.AddASCIIString(""); // Unknown
            snowballPile.AddASCIIString(""); // Unknown
            snowballPile.AddBoolean(true); // Unknown
            snowballPile.AddHostInt32(4); // Unknown
            snowballPile.AddHostInt32(3); // Unknown
            snowballPile.AddHostInt32(7); // Unknown
            snowballPile.AddHostInt32(8); // Unknown
            snowballPile.AddHostInt32(1); // Unknown
            snowballPile.AddHostInt32(3442); // Unknown
            snowballPile.AddFloat(0f); // Unknown
            snowballPile.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, snowballPile.GetRaw());

        }
        public static void SendWarpStones(SOEClient soeClient)
        {
            //Briarheart
            var addBhWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addBhWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addBhWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addBhWarpstone.AddHostInt32(24730); // Name ID
            addBhWarpstone.AddHostInt32(280); // Model ID
            addBhWarpstone.AddBoolean(false); // Unknown4
            addBhWarpstone.AddHostInt32(408679); // Unknown5
            addBhWarpstone.AddHostInt32(13951728); // Unknown6
            addBhWarpstone.AddHostInt32(1); // Unknown7
            addBhWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addBhWarpstone.AddFloat(51.1206f);
            addBhWarpstone.AddFloat(-29.71164f);
            addBhWarpstone.AddFloat(2801.191f);
            addBhWarpstone.AddFloat(1.0f);

            //Rotation
            addBhWarpstone.AddFloat(-0.06225472f);
            addBhWarpstone.AddFloat(0f);
            addBhWarpstone.AddFloat(0.9980603f);
            addBhWarpstone.AddFloat(0f);

            addBhWarpstone.AddHostInt32(1); // Unknown11

            addBhWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addBhWarpstone.AddHostInt32(1); // Unknown12

            addBhWarpstone.AddASCIIString(""); // TextureAlias
            addBhWarpstone.AddASCIIString(""); // TintAlias
            addBhWarpstone.AddHostInt32(0); // TintId
            addBhWarpstone.AddBoolean(true); // Unknown16
            addBhWarpstone.AddHostInt32(0); // Unknown17
            addBhWarpstone.AddHostInt32(0); // Unknown18
            addBhWarpstone.AddHostInt32(0); // Unknown19
            addBhWarpstone.AddASCIIString(""); // Custom Name
            addBhWarpstone.AddBoolean(false); // NameDisabled
            addBhWarpstone.AddHostInt32(0); // Unknown22
            addBhWarpstone.AddFloat(0.0f); // Unknown23
            addBhWarpstone.AddFloat(0.0f); // Unknown24
            addBhWarpstone.AddHostInt32(0); // Unknown25
            addBhWarpstone.AddBoolean(false); // Unknown26
            addBhWarpstone.AddFloat(0.0f); // Unknown27
            addBhWarpstone.AddBoolean(false); // Unknown28
            addBhWarpstone.AddHostInt32(100); // Unknown29
            addBhWarpstone.AddHostInt32(-1); // Unknown
            addBhWarpstone.AddHostInt32(-1); // Unknown
            addBhWarpstone.AddHostInt32(-1); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddHostInt32(-1); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown

            addBhWarpstone.AddHostInt32(0); // EffectTagsCount

            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown

            addBhWarpstone.AddHostInt32(0); // UnknownStruct2
            addBhWarpstone.AddHostInt32(0);
            addBhWarpstone.AddASCIIString("");
            addBhWarpstone.AddASCIIString("");
            addBhWarpstone.AddHostInt32(0);
            addBhWarpstone.AddASCIIString("");

            addBhWarpstone.AddFloat(0.0f);
            addBhWarpstone.AddFloat(0.0f);
            addBhWarpstone.AddFloat(0.0f);
            addBhWarpstone.AddFloat(0.0f);

            addBhWarpstone.AddHostInt32(-1);
            addBhWarpstone.AddHostInt32(0);
            addBhWarpstone.AddBoolean(true);
            addBhWarpstone.AddHostUInt64(0);
            addBhWarpstone.AddHostInt32(2);
            addBhWarpstone.AddFloat(0.0f);

            addBhWarpstone.AddHostInt32(0); // Target

            addBhWarpstone.AddHostInt32(0); // CharacterVariables

            addBhWarpstone.AddHostInt32(0);
            addBhWarpstone.AddFloat(0.0f);

            addBhWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addBhWarpstone.AddFloat(0.0f);
            addBhWarpstone.AddFloat(0.0f);
            addBhWarpstone.AddFloat(0.0f);

            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddFloat(0.0f); // Unknown
            addBhWarpstone.AddFloat(0.0f); // Unknown
            addBhWarpstone.AddFloat(0.0f); // Unknown
            addBhWarpstone.AddASCIIString(""); // Unknown
            addBhWarpstone.AddASCIIString(""); // Unknown
            addBhWarpstone.AddASCIIString(""); // Unknown
            addBhWarpstone.AddBoolean(false); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddHostInt32(8); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown
            addBhWarpstone.AddHostInt32(3442); // Unknown
            addBhWarpstone.AddFloat(0.0f); // Unknown
            addBhWarpstone.AddHostInt32(0); // Unknown

            //Bristlewood
            var addBswWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addBswWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addBswWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addBswWarpstone.AddHostInt32(390361); // Name ID
            addBswWarpstone.AddHostInt32(280); // Model ID
            addBswWarpstone.AddBoolean(false); // Unknown4
            addBswWarpstone.AddHostInt32(408679); // Unknown5
            addBswWarpstone.AddHostInt32(13951728); // Unknown6
            addBswWarpstone.AddHostInt32(1); // Unknown7
            addBswWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addBswWarpstone.AddFloat(-540.2822f);
            addBswWarpstone.AddFloat(-64.65118f);
            addBswWarpstone.AddFloat(2221.119f);
            addBswWarpstone.AddFloat(1.0f);

            //Rotation
            addBswWarpstone.AddFloat(-0.06225472f);
            addBswWarpstone.AddFloat(0f);
            addBswWarpstone.AddFloat(0.9980603f);
            addBswWarpstone.AddFloat(0f);

            addBswWarpstone.AddHostInt32(1); // Unknown11

            addBswWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addBswWarpstone.AddHostInt32(1); // Unknown12

            addBswWarpstone.AddASCIIString(""); // TextureAlias
            addBswWarpstone.AddASCIIString(""); // TintAlias
            addBswWarpstone.AddHostInt32(0); // TintId
            addBswWarpstone.AddBoolean(true); // Unknown16
            addBswWarpstone.AddHostInt32(0); // Unknown17
            addBswWarpstone.AddHostInt32(0); // Unknown18
            addBswWarpstone.AddHostInt32(0); // Unknown19
            addBswWarpstone.AddASCIIString(""); // Custom Name
            addBswWarpstone.AddBoolean(false); // NameDisabled
            addBswWarpstone.AddHostInt32(0); // Unknown22
            addBswWarpstone.AddFloat(0.0f); // Unknown23
            addBswWarpstone.AddFloat(0.0f); // Unknown24
            addBswWarpstone.AddHostInt32(0); // Unknown25
            addBswWarpstone.AddBoolean(false); // Unknown26
            addBswWarpstone.AddFloat(0.0f); // Unknown27
            addBswWarpstone.AddBoolean(false); // Unknown28
            addBswWarpstone.AddHostInt32(100); // Unknown29
            addBswWarpstone.AddHostInt32(-1); // Unknown
            addBswWarpstone.AddHostInt32(-1); // Unknown
            addBswWarpstone.AddHostInt32(-1); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddHostInt32(-1); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown

            addBswWarpstone.AddHostInt32(0); // EffectTagsCount

            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown

            addBswWarpstone.AddHostInt32(0); // UnknownStruct2
            addBswWarpstone.AddHostInt32(0);
            addBswWarpstone.AddASCIIString("");
            addBswWarpstone.AddASCIIString("");
            addBswWarpstone.AddHostInt32(0);
            addBswWarpstone.AddASCIIString("");

            addBswWarpstone.AddFloat(0.0f);
            addBswWarpstone.AddFloat(0.0f);
            addBswWarpstone.AddFloat(0.0f);
            addBswWarpstone.AddFloat(0.0f);

            addBswWarpstone.AddHostInt32(-1);
            addBswWarpstone.AddHostInt32(0);
            addBswWarpstone.AddBoolean(true);
            addBswWarpstone.AddHostUInt64(0);
            addBswWarpstone.AddHostInt32(2);
            addBswWarpstone.AddFloat(0.0f);

            addBswWarpstone.AddHostInt32(0); // Target

            addBswWarpstone.AddHostInt32(0); // CharacterVariables

            addBswWarpstone.AddHostInt32(0);
            addBswWarpstone.AddFloat(0.0f);

            addBswWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addBswWarpstone.AddFloat(0.0f);
            addBswWarpstone.AddFloat(0.0f);
            addBswWarpstone.AddFloat(0.0f);

            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddFloat(0.0f); // Unknown
            addBswWarpstone.AddFloat(0.0f); // Unknown
            addBswWarpstone.AddFloat(0.0f); // Unknown
            addBswWarpstone.AddASCIIString(""); // Unknown
            addBswWarpstone.AddASCIIString(""); // Unknown
            addBswWarpstone.AddASCIIString(""); // Unknown
            addBswWarpstone.AddBoolean(false); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddHostInt32(8); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown
            addBswWarpstone.AddHostInt32(3442); // Unknown
            addBswWarpstone.AddFloat(0.0f); // Unknown
            addBswWarpstone.AddHostInt32(0); // Unknown

            //Briarwood
            var addBwWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addBwWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addBwWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addBwWarpstone.AddHostInt32(20832); // Name ID
            addBwWarpstone.AddHostInt32(280); // Model ID
            addBwWarpstone.AddBoolean(false); // Unknown4
            addBwWarpstone.AddHostInt32(408679); // Unknown5
            addBwWarpstone.AddHostInt32(13951728); // Unknown6
            addBwWarpstone.AddHostInt32(1); // Unknown7
            addBwWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addBwWarpstone.AddFloat(-798.9668f);
            addBwWarpstone.AddFloat(-19.4226f);
            addBwWarpstone.AddFloat(1632.941f);
            addBwWarpstone.AddFloat(1.0f);

            //Rotation
            addBwWarpstone.AddFloat(-0.06225472f);
            addBwWarpstone.AddFloat(0f);
            addBwWarpstone.AddFloat(0.9980603f);
            addBwWarpstone.AddFloat(0f);

            addBwWarpstone.AddHostInt32(1); // Unknown11

            addBwWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addBwWarpstone.AddHostInt32(1); // Unknown12

            addBwWarpstone.AddASCIIString(""); // TextureAlias
            addBwWarpstone.AddASCIIString(""); // TintAlias
            addBwWarpstone.AddHostInt32(0); // TintId
            addBwWarpstone.AddBoolean(true); // Unknown16
            addBwWarpstone.AddHostInt32(0); // Unknown17
            addBwWarpstone.AddHostInt32(0); // Unknown18
            addBwWarpstone.AddHostInt32(0); // Unknown19
            addBwWarpstone.AddASCIIString(""); // Custom Name
            addBwWarpstone.AddBoolean(false); // NameDisabled
            addBwWarpstone.AddHostInt32(0); // Unknown22
            addBwWarpstone.AddFloat(0.0f); // Unknown23
            addBwWarpstone.AddFloat(0.0f); // Unknown24
            addBwWarpstone.AddHostInt32(0); // Unknown25
            addBwWarpstone.AddBoolean(false); // Unknown26
            addBwWarpstone.AddFloat(0.0f); // Unknown27
            addBwWarpstone.AddBoolean(false); // Unknown28
            addBwWarpstone.AddHostInt32(100); // Unknown29
            addBwWarpstone.AddHostInt32(-1); // Unknown
            addBwWarpstone.AddHostInt32(-1); // Unknown
            addBwWarpstone.AddHostInt32(-1); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddHostInt32(-1); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown

            addBwWarpstone.AddHostInt32(0); // EffectTagsCount

            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown

            addBwWarpstone.AddHostInt32(0); // UnknownStruct2
            addBwWarpstone.AddHostInt32(0);
            addBwWarpstone.AddASCIIString("");
            addBwWarpstone.AddASCIIString("");
            addBwWarpstone.AddHostInt32(0);
            addBwWarpstone.AddASCIIString("");

            addBwWarpstone.AddFloat(0.0f);
            addBwWarpstone.AddFloat(0.0f);
            addBwWarpstone.AddFloat(0.0f);
            addBwWarpstone.AddFloat(0.0f);

            addBwWarpstone.AddHostInt32(-1);
            addBwWarpstone.AddHostInt32(0);
            addBwWarpstone.AddBoolean(true);
            addBwWarpstone.AddHostUInt64(0);
            addBwWarpstone.AddHostInt32(2);
            addBwWarpstone.AddFloat(0.0f);

            addBwWarpstone.AddHostInt32(0); // Target

            addBwWarpstone.AddHostInt32(0); // CharacterVariables

            addBwWarpstone.AddHostInt32(0);
            addBwWarpstone.AddFloat(0.0f);

            addBwWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addBwWarpstone.AddFloat(0.0f);
            addBwWarpstone.AddFloat(0.0f);
            addBwWarpstone.AddFloat(0.0f);

            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddFloat(0.0f); // Unknown
            addBwWarpstone.AddFloat(0.0f); // Unknown
            addBwWarpstone.AddFloat(0.0f); // Unknown
            addBwWarpstone.AddASCIIString(""); // Unknown
            addBwWarpstone.AddASCIIString(""); // Unknown
            addBwWarpstone.AddASCIIString(""); // Unknown
            addBwWarpstone.AddBoolean(false); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddHostInt32(8); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown
            addBwWarpstone.AddHostInt32(3442); // Unknown
            addBwWarpstone.AddFloat(0.0f); // Unknown
            addBwWarpstone.AddHostInt32(0); // Unknown

            //Greenwood
            var addGwWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addGwWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addGwWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addGwWarpstone.AddHostInt32(428994); // Name ID
            addGwWarpstone.AddHostInt32(280); // Model ID
            addGwWarpstone.AddBoolean(false); // Unknown4
            addGwWarpstone.AddHostInt32(408679); // Unknown5
            addGwWarpstone.AddHostInt32(13951728); // Unknown6
            addGwWarpstone.AddHostInt32(1); // Unknown7
            addGwWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addGwWarpstone.AddFloat(-1587.791f);
            addGwWarpstone.AddFloat(-44.38825f);
            addGwWarpstone.AddFloat(-547.5848f);
            addGwWarpstone.AddFloat(1.0f);

            //Rotation
            addGwWarpstone.AddFloat(-0.06225472f);
            addGwWarpstone.AddFloat(0f);
            addGwWarpstone.AddFloat(0.9980603f);
            addGwWarpstone.AddFloat(0f);

            addGwWarpstone.AddHostInt32(1); // Unknown11

            addGwWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addGwWarpstone.AddHostInt32(1); // Unknown12

            addGwWarpstone.AddASCIIString(""); // TextureAlias
            addGwWarpstone.AddASCIIString(""); // TintAlias
            addGwWarpstone.AddHostInt32(0); // TintId
            addGwWarpstone.AddBoolean(true); // Unknown16
            addGwWarpstone.AddHostInt32(0); // Unknown17
            addGwWarpstone.AddHostInt32(0); // Unknown18
            addGwWarpstone.AddHostInt32(0); // Unknown19
            addGwWarpstone.AddASCIIString(""); // Custom Name
            addGwWarpstone.AddBoolean(false); // NameDisabled
            addGwWarpstone.AddHostInt32(0); // Unknown22
            addGwWarpstone.AddFloat(0.0f); // Unknown23
            addGwWarpstone.AddFloat(0.0f); // Unknown24
            addGwWarpstone.AddHostInt32(0); // Unknown25
            addGwWarpstone.AddBoolean(false); // Unknown26
            addGwWarpstone.AddFloat(0.0f); // Unknown27
            addGwWarpstone.AddBoolean(false); // Unknown28
            addGwWarpstone.AddHostInt32(100); // Unknown29
            addGwWarpstone.AddHostInt32(-1); // Unknown
            addGwWarpstone.AddHostInt32(-1); // Unknown
            addGwWarpstone.AddHostInt32(-1); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddHostInt32(-1); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown

            addGwWarpstone.AddHostInt32(0); // EffectTagsCount

            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown

            addGwWarpstone.AddHostInt32(0); // UnknownStruct2
            addGwWarpstone.AddHostInt32(0);
            addGwWarpstone.AddASCIIString("");
            addGwWarpstone.AddASCIIString("");
            addGwWarpstone.AddHostInt32(0);
            addGwWarpstone.AddASCIIString("");

            addGwWarpstone.AddFloat(0.0f);
            addGwWarpstone.AddFloat(0.0f);
            addGwWarpstone.AddFloat(0.0f);
            addGwWarpstone.AddFloat(0.0f);

            addGwWarpstone.AddHostInt32(-1);
            addGwWarpstone.AddHostInt32(0);
            addGwWarpstone.AddBoolean(true);
            addGwWarpstone.AddHostUInt64(0);
            addGwWarpstone.AddHostInt32(2);
            addGwWarpstone.AddFloat(0.0f);

            addGwWarpstone.AddHostInt32(0); // Target

            addGwWarpstone.AddHostInt32(0); // CharacterVariables

            addGwWarpstone.AddHostInt32(0);
            addGwWarpstone.AddFloat(0.0f);

            addGwWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addGwWarpstone.AddFloat(0.0f);
            addGwWarpstone.AddFloat(0.0f);
            addGwWarpstone.AddFloat(0.0f);

            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddFloat(0.0f); // Unknown
            addGwWarpstone.AddFloat(0.0f); // Unknown
            addGwWarpstone.AddFloat(0.0f); // Unknown
            addGwWarpstone.AddASCIIString(""); // Unknown
            addGwWarpstone.AddASCIIString(""); // Unknown
            addGwWarpstone.AddASCIIString(""); // Unknown
            addGwWarpstone.AddBoolean(false); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddHostInt32(8); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown
            addGwWarpstone.AddHostInt32(3442); // Unknown
            addGwWarpstone.AddFloat(0.0f); // Unknown
            addGwWarpstone.AddHostInt32(0); // Unknown

            //Merry Vale
            var addMvWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addMvWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addMvWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addMvWarpstone.AddHostInt32(41303); // Name ID
            addMvWarpstone.AddHostInt32(280); // Model ID
            addMvWarpstone.AddBoolean(false); // Unknown4
            addMvWarpstone.AddHostInt32(408679); // Unknown5
            addMvWarpstone.AddHostInt32(13951728); // Unknown6
            addMvWarpstone.AddHostInt32(1); // Unknown7
            addMvWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addMvWarpstone.AddFloat(-1180.403f);
            addMvWarpstone.AddFloat(-33.66966f);
            addMvWarpstone.AddFloat(-438.4043f);
            addMvWarpstone.AddFloat(1.0f);

            //Rotation
            addMvWarpstone.AddFloat(-0.06225472f);
            addMvWarpstone.AddFloat(0f);
            addMvWarpstone.AddFloat(0.9980603f);
            addMvWarpstone.AddFloat(0f);

            addMvWarpstone.AddHostInt32(1); // Unknown11

            addMvWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addMvWarpstone.AddHostInt32(1); // Unknown12

            addMvWarpstone.AddASCIIString(""); // TextureAlias
            addMvWarpstone.AddASCIIString(""); // TintAlias
            addMvWarpstone.AddHostInt32(0); // TintId
            addMvWarpstone.AddBoolean(true); // Unknown16
            addMvWarpstone.AddHostInt32(0); // Unknown17
            addMvWarpstone.AddHostInt32(0); // Unknown18
            addMvWarpstone.AddHostInt32(0); // Unknown19
            addMvWarpstone.AddASCIIString(""); // Custom Name
            addMvWarpstone.AddBoolean(false); // NameDisabled
            addMvWarpstone.AddHostInt32(0); // Unknown22
            addMvWarpstone.AddFloat(0.0f); // Unknown23
            addMvWarpstone.AddFloat(0.0f); // Unknown24
            addMvWarpstone.AddHostInt32(0); // Unknown25
            addMvWarpstone.AddBoolean(false); // Unknown26
            addMvWarpstone.AddFloat(0.0f); // Unknown27
            addMvWarpstone.AddBoolean(false); // Unknown28
            addMvWarpstone.AddHostInt32(100); // Unknown29
            addMvWarpstone.AddHostInt32(-1); // Unknown
            addMvWarpstone.AddHostInt32(-1); // Unknown
            addMvWarpstone.AddHostInt32(-1); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddHostInt32(-1); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown

            addMvWarpstone.AddHostInt32(0); // EffectTagsCount

            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown

            addMvWarpstone.AddHostInt32(0); // UnknownStruct2
            addMvWarpstone.AddHostInt32(0);
            addMvWarpstone.AddASCIIString("");
            addMvWarpstone.AddASCIIString("");
            addMvWarpstone.AddHostInt32(0);
            addMvWarpstone.AddASCIIString("");

            addMvWarpstone.AddFloat(0.0f);
            addMvWarpstone.AddFloat(0.0f);
            addMvWarpstone.AddFloat(0.0f);
            addMvWarpstone.AddFloat(0.0f);

            addMvWarpstone.AddHostInt32(-1);
            addMvWarpstone.AddHostInt32(0);
            addMvWarpstone.AddBoolean(true);
            addMvWarpstone.AddHostUInt64(0);
            addMvWarpstone.AddHostInt32(2);
            addMvWarpstone.AddFloat(0.0f);

            addMvWarpstone.AddHostInt32(0); // Target

            addMvWarpstone.AddHostInt32(0); // CharacterVariables

            addMvWarpstone.AddHostInt32(0);
            addMvWarpstone.AddFloat(0.0f);

            addMvWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addMvWarpstone.AddFloat(0.0f);
            addMvWarpstone.AddFloat(0.0f);
            addMvWarpstone.AddFloat(0.0f);

            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddFloat(0.0f); // Unknown
            addMvWarpstone.AddFloat(0.0f); // Unknown
            addMvWarpstone.AddFloat(0.0f); // Unknown
            addMvWarpstone.AddASCIIString(""); // Unknown
            addMvWarpstone.AddASCIIString(""); // Unknown
            addMvWarpstone.AddASCIIString(""); // Unknown
            addMvWarpstone.AddBoolean(false); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddHostInt32(8); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown
            addMvWarpstone.AddHostInt32(3442); // Unknown
            addMvWarpstone.AddFloat(0.0f); // Unknown
            addMvWarpstone.AddHostInt32(0); // Unknown

            //Lavender Coast
            var addLcWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addLcWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addLcWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addLcWarpstone.AddHostInt32(41304); // Name ID
            addLcWarpstone.AddHostInt32(280); // Model ID
            addLcWarpstone.AddBoolean(false); // Unknown4
            addLcWarpstone.AddHostInt32(408679); // Unknown5
            addLcWarpstone.AddHostInt32(13951728); // Unknown6
            addLcWarpstone.AddHostInt32(1); // Unknown7
            addLcWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addLcWarpstone.AddFloat(-2131.265f);
            addLcWarpstone.AddFloat(-21.38897f);
            addLcWarpstone.AddFloat(-284.6161f);
            addLcWarpstone.AddFloat(1.0f);

            //Rotation
            addLcWarpstone.AddFloat(-0.06225472f);
            addLcWarpstone.AddFloat(0f);
            addLcWarpstone.AddFloat(0.9980603f);
            addLcWarpstone.AddFloat(0f);

            addLcWarpstone.AddHostInt32(1); // Unknown11

            addLcWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addLcWarpstone.AddHostInt32(1); // Unknown12

            addLcWarpstone.AddASCIIString(""); // TextureAlias
            addLcWarpstone.AddASCIIString(""); // TintAlias
            addLcWarpstone.AddHostInt32(0); // TintId
            addLcWarpstone.AddBoolean(true); // Unknown16
            addLcWarpstone.AddHostInt32(0); // Unknown17
            addLcWarpstone.AddHostInt32(0); // Unknown18
            addLcWarpstone.AddHostInt32(0); // Unknown19
            addLcWarpstone.AddASCIIString(""); // Custom Name
            addLcWarpstone.AddBoolean(false); // NameDisabled
            addLcWarpstone.AddHostInt32(0); // Unknown22
            addLcWarpstone.AddFloat(0.0f); // Unknown23
            addLcWarpstone.AddFloat(0.0f); // Unknown24
            addLcWarpstone.AddHostInt32(0); // Unknown25
            addLcWarpstone.AddBoolean(false); // Unknown26
            addLcWarpstone.AddFloat(0.0f); // Unknown27
            addLcWarpstone.AddBoolean(false); // Unknown28
            addLcWarpstone.AddHostInt32(100); // Unknown29
            addLcWarpstone.AddHostInt32(-1); // Unknown
            addLcWarpstone.AddHostInt32(-1); // Unknown
            addLcWarpstone.AddHostInt32(-1); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddHostInt32(-1); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown

            addLcWarpstone.AddHostInt32(0); // EffectTagsCount

            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown

            addLcWarpstone.AddHostInt32(0); // UnknownStruct2
            addLcWarpstone.AddHostInt32(0);
            addLcWarpstone.AddASCIIString("");
            addLcWarpstone.AddASCIIString("");
            addLcWarpstone.AddHostInt32(0);
            addLcWarpstone.AddASCIIString("");

            addLcWarpstone.AddFloat(0.0f);
            addLcWarpstone.AddFloat(0.0f);
            addLcWarpstone.AddFloat(0.0f);
            addLcWarpstone.AddFloat(0.0f);

            addLcWarpstone.AddHostInt32(-1);
            addLcWarpstone.AddHostInt32(0);
            addLcWarpstone.AddBoolean(true);
            addLcWarpstone.AddHostUInt64(0);
            addLcWarpstone.AddHostInt32(2);
            addLcWarpstone.AddFloat(0.0f);

            addLcWarpstone.AddHostInt32(0); // Target

            addLcWarpstone.AddHostInt32(0); // CharacterVariables

            addLcWarpstone.AddHostInt32(0);
            addLcWarpstone.AddFloat(0.0f);

            addLcWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addLcWarpstone.AddFloat(0.0f);
            addLcWarpstone.AddFloat(0.0f);
            addLcWarpstone.AddFloat(0.0f);

            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddFloat(0.0f); // Unknown
            addLcWarpstone.AddFloat(0.0f); // Unknown
            addLcWarpstone.AddFloat(0.0f); // Unknown
            addLcWarpstone.AddASCIIString(""); // Unknown
            addLcWarpstone.AddASCIIString(""); // Unknown
            addLcWarpstone.AddASCIIString(""); // Unknown
            addLcWarpstone.AddBoolean(false); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddHostInt32(8); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown
            addLcWarpstone.AddHostInt32(3442); // Unknown
            addLcWarpstone.AddFloat(0.0f); // Unknown
            addLcWarpstone.AddHostInt32(0); // Unknown

            //Cobblestone Village
            var addCvWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addCvWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addCvWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addCvWarpstone.AddHostInt32(20247); // Name ID
            addCvWarpstone.AddHostInt32(280); // Model ID
            addCvWarpstone.AddBoolean(false); // Unknown4
            addCvWarpstone.AddHostInt32(408679); // Unknown5
            addCvWarpstone.AddHostInt32(13951728); // Unknown6
            addCvWarpstone.AddHostInt32(1); // Unknown7
            addCvWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addCvWarpstone.AddFloat(-1912.61f);
            addCvWarpstone.AddFloat(-38.46795f);
            addCvWarpstone.AddFloat(408.1028f);
            addCvWarpstone.AddFloat(1.0f);

            //Rotation
            addCvWarpstone.AddFloat(-0.06225472f);
            addCvWarpstone.AddFloat(0f);
            addCvWarpstone.AddFloat(0.9980603f);
            addCvWarpstone.AddFloat(0f);

            addCvWarpstone.AddHostInt32(1); // Unknown11

            addCvWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addCvWarpstone.AddHostInt32(1); // Unknown12

            addCvWarpstone.AddASCIIString(""); // TextureAlias
            addCvWarpstone.AddASCIIString(""); // TintAlias
            addCvWarpstone.AddHostInt32(0); // TintId
            addCvWarpstone.AddBoolean(true); // Unknown16
            addCvWarpstone.AddHostInt32(0); // Unknown17
            addCvWarpstone.AddHostInt32(0); // Unknown18
            addCvWarpstone.AddHostInt32(0); // Unknown19
            addCvWarpstone.AddASCIIString(""); // Custom Name
            addCvWarpstone.AddBoolean(false); // NameDisabled
            addCvWarpstone.AddHostInt32(0); // Unknown22
            addCvWarpstone.AddFloat(0.0f); // Unknown23
            addCvWarpstone.AddFloat(0.0f); // Unknown24
            addCvWarpstone.AddHostInt32(0); // Unknown25
            addCvWarpstone.AddBoolean(false); // Unknown26
            addCvWarpstone.AddFloat(0.0f); // Unknown27
            addCvWarpstone.AddBoolean(false); // Unknown28
            addCvWarpstone.AddHostInt32(100); // Unknown29
            addCvWarpstone.AddHostInt32(-1); // Unknown
            addCvWarpstone.AddHostInt32(-1); // Unknown
            addCvWarpstone.AddHostInt32(-1); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddHostInt32(-1); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown

            addCvWarpstone.AddHostInt32(0); // EffectTagsCount

            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown

            addCvWarpstone.AddHostInt32(0); // UnknownStruct2
            addCvWarpstone.AddHostInt32(0);
            addCvWarpstone.AddASCIIString("");
            addCvWarpstone.AddASCIIString("");
            addCvWarpstone.AddHostInt32(0);
            addCvWarpstone.AddASCIIString("");

            addCvWarpstone.AddFloat(0.0f);
            addCvWarpstone.AddFloat(0.0f);
            addCvWarpstone.AddFloat(0.0f);
            addCvWarpstone.AddFloat(0.0f);

            addCvWarpstone.AddHostInt32(-1);
            addCvWarpstone.AddHostInt32(0);
            addCvWarpstone.AddBoolean(true);
            addCvWarpstone.AddHostUInt64(0);
            addCvWarpstone.AddHostInt32(2);
            addCvWarpstone.AddFloat(0.0f);

            addCvWarpstone.AddHostInt32(0); // Target

            addCvWarpstone.AddHostInt32(0); // CharacterVariables

            addCvWarpstone.AddHostInt32(0);
            addCvWarpstone.AddFloat(0.0f);

            addCvWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addCvWarpstone.AddFloat(0.0f);
            addCvWarpstone.AddFloat(0.0f);
            addCvWarpstone.AddFloat(0.0f);

            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddFloat(0.0f); // Unknown
            addCvWarpstone.AddFloat(0.0f); // Unknown
            addCvWarpstone.AddFloat(0.0f); // Unknown
            addCvWarpstone.AddASCIIString(""); // Unknown
            addCvWarpstone.AddASCIIString(""); // Unknown
            addCvWarpstone.AddASCIIString(""); // Unknown
            addCvWarpstone.AddBoolean(false); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddHostInt32(8); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown
            addCvWarpstone.AddHostInt32(3442); // Unknown
            addCvWarpstone.AddFloat(0.0f); // Unknown
            addCvWarpstone.AddHostInt32(0); // Unknown

            //Lakeshore
            var addLsWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addLsWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addLsWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addLsWarpstone.AddHostInt32(41298); // Name ID
            addLsWarpstone.AddHostInt32(280); // Model ID
            addLsWarpstone.AddBoolean(false); // Unknown4
            addLsWarpstone.AddHostInt32(408679); // Unknown5
            addLsWarpstone.AddHostInt32(13951728); // Unknown6
            addLsWarpstone.AddHostInt32(1); // Unknown7
            addLsWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addLsWarpstone.AddFloat(-721.4506f);
            addLsWarpstone.AddFloat(9.538003f);
            addLsWarpstone.AddFloat(949.2157f);
            addLsWarpstone.AddFloat(1.0f);

            //Rotation
            addLsWarpstone.AddFloat(-0.06225472f);
            addLsWarpstone.AddFloat(0f);
            addLsWarpstone.AddFloat(0.9980603f);
            addLsWarpstone.AddFloat(0f);

            addLsWarpstone.AddHostInt32(1); // Unknown11

            addLsWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addLsWarpstone.AddHostInt32(1); // Unknown12

            addLsWarpstone.AddASCIIString(""); // TextureAlias
            addLsWarpstone.AddASCIIString(""); // TintAlias
            addLsWarpstone.AddHostInt32(0); // TintId
            addLsWarpstone.AddBoolean(true); // Unknown16
            addLsWarpstone.AddHostInt32(0); // Unknown17
            addLsWarpstone.AddHostInt32(0); // Unknown18
            addLsWarpstone.AddHostInt32(0); // Unknown19
            addLsWarpstone.AddASCIIString(""); // Custom Name
            addLsWarpstone.AddBoolean(false); // NameDisabled
            addLsWarpstone.AddHostInt32(0); // Unknown22
            addLsWarpstone.AddFloat(0.0f); // Unknown23
            addLsWarpstone.AddFloat(0.0f); // Unknown24
            addLsWarpstone.AddHostInt32(0); // Unknown25
            addLsWarpstone.AddBoolean(false); // Unknown26
            addLsWarpstone.AddFloat(0.0f); // Unknown27
            addLsWarpstone.AddBoolean(false); // Unknown28
            addLsWarpstone.AddHostInt32(100); // Unknown29
            addLsWarpstone.AddHostInt32(-1); // Unknown
            addLsWarpstone.AddHostInt32(-1); // Unknown
            addLsWarpstone.AddHostInt32(-1); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddHostInt32(-1); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown

            addLsWarpstone.AddHostInt32(0); // EffectTagsCount

            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown

            addLsWarpstone.AddHostInt32(0); // UnknownStruct2
            addLsWarpstone.AddHostInt32(0);
            addLsWarpstone.AddASCIIString("");
            addLsWarpstone.AddASCIIString("");
            addLsWarpstone.AddHostInt32(0);
            addLsWarpstone.AddASCIIString("");

            addLsWarpstone.AddFloat(0.0f);
            addLsWarpstone.AddFloat(0.0f);
            addLsWarpstone.AddFloat(0.0f);
            addLsWarpstone.AddFloat(0.0f);

            addLsWarpstone.AddHostInt32(-1);
            addLsWarpstone.AddHostInt32(0);
            addLsWarpstone.AddBoolean(true);
            addLsWarpstone.AddHostUInt64(0);
            addLsWarpstone.AddHostInt32(2);
            addLsWarpstone.AddFloat(0.0f);

            addLsWarpstone.AddHostInt32(0); // Target

            addLsWarpstone.AddHostInt32(0); // CharacterVariables

            addLsWarpstone.AddHostInt32(0);
            addLsWarpstone.AddFloat(0.0f);

            addLsWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addLsWarpstone.AddFloat(0.0f);
            addLsWarpstone.AddFloat(0.0f);
            addLsWarpstone.AddFloat(0.0f);

            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddFloat(0.0f); // Unknown
            addLsWarpstone.AddFloat(0.0f); // Unknown
            addLsWarpstone.AddFloat(0.0f); // Unknown
            addLsWarpstone.AddASCIIString(""); // Unknown
            addLsWarpstone.AddASCIIString(""); // Unknown
            addLsWarpstone.AddASCIIString(""); // Unknown
            addLsWarpstone.AddBoolean(false); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddHostInt32(8); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown
            addLsWarpstone.AddHostInt32(3442); // Unknown
            addLsWarpstone.AddFloat(0.0f); // Unknown
            addLsWarpstone.AddHostInt32(0); // Unknown

            //Shrouded Glade
            var addSdgWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addSdgWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addSdgWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addSdgWarpstone.AddHostInt32(41297); // Name ID
            addSdgWarpstone.AddHostInt32(280); // Model ID
            addSdgWarpstone.AddBoolean(false); // Unknown4
            addSdgWarpstone.AddHostInt32(408679); // Unknown5
            addSdgWarpstone.AddHostInt32(13951728); // Unknown6
            addSdgWarpstone.AddHostInt32(1); // Unknown7
            addSdgWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addSdgWarpstone.AddFloat(4.086852f);
            addSdgWarpstone.AddFloat(42.03188f);
            addSdgWarpstone.AddFloat(1117.699f);
            addSdgWarpstone.AddFloat(1.0f);

            //Rotation
            addSdgWarpstone.AddFloat(-0.06225472f);
            addSdgWarpstone.AddFloat(0f);
            addSdgWarpstone.AddFloat(0.9980603f);
            addSdgWarpstone.AddFloat(0f);

            addSdgWarpstone.AddHostInt32(1); // Unknown11

            addSdgWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addSdgWarpstone.AddHostInt32(1); // Unknown12

            addSdgWarpstone.AddASCIIString(""); // TextureAlias
            addSdgWarpstone.AddASCIIString(""); // TintAlias
            addSdgWarpstone.AddHostInt32(0); // TintId
            addSdgWarpstone.AddBoolean(true); // Unknown16
            addSdgWarpstone.AddHostInt32(0); // Unknown17
            addSdgWarpstone.AddHostInt32(0); // Unknown18
            addSdgWarpstone.AddHostInt32(0); // Unknown19
            addSdgWarpstone.AddASCIIString(""); // Custom Name
            addSdgWarpstone.AddBoolean(false); // NameDisabled
            addSdgWarpstone.AddHostInt32(0); // Unknown22
            addSdgWarpstone.AddFloat(0.0f); // Unknown23
            addSdgWarpstone.AddFloat(0.0f); // Unknown24
            addSdgWarpstone.AddHostInt32(0); // Unknown25
            addSdgWarpstone.AddBoolean(false); // Unknown26
            addSdgWarpstone.AddFloat(0.0f); // Unknown27
            addSdgWarpstone.AddBoolean(false); // Unknown28
            addSdgWarpstone.AddHostInt32(100); // Unknown29
            addSdgWarpstone.AddHostInt32(-1); // Unknown
            addSdgWarpstone.AddHostInt32(-1); // Unknown
            addSdgWarpstone.AddHostInt32(-1); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddHostInt32(-1); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown

            addSdgWarpstone.AddHostInt32(0); // EffectTagsCount

            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown

            addSdgWarpstone.AddHostInt32(0); // UnknownStruct2
            addSdgWarpstone.AddHostInt32(0);
            addSdgWarpstone.AddASCIIString("");
            addSdgWarpstone.AddASCIIString("");
            addSdgWarpstone.AddHostInt32(0);
            addSdgWarpstone.AddASCIIString("");

            addSdgWarpstone.AddFloat(0.0f);
            addSdgWarpstone.AddFloat(0.0f);
            addSdgWarpstone.AddFloat(0.0f);
            addSdgWarpstone.AddFloat(0.0f);

            addSdgWarpstone.AddHostInt32(-1);
            addSdgWarpstone.AddHostInt32(0);
            addSdgWarpstone.AddBoolean(true);
            addSdgWarpstone.AddHostUInt64(0);
            addSdgWarpstone.AddHostInt32(2);
            addSdgWarpstone.AddFloat(0.0f);

            addSdgWarpstone.AddHostInt32(0); // Target

            addSdgWarpstone.AddHostInt32(0); // CharacterVariables

            addSdgWarpstone.AddHostInt32(0);
            addSdgWarpstone.AddFloat(0.0f);

            addSdgWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addSdgWarpstone.AddFloat(0.0f);
            addSdgWarpstone.AddFloat(0.0f);
            addSdgWarpstone.AddFloat(0.0f);

            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddFloat(0.0f); // Unknown
            addSdgWarpstone.AddFloat(0.0f); // Unknown
            addSdgWarpstone.AddFloat(0.0f); // Unknown
            addSdgWarpstone.AddASCIIString(""); // Unknown
            addSdgWarpstone.AddASCIIString(""); // Unknown
            addSdgWarpstone.AddASCIIString(""); // Unknown
            addSdgWarpstone.AddBoolean(false); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddHostInt32(8); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown
            addSdgWarpstone.AddHostInt32(3442); // Unknown
            addSdgWarpstone.AddFloat(0.0f); // Unknown
            addSdgWarpstone.AddHostInt32(0); // Unknown

            //Highroad Junction
            var addHjWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addHjWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addHjWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addHjWarpstone.AddHostInt32(104037); // Name ID
            addHjWarpstone.AddHostInt32(280); // Model ID
            addHjWarpstone.AddBoolean(false); // Unknown4
            addHjWarpstone.AddHostInt32(408679); // Unknown5
            addHjWarpstone.AddHostInt32(13951728); // Unknown6
            addHjWarpstone.AddHostInt32(1); // Unknown7
            addHjWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addHjWarpstone.AddFloat(-444.3764f);
            addHjWarpstone.AddFloat(-3.003643f);
            addHjWarpstone.AddFloat(190.4847f);
            addHjWarpstone.AddFloat(1.0f);

            //Rotation
            addHjWarpstone.AddFloat(-0.06225472f);
            addHjWarpstone.AddFloat(0f);
            addHjWarpstone.AddFloat(0.9980603f);
            addHjWarpstone.AddFloat(0f);

            addHjWarpstone.AddHostInt32(1); // Unknown11

            addHjWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addHjWarpstone.AddHostInt32(1); // Unknown12

            addHjWarpstone.AddASCIIString(""); // TextureAlias
            addHjWarpstone.AddASCIIString(""); // TintAlias
            addHjWarpstone.AddHostInt32(0); // TintId
            addHjWarpstone.AddBoolean(true); // Unknown16
            addHjWarpstone.AddHostInt32(0); // Unknown17
            addHjWarpstone.AddHostInt32(0); // Unknown18
            addHjWarpstone.AddHostInt32(0); // Unknown19
            addHjWarpstone.AddASCIIString(""); // Custom Name
            addHjWarpstone.AddBoolean(false); // NameDisabled
            addHjWarpstone.AddHostInt32(0); // Unknown22
            addHjWarpstone.AddFloat(0.0f); // Unknown23
            addHjWarpstone.AddFloat(0.0f); // Unknown24
            addHjWarpstone.AddHostInt32(0); // Unknown25
            addHjWarpstone.AddBoolean(false); // Unknown26
            addHjWarpstone.AddFloat(0.0f); // Unknown27
            addHjWarpstone.AddBoolean(false); // Unknown28
            addHjWarpstone.AddHostInt32(100); // Unknown29
            addHjWarpstone.AddHostInt32(-1); // Unknown
            addHjWarpstone.AddHostInt32(-1); // Unknown
            addHjWarpstone.AddHostInt32(-1); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddHostInt32(-1); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown

            addHjWarpstone.AddHostInt32(0); // EffectTagsCount

            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown

            addHjWarpstone.AddHostInt32(0); // UnknownStruct2
            addHjWarpstone.AddHostInt32(0);
            addHjWarpstone.AddASCIIString("");
            addHjWarpstone.AddASCIIString("");
            addHjWarpstone.AddHostInt32(0);
            addHjWarpstone.AddASCIIString("");

            addHjWarpstone.AddFloat(0.0f);
            addHjWarpstone.AddFloat(0.0f);
            addHjWarpstone.AddFloat(0.0f);
            addHjWarpstone.AddFloat(0.0f);

            addHjWarpstone.AddHostInt32(-1);
            addHjWarpstone.AddHostInt32(0);
            addHjWarpstone.AddBoolean(true);
            addHjWarpstone.AddHostUInt64(0);
            addHjWarpstone.AddHostInt32(2);
            addHjWarpstone.AddFloat(0.0f);

            addHjWarpstone.AddHostInt32(0); // Target

            addHjWarpstone.AddHostInt32(0); // CharacterVariables

            addHjWarpstone.AddHostInt32(0);
            addHjWarpstone.AddFloat(0.0f);

            addHjWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addHjWarpstone.AddFloat(0.0f);
            addHjWarpstone.AddFloat(0.0f);
            addHjWarpstone.AddFloat(0.0f);

            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddFloat(0.0f); // Unknown
            addHjWarpstone.AddFloat(0.0f); // Unknown
            addHjWarpstone.AddFloat(0.0f); // Unknown
            addHjWarpstone.AddASCIIString(""); // Unknown
            addHjWarpstone.AddASCIIString(""); // Unknown
            addHjWarpstone.AddASCIIString(""); // Unknown
            addHjWarpstone.AddBoolean(false); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddHostInt32(8); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown
            addHjWarpstone.AddHostInt32(3442); // Unknown
            addHjWarpstone.AddFloat(0.0f); // Unknown
            addHjWarpstone.AddHostInt32(0); // Unknown

            //Wugachug
            var addWcWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addWcWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addWcWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addWcWarpstone.AddHostInt32(41301); // Name ID
            addWcWarpstone.AddHostInt32(280); // Model ID
            addWcWarpstone.AddBoolean(false); // Unknown4
            addWcWarpstone.AddHostInt32(408679); // Unknown5
            addWcWarpstone.AddHostInt32(13951728); // Unknown6
            addWcWarpstone.AddHostInt32(1); // Unknown7
            addWcWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addWcWarpstone.AddFloat(-52.95787f);
            addWcWarpstone.AddFloat(37.77331f);
            addWcWarpstone.AddFloat(-442.9354f);
            addWcWarpstone.AddFloat(1.0f);

            //Rotation
            addWcWarpstone.AddFloat(-0.06225472f);
            addWcWarpstone.AddFloat(0f);
            addWcWarpstone.AddFloat(0.9980603f);
            addWcWarpstone.AddFloat(0f);

            addWcWarpstone.AddHostInt32(1); // Unknown11

            addWcWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addWcWarpstone.AddHostInt32(1); // Unknown12

            addWcWarpstone.AddASCIIString(""); // TextureAlias
            addWcWarpstone.AddASCIIString(""); // TintAlias
            addWcWarpstone.AddHostInt32(0); // TintId
            addWcWarpstone.AddBoolean(true); // Unknown16
            addWcWarpstone.AddHostInt32(0); // Unknown17
            addWcWarpstone.AddHostInt32(0); // Unknown18
            addWcWarpstone.AddHostInt32(0); // Unknown19
            addWcWarpstone.AddASCIIString(""); // Custom Name
            addWcWarpstone.AddBoolean(false); // NameDisabled
            addWcWarpstone.AddHostInt32(0); // Unknown22
            addWcWarpstone.AddFloat(0.0f); // Unknown23
            addWcWarpstone.AddFloat(0.0f); // Unknown24
            addWcWarpstone.AddHostInt32(0); // Unknown25
            addWcWarpstone.AddBoolean(false); // Unknown26
            addWcWarpstone.AddFloat(0.0f); // Unknown27
            addWcWarpstone.AddBoolean(false); // Unknown28
            addWcWarpstone.AddHostInt32(100); // Unknown29
            addWcWarpstone.AddHostInt32(-1); // Unknown
            addWcWarpstone.AddHostInt32(-1); // Unknown
            addWcWarpstone.AddHostInt32(-1); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddHostInt32(-1); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown

            addWcWarpstone.AddHostInt32(0); // EffectTagsCount

            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown

            addWcWarpstone.AddHostInt32(0); // UnknownStruct2
            addWcWarpstone.AddHostInt32(0);
            addWcWarpstone.AddASCIIString("");
            addWcWarpstone.AddASCIIString("");
            addWcWarpstone.AddHostInt32(0);
            addWcWarpstone.AddASCIIString("");

            addWcWarpstone.AddFloat(0.0f);
            addWcWarpstone.AddFloat(0.0f);
            addWcWarpstone.AddFloat(0.0f);
            addWcWarpstone.AddFloat(0.0f);

            addWcWarpstone.AddHostInt32(-1);
            addWcWarpstone.AddHostInt32(0);
            addWcWarpstone.AddBoolean(true);
            addWcWarpstone.AddHostUInt64(0);
            addWcWarpstone.AddHostInt32(2);
            addWcWarpstone.AddFloat(0.0f);

            addWcWarpstone.AddHostInt32(0); // Target

            addWcWarpstone.AddHostInt32(0); // CharacterVariables

            addWcWarpstone.AddHostInt32(0);
            addWcWarpstone.AddFloat(0.0f);

            addWcWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addWcWarpstone.AddFloat(0.0f);
            addWcWarpstone.AddFloat(0.0f);
            addWcWarpstone.AddFloat(0.0f);

            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddFloat(0.0f); // Unknown
            addWcWarpstone.AddFloat(0.0f); // Unknown
            addWcWarpstone.AddFloat(0.0f); // Unknown
            addWcWarpstone.AddASCIIString(""); // Unknown
            addWcWarpstone.AddASCIIString(""); // Unknown
            addWcWarpstone.AddASCIIString(""); // Unknown
            addWcWarpstone.AddBoolean(false); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddHostInt32(8); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown
            addWcWarpstone.AddHostInt32(3442); // Unknown
            addWcWarpstone.AddFloat(0.0f); // Unknown
            addWcWarpstone.AddHostInt32(0); // Unknown

            //Seaside
            var addSsWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addSsWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addSsWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addSsWarpstone.AddHostInt32(41302); // Name ID
            addSsWarpstone.AddHostInt32(280); // Model ID
            addSsWarpstone.AddBoolean(false); // Unknown4
            addSsWarpstone.AddHostInt32(408679); // Unknown5
            addSsWarpstone.AddHostInt32(13951728); // Unknown6
            addSsWarpstone.AddHostInt32(1); // Unknown7
            addSsWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addSsWarpstone.AddFloat(-634.2769f);
            addSsWarpstone.AddFloat(10.53426f);
            addSsWarpstone.AddFloat(-1036.129f);
            addSsWarpstone.AddFloat(1.0f);

            //Rotation
            addSsWarpstone.AddFloat(-0.06225472f);
            addSsWarpstone.AddFloat(0f);
            addSsWarpstone.AddFloat(0.9980603f);
            addSsWarpstone.AddFloat(0f);

            addSsWarpstone.AddHostInt32(1); // Unknown11

            addSsWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addSsWarpstone.AddHostInt32(1); // Unknown12

            addSsWarpstone.AddASCIIString(""); // TextureAlias
            addSsWarpstone.AddASCIIString(""); // TintAlias
            addSsWarpstone.AddHostInt32(0); // TintId
            addSsWarpstone.AddBoolean(true); // Unknown16
            addSsWarpstone.AddHostInt32(0); // Unknown17
            addSsWarpstone.AddHostInt32(0); // Unknown18
            addSsWarpstone.AddHostInt32(0); // Unknown19
            addSsWarpstone.AddASCIIString(""); // Custom Name
            addSsWarpstone.AddBoolean(false); // NameDisabled
            addSsWarpstone.AddHostInt32(0); // Unknown22
            addSsWarpstone.AddFloat(0.0f); // Unknown23
            addSsWarpstone.AddFloat(0.0f); // Unknown24
            addSsWarpstone.AddHostInt32(0); // Unknown25
            addSsWarpstone.AddBoolean(false); // Unknown26
            addSsWarpstone.AddFloat(0.0f); // Unknown27
            addSsWarpstone.AddBoolean(false); // Unknown28
            addSsWarpstone.AddHostInt32(100); // Unknown29
            addSsWarpstone.AddHostInt32(-1); // Unknown
            addSsWarpstone.AddHostInt32(-1); // Unknown
            addSsWarpstone.AddHostInt32(-1); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddHostInt32(-1); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown

            addSsWarpstone.AddHostInt32(0); // EffectTagsCount

            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown

            addSsWarpstone.AddHostInt32(0); // UnknownStruct2
            addSsWarpstone.AddHostInt32(0);
            addSsWarpstone.AddASCIIString("");
            addSsWarpstone.AddASCIIString("");
            addSsWarpstone.AddHostInt32(0);
            addSsWarpstone.AddASCIIString("");

            addSsWarpstone.AddFloat(0.0f);
            addSsWarpstone.AddFloat(0.0f);
            addSsWarpstone.AddFloat(0.0f);
            addSsWarpstone.AddFloat(0.0f);

            addSsWarpstone.AddHostInt32(-1);
            addSsWarpstone.AddHostInt32(0);
            addSsWarpstone.AddBoolean(true);
            addSsWarpstone.AddHostUInt64(0);
            addSsWarpstone.AddHostInt32(2);
            addSsWarpstone.AddFloat(0.0f);

            addSsWarpstone.AddHostInt32(0); // Target

            addSsWarpstone.AddHostInt32(0); // CharacterVariables

            addSsWarpstone.AddHostInt32(0);
            addSsWarpstone.AddFloat(0.0f);

            addSsWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addSsWarpstone.AddFloat(0.0f);
            addSsWarpstone.AddFloat(0.0f);
            addSsWarpstone.AddFloat(0.0f);

            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddFloat(0.0f); // Unknown
            addSsWarpstone.AddFloat(0.0f); // Unknown
            addSsWarpstone.AddFloat(0.0f); // Unknown
            addSsWarpstone.AddASCIIString(""); // Unknown
            addSsWarpstone.AddASCIIString(""); // Unknown
            addSsWarpstone.AddASCIIString(""); // Unknown
            addSsWarpstone.AddBoolean(false); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddHostInt32(8); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown
            addSsWarpstone.AddHostInt32(3442); // Unknown
            addSsWarpstone.AddFloat(0.0f); // Unknown
            addSsWarpstone.AddHostInt32(0); // Unknown

            //Sanctuary
            var addSgWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addSgWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addSgWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addSgWarpstone.AddHostInt32(20831); // Name ID
            addSgWarpstone.AddHostInt32(280); // Model ID
            addSgWarpstone.AddBoolean(false); // Unknown4
            addSgWarpstone.AddHostInt32(408679); // Unknown5
            addSgWarpstone.AddHostInt32(13951728); // Unknown6
            addSgWarpstone.AddHostInt32(1); // Unknown7
            addSgWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addSgWarpstone.AddFloat(-1418.3218f);
            addSgWarpstone.AddFloat(-27.002932f);
            addSgWarpstone.AddFloat(347.82056f);
            addSgWarpstone.AddFloat(1.0f);

            //Rotation
            addSgWarpstone.AddFloat(-0.06225472f);
            addSgWarpstone.AddFloat(0f);
            addSgWarpstone.AddFloat(0.9980603f);
            addSgWarpstone.AddFloat(0f);

            addSgWarpstone.AddHostInt32(1); // Unknown11

            addSgWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addSgWarpstone.AddHostInt32(1); // Unknown12

            addSgWarpstone.AddASCIIString(""); // TextureAlias
            addSgWarpstone.AddASCIIString(""); // TintAlias
            addSgWarpstone.AddHostInt32(0); // TintId
            addSgWarpstone.AddBoolean(true); // Unknown16
            addSgWarpstone.AddHostInt32(0); // Unknown17
            addSgWarpstone.AddHostInt32(0); // Unknown18
            addSgWarpstone.AddHostInt32(0); // Unknown19
            addSgWarpstone.AddASCIIString(""); // Custom Name
            addSgWarpstone.AddBoolean(false); // NameDisabled
            addSgWarpstone.AddHostInt32(0); // Unknown22
            addSgWarpstone.AddFloat(0.0f); // Unknown23
            addSgWarpstone.AddFloat(0.0f); // Unknown24
            addSgWarpstone.AddHostInt32(0); // Unknown25
            addSgWarpstone.AddBoolean(false); // Unknown26
            addSgWarpstone.AddFloat(0.0f); // Unknown27
            addSgWarpstone.AddBoolean(false); // Unknown28
            addSgWarpstone.AddHostInt32(100); // Unknown29
            addSgWarpstone.AddHostInt32(-1); // Unknown
            addSgWarpstone.AddHostInt32(-1); // Unknown
            addSgWarpstone.AddHostInt32(-1); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddHostInt32(-1); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown

            addSgWarpstone.AddHostInt32(0); // EffectTagsCount

            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown

            addSgWarpstone.AddHostInt32(0); // UnknownStruct2
            addSgWarpstone.AddHostInt32(0);
            addSgWarpstone.AddASCIIString("");
            addSgWarpstone.AddASCIIString("");
            addSgWarpstone.AddHostInt32(0);
            addSgWarpstone.AddASCIIString("");

            addSgWarpstone.AddFloat(0.0f);
            addSgWarpstone.AddFloat(0.0f);
            addSgWarpstone.AddFloat(0.0f);
            addSgWarpstone.AddFloat(0.0f);

            addSgWarpstone.AddHostInt32(-1);
            addSgWarpstone.AddHostInt32(0);
            addSgWarpstone.AddBoolean(true);
            addSgWarpstone.AddHostUInt64(0);
            addSgWarpstone.AddHostInt32(2);
            addSgWarpstone.AddFloat(0.0f);

            addSgWarpstone.AddHostInt32(0); // Target

            addSgWarpstone.AddHostInt32(0); // CharacterVariables

            addSgWarpstone.AddHostInt32(0);
            addSgWarpstone.AddFloat(0.0f);

            addSgWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addSgWarpstone.AddFloat(0.0f);
            addSgWarpstone.AddFloat(0.0f);
            addSgWarpstone.AddFloat(0.0f);

            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddFloat(0.0f); // Unknown
            addSgWarpstone.AddFloat(0.0f); // Unknown
            addSgWarpstone.AddFloat(0.0f); // Unknown
            addSgWarpstone.AddASCIIString(""); // Unknown
            addSgWarpstone.AddASCIIString(""); // Unknown
            addSgWarpstone.AddASCIIString(""); // Unknown
            addSgWarpstone.AddBoolean(false); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddHostInt32(8); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown
            addSgWarpstone.AddHostInt32(3442); // Unknown
            addSgWarpstone.AddFloat(0.0f); // Unknown
            addSgWarpstone.AddHostInt32(0); // Unknown

            //Snowhill
            var addShWarpstone = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addShWarpstone.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addShWarpstone.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addShWarpstone.AddHostInt32(20830); // Name ID
            addShWarpstone.AddHostInt32(280); // Model ID
            addShWarpstone.AddBoolean(false); // Unknown4
            addShWarpstone.AddHostInt32(408679); // Unknown5
            addShWarpstone.AddHostInt32(13951728); // Unknown6
            addShWarpstone.AddHostInt32(1); // Unknown7
            addShWarpstone.AddFloat(1.0f); // Unknown8

            // Position
            addShWarpstone.AddFloat(50.92852f);
            addShWarpstone.AddFloat(32.425617f);
            addShWarpstone.AddFloat(370.30267f);
            addShWarpstone.AddFloat(1.0f);

            //Rotation
            addShWarpstone.AddFloat(0.938666f);
            addShWarpstone.AddFloat(0f);
            addShWarpstone.AddFloat(0.34482774f);
            addShWarpstone.AddFloat(0f);

            addShWarpstone.AddHostInt32(1); // Unknown11

            addShWarpstone.AddHostInt32(0); // CharacterAttachmentDataCount
            addShWarpstone.AddHostInt32(1); // Unknown12

            addShWarpstone.AddASCIIString(""); // TextureAlias
            addShWarpstone.AddASCIIString(""); // TintAlias
            addShWarpstone.AddHostInt32(0); // TintId
            addShWarpstone.AddBoolean(true); // Unknown16
            addShWarpstone.AddHostInt32(0); // Unknown17
            addShWarpstone.AddHostInt32(0); // Unknown18
            addShWarpstone.AddHostInt32(0); // Unknown19
            addShWarpstone.AddASCIIString(""); // Custom Name
            addShWarpstone.AddBoolean(false); // NameDisabled
            addShWarpstone.AddHostInt32(0); // Unknown22
            addShWarpstone.AddFloat(0.0f); // Unknown23
            addShWarpstone.AddFloat(0.0f); // Unknown24
            addShWarpstone.AddHostInt32(0); // Unknown25
            addShWarpstone.AddBoolean(false); // Unknown26
            addShWarpstone.AddFloat(0.0f); // Unknown27
            addShWarpstone.AddBoolean(false); // Unknown28
            addShWarpstone.AddHostInt32(100); // Unknown29
            addShWarpstone.AddHostInt32(-1); // Unknown
            addShWarpstone.AddHostInt32(-1); // Unknown
            addShWarpstone.AddHostInt32(-1); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddHostInt32(-1); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown

            addShWarpstone.AddHostInt32(0); // EffectTagsCount

            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown

            addShWarpstone.AddHostInt32(0); // UnknownStruct2
            addShWarpstone.AddHostInt32(0);
            addShWarpstone.AddASCIIString("");
            addShWarpstone.AddASCIIString("");
            addShWarpstone.AddHostInt32(0);
            addShWarpstone.AddASCIIString("");

            addShWarpstone.AddFloat(0.0f);
            addShWarpstone.AddFloat(0.0f);
            addShWarpstone.AddFloat(0.0f);
            addShWarpstone.AddFloat(0.0f);

            addShWarpstone.AddHostInt32(-1);
            addShWarpstone.AddHostInt32(0);
            addShWarpstone.AddBoolean(true);
            addShWarpstone.AddHostUInt64(0);
            addShWarpstone.AddHostInt32(2);
            addShWarpstone.AddFloat(0.0f);

            addShWarpstone.AddHostInt32(0); // Target

            addShWarpstone.AddHostInt32(0); // CharacterVariables

            addShWarpstone.AddHostInt32(0);
            addShWarpstone.AddFloat(0.0f);

            addShWarpstone.AddFloat(0.0f); // Unknown54, float[4]
            addShWarpstone.AddFloat(0.0f);
            addShWarpstone.AddFloat(0.0f);
            addShWarpstone.AddFloat(0.0f);

            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddFloat(0.0f); // Unknown
            addShWarpstone.AddFloat(0.0f); // Unknown
            addShWarpstone.AddFloat(0.0f); // Unknown
            addShWarpstone.AddASCIIString(""); // Unknown
            addShWarpstone.AddASCIIString(""); // Unknown
            addShWarpstone.AddASCIIString(""); // Unknown
            addShWarpstone.AddBoolean(false); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddHostInt32(8); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown
            addShWarpstone.AddHostInt32(3442); // Unknown
            addShWarpstone.AddFloat(0.0f); // Unknown
            addShWarpstone.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, addBhWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addBswWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addBwWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addGwWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addMvWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addLcWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addCvWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addLsWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addSdgWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addHjWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addWcWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addSsWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addSgWarpstone.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addShWarpstone.GetRaw());
        }
        public static void SendWarpWatchers(SOEClient soeClient)
        {
            var addKWarpWatcher = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addKWarpWatcher.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addKWarpWatcher.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addKWarpWatcher.AddHostInt32(384749); // Name ID
            addKWarpWatcher.AddHostInt32(468); // Model ID
            addKWarpWatcher.AddBoolean(false); // Unknown4
            addKWarpWatcher.AddHostInt32(408679); // Unknown5
            addKWarpWatcher.AddHostInt32(13951728); // Unknown6
            addKWarpWatcher.AddHostInt32(1); // Unknown7
            addKWarpWatcher.AddFloat(1.0f); // Unknown8

            // Position
            addKWarpWatcher.AddFloat(-1424.6484f);
            addKWarpWatcher.AddFloat(-28.323662f);
            addKWarpWatcher.AddFloat(346.41522f);
            addKWarpWatcher.AddFloat(1.0f);

            //Rotation
            addKWarpWatcher.AddFloat(0.31386694f);
            addKWarpWatcher.AddFloat(0f);
            addKWarpWatcher.AddFloat(-0.949467f);
            addKWarpWatcher.AddFloat(0f);

            addKWarpWatcher.AddHostInt32(1); // Unknown11

            addKWarpWatcher.AddHostInt32(0); // CharacterAttachmentDataCount
            addKWarpWatcher.AddHostInt32(1); // Unknown12

            addKWarpWatcher.AddASCIIString("base_02"); // TextureAlias
            addKWarpWatcher.AddASCIIString("mahogany"); // TintAlias
            addKWarpWatcher.AddHostInt32(0); // TintId
            addKWarpWatcher.AddBoolean(true); // Unknown16
            addKWarpWatcher.AddHostInt32(0); // Unknown17
            addKWarpWatcher.AddHostInt32(0); // Unknown18
            addKWarpWatcher.AddHostInt32(0); // Unknown19
            addKWarpWatcher.AddASCIIString(""); // Custom Name
            addKWarpWatcher.AddBoolean(false); // NameDisabled
            addKWarpWatcher.AddHostInt32(0); // Unknown22
            addKWarpWatcher.AddFloat(0.0f); // Unknown23
            addKWarpWatcher.AddFloat(0.0f); // Unknown24
            addKWarpWatcher.AddHostInt32(0); // Unknown25
            addKWarpWatcher.AddBoolean(false); // Unknown26
            addKWarpWatcher.AddFloat(0.0f); // Unknown27
            addKWarpWatcher.AddBoolean(false); // Unknown28
            addKWarpWatcher.AddHostInt32(100); // Unknown29
            addKWarpWatcher.AddHostInt32(-1); // Unknown
            addKWarpWatcher.AddHostInt32(-1); // Unknown
            addKWarpWatcher.AddHostInt32(-1); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddHostInt32(-1); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown

            addKWarpWatcher.AddHostInt32(0); // EffectTagsCount

            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown

            addKWarpWatcher.AddHostInt32(0); // UnknownStruct2
            addKWarpWatcher.AddHostInt32(0);
            addKWarpWatcher.AddASCIIString("");
            addKWarpWatcher.AddASCIIString("");
            addKWarpWatcher.AddHostInt32(0);
            addKWarpWatcher.AddASCIIString("");

            addKWarpWatcher.AddFloat(0.0f);
            addKWarpWatcher.AddFloat(0.0f);
            addKWarpWatcher.AddFloat(0.0f);
            addKWarpWatcher.AddFloat(0.0f);

            addKWarpWatcher.AddHostInt32(-1);
            addKWarpWatcher.AddHostInt32(0);
            addKWarpWatcher.AddBoolean(true);
            addKWarpWatcher.AddHostUInt64(0);
            addKWarpWatcher.AddHostInt32(2);
            addKWarpWatcher.AddFloat(0.0f);

            addKWarpWatcher.AddHostInt32(0); // Target

            addKWarpWatcher.AddHostInt32(0); // CharacterVariables

            addKWarpWatcher.AddHostInt32(0);
            addKWarpWatcher.AddFloat(0.0f);

            addKWarpWatcher.AddFloat(0.0f); // Unknown54, float[4]
            addKWarpWatcher.AddFloat(0.0f);
            addKWarpWatcher.AddFloat(0.0f);
            addKWarpWatcher.AddFloat(0.0f);

            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddFloat(0.0f); // Unknown
            addKWarpWatcher.AddFloat(0.0f); // Unknown
            addKWarpWatcher.AddFloat(0.0f); // Unknown
            addKWarpWatcher.AddASCIIString(""); // Unknown
            addKWarpWatcher.AddASCIIString(""); // Unknown
            addKWarpWatcher.AddASCIIString(""); // Unknown
            addKWarpWatcher.AddBoolean(false); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddHostInt32(8); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown
            addKWarpWatcher.AddHostInt32(3442); // Unknown
            addKWarpWatcher.AddFloat(0.0f); // Unknown
            addKWarpWatcher.AddHostInt32(0); // Unknown

            var addVWarpWatcher = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addVWarpWatcher.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addVWarpWatcher.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addVWarpWatcher.AddHostInt32(130731); // Name ID
            addVWarpWatcher.AddHostInt32(468); // Model ID
            addVWarpWatcher.AddBoolean(false); // Unknown4
            addVWarpWatcher.AddHostInt32(408679); // Unknown5
            addVWarpWatcher.AddHostInt32(13951728); // Unknown6
            addVWarpWatcher.AddHostInt32(1); // Unknown7
            addVWarpWatcher.AddFloat(1.0f); // Unknown8

            // Position
            addVWarpWatcher.AddFloat(56.24998f);
            addVWarpWatcher.AddFloat(31.53844f);
            addVWarpWatcher.AddFloat(374.89914f);
            addVWarpWatcher.AddFloat(1.0f);

            //Rotation
            addVWarpWatcher.AddFloat(0.46704218f);
            addVWarpWatcher.AddFloat(0f);
            addVWarpWatcher.AddFloat(-0.884235f);
            addVWarpWatcher.AddFloat(0f);

            addVWarpWatcher.AddHostInt32(1); // Unknown11

            addVWarpWatcher.AddHostInt32(0); // CharacterAttachmentDataCount
            addVWarpWatcher.AddHostInt32(1); // Unknown12

            addVWarpWatcher.AddASCIIString("base_03"); // TextureAlias
            addVWarpWatcher.AddASCIIString("olive"); // TintAlias
            addVWarpWatcher.AddHostInt32(0); // TintId
            addVWarpWatcher.AddBoolean(true); // Unknown16
            addVWarpWatcher.AddHostInt32(0); // Unknown17
            addVWarpWatcher.AddHostInt32(0); // Unknown18
            addVWarpWatcher.AddHostInt32(0); // Unknown19
            addVWarpWatcher.AddASCIIString(""); // Custom Name
            addVWarpWatcher.AddBoolean(false); // NameDisabled
            addVWarpWatcher.AddHostInt32(0); // Unknown22
            addVWarpWatcher.AddFloat(0.0f); // Unknown23
            addVWarpWatcher.AddFloat(0.0f); // Unknown24
            addVWarpWatcher.AddHostInt32(0); // Unknown25
            addVWarpWatcher.AddBoolean(false); // Unknown26
            addVWarpWatcher.AddFloat(0.0f); // Unknown27
            addVWarpWatcher.AddBoolean(false); // Unknown28
            addVWarpWatcher.AddHostInt32(100); // Unknown29
            addVWarpWatcher.AddHostInt32(-1); // Unknown
            addVWarpWatcher.AddHostInt32(-1); // Unknown
            addVWarpWatcher.AddHostInt32(-1); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddHostInt32(-1); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown

            addVWarpWatcher.AddHostInt32(0); // EffectTagsCount

            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown

            addVWarpWatcher.AddHostInt32(0); // UnknownStruct2
            addVWarpWatcher.AddHostInt32(0);
            addVWarpWatcher.AddASCIIString("");
            addVWarpWatcher.AddASCIIString("");
            addVWarpWatcher.AddHostInt32(0);
            addVWarpWatcher.AddASCIIString("");

            addVWarpWatcher.AddFloat(0.0f);
            addVWarpWatcher.AddFloat(0.0f);
            addVWarpWatcher.AddFloat(0.0f);
            addVWarpWatcher.AddFloat(0.0f);

            addVWarpWatcher.AddHostInt32(-1);
            addVWarpWatcher.AddHostInt32(0);
            addVWarpWatcher.AddBoolean(true);
            addVWarpWatcher.AddHostUInt64(0);
            addVWarpWatcher.AddHostInt32(2);
            addVWarpWatcher.AddFloat(0.0f);

            addVWarpWatcher.AddHostInt32(0); // Target

            addVWarpWatcher.AddHostInt32(0); // CharacterVariables

            addVWarpWatcher.AddHostInt32(0);
            addVWarpWatcher.AddFloat(0.0f);

            addVWarpWatcher.AddFloat(0.0f); // Unknown54, float[4]
            addVWarpWatcher.AddFloat(0.0f);
            addVWarpWatcher.AddFloat(0.0f);
            addVWarpWatcher.AddFloat(0.0f);

            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddFloat(0.0f); // Unknown
            addVWarpWatcher.AddFloat(0.0f); // Unknown
            addVWarpWatcher.AddFloat(0.0f); // Unknown
            addVWarpWatcher.AddASCIIString(""); // Unknown
            addVWarpWatcher.AddASCIIString(""); // Unknown
            addVWarpWatcher.AddASCIIString(""); // Unknown
            addVWarpWatcher.AddBoolean(false); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddHostInt32(8); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown
            addVWarpWatcher.AddHostInt32(3442); // Unknown
            addVWarpWatcher.AddFloat(0.0f); // Unknown
            addVWarpWatcher.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, addKWarpWatcher.GetRaw());
            LoginManager.SendTunneledClientPacket(soeClient, addVWarpWatcher.GetRaw());

            var addBoombox1 = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addBoombox1.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addBoombox1.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addBoombox1.AddHostInt32(18044); // Name ID
            addBoombox1.AddHostInt32(185); // Model ID
            addBoombox1.AddBoolean(false); // Unknown4
            addBoombox1.AddHostInt32(408679); // Unknown5
            addBoombox1.AddHostInt32(13951728); // Unknown6
            addBoombox1.AddHostInt32(1); // Unknown7
            addBoombox1.AddFloat(1.0f); // Unknown8

            // Position
            addBoombox1.AddFloat(88.90495f);
            addBoombox1.AddFloat(23.542553f);
            addBoombox1.AddFloat(410.57498f);
            addBoombox1.AddFloat(1.0f);

            //Rotation
            addBoombox1.AddFloat(0.71443385f);
            addBoombox1.AddFloat(0f);
            addBoombox1.AddFloat(-0.699703f);
            addBoombox1.AddFloat(0f);

            addBoombox1.AddHostInt32(2100); // Unknown11

            addBoombox1.AddHostInt32(0); // CharacterAttachmentDataCount
            addBoombox1.AddHostInt32(1); // Unknown12

            addBoombox1.AddASCIIString(""); // TextureAlias
            addBoombox1.AddASCIIString(""); // TintAlias
            addBoombox1.AddHostInt32(0); // TintId
            addBoombox1.AddBoolean(true); // Unknown16
            addBoombox1.AddFloat(-0.1f); // Unknown17
            addBoombox1.AddHostInt32(0); // Unknown18
            addBoombox1.AddHostInt32(0); // Unknown19
            addBoombox1.AddASCIIString(""); // Custom Name
            addBoombox1.AddBoolean(true); // NameDisabled
            addBoombox1.AddHostInt32(0); // Unknown22
            addBoombox1.AddFloat(0.0f); // Unknown23
            addBoombox1.AddFloat(0.0f); // Unknown24
            addBoombox1.AddHostInt32(0); // Unknown25
            addBoombox1.AddBoolean(false); // Unknown26
            addBoombox1.AddFloat(0.0f); // Unknown27
            addBoombox1.AddBoolean(false); // Unknown28
            addBoombox1.AddHostInt32(100); // Unknown29
            addBoombox1.AddHostInt32(-1); // Unknown
            addBoombox1.AddHostInt32(-1); // Unknown
            addBoombox1.AddHostInt32(-1); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddHostInt32(-1); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown

            addBoombox1.AddHostInt32(0); // EffectTagsCount

            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddBoolean(false); // Unknown

            addBoombox1.AddHostInt32(0); // UnknownStruct2
            addBoombox1.AddASCIIString("");
            addBoombox1.AddASCIIString("");
            addBoombox1.AddHostInt32(0);
            addBoombox1.AddASCIIString("");

            addBoombox1.AddFloat(0.0f);
            addBoombox1.AddFloat(0.0f);
            addBoombox1.AddFloat(0.0f);
            addBoombox1.AddFloat(0.0f);

            addBoombox1.AddHostInt32(0);
            addBoombox1.AddHostInt32(-1);
            addBoombox1.AddHostInt32(0);
            addBoombox1.AddBoolean(true);
            addBoombox1.AddHostUInt64(0);
            addBoombox1.AddHostInt32(2);
            addBoombox1.AddFloat(0.0f);

            addBoombox1.AddHostInt32(0); // Target

            addBoombox1.AddHostInt32(0); // CharacterVariables

            addBoombox1.AddHostInt32(0);
            addBoombox1.AddFloat(0.0f);

            addBoombox1.AddFloat(0.0f); // Unknown54, float[4]
            addBoombox1.AddFloat(0.0f);
            addBoombox1.AddFloat(0.0f);
            addBoombox1.AddFloat(0.0f);

            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddFloat(0.0f); // Unknown
            addBoombox1.AddFloat(0.0f); // Unknown
            addBoombox1.AddFloat(0.0f); // Unknown
            addBoombox1.AddASCIIString(""); // Unknown
            addBoombox1.AddASCIIString(""); // Unknown
            addBoombox1.AddASCIIString(""); // Unknown
            addBoombox1.AddBoolean(false); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddHostInt32(8); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown
            addBoombox1.AddHostInt32(3442); // Unknown
            addBoombox1.AddFloat(0.0f); // Unknown
            addBoombox1.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, addBoombox1.GetRaw());

            var addShBoombox = new SOEWriter((ushort)BasePackets.BasePlayerUpdatePacket, true);
            addShBoombox.AddHostUInt16((ushort)BasePlayerUpdatePackets.PlayerUpdatePacketAddNpc);
            addShBoombox.AddHostUInt64(LoginManager.RandomGUID()); // Guid
            addShBoombox.AddHostInt32(18044); // Name ID
            addShBoombox.AddHostInt32(185); // Model ID
            addShBoombox.AddBoolean(false); // Unknown4
            addShBoombox.AddHostInt32(408679); // Unknown5
            addShBoombox.AddHostInt32(13951728); // Unknown6
            addShBoombox.AddHostInt32(1); // Unknown7
            addShBoombox.AddFloat(1.0f); // Unknown8

            // Position
            addShBoombox.AddFloat(-63.10355f);
            addShBoombox.AddFloat(10.993467f);
            addShBoombox.AddFloat(327.5352f);
            addShBoombox.AddFloat(1.0f);

            //Rotation
            addShBoombox.AddFloat(-0.05765071f);
            addShBoombox.AddFloat(0f);
            addShBoombox.AddFloat(-0.9983369f);
            addShBoombox.AddFloat(0f);

            addShBoombox.AddHostInt32(2100); // Unknown11

            addShBoombox.AddHostInt32(0); // CharacterAttachmentDataCount
            addShBoombox.AddHostInt32(1); // Unknown12

            addShBoombox.AddASCIIString(""); // TextureAlias
            addShBoombox.AddASCIIString(""); // TintAlias
            addShBoombox.AddHostInt32(0); // TintId
            addShBoombox.AddBoolean(true); // Unknown16
            addShBoombox.AddFloat(-0.1f); // Unknown17
            addShBoombox.AddHostInt32(0); // Unknown18
            addShBoombox.AddHostInt32(0); // Unknown19
            addShBoombox.AddASCIIString(""); // Custom Name
            addShBoombox.AddBoolean(true); // NameDisabled
            addShBoombox.AddHostInt32(0); // Unknown22
            addShBoombox.AddFloat(0.0f); // Unknown23
            addShBoombox.AddFloat(0.0f); // Unknown24
            addShBoombox.AddHostInt32(0); // Unknown25
            addShBoombox.AddBoolean(false); // Unknown26
            addShBoombox.AddFloat(0.0f); // Unknown27
            addShBoombox.AddBoolean(false); // Unknown28
            addShBoombox.AddHostInt32(100); // Unknown29
            addShBoombox.AddHostInt32(-1); // Unknown
            addShBoombox.AddHostInt32(-1); // Unknown
            addShBoombox.AddHostInt32(-1); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddHostInt32(-1); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown

            addShBoombox.AddHostInt32(0); // EffectTagsCount

            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddBoolean(false); // Unknown

            addShBoombox.AddHostInt32(0); // UnknownStruct2
            addShBoombox.AddASCIIString("");
            addShBoombox.AddASCIIString("");
            addShBoombox.AddHostInt32(0);
            addShBoombox.AddASCIIString("");

            addShBoombox.AddFloat(0.0f);
            addShBoombox.AddFloat(0.0f);
            addShBoombox.AddFloat(0.0f);
            addShBoombox.AddFloat(0.0f);

            addShBoombox.AddHostInt32(0);
            addShBoombox.AddHostInt32(-1);
            addShBoombox.AddHostInt32(0);
            addShBoombox.AddBoolean(true);
            addShBoombox.AddHostUInt64(0);
            addShBoombox.AddHostInt32(2);
            addShBoombox.AddFloat(0.0f);

            addShBoombox.AddHostInt32(0); // Target

            addShBoombox.AddHostInt32(0); // CharacterVariables

            addShBoombox.AddHostInt32(0);
            addShBoombox.AddFloat(0.0f);

            addShBoombox.AddFloat(0.0f); // Unknown54, float[4]
            addShBoombox.AddFloat(0.0f);
            addShBoombox.AddFloat(0.0f);
            addShBoombox.AddFloat(0.0f);

            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddFloat(0.0f); // Unknown
            addShBoombox.AddFloat(0.0f); // Unknown
            addShBoombox.AddFloat(0.0f); // Unknown
            addShBoombox.AddASCIIString(""); // Unknown
            addShBoombox.AddASCIIString(""); // Unknown
            addShBoombox.AddASCIIString(""); // Unknown
            addShBoombox.AddBoolean(false); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddHostInt32(8); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown
            addShBoombox.AddHostInt32(3442); // Unknown
            addShBoombox.AddFloat(0.0f); // Unknown
            addShBoombox.AddHostInt32(0); // Unknown

            LoginManager.SendTunneledClientPacket(soeClient, addShBoombox.GetRaw());
        }
    }
}
    