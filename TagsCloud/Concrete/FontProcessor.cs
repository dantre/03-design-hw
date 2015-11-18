﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsCloud.Concrete
{
    public class FontProcessor : IFontProcessor
    {
        public IEnumerable<Tuple<string, int>> GetFonts(Tuple<string, int>[] words, Settings settings)
        {
            int min = words.Min(t => t.Item2);
            int max = words.Max(t => t.Item2);
            return words.Select(tuple => Tuple.Create(tuple.Item1, CountFont(settings.MaxFont, tuple.Item2, min, max)));
        }

        private int CountFont(int maxFont, int count, int min, int max)
        {
            return (int) Math.Floor(maxFont * (count - min) * 1.0 / (max - min));
        }
    }
}