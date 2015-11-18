using System;

namespace WordsCloud
{
    public interface IDataModifier
    {
        Tuple<string, int>[] RemoveBadWords(Tuple<string, int>[] words);
    }
}