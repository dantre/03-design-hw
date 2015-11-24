using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;

namespace TagsCloud
{
    public static class BitmapMethods
    {
        public static IEnumerable<Bitmap> GetTextImages(IEnumerable<Tuple<string, int>> fonts, Options options)
        {
            var mixedFonts = fonts.OrderBy(e => Guid.NewGuid());
            return mixedFonts.Select(tuple => CreateBitmapImage(tuple.Item1, tuple.Item2, options));
        }

        private static Bitmap CreateBitmapImage(string text, int size, Options options)
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
            using (Graphics graphics = Graphics.FromImage(destBitmap))
            {
                graphics.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
            return destBitmap;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
