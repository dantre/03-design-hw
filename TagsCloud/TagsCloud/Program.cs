using Ninject;
using TagsCloud.NInject;

namespace TagsCloud
{
    public static class Program
    {
        public static IKernel AppKernel = new StandardKernel(new BindingModule());
      
        private static void Main(string[] args)
        {
            var console = new ConsoleProgram();
            console.Run(args);
        }
    }
}


