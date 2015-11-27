using System;
using System.Collections.Generic;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsOnePerLineExtractor : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            rawText = rawText.Replace(@"\r\n", @"\n");
            return rawText.Split(new[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
