using System.Collections.Generic;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    public class EmptyWordsModifier : IWordsModifier
    {
        public IEnumerable<string> RemoveBadWords(IEnumerable<string> words)
        {
            return words;
        }
    }
}
