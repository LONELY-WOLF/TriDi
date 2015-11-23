using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Media;

namespace TriDi_netMF
{
    public static class Display
    {
        public static bool[][] buffer = new bool[240][];

        public static void Init()
        {
            for (int i = 0; i < 240; i++)
            {
                buffer[i] = new bool[320];
            }
        }

        public static void Fill(bool color)
        {
            for (int x = 0; x < 240; x++)
            {
                for (int y = 0; y < 320; y++)
                {
                    buffer[x][y] = color;
                }
            }
        }

        public static void DrawLine(int x1, int y1, int x2, int y2, bool color)
        {
            int x_s, x_e;
            float slope;
            bool useX;
            if (x1 == x2)
            {
                if (y1 == y2)
                {
                    DrawPoint(x1, y1, color);
                    return;
                }
                useX = false;
                slope = (float)(x2 - x1) / (y2 - y1);
            }
            else
            {
                slope = (float)(y2 - y1) / (x2 - x1);
                useX = System.Math.Abs(slope) < 1.0f;
                if (!useX) slope = 1.0f / slope;
            }
            float y;
            if (useX) //X is primary
            {
                if (x1 < x2)
                {
                    x_s = x1;
                    x_e = x2;
                    y = y1 + 0.5f;
                }
                else
                {
                    x_s = x2;
                    x_e = x1;
                    y = y2 + 0.5f;
                }
                for (int x = x_s; x < x_e; x++)
                {
                    DrawPoint(x, (int)y, color);
                    y += slope;
                }
            }
            else //Y is primary
            {
                //slope = 1 / slope;
                if (y1 < y2)
                {
                    x_s = y1;
                    x_e = y2;
                    y = x1 + 0.5f;
                }
                else
                {
                    x_s = y2;
                    x_e = y1;
                    y = x2 + 0.5f;
                }
                for (int x = x_s; x < x_e; x++)
                {
                    DrawPoint((int)y, x, color);
                    y += slope;
                }
            }
        }

        public static void DrawLine(int x1, int y1, int x2, int y2, bool color, Bitmap bmp)
        {
            int x_s, x_e;
            float slope;
            bool useX;
            if (x1 == x2)
            {
                if (y1 == y2)
                {
                    DrawPoint(x1, y1, color);
                    return;
                }
                useX = false;
                slope = (float)(x2 - x1) / (y2 - y1);
            }
            else
            {
                slope = (float)(y2 - y1) / (x2 - x1);
                useX = System.Math.Abs(slope) < 1.0f;
                if (!useX) slope = 1.0f / slope;
            }
            float y;
            if (useX) //X is primary
            {
                if (x1 < x2)
                {
                    x_s = x1;
                    x_e = x2;
                    y = y1 + 0.5f;
                }
                else
                {
                    x_s = x2;
                    x_e = x1;
                    y = y2 + 0.5f;
                }
                for (int x = x_s; x < x_e; x++)
                {
                    //DrawPoint(x, (int)y, color);
                    bmp.SetPixel(x, (int)y, color ? Color.Black : Color.White);
                    y += slope;
                }
            }
            else //Y is primary
            {
                //slope = 1 / slope;
                if (y1 < y2)
                {
                    x_s = y1;
                    x_e = y2;
                    y = x1 + 0.5f;
                }
                else
                {
                    x_s = y2;
                    x_e = y1;
                    y = x2 + 0.5f;
                }
                for (int x = x_s; x < x_e; x++)
                {
                    DrawPoint((int)y, x, color);
                    y += slope;
                }
            }
        }

        public static void DrawPoint(int x, int y, bool color)
        {
            if ((x >= 0) && (y >= 0) && (x < 240) && (y < 320))
            {
                buffer[x][y] = color;
            }
        }
    }
}
