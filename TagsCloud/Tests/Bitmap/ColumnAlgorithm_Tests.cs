﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data;
using TagsCloud.Options;

namespace Tests.Bitmap
{
    [TestClass]
    public class ColumnsAlgorithm_Tests
    {
        public List<WordIntPair> fonts;
        public InputOptions options;
        public IAlgorithm algorithm;

        [TestInitialize]
        public void Init()
        {
            fonts = new List<WordIntPair>
            {
                new WordIntPair("some", 3),
                new WordIntPair("Text", 10)
            };
            options = new InputOptions
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
        public void GetBitmap_on_backgroundColor_Red_should_return_bitmap_with_first_pixel_Red()
        {
            var result = algorithm.GetBitmap(fonts, options);
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), result.GetPixel(0, 0));
        }
    }
}
