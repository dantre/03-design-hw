using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data;
using TagsCloud.Data.Filters;
using TagsCloud.Data.Font;
using TagsCloud.Data.Frequencies;
using TagsCloud.Data.Readers;
using TagsCloud.Data.WordsExtractors;
using TagsCloud.Options;

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
            var fonts = GetFonts();
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

        public IList<WordIntPair> GetFonts()
        {
            var text = Program.AppKernel.Get<IFileReader>().GetRawText(options.InputFile);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var filteredWords = Program.AppKernel.Get<IWordsFilter>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IFrequencyCounter>().GetOrderedWordsFrequencies(filteredWords);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, options);
            return fonts;
        }
    }
}