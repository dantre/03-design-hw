using System;
using System.Collections.Generic;

namespace WordsCloud.Concrete.WordsExtractors
{
    public class WordsOnePerLineExtractor : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            return rawText.Split(new[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
