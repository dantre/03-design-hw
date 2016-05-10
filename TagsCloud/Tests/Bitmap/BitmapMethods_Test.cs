using System.Drawing;
using NUnit.Framework;
using TagsCloud.Bitmap;
using TagsCloud.Options;

namespace Tests.Bitmap
{
    [TestFixture]
    public class BitmapMethods_Test
    {
        [Test]
        public void Resize_should_resize_pixel_to_square()
        {
            var image = new System.Drawing.Bitmap(1,1);

            var result = BitmapMethods.ResizeImage(image, 20, 20);
            Assert.AreEqual(20, result.Height);
            Assert.AreEqual(20, result.Width);
        }

        [Test]
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

        [Test]
        public void CreateBitmapImage_chould_create_bitmap()
        {
            var result = BitmapMethods.CreateBitmapImage("some text", 20, new InputOptions {FontName = "Arial", TextColor = "Red", BackgroundColor = "Green"});

            Assert.AreEqual(typeof(System.Drawing.Bitmap), result.GetType());
        }
    }
}