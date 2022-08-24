using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using log4net;

namespace SOE.Core
{
    public interface IRole
    {
        void StartRole(SOEServer server);
    }

    public class SOERoleManager
    {
        // Components
        public SOEServer Server;
        public ILog Log;

        // Roles
        public List<IRole> Roles = new List<IRole>();

        public SOERoleManager(SOEServer server)
        {
            Server = server;

            Log = Server.Logger.GetLogger("SOERoleManager");
            Log.Info("Service constructed");
        }

        private void LoadRole(Assembly roleAssembly)
        {
            var roleType = typeof (IRole);
            var types = roleAssembly.GetTypes()
                .Where(p => roleType.IsAssignableFrom(p));

            foreach (var type in types)
            {
                // Create the role
                IRole role = (IRole)Activator.CreateInstance(type);

                // Add the role
                role.StartRole(Server);
                Roles.Add(role);
            }
        }

        public void LoadRoles(string[] roles)
        {
            foreach (var role in roles)
            {
                // Load the assembly
                Log.InfoFormat("Loading role: '{0}'...", role);
                try
                {
                    var roleAssembly = Assembly.LoadFile(Path.GetFullPath(role));

                    // Load the roles from this assembly
                    LoadRole(roleAssembly);
                }
                catch (Exception)
                {
                    Log.FatalFormat("Failed to load role '{0}'!", role);

                    Environment.Exit(0);
                    return;
                }
            }
        }
    }
}
