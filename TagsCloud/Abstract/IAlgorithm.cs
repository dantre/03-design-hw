using System;
using System.Collections.Generic;
using System.Drawing;

namespace WordsCloud
{
    public interface IAlgorithm
    {
        Bitmap GetImage(IEnumerable<Tuple<string, int>> fonts, Settings settings);
    }
}