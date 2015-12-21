using System.Drawing;
using Ninject;

namespace TagsCloud.Generators
{
    public class TagsCloudGenerator
    {
        
        private readonly InputOptions _inputOptions;

        public TagsCloudGenerator(InputOptions _inputOptions)
        {
            this._inputOptions = _inputOptions;
        }

        public Bitmap Generate()
        {
            var text = Program.AppKernel.Get<IFileReader>().GetRawText(_inputOptions.InputFile);
            var words = Program.AppKernel.Get<IWordsExtractor>().GetWords(text);
            var filteredWords = Program.AppKernel.Get<IWordsFilter>().RemoveBadWords(words);
            var tuples = Program.AppKernel.Get<IFrequencyCounter>().GetWordsFrequencies(filteredWords);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(tuples, _inputOptions);
            Bitmap image;
            try
            {
                image = Program.AppKernel.Get<IAlgorithm>(_inputOptions.AlgorithmName).GetBitmap(fonts, _inputOptions);
            }
            catch (ActivationException)
            {
                throw new UnknownAlgorithmException();
            }
            return image;
        }
    }
}