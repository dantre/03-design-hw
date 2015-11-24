using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloud;

namespace WordsCloud.Concrete.Algorithms
{
    class LineAlgorithm : IAlgorithm
    {
        public Bitmap GetImage(IEnumerable<Tuple<string, int>> fonts, Options options)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, options);
            int maxHeight = textImages.Max(i => i.Height);
            int sumWidth = textImages.Sum(i => i.Width);
            var resultImage = new Bitmap( sumWidth, maxHeight);
            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(Color.FromName(options.FontColor));
            objGraphics.Flush();

            int x = 0;
            int y = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0,0, image.Width,image.Height), resultImage, new Rectangle(x, (maxHeight-image.Height)/2, image.Width,image.Height));
                x += image.Width;
            }
            return resultImage;
        }
    }
}
