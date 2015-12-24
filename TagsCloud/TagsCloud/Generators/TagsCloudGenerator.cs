using System.Drawing;

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
            return kernel.GetBitmap(
                    kernel.CountFonts(
                        kernel.CountFrequencies(
                            kernel.FilterWords(kernel.ExtractWords(
                                kernel.ReadText(inputOptions.InputFile))))));
        }
    }
}