using Ninject;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data.Filters;
using TagsCloud.Data.Font;
using TagsCloud.Data.Frequencies;
using TagsCloud.Data.Readers;
using TagsCloud.Data.WordsExtractors;

namespace TagsCloud
{
    public class TagsCloudGenerator
    {
        private readonly InputOptions options;

        public TagsCloudGenerator(InputOptions options)
        {
            this.options = options;
        }

        public System.Drawing.Bitmap Generate()
        {
            var text = Program.AppKernel.Get<IFileReader>().GetRawText(options.InputFile);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var filteredWords = Program.AppKernel.Get<IWordsFilter>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IFrequencyCounter>().GetWordsFrequencies(filteredWords);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, options);
            System.Drawing.Bitmap image;
            try
            {
                image = Program.AppKernel.Get<IAlgorithm>(options.AlgorithmName).GetBitmap(fonts, options);
            }
            catch (ActivationException)
            {
                throw new UnknownAlgorithmException();
            }
            return image;
        }
    }
}