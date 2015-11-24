using System;
using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IDataProcessor
    {
        Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words);
    }
}