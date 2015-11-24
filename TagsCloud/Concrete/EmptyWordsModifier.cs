using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCloud.Concrete
{
    public class EmptyWordsModifier : IWordsModifier
    {
        public IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words;
        }
    }
}
