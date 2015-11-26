using NUnit.Framework;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class WordsFromTextExtractor_Tests
    {
        [Test]
        public void WordsFromTextExtractor_GetWords_Test()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A B CC, A ! D";
            string[] expectedResult = {"A", "B", "CC", "A", "D"};

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}