using System;
using Microsoft.SPOT;
using TriDi_netMF;
using Microsoft.SPOT.Presentation.Media;

namespace TriDi_netMF_demo_CLI
{
    public class Program
    {
        Bitmap bmp = new Bitmap(240, 320);
        float angle;
        float[][][] cube = new float[24][][];

        public static void Main()
        {
            Program app = new Program();

            Display.Init();
            app.CubeInit();

            while (true)
            {
                Display.Fill(false);
                app.angle += 0.05f;
                if (app.angle > (float)System.Math.PI * 2.0f)
                {
                    app.angle -= (float)System.Math.PI * 2.0f;
                }
                app.drawCube();
            }
        }

        public void CubeInit()
        {
            cube = new float[24][][];
            //1st
            float[] tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[0] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[1] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[2] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[3] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[4] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[5] = Math3D.VectorToMatrix(tPoint, true);

            //2nd
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[6] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[7] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[8] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[9] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[10] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[11] = Math3D.VectorToMatrix(tPoint, true);

            //3rd
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[12] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[13] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[14] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[15] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = 1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[16] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[17] = Math3D.VectorToMatrix(tPoint, true);

            //4th
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[18] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[19] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[20] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = -1;
            tPoint[3] = 1;
            cube[21] = Math3D.VectorToMatrix(tPoint, true);

            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = 1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[22] = Math3D.VectorToMatrix(tPoint, true);
            tPoint = new float[4];
            tPoint[0] = -1;
            tPoint[1] = -1;
            tPoint[2] = 1;
            tPoint[3] = 1;
            cube[23] = Math3D.VectorToMatrix(tPoint, true);
        }

        void drawCube()
        {
            float[][] Mr = Math3D.RotateMatrix(Math3D.Axis.Y, angle);
            float[][] Mp = Math3D.ProjectionMatrix(1.0f, 100.0f, (float)System.Math.PI * 0.15f, 240.0f / 320.0f);
            float[][] Mvp = Math3D.ViewportMatrix(240, 320);
            float[][] Mt = Math3D.TranslateMatrix(0, 0, 4);
            float[][] M = Math3D.MatrixM(Mr, Mt);
            M = Math3D.MatrixM(M, Mp);
            M = Math3D.MatrixM(M, Mvp);
            float[][][] cube2 = new float[24][][]; //12 lines
            for (int i = 0; i < 24; i++)
            {
                float[][] tVec = Math3D.MatrixM(cube[i], M);
                Math3D.MatrixNorm(tVec);
                cube2[i] = tVec;
            }

            for (int i = 0; i < 24; i += 2)
            {
                Display.DrawLine((int)(cube2[i][0][0]), (int)(cube2[i][1][0]), (int)(cube2[i + 1][0][0]), (int)(cube2[i + 1][1][0]), true);
            }
            DrawBuffer();
        }

        void DrawBuffer()
        {
            for (int x = 0; x < 240; x++)
            {
                for (int y = 0; y < 320; y++)
                {
                    bmp.SetPixel(x, y, Display.buffer[x][y] ? Color.Black : Color.White);
                }
            }
            bmp.Flush();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Display.Fill(false);
            angle += 0.05f;
            if (angle > (float)System.Math.PI * 2.0f)
            {
                angle -= (float)System.Math.PI * 2.0f;
            }
            this.drawCube();
        }
    }
}
