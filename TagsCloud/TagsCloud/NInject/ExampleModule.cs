using Ninject.Modules;
using TagsCloud.Abstract;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud.NInject
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
