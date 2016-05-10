using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Data.Filters;

namespace Tests.Data
{
    [TestClass]
    public class WordsFilter_Tests
    {
        [TestMethod]
        public void RemoveBadWords_should_remove_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] {"A", "and", "B", "or", "C"};
            var expected = new[] {"A", "B", "C"};

            var result = modifier.RemoveBadWords(data).ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RemoveBadWords_should_not_remove_not_articles()
        {
            var modifier = new WordsFilter();
            var data = new[] { "A", "B", "C" };
            var expected = new[] { "A", "B", "C" };

            var result = modifier.RemoveBadWords(data);

            CollectionAssert.AreEqual(expected, result.ToList());
        }
    }
}