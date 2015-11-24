using System.Collections.Generic;

namespace WordsCloud
{
    public interface IWordsExtractor
    {
        IEnumerable<string> GetWords(string rawText);
    }
}