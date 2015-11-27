using System.Collections.Generic;
using System.Linq;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class WordsFilter : IWordsFilter
    {
        // CR (krait): Поле можно сделать статическим. И List -- не самая подходящая структура данных для этого случая.
        private List<string> BadWords => new List<string> { "a", "the", "and", "or", "I", "in", "out", "under", "between"};

        public IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words.Where(IsValid);
        }

        private bool IsValid(string arg)
        {
            return !BadWords.Contains(arg);
        }
    }
}
