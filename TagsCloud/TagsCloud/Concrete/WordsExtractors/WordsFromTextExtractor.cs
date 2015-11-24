using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsFromTextExtractor : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            return Regex.Split(rawText, @"\W+")
                .Where(word => !string.IsNullOrEmpty(word));
        }
    }
}
