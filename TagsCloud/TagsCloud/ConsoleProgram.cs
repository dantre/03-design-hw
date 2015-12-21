using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http;
using CommandLine;
using TagsCloud.Generators;

namespace TagsCloud
{
    public class ConsoleProgram
    {
        private string[] args;
        private InputOptions inputOptions;
        private Kernel kernel;

        public ConsoleProgram(string[] args)
        {
            this.args = args;
            inputOptions = new InputOptions();
            kernel = new Kernel();
        }

        public void Run()
        {
            if (!Parser.Default.ParseArguments(args, inputOptions)) return;

            string errorMessage;
            if (!OptionsValidator.IsValid(inputOptions, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                return;
            }
            kernel = OptionsValidator.UpdateAlgoInKernel(inputOptions, kernel);

            Image image = new TagsCloudGenerator(inputOptions, kernel).Generate();
            image.Save(inputOptions.OutputFile, ImageFormat.Png);
        }
    }
}