using System.Drawing;
using Ninject;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud.Generators
{
    public class TagsCloudGenerator
    {
        private readonly InputOptions inputOptions;
        private readonly Kernel kernel;

        public TagsCloudGenerator(InputOptions inputOptions, Kernel kernel)
        {
            this.inputOptions = inputOptions;
            this.kernel = kernel;
        }

        public Bitmap Generate()
        {
            return kernel.getBitmap(
                kernel.countFonts(
                    kernel.countFrequencies(
                        kernel.fiterWords(
                            kernel.extractWords(
                                kernel.readText(inputOptions.InputFile)))),
                    inputOptions),
                inputOptions);
        }
    }
}