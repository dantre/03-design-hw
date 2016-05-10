using System;
using System.Collections.Generic;

namespace TagsCloud.Data.Frequencies
{
    public interface IFrequencyCounter
    {
       IList<WordIntPair> GetOrderedWordsFrequencies(IEnumerable<string> words);
    }
}