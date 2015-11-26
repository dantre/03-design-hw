using System;
using NUnit.Framework;
using TagsCloud.Concrete;

namespace Tests
{
    [TestFixture]
    public class FrequencyCounter_Tests
    {
        [Test]
        public void GetWordFrequencies_on_array_with_repeats_gives_right_counts()
        {
            var proc = new FrequencyCounter();
            var data = new[] {"a", "b", "c", "a", "a", "b"};
            var expected = new[]
            {
                Tuple.Create("a", 3),
                Tuple.Create("b", 2),
                Tuple.Create("c", 1)
            };

            var result = proc.GetWordsFrequencies(data);

            Assert.AreEqual(expected, result);
        }
    }
}