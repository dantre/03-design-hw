using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsCloud.Concrete
{
    public class FontProcessor : IFontProcessor
    {
        public IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, Settings settings)
        {
            int minCount = words.Min(t => t.Item2);
            int maxCount = words.Max(t => t.Item2);
            return words.Select(tuple => Tuple.Create(tuple.Item1, CountFont(tuple.Item2, settings.MaxFont, settings.MinFont, minCount, maxCount)));
        }

        private int CountFont(int count, int maxFont, int minFont, int minCount, int maxCount)
        {
            return  minFont + (int) Math.Ceiling((maxFont-minFont)*(count - minCount)*1.0/(maxCount - minCount));
        }
    }
}