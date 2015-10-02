using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriDi
{
    static class Math3D
    {
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
            if (isColumn)
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
    }
}
