using Ninject.Modules;
using TagsCloud.Bitmap.Algorithms;
using TagsCloud.Data.Filters;
using TagsCloud.Data.Font;
using TagsCloud.Data.Frequencies;
using TagsCloud.Data.Readers;
using TagsCloud.Data.WordsExtractors;
using TagsCloud.Options;

namespace TagsCloud.NInject
{
    public class BindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileReader>().To<TxtReader>();
            Bind<IWordsExtractor>().To<WordsFromTextExtractor>();
            Bind<IWordsFilter>().To<WordsFilter>();
            Bind<IFrequencyCounter>().To<FrequencyCounter>();
            Bind<IFontProcessor>().To<FontProcessor>();
            Bind<IAlgorithm>().To<ColumnsAlgorithm>().Named("Column");
            Bind<IAlgorithm>().To<LineAlgorithm>().Named("Line");
        }
    }
}
