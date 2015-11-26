using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IWordsFilter
    {
        IEnumerable<string> RemoveBadWords(IEnumerable<string> words);
    }
}