using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCloud
{
    class Program
    {
        private static void Main(string[] args)
        {
            string filename = "example.txt";
            var proc = new TextProcessorFromRawText(filename);
            foreach (var freq in proc.GetWordFrequencies())
            {
                Console.WriteLine($"{freq.Item1} {freq.Item2}");
            }
        }
    }

    public class TextProcessor
    {
        
    }

    public class TextProcessorFromRawText : IDataProcessor
    {
        private readonly string rawText;
        public TextProcessorFromRawText(string filename)
        {
            rawText = File.ReadAllText(filename);
        }

        public Tuple<string, int>[] GetWordFrequencies()
        {
            return Regex.Split(rawText, @"\W+")
                .Where(w => !string.IsNullOrEmpty(w))
                .Select(w => w.ToLower())
                .GroupBy(w => w)
                .Select(w => Tuple.Create(w.Key, w.Count()))
                .OrderByDescending(tuple => tuple.Item2)
                .ToArray();
        }
    }

    public interface IDataProcessor
    {
        Tuple<string, int>[] GetWordFrequencies();
    }

    public interface IFontProcessor
    {
        Tuple<string, int>[] GetFonts();
    }

    public class FontProcessor : IFontProcessor
    {
        
    }

    public interface IAlgorithm
    {
        
    }
    public interface ImageCreator
    {
        void CreateImage(IAlgorithm )
    }
}
