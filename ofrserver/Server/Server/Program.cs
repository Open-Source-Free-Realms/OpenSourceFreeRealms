using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SOE.Core;

namespace Server
{
    class Program
    {
        private static ServerOptions Options;
        private static Dictionary<string, SOEServer> Servers;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                File.WriteAllText("UnhandledException.log", e.ExceptionObject.ToString());
            };
            Options = new ServerOptions();

            // Successful parse?
            if (Parser.Default.ParseArguments(args, Options))
            {
                // Are we verbose?
                if (Options.Verbose)
                {
                    // Console.WriteLine verbosely
                    Console.WriteLine("Using configuration: {0}", Options.ConfigFile);
                }

                // Configure!
                Configure();
            }
            Process.GetCurrentProcess().WaitForExit();
        }

        static void Configure()
        {
            Servers = new Dictionary<string, SOEServer>();

            bool createDefault = !File.Exists(Options.ConfigFile);
            FileStream file = new FileStream(Options.ConfigFile, FileMode.OpenOrCreate);

            if (createDefault)
            {
                StreamWriter writer = new StreamWriter(file);
                // This creates an empty Config.json File
            }
            else
            {
                // Read the contents of the file
                StreamReader reader = new StreamReader(file);
                JArray rootArray = new JArray();

                try
                {
                    rootArray = JArray.Parse(reader.ReadToEnd());
                    reader.Close();
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid configuration!");
                    return;
                }

                foreach (var server in rootArray.Children<JObject>())
                {
                    // Check if this property is an Object
                    if (server.Type != JTokenType.Object)
                    {
                        Console.WriteLine("Invalid configuration! Servers must be JSON Objects!");
                        Environment.Exit(0);
                    }

                    // Make a new config
                    Dictionary<string, dynamic> serverConfig = new Dictionary<string, dynamic>();
                    
                    // Go through the server properties
                    foreach (var propertyKeyval in server)
                    {
                        string name = propertyKeyval.Key;
                        JToken property = propertyKeyval.Value;

                        if (property.Type == JTokenType.Object)
                        {
                            // We have a component configuration
                            Dictionary<string, dynamic> componentConfig = new Dictionary<string, dynamic>();

                            // Get the component settings
                            foreach (var componentKeyval in (JObject)property)
                            {
                                componentConfig.Add(componentKeyval.Key, componentKeyval.Value.Value<object>());
                            }

                            // Add it to the server configuration
                            serverConfig.Add(propertyKeyval.Key, componentConfig);
                        }
                        else if (property.Type == JTokenType.Array)
                        {
                            serverConfig.Add(name, property.ToObject<string[]>());
                        }
                        else
                        {
                            // Server value
                            serverConfig.Add(name, property.Value<object>());
                        }
                    }

                    // Setup a new SOEServer instance
                    SOEServer newServer = new SOEServer(serverConfig);
                    newServer.Run();

                    // Add the new server to our servers list
                    try
                    {
                        string serverName = newServer.Configuration["Name"];
                        Servers.Add(serverName, newServer);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid configuration! Two servers cannot have the same name!");
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}
