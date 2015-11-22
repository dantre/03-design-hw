using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCloud.Concrete.Algorithms
{
    class SimpleLineAlgorithm : IAlgorithm
    {
        public Bitmap GetImage(IEnumerable<Tuple<string, int>> fonts, Settings settings)
        {

            var textImages = GetTextImages(fonts, settings);
            int maxHeight = textImages.Max(i => i.Height);
            int sumWidth = textImages.Sum(i => i.Width);
            var resultImage = new Bitmap( sumWidth, maxHeight);
            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(settings.FontColour);
            objGraphics.Flush();

            int x = 0;
            int y = 0;
            foreach (var image in textImages)
            {
                resultImage = CopyRegionIntoImage(image, new Rectangle(0,0, image.Width,image.Height), resultImage, new Rectangle(x, (maxHeight-image.Height)/2, image.Width,image.Height));
                x += image.Width;
            }
            return resultImage;
        }

        public IEnumerable<Bitmap> GetTextImages(IEnumerable<Tuple<string, int>> fonts, Settings settings)
        {
            var mixedFonts = fonts.OrderBy(e => Guid.NewGuid());
            return mixedFonts.Select(tuple => CreateBitmapImage(tuple.Item1, tuple.Item2, settings));
        }

        private Bitmap CreateBitmapImage(string text, int size, Settings settings)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            Font objFont = new Font(settings.Font, size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            intWidth = (int)objGraphics.MeasureString(text, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(text, objFont).Height;

            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            objGraphics = Graphics.FromImage(objBmpImage);

            objGraphics.Clear(settings.FontColour);
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(text, objFont, new SolidBrush(settings.TextColour), 0, 0);
            objGraphics.Flush();

            return (objBmpImage);
        }

        public static Bitmap CopyRegionIntoImage(Bitmap srcBitmap, Rectangle srcRegion, Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics grD = Graphics.FromImage(destBitmap))
            {
                grD.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
            return destBitmap;
        }
    }
}
