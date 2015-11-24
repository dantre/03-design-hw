using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IWordsModifier
    {
        IEnumerable<string> RemoveBadWords(IEnumerable<string> words);
    }
}