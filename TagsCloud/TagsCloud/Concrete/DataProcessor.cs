using System;
using System.Collections.Generic;
using System.Linq;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class DataProcessor: IDataProcessor
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
