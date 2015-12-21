using System.IO;
using TagsCloud.Concrete.Algorithms;

namespace TagsCloud
{
    public class OptionsValidator
    {
        public static bool IsValid(InputOptions inputOptions, out string message)
        {
            if (!File.Exists(inputOptions.InputFile))
            {
                message = "File not found.";
                return false;
            }
            if (inputOptions.Height < 40)
            {
                message = "Height too little";
                return false;
            }
            if (inputOptions.Width < 40)
            {
                message = "Width too little";
                return false;
            }
            if (inputOptions.MaxFont < inputOptions.MinFont)
            {
                message = "Max font must be greater then Min font";
                return false;
            }
            if (inputOptions.AlgorithmName != "Line" && inputOptions.AlgorithmName != "Column")
            {
                message = "Unknown algorithm";
                return false;
            }
            message = "";
            return true;
        }

        public static Kernel UpdateAlgoInKernel(InputOptions inputOptions, Kernel kernel)
        {
            if (inputOptions.AlgorithmName == "Line")
            {
                kernel.getBitmap = LineAlgorithm.GetBitmap;
                return kernel;
            }
            return kernel;
        }
    }
}
