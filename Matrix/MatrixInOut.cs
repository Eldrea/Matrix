using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Matrix
{
    static class MatrixInOut
    {
        internal static void MatrixIn(ListOfMatrix list)
        {
            string dir = Directory.GetCurrentDirectory();
            string path = dir + "MatrixIn.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    for(int i = 0; i < list.count; i++) sw.WriteLine($"{list[i]}\n" );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        internal static ListOfMatrix MatrixOut(string filename)
        {
            Matrix[] arr_m = new Matrix[] { };
            ListOfMatrix list_of_matrix = new ListOfMatrix(arr_m);
            try
            {
                List<string> string_list = File.ReadAllLines(filename).ToList();
                for (int i =0; i<string_list.Count;i++)
                {
                    if (string_list[i] != string.Empty) list_of_matrix.AddMatrix(Matrix.TryParse(string_list[i]));
                }
                return list_of_matrix;
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
