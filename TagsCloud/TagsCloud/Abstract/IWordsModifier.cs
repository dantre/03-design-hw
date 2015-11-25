using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    // CR (krait): По условию фильтрация по списку плохих слов входит в основные требования.
    // CR (krait): Название не совсем отражает суть происходящего. IWordsFilter?
    public interface IWordsModifier
    {
        IEnumerable<string> RemoveBadWords(IEnumerable<string> words);
    }
}