using System.Collections.Generic;

namespace TagsCloud.Data.WordsExtractors
{
    public interface IWordsExtractor
    {
        IEnumerable<string> GetWords(string rawText);
    }
}