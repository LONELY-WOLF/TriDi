using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriDi
{
    static class Math3D
    {
        public static double[] VectorCrossM(double[] vector1, double[] vector2)
        {
            return new double[3] { vector1[1] * vector2[2] - vector1[2] * vector2[1],
                vector1[2] * vector2[0] - vector1[0] * vector2[2],
                vector1[0] * vector2[1] - vector1[1] * vector2[0] };
        }

        public static double[] VectorDotM(double[] vector1, double[] vector2)
        {
            return new double[3] { vector1[0] * vector2[0], vector1[1] * vector2[1], vector1[2] * vector2[2] };
        }

        public static double[] VectorSub(double[] vector1, double[] vector2)
        {
            return new double[3] { vector1[0] - vector2[0], vector1[1] - vector2[1], vector1[2] - vector2[2] };
        }

        public static double[] VectorAdd(double[] vector1, double[] vector2)
        {
            return new double[3] { vector1[0] + vector2[0], vector1[1] + vector2[1], vector1[2] + vector2[2] };
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
