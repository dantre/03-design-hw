using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloud.Concrete.Algorithms
{
    public class LineAlgorithm 
    {
        public static Bitmap GetBitmap(IEnumerable<Tuple<string, int>> fonts, InputOptions _inputOptions)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, _inputOptions).ToList();
            int maxHeight = textImages.Max(i => i.Height);
            var resultImage = new Bitmap(textImages.Sum(i => i.Width), maxHeight);

            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(Color.FromName(_inputOptions.BackgroundColor));
            objGraphics.Flush();

            int x = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    resultImage, new Rectangle(x, (maxHeight - image.Height) / 2, image.Width, image.Height));
                x += image.Width;
            }
            return BitmapMethods.ResizeImage(resultImage, _inputOptions.Width, _inputOptions.Height);
        }
    }
}
