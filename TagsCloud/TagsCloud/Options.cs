using CommandLine;
using CommandLine.Text;

namespace TagsCloud
{
    // CR (krait): Хочется иметь возможность задавать алгоритм, по которому будет генериться картинка.

    public class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file.")]
        public string InputFile { get; set; }

        [Option('o', "output", DefaultValue = "result.png", HelpText = "Output file.")]
        public string OutputFile { get; set; }

        [Option("minFont", DefaultValue = 20, HelpText = "Minimum font size.")]
        public int MinFont { get; set; }

        [Option("maxFont", DefaultValue = 40, HelpText = "Maximum font size.")]
        public int MaxFont { get; set; }

        [Option("width", DefaultValue = 400, HelpText = "Result image width.")]
        public int Width { get; set; }

        [Option("height", DefaultValue = 400, HelpText = "Result image height")]
        public int Height { get; set; }

        [Option("font", DefaultValue = "Consolas", HelpText = "Text Fontname.")]
        public string FontName { get; set; }

        [Option("textColor", DefaultValue = "Orange", HelpText = "Text color.")]
        public string TextColor { get; set; }
        
        [Option("backgroundColor", DefaultValue = "Blue", HelpText = "Background color.")]
        public string BackgroundColor { get; set; }

        [Option("algorithm", DefaultValue = "Column", HelpText ="Algorithm to use. (Column - Columns Algorithm, Line - Line Algorithm.")]
        public string AlgorithmName { get; set; }

        [HelpOption('h', "help", HelpText = "Show help information")]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("TagsCloud create tags cloud from input file"),
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: TagsCloud.exe -i filename");
            help.AddOptions(this);
            return help;
        }
    }
}