using System;
using System.Drawing;

namespace WordsCloud
{
    public interface IAlgorithm
    {
        Bitmap GetTagsCloud(Tuple<string, int>[] fonts);
    }
}