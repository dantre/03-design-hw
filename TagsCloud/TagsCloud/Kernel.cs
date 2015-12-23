using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Concrete;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud
{
    public class Kernel
    {
        public readonly Func<string, string> ReadText;
        public readonly Func<string, IEnumerable<string>> ExtractWords;
        public readonly Func<IEnumerable<string>, IEnumerable<string>> FilterWords;
        public readonly Func<IEnumerable<string>, Tuple<string, int>[]> CountFrequencies;
        public readonly Func<Tuple<string, int>[], int, int, IEnumerable<Tuple<string, int>>> CountFonts;
        public readonly Func<IEnumerable<Tuple<string, int>>, string, string, string, int, int, Bitmap> GetBitmap;
        
        public Kernel(InputOptions inputOptions)
        {
            ReadText = new TxtReader().GetRawText;
            ExtractWords = new WordsFromTextExtractor().GetWords;
            FilterWords = new WordsFilter().RemoveBadWords;
            CountFrequencies = new FrequencyCounter().GetWordsFrequencies;
            CountFonts = new FontProcessor().GetFonts;
            GetBitmap = new AlgorithmsNames().GetAlgorithmByName(inputOptions.AlgorithmName);
        }

        public Kernel(InputOptions inputOptions, Func<string, string> readerFunc)
        {
            ReadText = readerFunc;
            ExtractWords = new WordsFromTextExtractor().GetWords;
            FilterWords = new WordsFilter().RemoveBadWords;
            CountFrequencies = new FrequencyCounter().GetWordsFrequencies;
            CountFonts = new FontProcessor().GetFonts;
            GetBitmap = new AlgorithmsNames().GetAlgorithmByName(inputOptions.AlgorithmName);
        }
    }
}
