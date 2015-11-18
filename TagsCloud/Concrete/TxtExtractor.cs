using System.Collections.Generic;
using System.IO;

namespace WordsCloud.Concrete
{
    public class TxtExtractor : IDataExtractor
    {
        public IEnumerable<string> GetRawText(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}