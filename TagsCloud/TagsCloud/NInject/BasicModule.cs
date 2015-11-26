using Ninject.Modules;
using TagsCloud.Abstract;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud.NInject
{
    class BasicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFilerReader>().To<TxtReader>();
            Bind<IWordsExtractor>().To<WordsFromTextExtractor>();
            Bind<IWordsFilter>().To<WordsFilter>();
            Bind<IFrequencyCounter>().To<FrequencyCounter>();
            Bind<IFontProcessor>().To<FontProcessor>();
            Bind<IAlgorithm>().To<ColumnsAlgorithm>().Named("Column");
            Bind<IAlgorithm>().To<LineAlgorithm>().Named("Line");
        }
    }
}
