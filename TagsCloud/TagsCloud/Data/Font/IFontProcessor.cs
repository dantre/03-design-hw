using System.Collections.Generic;
using TagsCloud.Options;

namespace TagsCloud.Data.Font
{
    public interface IFontProcessor
    {
        IList<WordIntPair> GetFontSizes(IList<WordIntPair> wordsAndFreqs, InputOptions options);
    }
}