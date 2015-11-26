using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloud.Abstract
{
    public interface IAlgorithm
    {
        Bitmap GetBitmap(IEnumerable<Tuple<string, int>> fonts, Options options);
    }
}