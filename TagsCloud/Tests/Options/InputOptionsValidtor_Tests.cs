using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Options;

namespace Tests.Options
{
    [TestClass]
    public class InputOptionsValidtor_Tests
    {
        private readonly InputOptions options = new InputOptions
        {
            AlgorithmName = "Column",
            BackgroundColor = "Red",
            TextColor = "Green",
            FontName = "Arial",
            Height = 100,
            Width = 100,
            MaxFont = 40,
            MinFont = 10
        };
        private InputOptionsValidator validator;
        [TestInitialize]
        public void Init()
        {
            validator = new InputOptionsValidator(options);
        }

        [TestMethod]
        public void IsValid_on_good_config_should_return_true()
        {
           // ifvalidator.CheckWidth()
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
