using System;
using System.Drawing;
using System.Drawing.Imaging;
using CommandLine;
using TagsCloud.Generators;

namespace TagsCloud
{
    public class ConsoleProgram
    {
        private readonly string[] args;
        private readonly InputOptions inputOptions;
        private Kernel kernel;

        public ConsoleProgram(string[] args)
        {
            this.args = args;
            inputOptions = new InputOptions();
        }

        public void Run()
        {
            if (!Parser.Default.ParseArguments(args, inputOptions)) return;
            string errorMessage;
            if (!new OptionsValidator().IsValid(inputOptions, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }
            try
            {
                kernel = new Kernel(inputOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Image image = new TagsCloudGenerator(inputOptions, kernel).Generate();
            image.Save(inputOptions.OutputFile, ImageFormat.Png);
        }
    }
}