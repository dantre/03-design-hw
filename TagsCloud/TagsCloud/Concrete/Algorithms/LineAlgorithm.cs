﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloud.Concrete.Algorithms
{
    public class LineAlgorithm
    {
        private readonly string fontName;
        private readonly string backgroundColor;
        private readonly string textColor;
        private readonly int width;
        private readonly int height;

        public LineAlgorithm(InputOptions inputOptions)
        {
            fontName = inputOptions.FontName;
            backgroundColor = inputOptions.BackgroundColor;
            textColor = inputOptions.TextColor;
            width = inputOptions.Width;
            height = inputOptions.Height;
        }
        public Bitmap GetBitmap(IEnumerable<Tuple<string, int>> fonts)
        {
            var textImages = BitmapMethods.GetTextImages(fonts, fontName, backgroundColor, textColor).ToList();
            int maxHeight = textImages.Max(i => i.Height);
            var resultImage = new Bitmap(textImages.Sum(i => i.Width), maxHeight);

            var objGraphics = Graphics.FromImage(resultImage);
            objGraphics.Clear(Color.FromName(backgroundColor));
            objGraphics.Flush();

            int x = 0;
            foreach (var image in textImages)
            {
                resultImage = BitmapMethods.CopyRegionIntoImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    resultImage, new Rectangle(x, (maxHeight - image.Height) / 2, image.Width, image.Height));
                x += image.Width;
            }
            return BitmapMethods.ResizeImage(resultImage, width, height);
        }
    }
}
