using System;
using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Data.Frequencies
{
    public class FrequencyCounter: IFrequencyCounter
    {
        public Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words)
        {
            return words.Select(w => w.ToLower())
                .GroupBy(w => w)
                .Select(w => Tuple.Create(w.Key, w.Count()))
                .OrderByDescending(tuple => tuple.Item2)
                .ToArray();
        }
    }
}
