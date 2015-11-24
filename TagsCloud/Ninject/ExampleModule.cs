using Ninject.Modules;
using WordsCloud;
using WordsCloud.Concrete;
using WordsCloud.Concrete.Algorithms;
using WordsCloud.Concrete.DataProcessors;
using WordsCloud.Concrete.WordsExtractors;

namespace TagsCloud.Ninject
{
    class ExampleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataExtractor>().To<TxtExtractor>();
            Bind<IWordsExtractor>().To<WordsFromTextExtractor>();
            Bind<IWordsModifier>().To<EmptyWordsModifier>();
            Bind<IDataProcessor>().To<DataProcessor>();
            Bind<IFontProcessor>().To<FontProcessor>();
            Bind<IAlgorithm>().To<ColumnsAlgorithm>();
        }
    }
}
