using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCloud.Concrete.DataProcessors
{
    public class DataProcessorFromRawText : IDataProcessor
    {
        public Tuple<string, int>[] GetWordFrequencies(IEnumerable<string> lines)
        {
            return Regex.Split(string.Join(" ", lines), @"\W+")
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower())
                .GroupBy(w => w)
                .Select(w => Tuple.Create(w.Key, w.Count()))
                .OrderByDescending(tuple => tuple.Item2)
                .ToArray();
        }
    }
}
