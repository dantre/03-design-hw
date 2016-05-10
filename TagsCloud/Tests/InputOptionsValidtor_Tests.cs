using Microsoft.VisualStudio.TestTools.UnitTesting;
using TagsCloud.Options;

namespace Tests
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
        public void CheckWidth_on_width_100_should_return_true()
        {
            options.Width = 100;
            Assert.AreEqual(true, validator.CheckWidth());
        }

        [TestMethod]
        public void CheckWidth_on_width_1_should_return_false()
        {
            options.Width = 1;
            Assert.AreEqual(false, validator.CheckWidth());
        }

        [TestMethod]
        public void CheckAlgorithm_on_Line_should_return_true()
        {
            options.AlgorithmName = "Line";
            Assert.AreEqual(true, validator.CheckAlgorithm());
        }

        [TestMethod]
        public void CheckAlgorithm_on_ASD_should_return_false()
        {
            options.AlgorithmName = "ASD";
            Assert.AreEqual(false, validator.CheckAlgorithm());
        }

        [TestMethod]
        public void CheckTextColor_on_Green_should_return_true()
        {
            options.TextColor = "Green";
            Assert.AreEqual(true, validator.CheckTextColor());
        }

        [TestMethod]
        public void CheckTextColor_on_ASD_should_return_false()
        {
            options.TextColor = "ASD";
            Assert.AreEqual(false, validator.CheckTextColor());
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
