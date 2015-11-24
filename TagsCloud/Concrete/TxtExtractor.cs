using System.IO;

namespace WordsCloud.Concrete
{
    public class TxtExtractor : IDataExtractor
    {
        public string GetRawText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}