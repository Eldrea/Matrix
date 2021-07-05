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
        public ListOfMatrix(List<Matrix> arr_of_matrix)
        {
            listofmatrix = new List<Matrix>();
            for (int i = 0; i < arr_of_matrix.Count; i++)
            {
                listofmatrix.Add(arr_of_matrix[i]);
            }
        }
    }
}
