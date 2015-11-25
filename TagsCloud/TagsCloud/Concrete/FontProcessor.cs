using System;
using System.Collections.Generic;
using System.Linq;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class FontProcessor : IFontProcessor
    {
        public IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, Options options)
        {
            int minCount = words.Min(t => t.Item2);
            int maxCount = words.Max(t => t.Item2);
            return words.Select(tuple => Tuple.Create(tuple.Item1, CountFont(tuple.Item2, options.MaxFont, options.MinFont, minCount, maxCount)));
        }

        private int CountFont(int count, int maxFont, int minFont, int minCount, int maxCount)
        {
            return minFont + (int) Math.Ceiling((maxFont - minFont) * (count - minCount) * 1.0 / (maxCount - minCount));
        }
    }
}