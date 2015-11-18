using Ninject;

namespace WordsCloud
{
    public class TagsCloudGenerator
    {
        private readonly string filename;
        private readonly Settings settings;

        public TagsCloudGenerator(string filename, Settings settings)
        {
            this.filename = filename;
            this.settings = settings;

        }

        public void Do()
        {
            var lines = Program.AppKernel.Get<IDataExtractor>().GetRawText(filename);
            var freqs = Program.AppKernel.Get<IDataProcessor>().GetWordFrequencies(lines);
            freqs = Program.AppKernel.Get<IDataModifier>().RemoveBadWords(freqs);
            var fonts = Program.AppKernel.Get<IFontProcessor>().GetFonts(freqs, settings.MinFont, settings.MaxFont);
        }
    }
}