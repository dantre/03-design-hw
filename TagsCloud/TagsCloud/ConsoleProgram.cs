using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CommandLine;
using Ninject;

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
                image.Save(options.OutputFile, ImageFormat.Png);
            }
        }
    }

    public class UnknownAlgorithmException : Exception
    {
    }
}