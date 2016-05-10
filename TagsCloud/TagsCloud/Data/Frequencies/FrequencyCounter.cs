using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Data.Frequencies
{
    public class FrequencyCounter: IFrequencyCounter
    {
        public IList<WordIntPair> GetOrderedWordsFrequencies(IEnumerable<string> words)
        {
            return words.Select(w => w.ToLower())
                .GroupBy(w => w)
                .Select(grouping => new WordIntPair(grouping.Key, grouping.Count()))
                .OrderBy(pair => pair, WordIntPair.Comparer)
                .ToList();
        }
    }
}
