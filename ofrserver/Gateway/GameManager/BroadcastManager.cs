using Gateway.Login;
using SOE.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.GameManager
{
    internal class BroadcastManager
    {
        public static void BroadcastToPlayers(byte[] Packet)
        {
            List<SOEClient> Clients = LoginManager._server.ConnectionManager.Clients;
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i] != null) { 
                LoginManager.SendTunneledClientPacket(Clients[i], Packet);
                }
            }
        }
    }
}
