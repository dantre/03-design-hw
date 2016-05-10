using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Data.WordsExtractors;
namespace Tests.Data.Extractors
{
    [TestClass]
    public class WordsOnePerLineExtractor_Tests
    { 
        [TestMethod]
        public void GetWords_on_text_with_2_enters_should_give_two_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = @"A\r\n\r\nB";
            string[] expectedResult = { "A", "B"};
            var result = wordsExtractor.GetWords(data).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetWords_on_text_with_1_enter_should_give_two_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = @"A\r\nB";
            string[] expectedResult = { "A", "B" };
            var result = wordsExtractor.GetWords(data).ToList();
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetWords_on_empty_text_with_1_enter_should_give_no_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = "";
            var result = wordsExtractor.GetWords(data);
            Assert.AreEqual(0, result.Count());
        }
    }
}