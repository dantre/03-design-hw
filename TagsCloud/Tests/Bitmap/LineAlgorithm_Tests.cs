using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data;
using TagsCloud.Options;


namespace Tests.Bitmap
{
    [TestClass]
    class LineAlgorithm_Tests
    {
        public List<WordIntPair> fonts;
        public InputOptions options;
        public IAlgorithm algorithm;

        [TestInitialize]
        public void Init()
        {
            fonts = new List<WordIntPair>
            {
                new WordIntPair("a", 10)
            };
            options = new InputOptions
            {
                Width  = 100,
                Height = 100,
                FontName = "Arial",
                MinFont = 10,
                MaxFont = 40,
                BackgroundColor = "Red",
                TextColor = "Yellow"
            };
            algorithm = new LineAlgorithm();
        }

      /*  [TestMethod]
        public void GetBitmap_should_return_bitmap()
        {
            var result = algorithm.GetBitmap(fonts, options).;

            Assert.AreEqual(typeof(System.Drawing.Bitmap), result.GetType());
        }*/

        [TestMethod]
        public void GetBitmap_should_return_bitmap_with_width_eq_100()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(result.Width, 100);
        }

        [TestMethod]
        public void GetBitmap_should_return_bitmap_with_height_eq_100()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(result.Height, 100);
        }

        [TestMethod]
        public void GetBitmap_returns_first_pixel_in_background_color()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), result.GetPixel(0, 0));
        }
    }
}
