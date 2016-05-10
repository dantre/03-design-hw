using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Options;

namespace Tests.Options
{
    [TestClass]
    public class InputOptionsValidtor_Tests
    {
        private InputOptions options;
        private InputOptionsValidator validator;
        [TestInitialize]
        public void Init()
        {
            options = new InputOptions();
            validator = new InputOptionsValidator();
        }

        [TestMethod]
        public void IsParameterInSegment_on_20_between_10_and_30_should_return_true()
        {
            Assert.AreEqual(true, validator.IsParameterInSegment(20, 10, 30));
        }
        [TestMethod]
        public void IsParameterInSegment_on_20_between_10_and_15_should_return_false()
        {
            Assert.AreEqual(false, validator.IsParameterInSegment(20, 10, 15));
        }
    }
}
