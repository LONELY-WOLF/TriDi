using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriDi
{
    static class Display
    {
        public static bool[,] buffer = new bool[300, 200];

        public static void DrawLine(int x1, int y1, int x2, int y2, bool color)
        {
            int x_s, x_e;
            float slope = (float)(y2 - y1) / (x2 - x1);
            float y;
            if (Math.Abs(slope) < 1.0f) //X is primary
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
                slope = 1 / slope;
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
            if ((x >= 0) && (y >= 0) && (x < 300) && (y < 200))
            {
                buffer[x, y] = color;
            }
        }
    }
}
