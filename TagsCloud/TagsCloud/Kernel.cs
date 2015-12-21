using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud
{
    public class Kernel
    {
        public readonly Func<string, string> ReadText;
        public readonly Func<string, IEnumerable<string>> ExtractWords;
        public readonly Func<IEnumerable<string>, IEnumerable<string>> FiterWords;
        public readonly Func<IEnumerable<string>, Tuple<string, int>[]> CountFrequencies;
        public readonly Func<Tuple<string, int>[], InputOptions, IEnumerable<Tuple<string, int>>> CountFonts;
        public Func<IEnumerable<Tuple<string, int>>, InputOptions, Bitmap> GetBitmap;

        public Kernel()
        {
            ReadText = TxtReader.GetRawText;
            ExtractWords = WordsFromTextExtractor.GetWords;
            FiterWords = WordsFilter.RemoveBadWords;
            CountFrequencies = FrequencyCounter.GetWordsFrequencies;
            CountFonts = FontProcessor.GetFonts;
            GetBitmap = ColumnsAlgorithm.GetBitmap;
        }
    }
}
