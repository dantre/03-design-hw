using System.Collections.Generic;
using Ninject;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data;
using TagsCloud.Data.Filters;
using TagsCloud.Data.Font;
using TagsCloud.Data.Frequencies;
using TagsCloud.Data.Readers;
using TagsCloud.Data.WordsExtractors;
using TagsCloud.Options;

namespace TagsCloud.Generator
{
    public class TagCloudGenerator
    {
        private readonly InputOptions options;

        public TagCloudGenerator(InputOptions options)
        {
            this.options = options;
        }

        public System.Drawing.Bitmap Generate()
        {
            var fonts = GetWordsAndFontSizes();
            try
            {
                System.Drawing.Bitmap image = Program.AppKernel.Get<IAlgorithm>(options.AlgorithmName).GetBitmap(fonts, options);
                return image;
            }
            catch (ActivationException)
            {
                throw new UnknownAlgorithmException();
            }
        }

        public IList<WordIntPair> GetWordsAndFontSizes()
        {
            var text = Program.AppKernel.Get<IFileReader>().GetRawText(options.InputFile);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var filteredWords = Program.AppKernel.Get<IWordsFilter>().RemoveBadWords(words);
            var wordsAndFreqs = Program.AppKernel.Get<IFrequencyCounter>().GetOrderedWordsAndFrequencies(filteredWords);
            var wordsAndFontsSizes = Program.AppKernel.Get<IFontProcessor>().GetFontSizes(wordsAndFreqs, options);
            return wordsAndFontsSizes;
        }
    }
}