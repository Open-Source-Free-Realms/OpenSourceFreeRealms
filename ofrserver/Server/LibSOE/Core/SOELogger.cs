using System;
using System.Collections.Generic;

using log4net;
using log4net.Core;
using log4net.Filter;
using log4net.Layout;
using log4net.Appender;
using log4net.Repository;
using log4net.Repository.Hierarchy;

namespace SOE.Core
{
    public class SOELogger
    {
        // Components
        public SOEServer Server;

        // Repo
        public ILoggerRepository Repo;

        // Settings
        public Dictionary<string, dynamic> Configuration = new Dictionary<string, dynamic>
        {
            // Basic information
            {"Filename", "SOEServer.log"},
            {"LogPattern", "<%date> :%logger: [%level] %message%newline"},

            // Types of logging
            {"WantConsoleLogging", true},
            {"WantFileLogging", true},

            {"WantLibraryLogging", true},
            {"WantApplicationLogging", true},

            // Severities
            {"LoggingLevel", "all"},

            // Prettiness
            {"WantColors", true}
        };

        // Logging level dictionary
        public readonly Dictionary<string, Level> LoggingLevels = new Dictionary<string, Level>
        {
            {"all", Level.All},
            {"debug", Level.Debug},
            {"info", Level.Info},
            {"warn", Level.Warn},
            {"error", Level.Error},
            {"fatal", Level.Fatal},
            {"off", Level.Off}
        };

        public SOELogger(SOEServer server)
        {
            Server = server;
        }

        public void StartLogging()
        {
            // Get variables
            bool wantLibraryLogging = Configuration["WantLibraryLogging"];
            bool wantConsoleLogging = Configuration["WantConsoleLogging"];
            bool wantFileLogging = Configuration["WantFileLogging"];
            bool wantColors = Configuration["WantColors"];
            string rawFilename = Configuration["Filename"];
            string filename = string.Format(rawFilename, DateTime.Now);

            // Create a repo
            Repo = LogManager.CreateRepository(Server.GetFullname());
            Hierarchy hierachy = (Hierarchy) Repo;

            // Create a pattern
            PatternLayout pattern = new PatternLayout();
            pattern.ConversionPattern = Configuration["LogPattern"];
            pattern.ActivateOptions();

            // Create a filter
            LoggerMatchFilter[] filters = new LoggerMatchFilter[0];
            if (!wantLibraryLogging)
            {
                filters = new []
                {
                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOEServer",
                        AcceptOnMatch = false
                    },

                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOEConnectionManager",
                        AcceptOnMatch = false
                    },

                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOEProtocol",
                        AcceptOnMatch = false
                    },

                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOELogger",
                        AcceptOnMatch = false
                    },

                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOEDataChannel",
                        AcceptOnMatch = false
                    },

                    new LoggerMatchFilter()
                    {
                        LoggerToMatch = "SOERoleManager",
                        AcceptOnMatch = false
                    }
                };
            }

            // Appenders
            if (wantConsoleLogging)
            {
                if (wantColors)
                {
                    ColoredConsoleAppender appender = new ColoredConsoleAppender
                    {
                        Layout = pattern
                    };
                    appender.AddMapping(new ColoredConsoleAppender.LevelColors
                    {
                        Level = Level.Debug,
                        ForeColor = ColoredConsoleAppender.Colors.Cyan
                            | ColoredConsoleAppender.Colors.HighIntensity
                    });
                    appender.AddMapping(new ColoredConsoleAppender.LevelColors
                    {
                        Level = Level.Info,
                        ForeColor = ColoredConsoleAppender.Colors.White
                            | ColoredConsoleAppender.Colors.HighIntensity
                    });
                    appender.AddMapping(new ColoredConsoleAppender.LevelColors
                    {
                        Level = Level.Warn,
                        ForeColor = ColoredConsoleAppender.Colors.Yellow
                            | ColoredConsoleAppender.Colors.HighIntensity
                    });
                    appender.AddMapping(new ColoredConsoleAppender.LevelColors
                    {
                        Level = Level.Error,
                        ForeColor = ColoredConsoleAppender.Colors.Red
                            | ColoredConsoleAppender.Colors.HighIntensity
                    });
                    appender.AddMapping(new ColoredConsoleAppender.LevelColors
                    {
                        Level = Level.Fatal,
                        ForeColor = ColoredConsoleAppender.Colors.White
                            | ColoredConsoleAppender.Colors.HighIntensity,
                        BackColor = ColoredConsoleAppender.Colors.Red
                    });

                    foreach (var filter in filters)
                    {
                        appender.AddFilter(filter);
                    }

                    appender.ActivateOptions();
                    hierachy.Root.AddAppender(appender);
                }
                else
                {
                    ConsoleAppender appender = new ConsoleAppender
                    {
                        Layout = pattern
                    };
                    foreach (var filter in filters)
                    {
                        appender.AddFilter(filter);
                    }

                    appender.ActivateOptions();
                    hierachy.Root.AddAppender(appender);
                }
            }

            if (wantFileLogging)
            {
                FileAppender appender = new FileAppender
                {
                    AppendToFile = false,
                    File = filename,
                    Layout = pattern
                };
                foreach (var filter in filters)
                {
                    appender.AddFilter(filter);
                }

                appender.ActivateOptions();
                hierachy.Root.AddAppender(appender);
            }

            // Configure the hierachy
            Level configLevel = Level.All;
            if (LoggingLevels.ContainsKey(Configuration["LoggingLevel"]))
            {
                configLevel = LoggingLevels[Configuration["LoggingLevel"]];
            }

            hierachy.Root.Level = configLevel;
            hierachy.Configured = true;
        }

        public void Configure(Dictionary<string, dynamic> configuration)
        {
            foreach (var configVariable in configuration)
            {
                if (!Configuration.ContainsKey(configVariable.Key))
                {
                    // Bad configuration variable
                    Console.WriteLine("Invalid configuration variable '{0}' for SOELogger instance. Ignoring.", configVariable.Key);
                    continue;
                }

                // Set this variable
                Configuration[configVariable.Key] = configVariable.Value;
            }
        }

        public ILog GetLogger(string name)
        {
            return LogManager.GetLogger(Repo.Name, name);
        }
    }
}
