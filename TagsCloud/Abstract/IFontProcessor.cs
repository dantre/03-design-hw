using System;
using System.Collections.Generic;

namespace WordsCloud
{
    public interface IFontProcessor
    {
        IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, Settings settings);
    }
}