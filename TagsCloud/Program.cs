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
//            var settings = new Settings() {TextColour = Color.Red, MinFont = 12, MaxFont = 25};
            var settings = new Settings()
            {
                MinFont = 12,
                MaxFont = 26,
                FontColour = Color.Blue,
                TextColour = Color.Orange
            };
            var generator = new TagsCloudGenerator(filename, settings);
            generator.Generate();

        }
    }
}

