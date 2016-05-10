using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using TagsCloud.Data;
using TagsCloud.Options;

namespace TagsCloud.Bitmap
{
    public static class BitmapMethods
    {
        public static IEnumerable<System.Drawing.Bitmap> GetTextImages(IList<WordIntPair> fonts, InputOptions options)
        {
            var mixedFonts = fonts.OrderBy(e => Guid.NewGuid());
            return mixedFonts.Select(tuple => CreateBitmapImage(tuple.Word, tuple.Number, options));
        }

        public static System.Drawing.Bitmap CreateBitmapImage(string text, int size, InputOptions options)
        {
            System.Drawing.Bitmap objBmpImage = new System.Drawing.Bitmap(1, 1);
            Font objFont = new Font(options.FontName, size, FontStyle.Bold, GraphicsUnit.Pixel);
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            int width = (int)objGraphics.MeasureString(text, objFont).Width;
            int height = (int)objGraphics.MeasureString(text, objFont).Height;

            objBmpImage = new System.Drawing.Bitmap(objBmpImage, new Size(width, height));

            objGraphics = Graphics.FromImage(objBmpImage);

            objGraphics.Clear(ColorTranslator.FromHtml(options.BackgroundColor));
            objGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            objGraphics.DrawString(text, objFont, new SolidBrush(ColorTranslator.FromHtml(options.TextColor)), 0, 0);
            objGraphics.Flush();

            return (objBmpImage);
        }

        public static System.Drawing.Bitmap CopyRegionIntoImage(System.Drawing.Bitmap srcBitmap, Rectangle srcRegion, System.Drawing.Bitmap destBitmap, Rectangle destRegion)
        {
            using (Graphics graphics = Graphics.FromImage(destBitmap))
            {
                graphics.DrawImage(srcBitmap, destRegion, srcRegion, GraphicsUnit.Pixel);
            }
            return destBitmap;
        }

        public static System.Drawing.Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new System.Drawing.Bitmap(width, height);

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
