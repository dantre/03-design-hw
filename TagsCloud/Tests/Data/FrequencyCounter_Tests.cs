using System;
using System.Collections.Generic;
using NUnit.Framework;
using TagsCloud.Data;
using TagsCloud.Data.Frequencies;

namespace Tests.Data
{
    [TestFixture]
    public class FrequencyCounter_Tests
    {
        [Test]
        public void GetWordFrequencies_on_array_abcaab_should_return_3_WordIntPairs()
        {
            var proc = new FrequencyCounter();
            var data = new[] {"a", "b", "c", "a", "a", "b"};
            var result = proc.GetOrderedWordsFrequencies(data);
            Assert.AreEqual(3, result.Count);
        }
        [Test]
        public void GetWordFrequencies_on_array_abcaab_should_return_a3_b2_c1()
        {
            var proc = new FrequencyCounter();
            var data = new[] { "a", "b", "c", "a", "a", "b" };
            var expected = new List<WordIntPair>
            { 
                new WordIntPair("a", 3),
                new WordIntPair("b", 2),
                new WordIntPair("c", 1)
            };
            var result = proc.GetOrderedWordsFrequencies(data);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}