using System;
using System.Net;
using System.Threading;
using System.Collections.Generic;

using log4net;

using SOE.Interfaces;

namespace SOE.Core
{
    public delegate void ConnectionEventHandler(SOEClient client);

    public class SOEConnectionManager
    {
        // Server component
        public SOEServer Server;
        public readonly ILog Log;

        // Connections
        private readonly List<SOEClient> Clients;
        private readonly Dictionary<IPEndPoint, int> Host2ClientID;
        private readonly Dictionary<uint, int> SessionID2ClientID;

        // Settings
        public Dictionary<string, dynamic> Configuration = new Dictionary<string, dynamic>
        {
            // Basic information
            {"MaxConnections", -1},
            {"Timeout", 15},

            // Connection types
            {"WantRoutedConnections", false},
            {"WantDirectConnections", true}
        };

        public event ConnectionEventHandler OnConnection;

        public event ConnectionEventHandler OnDisconnect;

        public SOEConnectionManager(SOEServer server)
        {
            // Server
            Server = server;

            // Our client lists
            Clients = new List<SOEClient>();
            Host2ClientID = new Dictionary<IPEndPoint, int>();
            SessionID2ClientID = new Dictionary<uint, int>();

            // Log
            Log = Server.Logger.GetLogger("SOEConnectionManager");
            Log.Info("Service constructed");
        }

        public bool AddNewClient(SOEClient newClient)
        {
            // Get variables
            bool wantDirectConnections = Configuration["WantDirectConnections"];
            int maxConnections = Configuration["MaxConnections"];

            // Do we want this connection?
            if (!wantDirectConnections)
            {
                // We don't want a direct connection
                return false;
            }

            // Have we hit max connections?
            if (Clients.Count == maxConnections)
            {
                // Loop through the Clients list, looking for an open space
                bool hasSpace = false;
                for (int i = 0; i < Clients.Count; i++)
                {
                    // Is this client nulled?
                    if (Clients[i] == null)
                    {
                        hasSpace = true;
                        break;
                    }
                }

                // Don't continue adding this connection
                if (!hasSpace)
                {
                    return false;
                }
            }

            // Do they exist already?
            if (SessionID2ClientID.ContainsKey(newClient.GetSessionID()))
            {
                // Disconnect the new client
                Log.Warn("Someone tried connecting with the same Session ID!");
                newClient.Disconnect((ushort)SOEDisconnectReason.ConnectFail);

                // Don't continue adding this connection
                return false;
            }

            // Is there already a connection from this endpoint?
            if (Host2ClientID.ContainsKey(newClient.Client))
            {
                // Disconnect the new client
                Log.Warn("Someone tried connecting from the same endpoint!");
                newClient.Disconnect((ushort)SOEDisconnectReason.ConnectFail);

                // Don't continue adding this connection
                return false;
            }

            // Loop through the Clients list, looking for an open space
            int newClientId;
            for (newClientId = 0; newClientId < Clients.Count; newClientId++)
            {
                // Is this client nulled?
                if (Clients[newClientId] == null)
                {
                    // We've found an empty space!
                    break;
                }
            }

            // Set their Client ID
            newClient.SetClientID(newClientId);

            // Add them to the Clients map
            if (newClientId >= Clients.Count)
            {
                Clients.Add(newClient);
            }
            else
            {
                Clients[newClientId] = newClient;
            }

            // Add them to our maps
            Host2ClientID.Add(newClient.Client, newClientId);
            SessionID2ClientID.Add(newClient.GetSessionID(), newClientId);

            if (OnConnection != null)
            {
                OnConnection(newClient);
            }

            // Log
            Log.InfoFormat("New client connection from {0}, (ID: {1})", newClient.GetClientAddress(), newClient.GetClientID());
            return true;
        }

        public SOEClient GetClient(int clientId)
        {
            // Is the requested index within our List?
            if (clientId < Clients.Count)
            {
                // Return the associated client
                return Clients[clientId];
            }

            // Return a null client
            return null;
        }

        public SOEClient GetClientFromSessionID(uint sessionId)
        {
            // Does this SessionID exist?
            if (SessionID2ClientID.ContainsKey(sessionId))
            {
                // Return the associated client
                return Clients[SessionID2ClientID[sessionId]];
            }

            // Return a null client
            return null;
        }

        public SOEClient GetClientFromHost(IPEndPoint client)
        {
            // Do we have a connection from this endpoint?
            if (Host2ClientID.ContainsKey(client))
            {
                // Return the associated client
                return Clients[Host2ClientID[client]];
            }

            // Return a null client
            return null;
        }

        public void DisconnectClient(SOEClient client, ushort reason, bool clientBased = false)
        {
            // Disconnect
            Log.InfoFormat("Disconnecting client on {0} (ID: {1}) for reason: {2}", client.GetClientAddress(), client.GetClientID(), (SOEDisconnectReason)reason);
            
            // Are they a connected client?
            if (Clients.Contains(client))
            {
                // We don't care about them anymore
                // Open their ID as a space
                Host2ClientID.Remove(client.Client);
                SessionID2ClientID.Remove(client.GetSessionID());
                Clients[client.GetClientID()] = null;
            }

            // Was this a disconnect request from the client itself?
            if (!clientBased)
            {
                // Tell them we're disconnecting them
                SOEWriter packetWriter = new SOEWriter((ushort)SOEOPCodes.DISCONNECT);

                // Arguments
                packetWriter.AddUInt32(client.GetSessionID());
                packetWriter.AddUInt16(reason);

                // Send!
                SOEPacket packet = packetWriter.GetFinalSOEPacket(client, true, false);
                client.SendPacket(packet);
            }

            if (OnDisconnect != null)
            {
                OnDisconnect(client);
            }
        }

        public void StartKeepAliveThread()
        {
            // Get variables
            int clientTimeout = Configuration["Timeout"];
            int threadSleep = Server.Configuration["ServerThreadSleep"];

            Thread keepAliveThread = new Thread((threadStart3) =>
            {
                while (Server.Running)
                {
                    // Get a Now time for this cycle
                    int now = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                    // Loop through the clients
                    for (int i = 0; i < Clients.Count; i++)
                    {
                        // Client
                        SOEClient client = GetClient(i);

                        // Empty space?
                        if (client == null)
                        {
                            continue;
                        }

                        // Idle?
                        if (now > (client.GetLastInteraction() + clientTimeout))
                        {
                            Log.InfoFormat("Disconnecting Idle client");
                            client.Disconnect((ushort)SOEDisconnectReason.Timeout);
                        }
                    }

                    Thread.Sleep(threadSleep);
                }
            });
            keepAliveThread.Name = "SOEConnectionManager::KeepAliveThread";
            keepAliveThread.Start();
        }

        public void Configure(Dictionary<string, dynamic> configuration)
        {
            foreach (var configVariable in configuration)
            {
                if (!Configuration.ContainsKey(configVariable.Key))
                {
                    // Bad configuration variable
                    Console.WriteLine("Invalid configuration variable '{0}' for SOEConnectionManager instance. Ignoring", configVariable.Key);
                    continue;
                }

                // Set this variable
                Configuration[configVariable.Key] = configVariable.Value;
            }
        }
    }
}
