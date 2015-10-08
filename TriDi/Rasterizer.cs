using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriDi
{
    static class Rasterizer
    {
        public static float[,] ZBuffer = new float[300, 200];

        public static Texture LoadTexture(string filename)
        {
            Bitmap bmp = new Bitmap(filename);
            bmp.MakeTransparent(Color.FromArgb(0, 255, 0));
            Texture t;
            t.Bitmap = new bool[bmp.Width, bmp.Height];
            t.Alpha = new bool[bmp.Width, bmp.Height];
            for(int x = 0;x< bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height;y++)
                {
                    Color p = bmp.GetPixel(x, y);
                    if (p.A == 0)
                    {
                        t.Alpha[x,y] = false;
                    }
                    else
                    {
                        t.Alpha[x, y] = true;
                        t.Bitmap[x, y] = (p == Color.Black);
                    }
                }
            }
            return t;
        }

        public struct Texture
        {
            public bool[,] Bitmap;
            public bool[,] Alpha;
        }
    }
}
