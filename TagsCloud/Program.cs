using System;
using System.Collections.Generic;
using System.Drawing;
using Ninject;

namespace WordsCloud
{
    class Program
    {
        public static IKernel AppKernel;

        private static void Main(string[] args)
        {
            AppKernel = new StandardKernel(new SimpleModule());
            string filename = "simple.txt";
            var settings = new Settings()
            {
                MinFont = 20,
                MaxFont = 40,
                FontColour = Color.Blue,
                TextColour = Color.Orange,
                Font = "Arial"
            };
            var generator = new TagsCloudGenerator(filename, settings);
            generator.Generate();

        }
    }
}

