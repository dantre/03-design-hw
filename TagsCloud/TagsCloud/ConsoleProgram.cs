using System;
using System.Drawing;
using System.Drawing.Imaging;
using CommandLine;
using Ninject;
using TagsCloud.Generator;
using TagsCloud.Options;

namespace TagsCloud
{
    public class ConsoleProgram
    {
        private string[] args;
        private IOptionsValidator Validator { get; set; }

        public ConsoleProgram(string[] args)
        {
            this.args = args;
        }

        public void Run()
        {
            var options = new InputOptions();
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Command line parser error");
                return;
            }
            
            Validator = new InputOptionsValidator(options);
            string message;
            if (!Validator.IsValid(out message))
            {
                Console.WriteLine(message);
                return;
            }

            var generator = new TagCloudGenerator(options);
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
    }

    public class UnknownAlgorithmException : Exception
    {
    }
}