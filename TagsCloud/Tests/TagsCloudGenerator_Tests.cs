using System.Drawing;
using Ninject;
using NSubstitute;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Data.Readers;
using TagsCloud.NInject;

namespace Tests
{
    [TestFixture]
    class TagsCloudGenerator_Tests
    {
        private InputOptions options;
        private TagsCloudGenerator generator;
        [SetUp]
        public void Init()
        {
            options = new InputOptions
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
            Program.AppKernel = new StandardKernel(new BindingModule());
            var reader = Substitute.For<IFileReader>();
            reader.GetRawText("test").Returns("test text");
            Program.AppKernel.Unbind<IFileReader>();
            Program.AppKernel.Bind<IFileReader>().ToConstant(reader);
            generator = new TagsCloudGenerator(options);
        }

        [Test]
        public void Generate_should_return_bitmap()
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
    }
}
