using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[9] { 5, 6, 8, 4, 3, 68, 51, 6, 100};

            SortingAlgorithm.QuickSort(a, 0, a.Length - 1);

            foreach (int item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
