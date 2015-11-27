using System.Linq;
using NUnit.Framework;
using TagsCloud.Concrete.WordsExtractors;

namespace Tests
{
    [TestFixture]
    public class WordsFromTextExtractor_Tests
    {
        [Test]
        public void WordsFromTextExtractor_GetWords_on_text_with_punctuation_gives_words_without_punctuation()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A,B. CC, A ! D";
            string[] expectedResult = {"A", "B", "CC", "A", "D"};

            var result = wordsExtractor.GetWords(data);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WordsFromTextExtractor_GetWords_on_text_4_words_gives_4_words()
        {
            var wordsExtractor = new WordsFromTextExtractor();
            string data = @"A B A C";

            var result = wordsExtractor.GetWords(data);

            Assert.AreEqual(4, result.Count());
        }
    }
}