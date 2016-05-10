using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Bitmap;
using TagsCloud.Options;

namespace Tests.Bitmap
{
    [TestClass]
    public class BitmapMethods_Test
    {
        [TestMethod]
        public void Resize_from_1x1_to_200x100_should_return_bitmap_with_width_200()
        {
            var image = new System.Drawing.Bitmap(1,1);
            var result = BitmapMethods.ResizeImage(image, 200, 100);
            Assert.AreEqual(200, result.Width);
        }

        [TestMethod]
        public void Resize_from_1x1_to_200x100_should_return_bitmap_with_height_100()
        {
            var image = new System.Drawing.Bitmap(1, 1);
            var result = BitmapMethods.ResizeImage(image, 200, 100);
            Assert.AreEqual(100, result.Height);
        }

        [TestMethod]
        public void CopyRegionIntoImage_should_copy_white_image_to_black_image()
        {
            var sourceImage = new System.Drawing.Bitmap(20, 20);
            using (Graphics graphics = Graphics.FromImage(sourceImage))
            {
                graphics.Clear(Color.Black);
            }
            var destImage = new System.Drawing.Bitmap(20, 20);
            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.Clear(Color.White);
            }

            destImage = BitmapMethods.CopyRegionIntoImage(sourceImage, new Rectangle(0, 0, 20, 20), destImage,
                new Rectangle(0, 0, 20, 20));
            Assert.AreEqual(Color.FromArgb(255,0,0,0), destImage.GetPixel(0,0));
        }
    }
}