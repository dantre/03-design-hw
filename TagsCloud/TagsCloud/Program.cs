using Ninject;
using TagsCloud.NInject;

namespace TagsCloud
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            new ConsoleProgram(args).Run();
        }
    }
}


