using log4net;

using SOE.Core;

using Gateway.Login;

namespace Gateway
{
    public class Gateway : IRole
    {
        private static ILog _log;

        public static SOEServer Server;

        public void StartRole(SOEServer server)
        {
            // Set our server
            Server = server;

            // Get a logger
            _log = Server.Logger.GetLogger("Gateway");
            _log.Info("Constructing gateway...");

            // Construct our managers
            LoginManager.Start();

            // Finish!
            _log.Info("Finished constructing gateway!");

        }
    }
}
