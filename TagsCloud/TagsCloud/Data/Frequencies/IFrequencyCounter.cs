using System.Collections.Generic;

namespace TagsCloud.Data.Frequencies
{
    public interface IFrequencyCounter
    {
       IList<WordIntPair> GetOrderedWordsAndFrequencies(IEnumerable<string> words);
    }
}