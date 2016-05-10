using System;
using NUnit.Framework;
using TagsCloud.Data;
using TagsCloud.Data.Frequencies;

namespace Tests.Data
{
    [TestFixture]
    public class FrequencyCounter_Tests
    {
        [Test]
        public void GetWordFrequencies_on_array_abcaa_should_give_3_a()
        {
            var proc = new FrequencyCounter();
            var data = new[] {"a", "b", "c", "a", "a"};

            var result = proc.GetOrderedWordsFrequencies(data);

            Assert.AreEqual(new WordIntPair("a", 3), result);
        }

    }
}