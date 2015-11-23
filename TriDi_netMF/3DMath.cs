using System;
using Microsoft.SPOT;

namespace TriDi_netMF
{
    public static class Math3D
    {
        public static void MatrixNorm(float[][] matrix)
        {
            int xmax = matrix[0].Length;
            int ymax = matrix.Length;
            for (int x = 0; x < xmax; x++)
            {
                for (int y = 0; y < ymax; y++)
                {
                    matrix[y][x] /= matrix[ymax - 1][xmax - 1];
                }
            }
        }

        public static float[][] ViewportMatrix(int width, int height)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            MatrixDiagonalFill(res);
            res[0][0] = width / 2.0f;
            res[0][3] = width / 2.0f;
            res[1][1] = -height / 2.0f;
            res[1][3] = height / 2.0f;
            res[2][3] = 1.0f;
            return res;
        }

        public static float[][] ProjectionMatrix(float nearClip, float farClip, float vFOV, float aspect)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            MatrixZeroFill(res);
            res[0][0] = 1.0f / (float)System.Math.Tan(vFOV) / aspect;
            res[1][1] = 1.0f / (float)System.Math.Tan(vFOV);
            res[2][2] = farClip / (farClip - nearClip);
            res[3][2] = -farClip / (farClip - nearClip) * nearClip;
            res[2][3] = 1.0f;
            return res;
        }

        public static float[][] TranslateMatrix(float x, float y, float z)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            MatrixDiagonalFill(res);
            res[0][3] = x;
            res[1][3] = y;
            res[2][3] = z;
            return res;
        }

        public static float[][] RotateMatrix(Axis axis, float angle)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            MatrixDiagonalFill(res);
            switch (axis)
            {
                case Axis.X:
                    {
                        res[1][1] = (float)System.Math.Cos(angle);
                        res[1][2] = (float)System.Math.Sin(angle);
                        res[2][1] = -(float)System.Math.Sin(angle);
                        res[2][2] = (float)System.Math.Cos(angle);
                        break;
                    }
                case Axis.Y:
                    {
                        res[0][0] = (float)System.Math.Cos(angle);
                        res[0][2] = (float)System.Math.Sin(angle);
                        res[2][0] = -(float)System.Math.Sin(angle);
                        res[2][2] = (float)System.Math.Cos(angle);
                        break;
                    }
                case Axis.Z:
                    {
                        res[0][0] = (float)System.Math.Cos(angle);
                        res[0][1] = (float)System.Math.Sin(angle);
                        res[1][0] = -(float)System.Math.Sin(angle);
                        res[1][1] = (float)System.Math.Cos(angle);
                        break;
                    }
            }
            return res;
        }

        public static float[][] ScaleMatrix(float scaleX, float scaleY, float scaleZ)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            MatrixZeroFill(res);
            res[0][0] = scaleX;
            res[1][1] = scaleY;
            res[2][2] = scaleZ;
            res[3][3] = 1.0f;
            return res;
        }

        public static float[] MatrixToVector(float[][] vector, bool isColumn)
        {
            float[] res;
            if (isColumn)
            {
                res = new float[vector.Length];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = vector[i][0];
                }
            }
            else
            {
                res = new float[vector[0].Length];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = vector[0][i];
                }
            }
            return res;
        }

        public static float[][] VectorToMatrix(float[] vector, bool isColumn)
        {
            float[][] res = new float[4][];
            res[0] = new float[4];
            res[1] = new float[4];
            res[2] = new float[4];
            res[3] = new float[4];
            if (!isColumn)
            {
                res = new float[1][];
                res[0] = new float[vector.Length];
                for (int i = 0; i < vector.Length; i++)
                {
                    res[0][i] = vector[i];
                }
            }
            else
            {
                res = new float[vector.Length][];
                for (int i = 0; i < vector.Length; i++)
                {
                    res[i] = new float[1];
                    res[i][0] = vector[i];
                }
            }
            return res;
        }

        public static float[][] MatrixM(float[][] m1, float[][] m2)
        {
            if (m2[0].Length == m1.Length)
            {
                int xmax = m2.Length;
                int ymax = m1[0].Length;
                int zmax = m2[0].Length;
                float[][] res = new float[xmax][];
                for (int x = 0; x < xmax; x++)
                {
                    res[x] = new float[ymax];
                    for (int y = 0; y < ymax; y++)
                    {
                        res[x][y] = 0.0f;
                        for (int z = 0; z < zmax; z++)
                        {
                            res[x][y] += m2[x][z] * m1[z][y];
                        }
                    }
                }
                return res;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static float[][] MatrixAdd(float[][] m1, float[][] m2)
        {
            int m1l0 = m1.Length;
            int m1l1 = m1[0].Length;
            if ((m1l0 == m2.Length) && (m1l1 == m2[0].Length))
            {
                float[][] mr = new float[m1l0][];
                for (int i = 0; i < m1l0; i++)
                {
                    mr[i] = new float[m1l1];
                    for (int j = 0; j < m1l1; j++)
                    {
                        mr[i][j] = m1[i][j] + m2[i][j];
                    }
                }
                return mr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static void MatrixDiagonalFill(float[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[i][j] = (i != j) ? 0.0f : 1.0f;
                }
            }
        }

        public static void MatrixZeroFill(float[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[i][j] = 0.0f;
                }
            }
        }

        public static float[] VectorCrossM(float[] v1, float[] v2)
        {
            return new float[3] { v1[1] * v2[2] - v1[2] * v2[1],
                v1[2] * v2[0] - v1[0] * v2[2],
                v1[0] * v2[1] - v1[1] * v2[0] };
        }

        public static float[] VectorDotM(float[] v1, float[] v2)
        {
            return new float[3] { v1[0] * v2[0], v1[1] * v2[1], v1[2] * v2[2] };
        }

        public static float[] VectorSub(float[] v1, float[] v2)
        {
            return new float[3] { v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2] };
        }

        public static float[] VectorAdd(float[] v1, float[] v2)
        {
            return new float[3] { v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2] };
        }

        public static float[] VectorNormalize(float[] vector)
        {
            return VectorScalarM(vector, 1.0f / VectorLength(vector));
        }

        public static float[] VectorScalarM(float[] vector, float scalar)
        {
            return new float[3] { vector[0] * scalar, vector[1] * scalar, vector[2] * scalar };
        }

        public static float VectorLength(float[] vector)
        {
            return (float)System.Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1] + vector[2] * vector[2]);
        }

        public enum Axis
        {
            X, Y, Z
        };
    }
}
