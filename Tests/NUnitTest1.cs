using System;
using Moq;
using NUnit.Framework;
using WordsCloud;
using WordsCloud.Concrete;


namespace Tests
{
    [TestFixture]
    public class TxtExtractor_Test
    {
        [Test]
        public void GetRawText_on_file_with_some_lines_should_give_same_lines()
        {
            var mock = new Mock<IDataExtractor>();
            mock.Setup(t => t.GetRawText("test")).Returns(() => new[] {"1", "2","3"});
            
            var result = mock.Object.GetRawText("test");

            CollectionAssert.AreEqual(new[] {"1", "2", "3"}, result);
        }
    }
}