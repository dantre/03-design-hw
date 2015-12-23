using System.IO;
using TagsCloud.Concrete.Algorithms;

namespace TagsCloud
{
    public static class OptionsValidator
    {
        public static bool IsValid(InputOptions inputOptions, out string message)
        {
            // CR (krait): Эту портянку не помешало бы как-то разбить и избавить от дублирования. Если число параметров увеличится, здесь будет полный треш.
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
            if (inputOptions.Height > 2048)
            {
                message = "Height too big";
                return false;
            }
            if (inputOptions.Width > 2048)
            {
                message = "Width too big";
                return false;
            }
            if (inputOptions.MaxFont < inputOptions.MinFont)
            {
                message = "Max font must be greater then Min font";
                return false;
            }
            // CR (krait): При появлении нового алгоритма придется сделать много работы: добавить его сюда, в текст хелпа и в UpdateAlgoInKernel. Кажется, этого можно было легко избежать. 
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
                kernel.GetBitmap = LineAlgorithm.GetBitmap;
                return kernel;
            }
            return kernel;
        }
    }
}
