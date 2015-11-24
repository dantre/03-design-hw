using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;

namespace WordsCloud.Concrete.Algorithms
{
    class LineAlgorithm : IAlgorithm
    {
        public Bitmap GetImage(IEnumerable<Tuple<string, int>> fonts, Options options)
        {

            var textImages = GetTextImages(fonts, options);
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
                resultImage = CopyRegionIntoImage(image, new Rectangle(0,0, image.Width,image.Height), resultImage, new Rectangle(x, (maxHeight-image.Height)/2, image.Width,image.Height));
                x += image.Width;
            }
            return resultImage;
        }

        public IEnumerable<Bitmap> GetTextImages(IEnumerable<Tuple<string, int>> fonts, Options options)
        {
            var mixedFonts = fonts.OrderBy(e => Guid.NewGuid());
            return mixedFonts.Select(tuple => CreateBitmapImage(tuple.Item1, tuple.Item2, options));
        }

        private Bitmap CreateBitmapImage(string text, int size, Options options)
        {
            Bitmap objBmpImage = new Bitmap(1, 1);

            int intWidth = 0;
            int intHeight = 0;

            Font objFont = new Font(options.FontName, size, FontStyle.Bold, GraphicsUnit.Pixel);

            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            intWidth = (int)objGraphics.MeasureString(text, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(text, objFont).Height;

            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            objGraphics = Graphics.FromImage(objBmpImage);

            objGraphics.Clear(Color.FromName(options.FontColor));
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(text, objFont, new SolidBrush(Color.FromName(options.TextColor)), 0, 0);
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
