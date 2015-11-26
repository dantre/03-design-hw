using System;
using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IFrequencyCounter
    {
        Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words);
    }
}