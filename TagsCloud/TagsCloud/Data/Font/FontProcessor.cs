using System;
using System.Collections.Generic;
using System.Linq;
using TagsCloud.Options;

namespace TagsCloud.Data.Font
{
    public class FontProcessor : IFontProcessor
    {
        private int CountFont(int count, int maxFont, int minFont, int minCount, int maxCount)
        {
            if (maxCount == minCount)
                return (maxFont + minFont)/2;
            return minFont + (int) Math.Ceiling((maxFont - minFont) * (count - minCount) * 1.0 / (maxCount - minCount));
        }

        public IList<WordIntPair> GetFontSizes(IList<WordIntPair> wordsAndFreqs, InputOptions options)
        {
            int minCount = wordsAndFreqs.Min(t => t.Number);
            int maxCount = wordsAndFreqs.Max(t => t.Number);
            return wordsAndFreqs.Select(tuple => new WordIntPair(
                tuple.Word, 
                CountFont(tuple.Number, options.MaxFont, options.MinFont, minCount, maxCount)))
                .ToList();
        }
    }
}