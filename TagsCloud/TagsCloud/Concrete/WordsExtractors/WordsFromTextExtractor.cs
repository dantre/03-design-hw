using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TagsCloud.Concrete.WordsExtractors
{
    public class WordsFromTextExtractor
    {
        public static IEnumerable<string> GetWords(string rawText)
        {
            return Regex.Split(rawText, @"\W+")
                .Where(word => !string.IsNullOrEmpty(word));
        }
    }
}
