using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using System;

namespace Gateway.MapChat
{
    internal class Map
    {
        public static void SendPacketPointOfInterestDefinitionReply(SOEClient soeClient)
        {
            var packetPointOfInterestDefinitionReply = new SOEWriter();

            foreach (var pointOfInterestDefinition in LoginManager.PointOfInterestDefinitions)
            {
                // Indicate we have more definitions
                packetPointOfInterestDefinitionReply.AddBoolean(true);

                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Id);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.NameId);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.LocationId);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.X);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.Y);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.Z);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.Heading);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.IconId);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.NotificationType);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.SubNameId);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown11);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.BreadCrumbQuestId);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.TeleportLocationId);
                packetPointOfInterestDefinitionReply.AddASCIIString(pointOfInterestDefinition.AtlasName);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown15);
            }

            // Indicate we have no more definitions
            packetPointOfInterestDefinitionReply.AddBoolean(false);

            var rawBytes = packetPointOfInterestDefinitionReply.GetRaw();

            var basePlayerUpdate = new SOEWriter((ushort)BasePackets.PacketPointOfInterestDefinitionReply, true);

            basePlayerUpdate.AddHostInt32(rawBytes.Length);

            basePlayerUpdate.AddBytes(rawBytes);

            LoginManager.SendTunneledClientPacket(soeClient, basePlayerUpdate.GetRaw());
        }

        public static bool IsPointInSquare(float x, float z, float cx0, float cz0, float cx1, float cz1)
        {
            float minX = Math.Min(cx0, cx1);
            float maxX = Math.Max(cx0, cx1);
            float minZ = Math.Min(cz0, cz1);
            float maxZ = Math.Max(cz0, cz1);
            return x > minX && x < maxX && z > minZ && z < maxZ;
        }

        public static bool inBlackspore(float[] pos0)
        {
            return IsPointInSquare(pos0[0], pos0[2], -1602.665f, 1596.845f, -2644.895f, 769.8992f);
        }

        public static bool inSanctuary(float[] pos0)
        {
            return IsPointInSquare(pos0[0], pos0[2], -860.1044f, 474.2705f, -1525.813f, 150.1886f);
        }

        public static bool inSeaside(float[] pos0)
        {
            return IsPointInSquare(pos0[0], pos0[2], 193.748f, -995.8353f, -1125.708f, -1651.906f);
        }

        public static double MerryValeMagnitude(float[] pos0)
        {
            return Math.Sqrt(
                Math.Pow(-1035.667 - pos0[0], 2) +
                Math.Pow(-399.0692 - pos0[2], 2)
            );
        }

        public static double BriarwoodMagnitude(float[] pos0)
        {
            return Math.Sqrt(
                Math.Pow(-933.0994 - pos0[0], 2) +
                Math.Pow(-33.47968 - pos0[1], 2) +
                Math.Pow(1901.2840 - pos0[2], 2)
            );
        }

        public static double inShroudedGlade(float[] pos0)
        {
            return Math.Sqrt(
                Math.Pow(89.80905 - pos0[0], 2) +
                Math.Pow(1176.479 - pos0[2], 2)
            );
        }

        public static bool inSnowhill(float[] pos0)
        {
            return IsPointInSquare(pos0[0], pos0[2], 610.8266f, 669.3798f, 45.85328f, -52.44703f);
        }

        public static bool inWugachug(float[] pos0)
        {
            return IsPointInSquare(pos0[0], pos0[2], 153.7834f, -428.4424f, -80.39778f, -476.5051f);
        }

        public static double SunstoneValleyMagnitude(float[] pos0)
        {
            return Math.Sqrt(
                Math.Pow(713.7668 - pos0[0], 2) +
                Math.Pow(1965.37 - pos0[2], 2)
            );
        }

        public static void SendPacketPOIChangeMessage(SOEClient soeClient)
        {
            //TODO
            LoginManager.SendTunneledClientPacket(soeClient, LoginManager.StringToByteArray(/* PacketPOIChangeMessage */ "0500010E0000006800AB0D00000500000023010000"));
        }
        public static void SendObjectiveTargetUpdatePacket(SOEClient soeClient)
        {
            LoginManager.SendTunneledClientPacket(soeClient, LoginManager.StringToByteArray(/* Quest Marker */"2F000E017B10CEC614CA943E01000000320000006027000068BF06000CA7B9C3CB9AA4C2C62E16450000803F05000000"));
        }
    }
}
