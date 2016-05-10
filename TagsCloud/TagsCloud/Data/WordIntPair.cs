using System.Collections.Generic;

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

        protected bool Equals(WordIntPair other)
        {
            return string.Equals(Word, other.Word) && Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WordIntPair)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Word.GetHashCode() * 397) ^ Number;
            }
        }

        public static bool operator ==(WordIntPair left, WordIntPair right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WordIntPair left, WordIntPair right)
        {
            return !Equals(left, right);
        }
    }

    public class WordIntPairComparer : Comparer<WordIntPair>
    {
        public override int Compare(WordIntPair x, WordIntPair y)
        {
            if (x == null || y == null)
                return 0;
            return y.Number - x.Number;
        }
    }
}
