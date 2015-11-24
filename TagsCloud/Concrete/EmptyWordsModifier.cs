using System.Collections.Generic;

namespace WordsCloud.Concrete
{
    public class EmptyWordsModifier : IWordsModifier
    {
        public IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words;
        }
    }
}
