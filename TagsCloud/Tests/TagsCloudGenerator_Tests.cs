using System.Drawing;
using Ninject;
using NSubstitute;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Abstract;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;
using TagsCloud.Generators;

namespace Tests
{
    [TestFixture]
    class TagsCloudGenerator_Tests
    {
        private Options options;
        private TagsCloudGenerator generator;
        [SetUp]
        public void Init()
        {
            options = new Options
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
            Program.AppKernel = new StandardKernel();
            var reader = NSubstitute.Substitute.For<IFileReader>();
            reader.GetRawText("test").Returns("test text");
            Program.AppKernel.Bind<IFileReader>().ToConstant(reader);
            Program.AppKernel.Bind<IWordsExtractor>().To<WordsFromTextExtractor>();
            Program.AppKernel.Bind<IWordsFilter>().To<WordsFilter>();
            Program.AppKernel.Bind<IFrequencyCounter>().To<FrequencyCounter>();
            Program.AppKernel.Bind<IFontProcessor>().To<FontProcessor>();
            Program.AppKernel.Bind<IAlgorithm>().To<ColumnsAlgorithm>().Named("Column");
            Program.AppKernel.Bind<IAlgorithm>().To<LineAlgorithm>().Named("Line");
            generator = new TagsCloudGenerator(options);
        }

        [Test]
        public void TagsCloudGenerator_Generate_should_return_bitmap()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(typeof(Bitmap), bitmap.GetType());
        }

        [Test]
        public void TagsCloudGenerator_Generate_should_return_bitmap_with_height_100()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(100, bitmap.Height);
        }

        [Test]
        public void TagsCloudGenerator_Generate_should_return_bitmap_with_first_pixel_red()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(0, 0));
        }
    }
}
