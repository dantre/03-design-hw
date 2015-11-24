using System;
using System.Collections.Generic;

namespace TagsCloud.Abstract
{
    public interface IFontProcessor
    {
        IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, Options options);
    }
}