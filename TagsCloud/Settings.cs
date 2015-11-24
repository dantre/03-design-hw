using System.Collections.Generic;
using System.Drawing;

namespace WordsCloud
{
    public struct Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MinFont { get; set; }
        public int MaxFont { get; set; }
        public IList<Color> TextColours { get; set; }
        public IList<Color> FontColours { get; set; }
        public string Font { get; set; }
    }
}