using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;

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

                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown2);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown3);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.PositionX);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.PositionY);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.PositionZ);
                packetPointOfInterestDefinitionReply.AddFloat(pointOfInterestDefinition.SpawnOffset);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown8);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown9);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown10);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown11);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown12);
                packetPointOfInterestDefinitionReply.AddHostInt32(pointOfInterestDefinition.Unknown13);
                packetPointOfInterestDefinitionReply.AddASCIIString(pointOfInterestDefinition.Unknown14);
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
