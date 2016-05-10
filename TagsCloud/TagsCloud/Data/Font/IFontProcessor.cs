using System;
using System.Collections.Generic;

namespace TagsCloud.Data.Font
{
    public interface IFontProcessor
    {
        IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, InputOptions options);
    }
}