using System.Collections.Generic;
using TagsCloud.Options;

namespace TagsCloud.Data.Font
{
    public interface IFontProcessor
    {
        IList<WordIntPair> GetFonts(IList<WordIntPair> wordsAndFreqs, InputOptions options);
    }
}