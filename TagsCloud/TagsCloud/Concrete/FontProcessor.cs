using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Concrete
{
    public class FontProcessor
    {
        public IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, int maxFont, int minFont)
        {
            int minCount = words.Min(t => t.Item2);
            int maxCount = words.Max(t => t.Item2);
            return words.Select(tuple => Tuple.Create(tuple.Item1, CountFont(tuple.Item2, maxFont, minFont, minCount, maxCount)));
        }

        private int CountFont(int count, int maxFont, int minFont, int minCount, int maxCount)
        {
            if (maxCount == minCount)
                return (maxFont + minFont)/2;
            return minFont + (int) Math.Ceiling((maxFont - minFont) * (count - minCount) * 1.0 / (maxCount - minCount));
        }
    }
}