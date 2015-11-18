using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCloud.Concrete
{
    public class EmptyDataModifier : IDataModifier
    {
        public Tuple<string, int>[] RemoveBadWords(Tuple<string, int>[] words)
        {
            return words;
        }
    }
}
