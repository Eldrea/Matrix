using System;
using System.Linq;

namespace Matrix
{
    class Matrix
    {

        private double[,] matrix = new double[,] { };
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public Matrix()
        {
            matrix = new double[2, 2] { { 0, 0 }, { 0, 0 } };
        }
        public Matrix(double a, double b, double c, double d)
        {
            matrix = new double[2, 2] { { a, b }, { c, d } };
        }
        public Matrix Invertible
        {
            get
            {
                double det = this.Det;
                try
                {
                    Matrix invertible = new Matrix(this[1, 1] / det, -this[0, 1] / det, -this[1, 0] / det, this[0, 0] / det);
                    return invertible;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public override string ToString()
        {
            string s = $"{matrix[0, 0]} {matrix[0, 1]} \n{matrix[1, 0]} {matrix[1, 1]}";
            return s;
        }
        public double Det
        {
            get { return (this[0, 0] * this[1, 1]) - (this[0, 1] * this[1, 0]); }
        }
        public static bool operator ==(Matrix m1, Matrix m2)
        {
            return m1.Det == m2.Det;
        }
        public static bool operator !=(Matrix m1, Matrix m2)
        {
            return m1.Det != m2.Det;
        }
        public static bool operator >(Matrix m1, Matrix m2)
        {
            return m1.Det > m2.Det;
        }
        public static bool operator <(Matrix m1, Matrix m2)
        {
            return m1.Det < m2.Det;
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) m1[i, j] += m2[i, j];
            }
            return m1;
        }
        public static Matrix operator ++(Matrix m1)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) m1[i, j] += 1;
            }
            return m1;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) m1[i, j] -= m2[i, j];
            }
            return m1;
        }
        public static Matrix operator --(Matrix m1)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) m1[i, j] -= 1;
            }
            return m1;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix res = new Matrix(0, 0, 0, 0);
            res[0, 0] = m1[0, 0] * m2[0, 0] + m1[0, 1] * m2[1, 0];
            res[0, 1] = m1[0, 0] * m2[0, 1] + m1[0, 1] * m2[1, 1];
            res[1, 0] = m1[1, 0] * m2[0, 0] + m1[1, 1] * m2[1, 0];
            res[1, 1] = m1[1, 0] * m2[0, 1] + m1[1, 1] * m2[1, 1];
            return res;
        }
        public static Matrix operator /(Matrix m1, Matrix m2)
        {
            return m1 * m2.Invertible;
        }

        public static Matrix Parse(string s)
        {
            Matrix matrix = new Matrix();
            int[] ia = s.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            matrix[0, 0] = ia[0];
            matrix[0, 1] = ia[1];
            matrix[1, 0] = ia[2];
            matrix[1, 1] = ia[3];
            return matrix;
        }
        public static Matrix TryParse(string s)
        {
            try
            {
                return Parse(s);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


    class Programm
    {
        static void Display(Matrix matrix)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++) Console.Write(matrix[i, j] + " ");
                Console.WriteLine("");
            }
        }
        static void printArray(ListOfMatrix arr)
        {
            int n = arr.count;
            for (int i = 0; i < n; ++i)
            {
                Display(arr[i]);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\pboga\source\repos\Matrix\Matrix\bin\Debug\MatrixIn.txt";
            ListOfMatrix list = MatrixInOut.MatrixOut(path);
            printArray(list);

        }

    }
}
