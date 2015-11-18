using System;
using System.Collections.Generic;
using System.Drawing;
using Ninject;
using Ninject.Modules;
using WordsCloud.Concrete;
using WordsCloud.Extractors;

namespace WordsCloud
{
    class Program
    {
        public static IKernel AppKernel;

        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new SimpleModule());
            string filename = "simple.txt";
//            var settings = new Settings() {TextColour = Color.Red, MinFont = 12, MaxFont = 25};
            var settings = new Settings() {MinFont = 12, MaxFont = 26, FontColour = Color.Blue, TextColour = Color.Orange};
            var generator = new TagsCloudGenerator(filename, settings);

        }
    }

    public class SimpleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataExtractor>().To<TxtExtractor>();
            Bind<IDataProcessor>().To<DataProcessorFromWordList>();
            Bind<IDataModifier>().To<EmptyDataModifier>();

        }
    }

    public class TagsCloudGenerator
    {
        private readonly string filename;
        private readonly Settings settings;
        public TagsCloudGenerator(string filename, Settings settings)
        {
            this.filename = filename;
            this.settings = settings;

        }

        public void Do()
        {
            var lines = Program.AppKernel.Get<IDataExtractor>().GetRawText(filename);
            var freqs = Program.AppKernel.Get<IDataProcessor>().GetWordFrequencies(lines);
            freqs = Program.AppKernel.Get<IDataModifier>().RemoveBadWords(freqs);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(freqs);
        }
    }


    public struct Settings
    {
        public int MinFont { get; set; }
        public int MaxFont { get; set; }
        public Color TextColour { get; set; }
        public Color FontColour { get; set; }
    }

    //    public Tuple<string, int>[] GetWordFrequencies()
//    {
//        return Regex.Split(rawText, @"\W+")
//            .Where(w => !string.IsNullOrEmpty(w))
//            .Select(w => w.ToLower())
//            .GroupBy(w => w)
//            .Select(w => Tuple.Create(w.Key, w.Count()))
//            .OrderByDescending(tuple => tuple.Item2)
//            .ToArray();
//    }
}

