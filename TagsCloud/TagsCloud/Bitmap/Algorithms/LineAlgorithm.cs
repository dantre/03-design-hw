using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloud.Data;
using TagsCloud.Options;

namespace TagsCloud.Bitmap.Algorithms
{
    public class LineAlgorithm : BaseAlgorithm
    {
        private int maxHeight;
        private int sumWidth;

        public override System.Drawing.Bitmap GetBitmap(IList<WordIntPair> fonts, InputOptions options)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, options).ToList();
            CountVariables(textImages);

            var resultImage = new System.Drawing.Bitmap( sumWidth, maxHeight);
            FillBackgroundColor(resultImage, options.BackgroundColor);
            FillImagesWithWordsImages(resultImage, textImages);
            return BitmapMethods.ResizeImage(resultImage, options.Width, options.Height);
        }

        private void FillImagesWithWordsImages(System.Drawing.Bitmap resultImage, List<System.Drawing.Bitmap> textImages)
        {
            int x = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    resultImage, new Rectangle(x, (maxHeight - image.Height) / 2, image.Width, image.Height));
                x += image.Width;
            }
        }

        private void CountVariables(List<System.Drawing.Bitmap> textImages)
        {
            maxHeight = textImages.Max(i => i.Height);
            sumWidth = textImages.Sum(i => i.Width);
        }
    }
}
