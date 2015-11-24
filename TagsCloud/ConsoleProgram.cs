using System;
using System.Drawing.Imaging;
using System.IO;

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
                    return;
                }
                var generator = new TagsCloudGenerator(options.InputFile, options);
                var image = generator.Generate();
                image.Save(options.OutputFile, ImageFormat.Png);
            }
        }
    }
}