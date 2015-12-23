using System;
using System.Drawing;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Generators;

namespace Tests
{
    [TestFixture]
    class TagsCloudGenerator_Tests
    {
        private InputOptions inputOptions;
        private TagsCloudGenerator generator;
        private Kernel kernel;

        [SetUp]
        public void Init()
        {
            inputOptions = new InputOptions
            {
                Width = 100,
                Height = 100,
                FontName = "Arial",
                MinFont = 10,
                MaxFont = 40,
                BackgroundColor = "Red",
                TextColor = "Yellow",
                InputFile = "test",
                OutputFile = "result.png",
                AlgorithmName = "Column"
            };
            
            kernel = new Kernel(inputOptions, new Func<string, string>(FakeReader));
            generator = new TagsCloudGenerator(inputOptions, kernel);
        }

        [Test]
        public void Generate_should_return_something()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(typeof(Bitmap), bitmap.GetType());
        }

        [Test]
        public void  Generate_should_return_bitmap_with_height_100()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(100, bitmap.Height);
        }

        [Test]
        public void Generate_should_return_bitmap_with_first_pixel_red()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(0, 0));
        }

        public string FakeReader(string filename)
        {
            return "A B C D";
        }
    }
}
