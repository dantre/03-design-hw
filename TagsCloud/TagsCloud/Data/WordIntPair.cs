using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloud.Data
{
    public class WordIntPair
    {
        public readonly static Comparer<WordIntPair> Comparer = new WordIntPairComparer();

        public string Word { get; set; }
        public int Number { get; set; }

        public WordIntPair(string word, int number)
        {
            Word = word;
            Number = number;
        }
    }

    public class WordIntPairComparer : Comparer<WordIntPair>
    {
        public override int Compare(WordIntPair x, WordIntPair y)
        {
            if (x == null || y == null)
                return 0;
            return x.Number - y.Number;
        }
    }
}
