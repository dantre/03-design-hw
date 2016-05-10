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
        private InputOptions Options { get; }

        private readonly Dictionary<Func<bool>, string> RulesAndErrorMessages;

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
                { CheckBackgroundColor, "Validation Error: Cannot recognize background color"}
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

        private bool CheckInputFile()
        {
            return File.Exists(Options.InputFile);
        }

        private bool CheckWidth()
        {
            return IsParameterInSegment(Options.Width, 40, 2048);
        }

        private bool CheckHeight()
        {
            return IsParameterInSegment(Options.Height, 40, 2048);
        }

        private bool CheckMinFont()
        {
            return IsParameterInSegment(Options.MinFont, 8, Options.MaxFont);
        }

        private bool CheckMaxFont()
        {
            return IsParameterInSegment(Options.MaxFont, Options.MinFont, 70);
        }

        private bool CheckTextColor()
        {
            return colorChecker.IsColorExists(Options.TextColor);
        }

        private bool CheckBackgroundColor()
        {
            return colorChecker.IsColorExists(Options.BackgroundColor);
        }

        private readonly ColorChecker colorChecker = new ColorChecker();

        public bool IsParameterInSegment(int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }
    }

    public interface IOptionsValidator
    {
        bool IsValid(out string message);
    }
}
