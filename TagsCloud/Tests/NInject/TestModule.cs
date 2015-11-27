using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
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
