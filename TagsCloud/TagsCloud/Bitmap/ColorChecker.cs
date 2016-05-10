using System;
using System.Drawing;

namespace TagsCloud.Bitmap
{
    public class ColorChecker
    {
        public bool IsColorExists(string colorName)
        {
            try
            {
                ColorTranslator.FromHtml(colorName);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
