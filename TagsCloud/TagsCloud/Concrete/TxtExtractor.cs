using System.IO;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class TxtExtractor : IDataExtractor
    {
        public string GetRawText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}