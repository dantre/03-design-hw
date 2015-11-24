using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCloud.Concrete.WordsExtractors
{
    class WordsFromTextExtractor : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            return Regex.Split(rawText, @"\W+")
                .Where(word => !string.IsNullOrEmpty(word));
        }
    }
}
