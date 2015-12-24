using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Concrete.Algorithms;

namespace TagsCloud
{
    public class AlgorithmsNames
    {
        private readonly Dictionary<string, Func<IEnumerable<Tuple<string, int>>, Bitmap>> AlgoDictionary;

        public AlgorithmsNames(InputOptions inputOptions)
        {
            AlgoDictionary =
                new Dictionary<string, Func<IEnumerable<Tuple<string, int>> , Bitmap>>
                {
                    {"Line", new LineAlgorithm(inputOptions).GetBitmap},
                    {"Column", new ColumnsAlgorithm(inputOptions).GetBitmap}
                };
        }

        public Func<IEnumerable<Tuple<string, int>>, Bitmap> GetAlgorithmByName(string name)
        {
            if (IsAlgorithmExists(name))
                return AlgoDictionary[name];
            throw new Exception("Unknown Algorithm");
        }

        public bool IsAlgorithmExists(string name)
        {
            return AlgoDictionary.ContainsKey(name);
        }
    }
}
