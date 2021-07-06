using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    class Program
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
            Matrix[] arr_matrix = new Matrix[] { };
            ListOfMatrix list_matrix = new ListOfMatrix(arr_matrix);
            
            bool check = true;
            while (check)
            {
                Console.WriteLine("1 - add matrix\n" +
                    "2 - == [i] [j]\n" +
                    "3 - != [i] [j]\n" +
                    "4 - > [i] [j]\n" +
                    "5 - < [i] [j]\n" +
                    "6 - [i] + [j]\n" +
                    "7 - [i]++\n" +
                    "8 - [i] - [j]\n" +
                    "9 - [i]--\n" +
                    "10 - [i] * [j]\n" +
                    "11 - [i] / [j]\n" +
                    "12 - Invertible [i]\n" +
                    "13 - Display all\n" +
                    "14 - Find determinant of entered matrix\n" +
                    "15 - Display First Matrix\n"+
                    "16 - Display Last Matrix\n"+
                    "17 - Sort ListOfMatrix\n"+
                    "18 - Convert ListOfMatrix to ArrayOfMatrix and Display\n"+
                    "19 - Convert to ArraySting and Display\n"+
                    "20 - Det [i]\n"+
                    "21 - Record in File\n" +
                    "22 - Read from File s\n" +
                    "23 - Exit\n"
                    );
                int switch_case = Convert.ToInt32(Console.ReadLine());
                switch (switch_case)
                {
                    case 1: // add matrix
                        string s = Console.ReadLine();
                        list_matrix.AddMatrix(Matrix.Parse(s));
                        Console.WriteLine("Matrix Added\n");
                        break;
                    case 2: // == 
                        int i = Convert.ToInt32(Console.ReadLine());
                        int j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list_matrix[i] == list_matrix[j]);
                        break;
                    case 3:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list_matrix[i] != list_matrix[j]);
                        break;
                    case 4:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list_matrix[i] > list_matrix[j]);
                        break;
                    case 5:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list_matrix[i] < list_matrix[j]);
                        break;
                    case 6:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i] + list_matrix[j]);
                        break;
                    case 7:
                        i = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i]++);
                        break;
                    case 8:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i] - list_matrix[j]);
                        break;
                    case 9:
                        i = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i]--);
                        break;
                    case 10:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i] * list_matrix[j]);
                        break;
                    case 11:
                        i = Convert.ToInt32(Console.ReadLine());
                        j = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i] / list_matrix[j]);
                        break;
                    case 12:
                        i = Convert.ToInt32(Console.ReadLine());
                        Display(list_matrix[i].Invertible);
                        break;
                    case 13:
                        printArray(list_matrix);
                        break;
                    case 14:
                        s = Console.ReadLine();
                        Console.WriteLine(Matrix.Parse(s).Det);
                        break;
                    case 15:
                        Display(list_matrix.First());
                        break;
                    case 16:
                        Display(list_matrix.Last());
                        break;
                    case 17:
                        list_matrix.sort(0, list_matrix.count-1);
                        printArray(list_matrix);
                        break;
                    case 18: //to array
                        Matrix[] arr = list_matrix.ToArray();
                        for (i = 0; i < arr.Length; i++)
                        {
                            Display(arr[i]);
                        }
                        break;
                    case 19: //to arr string
                        list_matrix.ToArrString();
                        break;
                    case 20:
                        i = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list_matrix[i].Det);
                        break;
                    case 21:
                        MatrixInOut.MatrixIn(list_matrix);
                        break;
                    case 22:
                        Console.WriteLine("Enter path");
                        s = Console.ReadLine();
                        ListOfMatrix tmp = MatrixInOut.MatrixOut(s);
                        printArray(tmp);
                        break;
                    case 23:
                        check = false;
                        break;
                }

            }
        }

    }
}
