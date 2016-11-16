using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    static class SortingAlgorithm
    {
        /// <summary>
        /// T(n)= O(n^2)
        /// </summary>
        /// <param name="array">sortable array</param>
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; ++j)
                {
                    if(array[j] < array[min])
                    {
                        min = j;
                    }
                    else { }
                }

                Swap(ref array[i], ref array[min]);
            }
        }

        /// <summary>
        /// T(n) = O(n^2)
        /// </summary>
        /// <param name="array">sortable array</param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                for (int j = i; j > 0 && array[j - 1] > array[j]; --j)
                {
                    Swap(ref array[j], ref array[j - 1]);
                }
            }
        }

        /// <summary>
        /// T(n) = O(n^2)
        /// </summary>
        /// <param name="array">sortable array</param>
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                bool isSwap = false;

                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isSwap = true;
                    }
                    else { }
                }

                if (!isSwap)
                {
                    return;
                }
                else { }
            }
        }

        /// <summary>
        /// T(n) = O(1)
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
