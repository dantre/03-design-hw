using NUnit.Framework;
using TagsCloud.Concrete;

namespace Tests
{
    [TestFixture]
    public class WordsFilter_Tests
    {
        [Test]
        public void RemoveBadWords_removes_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] {"A", "and", "B", "or", "C"};
            var expected = new[] {"A", "B", "C"};

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RemoveBadWords_doesnt_removes_not_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] { "A", "B", "C" };
            var expected = new[] { "A", "B", "C" };

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(expected, result);
        }
    }
}