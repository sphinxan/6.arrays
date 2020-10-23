using System;
using System.Globalization;
using System.Linq;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetResult(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3 }));
            int[,] array = { { 1, 2, 3 }, { 3, 4, 5 }, { 7, 8, 9 } };
            Console.WriteLine(GetResult(array, new int[] { 3, 4, 5 }));
            int[,] array2 = { { 3, 4, 5 }, { 6, 7, 8 } };
            Console.WriteLine(GetResult(array, array2));
        }

        static bool GetResult(int[] first, int[] second)
        {
            var answer = true;
            bool firstnum = true;
            int j = 0;
            for (int i = 0; i < first.Count(); i++)
            {
                if (firstnum == true && first[i] == second[j])
                {
                    firstnum = false;
                    j++;
                }
                else if (j != second.Count() && first[i] == second[j] && firstnum == false)
                    j++;
                else if (j == second.Count() && firstnum == false)
                    break;
                else if (firstnum == false)
                    answer = false;
            }
            return answer;
        }

        static bool GetResult(int[,] first, int[] second)
        {
            var answer = true;
            int rows = first.GetUpperBound(0) + 1; //количество строк таблицы
            int columns = first.Length / rows; //количество элементов в каждой строке
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    if (first[i, j] != second[j] && columns != second.Count())
                        answer = false;
            return answer;
        }

        static bool GetResult(int[,] first, int[,] second)
        {
            var answer = 0;
            int rows = first.GetUpperBound(0) + 1;
            int columns = first.Length / rows;
            int rowsInSecond = second.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (rowsInSecond == i)
                    {
                        i = rows;
                        j = columns;
                        break;
                    }
                    if (first[i, j] != second[i, j])
                    {
                        i++;
                        j = 0;
                        break;
                    }
                }
                answer++;
            }
            answer--;
            return answer == rowsInSecond;
        }
    }
}
