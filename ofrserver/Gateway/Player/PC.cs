using log4net;
using SOE.Core;
using SOE.Interfaces;
using SOE;
using Gateway.Login;
using System.IO;
using System;
using Newtonsoft.Json;
using static Gateway.Login.ClientPcData;
using System.Collections.Generic;

namespace Gateway.Player
{
    internal class PC
    {
        private static SOEServer _server = Gateway.Server;
        private static ILog _log = _server.Logger.GetLogger("PlayerCharacter");

        

        public static void SendPlayerUpdatePacketAddPc(SOEClient soeClient)
        {
            _log.Info($"Client {soeClient.GetClientID()} Replicate Player Character");
        }

        
    }
}
