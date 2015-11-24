using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IWordsExtractor
    {
        IEnumerable<string> GetWords(string rawText);
    }
}