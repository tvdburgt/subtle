using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace Subtle.Cli
{
    class SubtleOptions
    {
        [Option("dry-run", DefaultValue = false, HelpText = "Perform a dry run (only search for subtitles, do not download them).")]
        public bool DryRun { get; set; }

        [Option('r', "replace", DefaultValue = false, HelpText = "Replace existing subtitles.")]
        public bool Replace { get; set; }

        [Option('s', "shallow", DefaultValue = false, HelpText = "Perform a shallow search (non-recursive search for top-level directory).")]
        public bool Shallow { get; set; }

        [Option('l', "language", DefaultValue = "en", HelpText = "Language code for subtitles (can be either ISO 639-1 or 639-2).")]
        public string Language { get; set; }

        [ValueOption(0)]
        public string Path { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var name = Assembly.GetExecutingAssembly().GetName().Name;
            var help = new HelpText
            {
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true,
            };
            help.AddPreOptionsLine($"Usage: {name} [options] <path>");
            help.AddOptions(this);
            return help;
        }
    }
}
