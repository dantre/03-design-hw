using System.IO;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class TxtReader : IFileReader
    {
        public string GetRawText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}