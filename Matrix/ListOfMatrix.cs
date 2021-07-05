using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class ListOfMatrix
    {
        List<Matrix> listofmatrix = new List<Matrix>();
        public Matrix this[int i]
        {
            get
            {
                try { return listofmatrix[i]; }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            set
            {
                try { listofmatrix[i] = value; }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
        public int count { get; set; }
        public ListOfMatrix(Matrix[] arr_of_matrix)
        {
            count = arr_of_matrix.Length;
            listofmatrix = new List<Matrix>();
            for (int i = 0; i < arr_of_matrix.Length; i++)
            {
                listofmatrix.Add(arr_of_matrix[i]);
            }
        }
        public void AddMatrix(Matrix m)
        {
            listofmatrix.Add(m);
            count++;
        }

        public Matrix Min()
        {
            double min_det = double.MaxValue;
            int m_index = -1;
            for(int i = 0; i < this.count; i++)
            {
                if (this[i].Det < min_det)
                {
                    min_det = this[i].Det;
                    m_index = i;
                }
            }
            return this[m_index];
        }
        public Matrix Max()
        {
            double max_det = double.MinValue;
            int m_index = -1;
            for (int i = 0; i < this.count; i++)
            {
                if (this[i].Det > max_det)
                {
                    max_det = this[i].Det;
                    m_index = i;
                }
            }
            return this[m_index];
        }
        public ListOfMatrix Sort()
        {
            return this;
        }

    }
}
