using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloud.Data;
using TagsCloud.Options;

namespace TagsCloud.Bitmap.Algorithms
{
    public class ColumnsAlgorithm : IAlgorithm
    {
        public System.Drawing.Bitmap GetBitmap(IList<WordIntPair> fonts, InputOptions options)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, options).ToList();
            int maxHeight = textImages.Max(i => i.Height);
            int sumWidth = textImages.Sum(i => i.Width);

            int countLines = Math.Max(5, sumWidth / 1024);
            int lineWidth = sumWidth / countLines;

            var resultImage = new System.Drawing.Bitmap(lineWidth + 100, maxHeight * countLines);
            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(ColorTranslator.FromHtml(options.BackgroundColor));
            objGraphics.Flush();

            int x = 0;
            int yAddition = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    resultImage, new Rectangle(x, (maxHeight - image.Height) / 2 + yAddition, image.Width, image.Height));
                x += image.Width;
                if (x > lineWidth)
                {
                    x = 0;
                    yAddition += maxHeight;
                }
            }

            return BitmapMethods.ResizeImage(resultImage, options.Width, options.Height);
        }
    }
}