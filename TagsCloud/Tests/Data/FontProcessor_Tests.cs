using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Data;
using TagsCloud.Data.Font;
using TagsCloud.Options;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

namespace Tests.Data
{
    [TestClass]
    public class FontProcessor_Tests
    {
        [TestMethod]
        public void GetFonts_on_different_freqs_should_give_different_fonts()
        {
            var proc = new FontProcessor();
            var data = new List<WordIntPair>
            {
                new WordIntPair("A", 12),
                new WordIntPair("B", 5),
                new WordIntPair("C", 1)
            };
            var settings = new InputOptions {MinFont = 10, MaxFont = 20};
            var expected = new List<WordIntPair>
            {
                new WordIntPair("A", 20),
                new WordIntPair("B", 14),
                new WordIntPair("C", 10)
            };

            var result = proc.GetFontSizes(data, settings).ToList();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetFonts_on_equal_freqs_should_return_equal_fonts_sizes()
        {
            var proc = new FontProcessor();
            var data = new List<WordIntPair>
            {
                new WordIntPair("A", 10),
                new WordIntPair("B", 10),
                new WordIntPair("C", 10)
            };
            var settings = new InputOptions { MinFont = 20, MaxFont = 20 };
            var expected = new List<WordIntPair>
            {
                new WordIntPair("A", 20),
                new WordIntPair("B", 20),
                new WordIntPair("C", 20)
            };

            var result = proc.GetFontSizes(data, settings).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}