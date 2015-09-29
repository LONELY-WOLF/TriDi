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
        Bitmap bmp = new Bitmap(300, 200);

        private void Form1_Load(object sender, EventArgs e)
        {
            for (double i = 0; i < Math.PI * 2.0; i += Math.PI / 6.0)
            {
                Display.DrawLine(150, 100, 150 + (int)(Math.Cos(i) * 50.0), 100 + (int)(Math.Sin(i) * 50.0), true);
            }
            DrawBuffer();
        }

        void DrawBuffer()
        {
            for (int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    bmp.SetPixel(x, y, Display.buffer[x, y] ? Color.Black : Color.White);
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
