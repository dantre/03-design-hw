using System;

namespace WordsCloud
{
    public interface IFontProcessor
    {
        Tuple<string, int>[] GetFonts(Tuple<string, int>[] words, int minFont, int maxFont);
    }
}