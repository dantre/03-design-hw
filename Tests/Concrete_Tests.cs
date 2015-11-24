using System;
using System.Linq;
using NUnit.Framework;
using WordsCloud;
using WordsCloud.Concrete;
using WordsCloud.Concrete.DataProcessors;
using WordsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class Concrete_Tests
    {
        [Test]
        public void FontProcessor_GetFonts_Test()
        {
            var proc = new FontProcessor();
            var data = new[]
            {
                Tuple.Create("A", 12),
                Tuple.Create("B", 5),
                Tuple.Create("C", 1)
            };
            var settings = new Options { MinFont = 10, MaxFont = 20 };
            var expected = new[]
            {
                Tuple.Create("A", 20),
                Tuple.Create("B", 14),
                Tuple.Create("C", 10)
            };

            var result = proc.GetFonts(data, settings).ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void DataProcessor_GetWordFrequencies_Test()
        {
            var proc = new DataProcessor();
            var data = new[] {"a", "b", "c", "a", "a", "b"};
            var expected = new[]
            {
                Tuple.Create("a", 3),
                Tuple.Create("b", 2),
                Tuple.Create("c", 1)
            };

            var result = proc.GetWordsFrequencies(data);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EmptyWordsModifier_RemoveBadWords_Test()
        {
            var modifier = new EmptyWordsModifier();
            var data = new[] { "A", "B", "A", "C" };

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(data, result);
        }

        [Test]
        public void WordsFromTextExtractor_GetWords_Test()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A B CC, A ! D";
            string[] expectedResult = {"A", "B", "CC", "A", "D"};

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult,  result);
        }

        [Test]
        public void WordsOnePerLineExtractor_GetWords_Test()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = @"A\r\nB\r\n\r\nC";
            string[] expectedResult = { "A", "B", "C"};

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}