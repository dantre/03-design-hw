using Ninject.Modules;
using WordsCloud.Concrete;
using WordsCloud.Concrete.DataProcessors;

namespace WordsCloud
{
    public class SimpleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataExtractor>().To<TxtExtractor>();
            Bind<IDataProcessor>().To<DataProcessorFromWordList>();
            Bind<IDataModifier>().To<EmptyDataModifier>();
            Bind<IFontProcessor>().To<FontProcessor>();
        }
    }
}