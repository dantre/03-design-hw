using System;
using System.Collections.Generic;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsOnePerLineExtractor : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            // CR (krait): А что если файл в Unix-стиле и строки резделены только \n?
            return rawText.Split(new[] { @"\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
