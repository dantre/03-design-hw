﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloud.Concrete.Algorithms
{
    public class ColumnsAlgorithm 
    {
        // CR (krait): Зачем в имени _inputOptions подчеркивание? Чем этот параметр особенный? 
        public static Bitmap GetBitmap(IEnumerable<Tuple<string, int>> fonts, InputOptions _inputOptions)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, _inputOptions).ToList();
            int maxHeight = textImages.Max(i => i.Height);
            int sumWidth = textImages.Sum(i => i.Width);

            int countLines = Math.Max(5, sumWidth / 1024);
            int lineWidth = sumWidth/countLines;

            var resultImage = new Bitmap(lineWidth + 100, maxHeight * countLines);
            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(Color.FromName(_inputOptions.BackgroundColor));
            objGraphics.Flush();

            int x = 0;
            int yAddition = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0, 0, image.Width, image.Height), 
                    resultImage, new Rectangle(x, (maxHeight - image.Height) / 2 + yAddition, image.Width, image.Height));
                x += image.Width;
                if (x > lineWidth)
                {
                    x = 0;
                    yAddition += maxHeight;
                }
            }

            return BitmapMethods.ResizeImage(resultImage, _inputOptions.Width, _inputOptions.Height);
        }
    }
}