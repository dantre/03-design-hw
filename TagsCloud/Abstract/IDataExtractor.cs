using System;
using System.Collections.Generic;

namespace WordsCloud
{
    public interface IDataExtractor
    {
        IEnumerable<string> GetRawText(string filename);
    }
}