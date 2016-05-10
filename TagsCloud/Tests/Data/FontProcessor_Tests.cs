using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Data.Font;
using TagsCloud.Options;

namespace Tests.Data
{
    [TestClass]
    public class FontProcessor_Tests
    {
        [TestMethod]
        public void GetFonts_on_different_freqs_should_give_different_fonts()
        {
            var proc = new FontProcessor();
            var data = new[]
            {
                Tuple.Create("A", 12),
                Tuple.Create("B", 5),
                Tuple.Create("C", 1)
            };
            var settings = new InputOptions {MinFont = 10, MaxFont = 20};
            var expected = new[]
            {
                Tuple.Create("A", 20),
                Tuple.Create("B", 14),
                Tuple.Create("C", 10)
            };

            var result = proc.GetFonts(data, settings).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}