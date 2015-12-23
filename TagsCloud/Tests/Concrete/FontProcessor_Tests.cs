using System;
using System.Linq;
using NUnit.Framework;
using TagsCloud;
using TagsCloud.Concrete;

namespace Tests
{
    [TestFixture]
    public class FontProcessor_Tests
    {
        [Test]
        public void GetFonts_on_different_freqs_should_give_different_fonts()
        {
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

            var result = new FontProcessor().GetFonts(data, settings.MaxFont, settings.MinFont).ToList();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}