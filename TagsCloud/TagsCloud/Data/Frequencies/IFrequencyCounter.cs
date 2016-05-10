using System;
using System.Collections.Generic;

namespace TagsCloud.Data.Frequencies
{
    public interface IFrequencyCounter
    {
        Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words);
    }
}