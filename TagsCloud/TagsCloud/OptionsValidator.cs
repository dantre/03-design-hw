using System.IO;

namespace TagsCloud
{
    public class OptionsValidator
    {
        public bool IsValid(InputOptions inputOptions, out string message)
        {
            if (!File.Exists(inputOptions.InputFile))
            {
                message = "File not found.";
                return false;
            }
            if (!IsOkWidth(inputOptions.Width))
            {
                message = "Width is not vaild";
                return false;
            }
            if (!IsOkHeight(inputOptions.Height))
            {
                message = "Height is not valid";
                return false;
            }
            if (inputOptions.MaxFont < inputOptions.MinFont)
            {
                message = "Max font must be greater then Min font";
                return false;
            }
            if (!new AlgorithmsNames(inputOptions).IsAlgorithmExists(inputOptions.AlgorithmName))
            {
                message = "Unknown algorithm";
                return false;
            }
            message = "";
            return true;
        }

        // CR (krait): Стало лучше, но можно ещё лучше. Этот код можно не дублировать.
        private bool IsOkWidth(int width)
        {
            return width > 40 && width < 2048;
        }

        private bool IsOkHeight(int height)
        {
            return height > 40 && height < 2048;
        }
    }
}
