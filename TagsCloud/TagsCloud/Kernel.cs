using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud
{
    class Kernel
    {
        public Func<string, string> readText;
        public Func<string, IEnumerable<string>> extractWords;
        public Func<IEnumerable<string>, IEnumerable<string>> fiterWords;
        public Func<IEnumerable<string>, Tuple<string, int>[]> countFrequencies;
        public Func<Tuple<string, int>[], InputOptions, IEnumerable<Tuple<string, int>>> countFonts;
        public Func<IEnumerable<Tuple<string, int>>, InputOptions, Bitmap> getBitmap;

        public Kernel()
        {
            readText = TxtReader.GetRawText;
            extractWords = WordsFromTextExtractor.GetWords;
            fiterWords = WordsFilter.RemoveBadWords;
            countFrequencies = FrequencyCounter.GetWordsFrequencies;
            countFonts = FontProcessor.GetFonts;
            getBitmap = ColumnsAlgorithm.GetBitmap;
        }
    }
}
