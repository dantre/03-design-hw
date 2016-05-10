using System;
using System.Collections.Generic;

namespace TagsCloud.Bitmap.Algorithms
{
    public interface IAlgorithm
    {
        System.Drawing.Bitmap GetBitmap(IEnumerable<Tuple<string, int>> fonts, InputOptions options);
    }
}