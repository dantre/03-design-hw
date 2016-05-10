using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Bitmap;

namespace Tests.Bitmap
{
    [TestClass]
    public class ColorChecker_Tests
    {
        private readonly ColorChecker colorChecker = new ColorChecker();
        
        [TestMethod]
        public void IsColorExists_on_Red_should_return_true()
        {
            string colorName = "Red";
            bool result = colorChecker.IsColorExists(colorName);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsColorExists_on_asd_shoult_return_false()
        {
            string colorName = "asd";
            bool result = colorChecker.IsColorExists(colorName);
            Assert.AreEqual(false, result);
        }
    }
}
