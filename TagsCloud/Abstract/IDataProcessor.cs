using System;
using System.Collections.Generic;

namespace WordsCloud
{
    public interface IDataProcessor
    {
        Tuple<string, int>[] GetWordFrequencies(IEnumerable<string> lines);
    }
}