using System.Collections.Generic;

namespace TagsCloud.Data.Filters
{
    public interface IWordsFilter
    {
        IEnumerable<string> RemoveBadWords(IEnumerable<string> words);
    }
}