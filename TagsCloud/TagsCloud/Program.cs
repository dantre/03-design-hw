using Ninject;
using TagsCloud.NInject;

namespace TagsCloud
{
    public static class Program
    {
        public static IKernel AppKernel;
      
        private static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new BasicModule());
            var console = new ConsoleProgram(args);
            console.Run();
        }
    }
}


