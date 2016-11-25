using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    public static class SortingAlgorithm
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
                    if (array[j] < array[min])
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
        /// T(n) = (n log n)
        /// </summary>
        /// <param name="array">Array which we want to sort</param>
        public static void HeapSort(int[] array)
        {
            List<int> resultArray = array.ToList<int>();
            BuildBinaryHeap(resultArray);
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = resultArray[0];
                resultArray[0] = resultArray[resultArray.Count - 1];
                resultArray.RemoveAt(resultArray.Count - 1);
                Heapify(resultArray, 0);
            }
        }

        /// <summary>
        /// T(n) = O(n log n);
        /// </summary>
        /// <param name="array">Array which we want to sort</param>
        /// <param name="firstIndex">Start of array</param>
        /// <param name="lastIndex">End of array</param>
        public static void QuickSort(int[] array, int firstIndex, int lastIndex)
        {
            int left = firstIndex;
            int right = lastIndex;
            int middle = (firstIndex + lastIndex) / 2;

            while (left < right)
            {
                while (array[left] < array[middle])
                {
                    ++left;
                }

                while (array[right] > array[middle])
                {
                    --right;
                }

                if (left <= right)
                {
                    Swap(ref array[left], ref array[right]);

                    ++left;
                    --right;
                }
                else { }
            }

            if (left < lastIndex)
            {
                QuickSort(array, left, lastIndex);
            }
            else { }

            if (right > firstIndex)
            {
                QuickSort(array, firstIndex, right);
            }
            else { }
        }

        /// <summary>
        /// T(n) = O(n log n);
        ///      where n - sum of the lengths merged arrays
        /// </summary>
        /// <param name="array">Array which we want to sort.</param>
        /// <returns>Sorted array</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }
            else
            {
                int midIndex = array.Length / 2;
                return Merge(MergeSort(array.Take(midIndex).ToArray()), MergeSort(array.Skip(midIndex).ToArray()));
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

        /// <summary>
        /// T(n) = O(n)
        /// </summary>
        /// <param name="array">Source array</param>
        private static void BuildBinaryHeap(List<int> array)
        {
            int firstIndex = ((array.Count / 2) - 1);
            for (int i = firstIndex; i >= 0; --i)
            {
                Heapify(array, i);
            }
        }

        /// <summary>
        /// T(n) = O(log n)
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="index">Index of element</param>
        private static void Heapify(List<int> array, int index)
        {
            int firstChildIndex = index * 2 + 1;
            int secondChildIndex = index * 2 + 2;
            int largestElementIndex = index;

            if ((firstChildIndex < array.Count) && (array[firstChildIndex] > array[largestElementIndex]))
            {
                largestElementIndex = firstChildIndex;
            }
            else { }

            if ((secondChildIndex < array.Count) && (array[secondChildIndex] > array[largestElementIndex]))
            {
                largestElementIndex = secondChildIndex;
            }
            else { }

            if (largestElementIndex != index)
            {
                int temp = array[index];
                array[index] = array[largestElementIndex];
                array[largestElementIndex] = temp;
                Heapify(array, largestElementIndex);
            }
            else { }
        }

        /// <summary>
        /// T(n) = O(n);
        ///     where n - sum sum of the lengths merged arrays
        /// </summary>
        /// <param name="firtsArray">First array</param>
        /// <param name="secondArray">Second Array</param>
        /// <returns>Merged array</returns>
        private static int[] Merge(int[] firtsArray, int[] secondArray)
        {
            int i = 0;
            int j = 0;
            int[] resultArray = new int[firtsArray.Length + secondArray.Length];

            for ( ; i < firtsArray.Length && j < secondArray.Length; )
            {
                if (firtsArray[i] < secondArray[j])
                {
                    resultArray[i + j] = firtsArray[i];
                    ++i;
                }
                else
                {
                    resultArray[i + j] = secondArray[j];
                    ++j;
                }
            }

            if (i == firtsArray.Length)
            {
                for ( ; j < secondArray.Length; ++j)
                {
                    resultArray[i + j] = secondArray[j];
                }
            }
            else 
            {
                for ( ; i < firtsArray.Length; ++i)
                {
                    resultArray[i + j] = firtsArray[i];
                }
            }

            return resultArray;
        }
    }
}
