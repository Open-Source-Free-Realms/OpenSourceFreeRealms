using CommandLine;

namespace LandwalkerServer
{
    internal class ServerOptions
    {
        [Option('c', "config", DefaultValue = "Config.json", HelpText = "The configuration for this daemon.")]
        public string ConfigFile { get; set; }

        [Option('v', "verbose", DefaultValue = false, HelpText = "Ouput daemon-specific messages to stdout.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }
    }
}