using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Abstract;
using TagsCloud.Concrete.Algorithms;

namespace Tests.Concrete
{
    [TestFixture]
    class ColumnsAlgorithm_Tests
    {
        public List<Tuple<string, int>> fonts;
        public Options options;
        public IAlgorithm algorithm;

        [SetUp]
        public void Init()
        {
            fonts = new List<Tuple<string, int>>
            {
                Tuple.Create("a", 10)
            };
            options = new Options
            {
                Width = 100,
                Height = 100,
                FontName = "Arial",
                MinFont = 10,
                MaxFont = 40,
                BackgroundColor = "Red",
                TextColor = "Yellow"
            };
            algorithm = new ColumnsAlgorithm();
        }

        [Test]
        public void ColumnsAlgorithm_GetBitmap_should_return_bitmap()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(typeof(Bitmap), result.GetType());
        }

        [Test]
        public void ColumnsAlgorithm_GetBitmap_should_return_bitmap_with_width_eq_100()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(result.Width, 100);
        }

        [Test]
        public void ColumnsAlgorithm_GetBitmap_should_return_bitmap_with_height_eq_100()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(result.Height, 100);
        }

        [Test]
        public void ColumnsAlgorithm_GetBitmap_should_return_first_pixel_in_background_color()
        {
            var result = algorithm.GetBitmap(fonts, options);

            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), result.GetPixel(0, 0));
        }
    }
}
