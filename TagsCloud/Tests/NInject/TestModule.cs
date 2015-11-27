using Ninject.Modules;
using TagsCloud.Abstract;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests.NInject
{
    class TestModule : NinjectModule
    {
        public override void Load()
        {
            // CR (krait): Можно не создавать отдельный модуль, а биндить ридер отдельно в тестах, где это нужно.
            // CR (krait): Ещё, вместо FakeReader'а можно создавать реализацию на ходу, используя какой-нибудь mock-фреймворк типа NSubstitute.
            Bind<IFileReader>().To<FakeReader>();
            Bind<IWordsExtractor>().To<WordsFromTextExtractor>();
            Bind<IWordsFilter>().To<WordsFilter>();
            Bind<IFrequencyCounter>().To<FrequencyCounter>();
            Bind<IFontProcessor>().To<FontProcessor>();
            Bind<IAlgorithm>().To<ColumnsAlgorithm>().Named("Column");
            Bind<IAlgorithm>().To<LineAlgorithm>().Named("Line");
        }
    }
}
