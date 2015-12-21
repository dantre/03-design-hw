using System.Linq;
using NUnit.Framework;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class WordsOnePerLineExtractor_Tests
    { 
        [Test]
        public void GetWords_on_text_with_2_enters_should_give_two_words()
        {
            string data = @"A\r\n\r\nB";
            string[] expectedResult = { "A", "B"};
            var result = WordsOnePerLineExtractor.GetWords(data);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetWords_on_text_with_1_enter_should_give_two_words()
        {
            string data = @"A\r\nB";
            string[] expectedResult = { "A", "B" };
            var result = WordsOnePerLineExtractor.GetWords(data);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void GetWords_on_empty_text_with_1_enter_should_give_no_words()
        {
            string data = "";
            var result = WordsOnePerLineExtractor.GetWords(data);
            Assert.AreEqual(0, result.Count());
        }
    }
}