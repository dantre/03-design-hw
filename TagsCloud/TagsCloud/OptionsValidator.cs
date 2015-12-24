using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

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

            if (!IsOkParameter(inputOptions.Width, 40, 2048))
            {
                message = "Width is not vaild";
                return false;
            }
            if (!IsOkParameter(inputOptions.Height, 40, 2048))
            {
                message = "Height is not valid";
                return false;
            }
            if (!IsOkParameter(inputOptions.MinFont, 8, inputOptions.MaxFont))
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
        private bool IsOkParameter(int value, int minValue, int maxValue)
        {
            return value> minValue && value < maxValue;
        }
    }
}
