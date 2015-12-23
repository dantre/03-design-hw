using System.IO;

namespace TagsCloud.Concrete
{
    public class TxtReader
    {
        public string GetRawText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}