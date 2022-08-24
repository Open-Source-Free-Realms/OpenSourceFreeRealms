using System;
using System.Net;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Collections.Concurrent;

using log4net;

using SOE.Interfaces;

namespace SOE.Core
{
    public struct SOEPendingPacket
    {
        public SOEClient Client;
        public byte[] Packet;

        public SOEPendingPacket(SOEClient sender, byte[] packet)
        {
            Client = sender;
            Packet = packet;
        }
    }

    public struct SOEPendingMessage
    {
        public SOEClient Client;
        public byte[] Message;

        public SOEPendingMessage(SOEClient sender, byte[] packet)
        {
            Client = sender;
            Message = packet;
        }
    }

    public class SOEServer
    {
        // Server components
        private readonly UdpClient UdpClient;
        public readonly SOEConnectionManager ConnectionManager;
        public readonly SOEProtocol Protocol;
        public readonly SOERoleManager RoleManager;
        public readonly SOELogger Logger;
        public readonly ILog Log;

        private readonly ConcurrentQueue<SOEPendingPacket> IncomingPackets;
        private readonly ConcurrentQueue<SOEPendingMessage> IncomingMessages;
        
        // Server variables
        public bool Running = true;

        // Settings
        public Dictionary<string, dynamic> Configuration = new Dictionary<string, dynamic>
        {
            // Basic information
            {"Name", "SOEServer"},
            {"Port", 20260},
            {"ID", 4001},

            // Application settings
            {"AppName", "Sony Online"},
            {"ShortAppName", "SOE"},

            // Threading toggles
            {"WantDynamicThreading", true},
            {"WantPacketThreading", true},
            {"WantMessageThreading", true},

            // Threading settings
            {"ServerThreadSleep", 13},
            {"MinThreadPoolSize", 2},
            {"MaxThreadPoolSize", 8}
        };

        public Dictionary<string, dynamic> ApplicationConfiguration;

        public SOEServer(Dictionary<string, dynamic> configuration)
        {
            // Configure!
            foreach (var configVariable in configuration)
            {
                if (!Configuration.ContainsKey(configVariable.Key))
                {
                    // We do this in a specific order so, continue!
                    continue;
                }

                // Set this variable
                Configuration[configVariable.Key] = configVariable.Value;
            }

            ApplicationConfiguration = new Dictionary<string, dynamic>();
            if (configuration.ContainsKey("Application"))
            {
                ApplicationConfiguration = configuration["Application"];
            }

            // Start logging
            Logger = new SOELogger(this);
            if (configuration.ContainsKey("Logger"))
            {
                Logger.Configure(configuration["Logger"]);
            }
            Logger.StartLogging();

            Log = Logger.GetLogger("SOEServer");
            Log.InfoFormat("Initializing server...");

            // Configure components
            ConnectionManager = new SOEConnectionManager(this);
            if (configuration.ContainsKey("ConnectionManager"))
            {
                ConnectionManager.Configure(configuration["ConnectionManager"]);
            }

            Protocol = new SOEProtocol(this);
            if (configuration.ContainsKey("Protocol"))
            {
                Protocol.Configure(configuration["Protocol"]);
            }

            RoleManager = new SOERoleManager(this);
            if (configuration.ContainsKey("Roles"))
            {
                IEnumerable<object> ol = configuration["Roles"];
                IEnumerable<string> roles = ol.Cast<string>();

                RoleManager.LoadRoles(roles.ToArray());
            }

            // Get variables
            int port = Configuration["Port"];

            // UDP Listener
            try
            {
                UdpClient = new UdpClient(port);
            }
            catch (SocketException)
            {
                Log.FatalFormat("You already have a server running on port: {0}", port);
                Environment.Exit(0);
            }

            IncomingPackets = new ConcurrentQueue<SOEPendingPacket>();
            IncomingMessages = new ConcurrentQueue<SOEPendingMessage>();

            // Initialize our message handlers
            MessageHandlers.Initialize();

            // Finish constructing
            Log.Info("Finished initiating server!");
        }

        public string GetFullname()
        {
            string name = Configuration["Name"];
            int id = Configuration["ID"];

            return string.Format("{0}{1}", name, id);
        }

        private void DoNetCycle()
        {
            // Get variables
            bool wantPacketThreading = Configuration["WantPacketThreading"];
            int port = Configuration["Port"];

            // Receive a packet
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
            byte[] rawPacket;

            try
            {
                rawPacket = UdpClient.Receive(ref sender);
            }
            catch (SocketException)
            {
                // Maybe we just killed the client?
                return;
            }

            // Get the associated client (or create a new fake one)
            SOEClient client = ConnectionManager.GetClientFromHost(sender);
            if (client == null)
            {
                // Make a fake client for new connections
                client = new SOEClient(ConnectionManager, sender);
            }

            // Do we wanna handle this, or give it to our workers?
            if (wantPacketThreading)
            {
                // Put it in the queue for our workers..
                IncomingPackets.Enqueue(new SOEPendingPacket(client, rawPacket));
            }
            else
            {
                // Handle the packet
                Protocol.HandlePacket(client, rawPacket);
            }
        }

        public void SendPacket(SOEClient client, SOEPacket packet)
        {
            // Send the message
            UdpClient.Send(packet.GetRaw(), packet.GetLength(), client.Client);
        }

        public void ReceiveMessage(SOEClient sender, byte[] rawMessage)
        {
            // Get variables
            bool wantMessageThreading = Configuration["WantMessageThreading"];

            if (wantMessageThreading)
            {
                IncomingMessages.Enqueue(new SOEPendingMessage(sender, rawMessage));
            }
            else
            {
                Protocol.HandleMessage(sender, rawMessage);
            }
        }

        public void Run()
        {
            // Get variables
            bool wantPacketThreading = Configuration["WantPacketThreading"];
            bool wantMessageThreading = Configuration["WantMessageThreading"];
            int maxThreadPoolSize = Configuration["MaxThreadPoolSize"];
            int threadSleep = Configuration["ServerThreadSleep"];

            // Server threads
            Log.Info("Starting server threads...");
            Thread netThread = new Thread((threadStart) =>
            {
                while (Running)
                {
                    // Do a cycle
                    DoNetCycle();

                    // Sleep
                    Thread.Sleep(threadSleep);
                }
            });
            netThread.Name = "SOEServer::NetThread";
            netThread.Start();

            // Create the packet worker threads
            if (wantPacketThreading)
            {
                for (int i = 0; i < maxThreadPoolSize; i++)
                {
                    Thread workerThread = new Thread((workerThreadStart) =>
                    {
                        while (Running)
                        {
                            // Get a packet and handle it.
                            SOEPendingPacket packet;

                            if (IncomingPackets.TryDequeue(out packet))
                            {
                                Protocol.HandlePacket(packet.Client, packet.Packet);
                            }

                            // Sleep
                            Thread.Sleep(threadSleep);
                        }
                    });

                    workerThread.Name = string.Format("SOEServer::PacketWorkerThread{0}", i + 1);
                    workerThread.Start();
                }
            }

            // Create the message worker threads
            if (wantMessageThreading)
            {
                for (int i = 0; i < maxThreadPoolSize; i++)
                {
                    Thread workerThread = new Thread((workerThreadStart) =>
                    {
                        while (Running)
                        {
                            // Get a packet and handle it.
                            SOEPendingMessage message;

                            if (IncomingMessages.TryDequeue(out message))
                            {
                                Protocol.HandleMessage(message.Client, message.Message);
                            }

                            // Sleep
                            Thread.Sleep(threadSleep);
                        }
                    });

                    workerThread.Name = string.Format("SOEServer::MessageWorkerThread{0}", i + 1);
                    workerThread.Start();
                }
            }

            // Create the idle connection thread
            ConnectionManager.StartKeepAliveThread();

            // Done
            Log.Info("Started listening!");
        }

        public void Stop()
        {
            Running = false;
        }
    }
}
