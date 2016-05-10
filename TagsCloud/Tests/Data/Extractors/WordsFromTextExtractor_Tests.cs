using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Data.WordsExtractors;

namespace Tests.Data.Extractors
{
    [TestClass]
    public class WordsFromTextExtractor_Tests
    {
        [TestMethod]
        public void GetWords_on_text_with_punctuation_gives_words_without_punctuation()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A,B. CC, A ! D";
            string[] expectedResult = {"A", "B", "CC", "A", "D"};

            var result = wordsExtractor.GetWords(data).ToList();

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetWords_on_text_with_4_different_words_gives_4_words()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A B A C";

            var result = wordsExtractor.GetWords(data);

            Assert.AreEqual(4, result.Count());
        }
    }
}