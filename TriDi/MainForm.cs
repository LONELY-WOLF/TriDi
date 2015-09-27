using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriDi
{
    public partial class MainForm : Form
    {
        bool[,] buffer = new bool[300, 200];
        Bitmap bmp = new Bitmap(300, 200);

        private void Form1_Load(object sender, EventArgs e)
        {
            for (double i = 0; i < Math.PI * 2.0; i += Math.PI / 6.0)
            {
                DrawLine(150, 100, 150 + (int)(Math.Cos(i) * 50.0), 100 + (int)(Math.Sin(i) * 50.0), true);
            }
            DrawBuffer();
        }

        void DrawLine(int x1, int y1, int x2, int y2, bool color)
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

        void DrawPoint(int x, int y, bool color)
        {
            if ((x >= 0) && (y >= 0) && (x < 300) && (y < 200))
            {
                buffer[x, y] = color;
            }
        }

        void DrawBuffer()
        {
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    bmp.SetPixel(x, y, buffer[x, y] ? Color.Black : Color.White);
                }
            }
            display.Image = bmp;
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void display_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(
               display.Image,
                new Rectangle(0, 0, display.Width, display.Height),
                // destination rectangle 
                0,
                0,           // upper-left corner of source rectangle
                display.Image.Width,       // width of source rectangle
                display.Image.Height,      // height of source rectangle
                GraphicsUnit.Pixel);
        }
    }
}
