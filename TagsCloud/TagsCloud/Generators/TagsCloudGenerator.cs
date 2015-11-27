using System.Drawing;
using Ninject;
using TagsCloud.Abstract;

namespace TagsCloud.Generators
{
    public class TagsCloudGenerator
    {
        
        private readonly Options options;

        public TagsCloudGenerator(Options options)
        {
            this.options = options;
        }

        public Bitmap Generate()
        {
            var text = Program.AppKernel.Get<IFileReader>().GetRawText(options.InputFile);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var filteredWords = Program.AppKernel.Get<IWordsFilter>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IFrequencyCounter>().GetWordsFrequencies(filteredWords);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, options);
            var image = Program.AppKernel.Get<IAlgorithm>(options.AlgorithmName).GetBitmap(fonts, options);
            return image;
        }
    }
}