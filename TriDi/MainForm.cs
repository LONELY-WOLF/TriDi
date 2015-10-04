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
            display.Image = bmp;
            display_Click(null, null);
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

        private void display_Click(object sender, EventArgs e)
        {
            List<double[,]> cube = new List<double[,]>(24); //12 lines

            //1st
            double[] tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            //2nd
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            //3rd
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            //4th
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));
            tPoint = new double[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube.Add(Math3D.VectorToMatrix(tPoint, true));

            double[,] Mp = Math3D.ProjectionMatrix(1.0, 100.0, Math.PI * 0.3, 1.5);
            double[,] Mt = Math3D.TranslateMatrix(0, 0, 2);
            double[,] M = Math3D.MatrixM(Mp, Mt);
            List<double[,]> cube2 = new List<double[,]>(24); //12 lines
            foreach (double[,] p in cube)
            {
                cube2.Add(Math3D.MatrixM(M, p));
                Math3D.MatrixNorm(cube2.Last());
            }

            for (int i = 0; i < 24; i += 2)
            {
                Display.DrawLine((int)(cube2[i][0, 0] * 150) + 150, (int)(cube2[i][1, 0] * 100) + 100, (int)(cube2[i + 1][0, 0] * 150) + 150, (int)(cube2[i + 1][1, 0] * 100) + 100, true);
            }

            //for (double i = 0; i < Math.PI * 2.0; i += Math.PI / 6.0)
            //{
            //    Display.DrawLine(150, 100, 150 + (int)(Math.Cos(i) * 50.0), 100 + (int)(Math.Sin(i) * 50.0), true);
            //}
            DrawBuffer();
        }
    }
}
