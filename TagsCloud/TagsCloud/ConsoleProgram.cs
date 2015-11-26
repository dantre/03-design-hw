using System;
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
                if (!Program.AppKernel.Get<IOptionsValidator>().IsValid(options))
                {
                    Console.WriteLine("Parameters are invalid.");
                    return;
                }
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