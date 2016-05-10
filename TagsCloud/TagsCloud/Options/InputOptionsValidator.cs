using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TagsCloud.Bitmap;

namespace TagsCloud.Options
{
    public class InputOptionsValidator : IOptionsValidator
    {
        private InputOptions Options { get; set; }
        private readonly ColorChecker colorChecker = new ColorChecker();
        private readonly Dictionary<Func<bool>, string> RulesAndErrorMessages;
        private readonly List<string> knownAlgorithms = new List<string> {"Column", "Line"};

        public InputOptionsValidator(InputOptions options)
        {
            Options = options;
            RulesAndErrorMessages = new Dictionary<Func<bool>, string>
            {
                { CheckHeight, "Validation Error: Wrong height" },
                { CheckWidth, "Validation Error: Wrong width" },
                { CheckMaxFont, "Validation Error: Font size error" },
                { CheckMinFont, "Validation Error: Font size error" },
                { CheckInputFile, "Validation Error: File doesn't exists" },
                { CheckTextColor, "Validation Error: Cannot recognize this text color" },
                { CheckBackgroundColor, "Validation Error: Cannot recognize background color"},
                { CheckAlgorithm, "Validation Error: Unknown Algorithm" }
            };
        }

        public bool IsValid(out string message)
        {
            foreach (var rulesAndErrorMessage in RulesAndErrorMessages)
            {
                if (!rulesAndErrorMessage.Key())
                {
                    message = rulesAndErrorMessage.Value;
                    return false;
                }
            }
            message = "";
            return true;
        }

        public bool IsParameterInSegment(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        #region Options checks
        public bool CheckInputFile()
        {
            return File.Exists(Options.InputFile);
        }

        public bool CheckWidth()
        {
            return IsParameterInSegment(Options.Width, 40, 2048);
        }

        public bool CheckHeight()
        {
            return IsParameterInSegment(Options.Height, 40, 2048);
        }

        public bool CheckMinFont()
        {
            return IsParameterInSegment(Options.MinFont, 8, Options.MaxFont);
        }

        public bool CheckMaxFont()
        {
            return IsParameterInSegment(Options.MaxFont, Options.MinFont, 70);
        }

        public bool CheckTextColor()
        {
            return colorChecker.IsColorExists(Options.TextColor);
        }

        public bool CheckAlgorithm()
        {
            return knownAlgorithms.Contains(Options.AlgorithmName);
        }

        public bool CheckBackgroundColor()
        {
            return colorChecker.IsColorExists(Options.BackgroundColor);
        }
        #endregion
    }

    public interface IOptionsValidator
    {
        bool IsValid(out string message);
        bool CheckInputFile();
        bool CheckWidth();
        bool CheckHeight();
        bool CheckMinFont();
        bool CheckMaxFont();
        bool CheckTextColor();
        bool CheckBackgroundColor();
        bool CheckAlgorithm();
    }
}
