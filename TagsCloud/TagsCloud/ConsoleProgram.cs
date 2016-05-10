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
        private readonly InputOptions options = new InputOptions();

        public void Run(string[] arguments)
        {
            if (!IsOptionsProper(arguments))
                return;

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

        private bool IsOptionsProper(string[] arguments)
        {
            return ParserAccepts(arguments) && ValidatorAccepts();
        }

        private bool ParserAccepts(string[] arguments)
        {
            if (!Parser.Default.ParseArguments(arguments, options))
            {
                Console.WriteLine("Arguments parsing error");
                return false;
            }
            return true;
        }

        private bool ValidatorAccepts()
        {
            string message;
            var validator = new InputOptionsValidator(options);
            if (!validator.IsValid(out message))
            {
                Console.WriteLine(message);
                return false;
            }
            return true;
        }
    }

    public class UnknownAlgorithmException : Exception
    {
    }
}