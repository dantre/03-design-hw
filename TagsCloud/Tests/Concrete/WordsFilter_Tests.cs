using NUnit.Framework;
using TagsCloud.Concrete;

namespace Tests
{
    [TestFixture]
    public class WordsFilter_Tests
    {
        [Test]
        public void WordsFilter_RemoveBadWords_should_remove_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] {"A", "and", "B", "or", "C"};
            var expected = new[] {"A", "B", "C"};

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void WordsFilter_RemoveBadWords_shouldnot_remove_not_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] { "A", "B", "C" };
            var expected = new[] { "A", "B", "C" };

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(expected, result);
        }
    }
}