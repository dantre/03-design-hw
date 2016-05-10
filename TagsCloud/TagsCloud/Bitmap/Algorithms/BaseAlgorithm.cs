using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Data;
using TagsCloud.Options;

namespace TagsCloud.Bitmap.Algorithms
{
    public abstract class BaseAlgorithm : IAlgorithm
    {
        public abstract System.Drawing.Bitmap GetBitmap(IList<WordIntPair> fonts, InputOptions options);

        protected void FillBackgroundColor(System.Drawing.Bitmap resultImage, string backgroundColor)
        {
            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(ColorTranslator.FromHtml(backgroundColor));
            objGraphics.Flush();
        }
    }
}
