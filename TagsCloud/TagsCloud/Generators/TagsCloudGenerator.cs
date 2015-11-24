using System.Drawing;
using Ninject;
using TagsCloud.Abstract;

namespace TagsCloud.Generators
{
    public class TagsCloudGenerator
    {
        private readonly string filename;
        private readonly Options options;

        public TagsCloudGenerator(string filename, Options options)
        {
            this.filename = filename;
            this.options = options;
        }

        public Image Generate()
        {
            var text = Program.AppKernel.Get<IDataExtractor>().GetRawText(filename);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var wordsWithoutRepeats = Program.AppKernel.Get<IWordsModifier>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IDataProcessor>().GetWordsFrequencies(wordsWithoutRepeats);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, options);
            var image = Program.AppKernel.Get<IAlgorithm>().GetImage(fonts, options);
            return image;
        }
    }
}