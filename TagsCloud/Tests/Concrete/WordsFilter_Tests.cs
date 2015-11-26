using NUnit.Framework;
using TagsCloud.Concrete;

namespace Tests
{
    [TestFixture]
    public class WordsFilter_Tests
    {
        [Test]
        public void EmptyWordsModifier_RemoveBadWords_Test()
        {
            var modifier = new WordsFilter();
            var data = new[] {"A", "B", "A", "C"};

            var result = modifier.RemoveBadWords(data);

            Assert.AreEqual(data, result);
        }
    }
}