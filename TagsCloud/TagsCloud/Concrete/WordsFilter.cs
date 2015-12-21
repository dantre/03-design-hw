using System.Collections.Generic;
using System.Linq;

namespace TagsCloud.Concrete
{
    public class WordsFilter
    {
        private static HashSet<string> BadWords => new HashSet<string> { "a", "the", "and", "or", "I", "in", "out", "under", "between"};

        public static IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words.Where(IsValid);
        }

        private static bool IsValid(string arg)
        {
            return !BadWords.Contains(arg);
        }
    }
}
