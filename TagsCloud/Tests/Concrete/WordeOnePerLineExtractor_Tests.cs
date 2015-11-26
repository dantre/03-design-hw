using NUnit.Framework;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class WordeOnePerLineExtractor_Tests
    { 
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