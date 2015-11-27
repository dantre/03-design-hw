using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete.WordsExtractors
{
    class WordsOnePerLineExtractorUnixStyle : IWordsExtractor
    {
        public IEnumerable<string> GetWords(string rawText)
        {
            return rawText.Split(new[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
