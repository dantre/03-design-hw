using System;
using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    // CR (krait): Название этого интерфейса не делает понятным его назначение.
    public interface IDataProcessor
    {
        Tuple<string, int>[] GetWordsFrequencies(IEnumerable<string> words);
    }
}