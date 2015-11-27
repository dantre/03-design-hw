using System;
using System.Collections.Generic;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsOnePerLineExtractorWindowsStyle : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            return rawText.Split(new[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
