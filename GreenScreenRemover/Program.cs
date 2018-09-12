using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace GreenScreenRemover
{
    class Program
    {
        private const string SOURCE_PATH = "./source.png";
        private const string RESULT_PATH = "./result.png";

        public static void Main(string[] args)
        {
            string sourcePath = SOURCE_PATH;
            string resultPath = RESULT_PATH;
            byte threshold = 10;

            if (args.Length >= 1)
            {
                sourcePath = args[0];
            }
            if (args.Length >= 2)
            {
                resultPath = args[1];
            }
            if (args.Length >= 3)
            {
                if (byte.TryParse(args[2], out byte b))
                {
                    threshold = b;
                }
            }

            removeBackground(sourcePath, resultPath, threshold);
        }

        private static void removeBackground(string sourcePath, string resultPath, byte threshold = 10)
        {
            Bitmap source = null;
            Bitmap result = null;
            try
            {
                source = new Bitmap(sourcePath);
                result = new Bitmap(source);
                for (int x = 0; x < source.Width; x++)
                {
                    for (int y = 0; y < source.Height; y++)
                    {
                        var color = source.GetPixel(x, y);
                        if (color.G > color.R + threshold
                        && color.G > color.B + threshold)
                        {
                            color = Color.Transparent;
                        }

                        result.SetPixel(x, y, color);
                    }
                }
                result.Save(resultPath, ImageFormat.Png);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                }
                if (result != null)
                {
                    result.Dispose();
                }
            }
        }
    }
}
