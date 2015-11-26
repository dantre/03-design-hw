using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagsCloud.Abstract;

namespace TagsCloud.Concrete
{
    class OptionsValidator : IOptionsValidator
    {
        public bool IsValid(Options options)
        {
            if (options.AlgorithmNumber < 1 || options.AlgorithmNumber > 2)
                return false;
            if (options.MaxFont < options.MinFont)
                return false;
            if (options.Width < 0 || options.Height < 0)
                return false;
            return true;
        }
    }
}
