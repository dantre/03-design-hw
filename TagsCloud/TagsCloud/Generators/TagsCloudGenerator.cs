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
            return null;
//            return kernel.GetBitmap(
//                    kernel.CountFonts(
//                        kernel.CountFrequencies(
//                            kernel.FilterWords(
//                                kernel.ExtractWords(
//                                    kernel.ReadText(inputOptions.InputFile)))),
//                            inputOptions.MaxFont, 
//                            inputOptions.MinFont),
//                        inputOptions.FontName,
//                        inputOptions.BackgroundColor,
//                        inputOptions.TextColor,
//                        inputOptions.Width,
//                        inputOptions.Height);
        }
    }
}