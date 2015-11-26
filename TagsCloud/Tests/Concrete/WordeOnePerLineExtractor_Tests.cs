using System.Linq;
using NUnit.Framework;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class WordeOnePerLineExtractor_Tests
    { 
        [Test]
        public void GetWords_on_text_with_2_enters_gives_two_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = @"A\r\n\r\nB";
            string[] expectedResult = { "A", "B"};

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult, result);
        }
        [Test]
        public void GetWords_on_text_with_1_enter_gives_two_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = @"A\r\nB";
            string[] expectedResult = { "A", "B" };

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetWords_on_empty_text_with_1_enter_no_words()
        {
            var wordsExtractor = new WordsOnePerLineExtractor();
            string data = "";
            var result = wordsExtractor.GetWords(data);
            Assert.AreEqual(0, result.Count());
        }
    }
}