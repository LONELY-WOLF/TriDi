using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriDi
{
    static class Math3D
    {
        public static void MatrixNorm(double[,] matrix)
        {
            int xmax = matrix.GetLength(1);
            int ymax = matrix.GetLength(0);
            for (int x = 0; x < xmax; x++)
            {
                for (int y = 0; y < ymax; y++)
                {
                    matrix[y, x] /= matrix[ymax - 1, xmax - 1];
                }
            }
        }

        public static double[,] ViewportMatrix(int width, int height)
        {
            double[,] res = new double[4, 4];
            MatrixDiagonalFill(res);
            res[0, 0] = width / 2.0;
            res[0, 3] = width / 2.0;
            res[1, 1] = -height / 2.0;
            res[1, 3] = height / 2.0;
            res[2, 3] = 1;
            return res;
        }

        public static double[,] ProjectionMatrix(double nearClip, double farClip, double vFOV, double aspect)
        {
            double[,] res = new double[4, 4];
            MatrixZeroFill(res);
            res[0, 0] = 1.0 / Math.Tan(vFOV) / aspect;
            res[1, 1] = 1.0 / Math.Tan(vFOV);
            res[2, 2] = farClip / (farClip - nearClip);
            res[3, 2] = -farClip / (farClip - nearClip) * nearClip;
            res[2, 3] = 1.0;
            return res;
        }

        public static double[,] TranslateMatrix(double x, double y, double z)
        {
            double[,] res = new double[4, 4];
            MatrixDiagonalFill(res);
            res[0, 3] = x;
            res[1, 3] = y;
            res[2, 3] = z;
            return res;
        }

        public static double[,] RotateMatrix(Axis axis, double angle)
        {
            double[,] res = new double[4, 4];
            MatrixDiagonalFill(res);
            switch (axis)
            {
                case Axis.X:
                    {
                        res[1, 1] = Math.Cos(angle);
                        res[1, 2] = Math.Sin(angle);
                        res[2, 1] = -Math.Sin(angle);
                        res[2, 2] = Math.Cos(angle);
                        break;
                    }
                case Axis.Y:
                    {
                        res[0, 0] = Math.Cos(angle);
                        res[0, 2] = Math.Sin(angle);
                        res[2, 0] = -Math.Sin(angle);
                        res[2, 2] = Math.Cos(angle);
                        break;
                    }
                case Axis.Z:
                    {
                        res[0, 0] = Math.Cos(angle);
                        res[0, 1] = Math.Sin(angle);
                        res[1, 0] = -Math.Sin(angle);
                        res[1, 1] = Math.Cos(angle);
                        break;
                    }
            }
            return res;
        }

        public static double[,] ScaleMatrix(double scaleX, double scaleY, double scaleZ)
        {
            double[,] res = new double[4, 4];
            MatrixZeroFill(res);
            res[0, 0] = scaleX;
            res[1, 1] = scaleY;
            res[2, 2] = scaleZ;
            res[3, 3] = 1.0;
            return res;
        }

        public static double[] MatrixToVector(double[,] vector, bool isColumn)
        {
            double[] res;
            if (isColumn)
            {
                res = new double[vector.GetLength(0)];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = vector[i, 0];
                }
            }
            else
            {
                res = new double[vector.GetLength(1)];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = vector[0, i];
                }
            }
            return res;
        }

        public static double[,] VectorToMatrix(double[] vector, bool isColumn)
        {
            double[,] res;
            if (!isColumn)
            {
                res = new double[1, vector.Length];
                for (int i = 0; i < vector.Length; i++)
                {
                    res[0, i] = vector[i];
                }
            }
            else
            {
                res = new double[vector.Length, 1];
                for (int i = 0; i < vector.Length; i++)
                {
                    res[i, 0] = vector[i];
                }
            }
            return res;
        }

        public static double[,] MatrixM(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) == m2.GetLength(0))
            {
                int xmax = m1.GetLength(0);
                int ymax = m2.GetLength(1);
                int zmax = m1.GetLength(1);
                double[,] res = new double[xmax, ymax];
                for (int x = 0; x < xmax; x++)
                {
                    for (int y = 0; y < ymax; y++)
                    {
                        res[x, y] = 0.0;
                        for (int z = 0; z < zmax; z++)
                        {
                            res[x, y] += m1[x, z] * m2[z, y];
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

        public static double[,] MatrixAdd(double[,] m1, double[,] m2)
        {
            int m1l0 = m1.GetLength(0);
            int m1l1 = m1.GetLength(1);
            if ((m1l0 == m2.GetLength(0)) && (m1l1 == m2.GetLength(1)))
            {
                double[,] mr = new double[m1l0, m1l1];
                for (int i = 0; i < m1l0; i++)
                {
                    for (int j = 0; j < m1l1; j++)
                    {
                        mr[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                return mr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static void MatrixDiagonalFill(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = (i != j) ? 0.0 : 1.0;
                }
            }
        }

        public static void MatrixZeroFill(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0.0;
                }
            }
        }

        public static double[] VectorCrossM(double[] v1, double[] v2)
        {
            return new double[3] { v1[1] * v2[2] - v1[2] * v2[1],
                v1[2] * v2[0] - v1[0] * v2[2],
                v1[0] * v2[1] - v1[1] * v2[0] };
        }

        public static double[] VectorDotM(double[] v1, double[] v2)
        {
            return new double[3] { v1[0] * v2[0], v1[1] * v2[1], v1[2] * v2[2] };
        }

        public static double[] VectorSub(double[] v1, double[] v2)
        {
            return new double[3] { v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2] };
        }

        public static double[] VectorAdd(double[] v1, double[] v2)
        {
            return new double[3] { v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2] };
        }

        public static double[] VectorNormalize(double[] vector)
        {
            return VectorScalarM(vector, 1.0 / VectorLength(vector));
        }

        public static double[] VectorScalarM(double[] vector, double scalar)
        {
            return new double[3] { vector[0] * scalar, vector[1] * scalar, vector[2] * scalar };
        }

        public static double VectorLength(double[] vector)
        {
            return Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1] + vector[2] * vector[2]);
        }

        public enum Axis
        {
            X, Y, Z
        };
    }
}
