using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CommandLine;

namespace TagsCloud
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
            var options = new InputOptions();
            if (Parser.Default.ParseArguments(args, options))
            {
                if (!File.Exists(options.InputFile))
                {
                    Console.WriteLine("File not found.");
                    return;
                }
                var generator = new TagsCloudGenerator(options);
                Image image;
                try
                {
                    image = generator.Generate();
                }
                catch (UnknownAlgorithmException)
                {
                    Console.WriteLine("Unknown algorithm");
                    return;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong arguments value");  
                    return;
                }
                image.Save(options.OutputFile, ImageFormat.Png);
            }
            else
            {
                Console.WriteLine("Wrong arguments type");
            }
        }
    }

    public class UnknownAlgorithmException : Exception
    {
    }
}