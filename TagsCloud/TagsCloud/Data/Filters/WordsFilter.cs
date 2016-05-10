using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Data.Filters
{
    public class WordsFilter : IWordsFilter
    {
        private static HashSet<string> BadWords => new HashSet<string> { "a", "the", "and", "or", "I", "in", "out", "under", "between"};

        public IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words.Where(IsValidWord);
        }

        private bool IsValidWord(string word)
        {
            return !BadWords.Contains(word);
        }
    }
}
