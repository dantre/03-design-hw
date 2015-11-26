using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Ninject;
using TagsCloud.Abstract;
using TagsCloud.Generators;

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
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (!File.Exists(options.InputFile))
                {
                    Console.WriteLine("File not found.");
                    return;
                }
                var generator = new TagsCloudGenerator(options.InputFile, options);
                Image image;
                try
                {
                    image = generator.Generate();
                }
                catch (ActivationException exception)
                {
                    Console.WriteLine("Unknown algorithm");
                    return;
                }
                image.Save(options.OutputFile, ImageFormat.Png);
            }
        }
    }
}