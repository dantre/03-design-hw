﻿using System;
using System.Drawing.Imaging;
using Ninject;

namespace WordsCloud
{
    public class TagsCloudGenerator
    {
        private readonly string filename;
        private readonly Settings settings;

        public TagsCloudGenerator(string filename, Settings settings)
        {
            this.filename = filename;
            this.settings = settings;
        }

        public void Generate()
        {
            var text = Program.AppKernel.Get<IDataExtractor>().GetRawText(filename);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var wordsWithoutRepeats = Program.AppKernel.Get<IWordsModifier>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IDataProcessor>().GetWordsFrequencies(wordsWithoutRepeats);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, settings);
            var image = Program.AppKernel.Get<IAlgorithm>().GetImage(fonts, settings);
            image.Save("result.png", ImageFormat.Png);
        }

//        public void Generate()
//        {
//            var lines = Program.AppKernel.Get<IDataExtractor>().GetRawText(filename);
//            var freqs = Program.AppKernel.Get<IDataProcessor>().GetWordsFrequencies(lines);
//            freqs = Program.AppKernel.Get<IDataModifier>().RemoveBadWords(freqs);
//            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(freqs, settings);
//            var image = Program.AppKernel.Get<IAlgorithm>().GetImage(fonts, settings);
//            image.Save("result.png", ImageFormat.Png);
//        }
    }
}