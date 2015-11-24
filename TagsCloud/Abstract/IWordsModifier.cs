using System.Collections.Generic;

namespace WordsCloud
{
    public interface IWordsModifier
    {
        IEnumerable<string> RemoveBadWords(IEnumerable<string> words);
    }
}