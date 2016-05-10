using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CommandLine;
using Ninject;
using TagsCloud.Options;

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
                string message;
                if (InputOptionsValidator.IsValid(options, out message))
                {
                    Console.WriteLine(message);
                }

                var generator = new TagsCloudGenerator(options);
                try
                {
                    Image image = generator.Generate();
                    image.Save(options.OutputFile, ImageFormat.Png);
                }
                catch (UnknownAlgorithmException)
                {
                    Console.WriteLine("Unknown algorithm");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Wrong arguments value");
                }
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