using System.Collections.Generic;
using System.Drawing;
using Ninject;

namespace WordsCloud
{
    public static class Program
    {
        public static IKernel AppKernel;
      
        private static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new BasicModule());
            //            var console = new ConsoleProgram(args);
            //            console.Run();
            var settings = new Settings()
            {
                MinFont = 20,
                MaxFont = 40,
                FontColours = new List<Color> { Color.Blue, Color.Purple },
                TextColours = new List<Color> { Color.Orange, Color.Red },
                Font = "Arial"
            };
            var t = new TagsCloudGenerator("simple.txt", settings);
            t.Generate();
        }
    }
}


