using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace WordsCloud
{
    public class ConsoleProgram
    {

        private string[] args;
        public ConsoleProgram(string[] args)
        {
            this.args = args;
        }

        public void Run()
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (!File.Exists(options.InputFile))
                {
                    Console.WriteLine("File not found.");
                }
            }
//
//            var settings = new Settings
//            {
//                MinFont = 20,
//                MaxFont = 40,
//                FontColour = Color.Blue,
//                TextColour = Color.Orange,
//                Font = "Arial"
//            };
//            var t = new TagsCloudGenerator("simple.txt", settings);
//            t.Generate();
        }
    }


    class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file.")]
        public string InputFile { get; set; }

        [Option('o', "output", DefaultValue = "result.png", HelpText = "Output file.")]
        public string OutputFile { get; set; }

        [Option("minFont", DefaultValue = 20, HelpText = "Minimum font size.")]
        public int MinFont { get; set; }

        [Option("maxFont", DefaultValue = 40, HelpText = "Maximum font size.")]
        public int MaxFont { get; set; }

        [Option("width", HelpText = "Result image width.")]
        public int Width { get; set; }

        [Option("height", HelpText = "Result image height")]
        public int Height { get; set; }

        [HelpOption('h', "help", HelpText = "Show help information")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("WordsCloud", "1.0"),
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: app -p Someone");
            help.AddOptions(this);
            
            return help;
        }
    }
}