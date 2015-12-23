using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloud.Concrete;
using TagsCloud.Concrete.Algorithms;
using TagsCloud.Concrete.WordsExtractors;

namespace TagsCloud
{
    public class Kernel
    {
        // CR (krait): Публичные поля без readonly -- плохая практика. Даже если в этом случае их использование выглядит безобидно, лучше не привыкать так писать.
        public Func<string, string> ReadText;
        public readonly Func<string, IEnumerable<string>> ExtractWords;
        public readonly Func<IEnumerable<string>, IEnumerable<string>> FilterWords;
        public readonly Func<IEnumerable<string>, Tuple<string, int>[]> CountFrequencies;
        public readonly Func<Tuple<string, int>[], InputOptions, IEnumerable<Tuple<string, int>>> CountFonts;
        public Func<IEnumerable<Tuple<string, int>>, InputOptions, Bitmap> GetBitmap;

        // CR (krait): Кажется, что вместо изменения полей снаружи, можно принимать InputOptions и принимать решения по биндингу в этом конструкторе.
        public Kernel()
        {
            // CR (krait): Незачем усложнять сигнатуры всех этих методов передачей InputOptions. Вместо этого можно сделать классы не статическими и передавать параметры в конструкторе.
            // CR (krait): При этом лучше передавать не InputOptions, а конкретные параметры, нужные для работы компонента. Так будет понятнее, что от чего зависит.
            ReadText = TxtReader.GetRawText;
            ExtractWords = WordsFromTextExtractor.GetWords;
            FilterWords = WordsFilter.RemoveBadWords;
            CountFrequencies = FrequencyCounter.GetWordsFrequencies;
            CountFonts = FontProcessor.GetFonts;
            GetBitmap = ColumnsAlgorithm.GetBitmap;
        }
    }
}
