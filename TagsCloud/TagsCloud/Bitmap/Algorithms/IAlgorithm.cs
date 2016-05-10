using System.Collections.Generic;
using TagsCloud.Data;
using TagsCloud.Options;

namespace TagsCloud.Bitmap.Algorithms
{
    public interface IAlgorithm
    {
        System.Drawing.Bitmap GetBitmap(IList<WordIntPair> fonts, InputOptions options);
    }
}