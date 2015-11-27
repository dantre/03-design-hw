using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Ninject;
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
                var generator = new TagsCloudGenerator(options);
                Image image;
                try
                {
                    image = generator.Generate();
                }
                // CR (krait): Эта логика должна быть внутри генератора. Причем обернут должен быть только один вызов Get, потому что если вдруг всплывёт какой-то косяк с другими регистрациями, эксепшн не должен пойматься.
                // CR (krait): Но сообщение должно печататься здесь. Можно пробрасывать сюда новый, специальный эксепшн или возвращать ошибку.
                catch (ActivationException) 
                {
                    Console.WriteLine("Unknown algorithm");
                    return;
                }
                image.Save(options.OutputFile, ImageFormat.Png);
            }
        }
    }
}