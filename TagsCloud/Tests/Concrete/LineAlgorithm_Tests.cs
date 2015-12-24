using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Concrete.Algorithms;

namespace Tests.Concrete
{
    [TestFixture]
    class LineAlgorithm_Tests
    {
        public List<Tuple<string, int>> fonts;
        public InputOptions inputOptions;
        public Func<IEnumerable<Tuple<string, int>>, Bitmap> GetBitmap;

        [SetUp]
        public void Init()
        {
            fonts = new List<Tuple<string, int>>
            {
                Tuple.Create("a", 10)
            };
            inputOptions = new InputOptions
            {
                Width  = 100,
                Height = 100,
                FontName = "Arial",
                MinFont = 10,
                MaxFont = 40,
                BackgroundColor = "Red",
                TextColor = "Yellow"
            };
            GetBitmap = new LineAlgorithm(inputOptions).GetBitmap;
        }

        [Test]
        public void GetBitmap_should_return_bitmap()
        {
            var result = GetBitmap(fonts);

            Assert.AreEqual(typeof(Bitmap), result.GetType());
        }

        [Test]
        public void GetBitmap_should_return_bitmap_with_width_eq_100()
        {
            var result = GetBitmap(fonts);

            Assert.AreEqual(result.Width, 100);
        }

        [Test]
        public void GetBitmap_should_return_bitmap_with_height_eq_100()
        {
            var result = GetBitmap(fonts);

            Assert.AreEqual(result.Height, 100);
        }

        [Test]
        public void GetBitmap_returns_first_pixel_in_background_color()
        {
            var result = GetBitmap(fonts);

            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), result.GetPixel(0, 0));
        }
    }
}
