using System.IO;

namespace TagsCloud.Data.Readers
{
    public class TxtReader : IFileReader
    {
        public string GetRawText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}