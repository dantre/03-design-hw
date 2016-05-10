using System.Collections.ObjectModel;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using NSubstitute;
using TagsCloud;
using TagsCloud.Data.Readers;
using TagsCloud.Generator;
using TagsCloud.NInject;
using TagsCloud.Options;


namespace Tests
{
    [TestClass]
    public class TagsCloudGenerator_Tests
    {
        private InputOptions options;
        private TagCloudGenerator generator;
        [TestInitialize]
        public void Init()
        {
            options = new InputOptions
            {
                Width = 200,
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
            generator = new TagCloudGenerator(options);
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownAlgorithmException))]
        public void Generate_on_algorithm_name_ASD_should_throw_unknown_algorithm_ecxeption()
        {
            options.AlgorithmName = "ASD";
            generator.Generate();
        }

        [TestMethod]
        public void  Generate_on_options_height_100_should_return_bitmap_with_height_100()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(100, bitmap.Height);
        }

        [TestMethod]
        public void Generate_on_options_width_100_should_return_bitmap_with_width_200()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(200, bitmap.Width);
        }

        [TestMethod]
        public void Generate_on_backgroundColor_Red_should_return_bitmap_with_first_pixel_Red()
        {
            var bitmap = generator.Generate();
            Assert.AreEqual(Color.FromArgb(255, 255, 0, 0), bitmap.GetPixel(0, 0));
        }

        [TestMethod]
        public void Generate_on_textColor_Yellow_should_contains_Yellow_pixel()
        {
            var bitmap = generator.Generate();
            var pixels = new Collection<Color>();
            for (int i = 1; i < bitmap.Width; i++)
                for (int j = 1; j < bitmap.Height; j++)
                {
                    pixels.Add(bitmap.GetPixel(i,j));
                }
            CollectionAssert.Contains(pixels, Color.FromArgb(255, 255, 255, 0));
        }
    }
}
