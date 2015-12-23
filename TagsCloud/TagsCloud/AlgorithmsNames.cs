using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Concrete.Algorithms;

namespace TagsCloud
{
    public class AlgorithmsNames
    {
        private readonly Dictionary<string, Func<IEnumerable<Tuple<string, int>>, string, string, string, int, int, Bitmap>> AlgoDictionary;

        public AlgorithmsNames()
        {
            AlgoDictionary =
                new Dictionary<string, Func<IEnumerable<Tuple<string, int>>, string, string, string, int, int, Bitmap>>
                {
                    {"Line", new LineAlgorithm().GetBitmap},
                    {"Column", new ColumnsAlgorithm().GetBitmap}
                };
        }

        public Func<IEnumerable<Tuple<string, int>>, string, string, string, int, int, Bitmap> GetAlgorithmByName(string name)
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
