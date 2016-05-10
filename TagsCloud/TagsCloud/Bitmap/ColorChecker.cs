using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
