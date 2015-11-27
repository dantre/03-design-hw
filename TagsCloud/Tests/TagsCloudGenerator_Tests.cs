using System.Drawing;
using Ninject;
using TagsCloud;
using TagsCloud.Generators;
using NUnit.Framework;
using Tests.NInject;

namespace Tests
{
    [TestFixture]
    class TagsCloudGenerator_Tests
    {
        // CR (krait): Зачем поля публичные? Относится ко всем тестам.
        public Options options;
        public TagsCloudGenerator generator;
        [SetUp]
        public void Init()
        {
            options = new Options()
            {
                Width = 100,
                Height = 100,
                FontName = "Arial",
                MinFont = 10,
                MaxFont = 40,
                BackgroundColor = "Red",
                TextColor = "Yellow",
                InputFile = "simple.txt",
                OutputFile = "result.png",
                AlgorithmName = "Column"
            };
            generator = new TagsCloudGenerator(options);
            Program.AppKernel = new StandardKernel(new TestModule());
        }

        [Test]
        public void Generate_returns_bitmap()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(typeof(Bitmap), bitmap.GetType());
        }

        [Test]
        public void Generate_returns_bitmap_height_100()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(100, bitmap.Height);
        }

        [Test]
        public void Generate_returns_bitmap_with_first_pixel_green()
        {
            var bitmap = generator.Generate();
            // CR (krait): Это не green :)
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(0, 0));
        }
    }
}
