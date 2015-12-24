using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Concrete
{
    public class FontProcessor
    {
        private readonly int maxFont;
        private readonly int minFont;

        public FontProcessor(InputOptions inputOptions)
        {
            maxFont = inputOptions.MaxFont;
            minFont = inputOptions.MinFont;
        }

        public IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words)
        {
            int minCount = words.Min(t => t.Item2);
            int maxCount = words.Max(t => t.Item2);
            return words.Select(tuple => Tuple.Create(tuple.Item1, CountFont(tuple.Item2,  minCount, maxCount)));
        }

        private int CountFont(int count, int minCount, int maxCount)
        {
            if (maxCount == minCount)
                return (maxFont + minFont)/2;
            return minFont + (int) Math.Ceiling((maxFont - minFont) * (count - minCount) * 1.0 / (maxCount - minCount));
        }
    }
}