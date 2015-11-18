using System.Collections.Generic;
using System.IO;

namespace WordsCloud.Extractors
{
    public class TxtExtractor : IDataExtractor
    {
        public IEnumerable<string> GetRawText(string filename)
        {
            return File.ReadAllLines(filename);
        }
    }
}