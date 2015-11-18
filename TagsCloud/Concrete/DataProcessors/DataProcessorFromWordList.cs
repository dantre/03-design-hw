using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCloud.Concrete
{
    public class DataProcessorFromWordList : IDataProcessor
    {
        public Tuple<string, int>[] GetWordFrequencies(IEnumerable<string> lines)
        {
            return lines
                .Select(w => w.ToLower())
                .GroupBy(w => w)
                .Select(w => Tuple.Create(w.Key, w.Count()))
                .OrderByDescending(tuple => tuple.Item2)
                .ToArray();
        }
    }
}
