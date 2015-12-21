using System;
using System.Collections.Generic;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsOnePerLineExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            rawText = rawText.Replace(@"\r\n", @"\n");
            return rawText.Split(new[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
