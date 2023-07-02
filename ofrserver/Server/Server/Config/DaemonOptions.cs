using CommandLine;

namespace Server
{
    internal class DaemonOptions
    {
        [Option('c', "config", HelpText = "The configuration for this daemon.")]
        public string ConfigFile { get; set; } = "Config.json";

        [Option('v', "verbose", HelpText = "Ouput daemon-specific messages to stdout.")]
        public bool Verbose { get; set; } = false;
    }
}