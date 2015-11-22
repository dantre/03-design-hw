using System.Drawing;

namespace WordsCloud
{
    public struct Settings
    {
        public int MinFont { get; set; }
        public int MaxFont { get; set; }
        public Color TextColour { get; set; }
        public Color FontColour { get; set; }
        public string Font { get; set; }
    }
}