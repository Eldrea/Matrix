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
		public void merge(int l, int m, int r)
		{
			int n1 = m - l + 1;
			int n2 = r - m;
			Matrix[] L = new Matrix[n1];
			Matrix[] R = new Matrix[n2];
			int i, j;
			for (i = 0; i < n1; ++i)
				L[i] = this[l + i];
			for (j = 0; j < n2; ++j)
				R[j] = this[m + 1 + j];
			i = 0;
			j = 0;
			int k = l;
			while (i < n1 && j < n2)
			{
				if (L[i].Det <= R[j].Det)
				{
					this[k] = L[i];
					i++;
				}
				else
				{
					this[k] = R[j];
					j++;
				}
				k++;
			}
			while (i < n1)
			{
				this[k] = L[i];
				i++;
				k++;
			}
			while (j < n2)
			{
				this[k] = R[j];
				j++;
				k++;
			}
		}
		public void sort(int l, int r)
		{
			if (l < r)
			{
				int m = l + (r - l) / 2;
				sort(l, m);
				sort(m + 1, r);
				merge(l, m, r);
			}
		}
        public void ToArrString()
        {
            List<string> arr = new List<string>();
            for (int i = 0; i < this.count; i++)
            {
                arr.Add($"{this[i].ToString()} ");
            }
            for(int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]+'\n');
            }
        }
        public Matrix[] ToArray()
        {
            Matrix[] arr = new Matrix[count];
            for (int i = 0; i < count; i++) arr[i] = this[i];
            return arr;
        }
        public Matrix First()
        {
            return this[0];
        }
        public Matrix Last()
        {
            return this[count - 1];
        }
	}
}
