using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// This class includes a variety of search algorithms.
    /// </summary>
    public static class SearchAlgorithms
    {
        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="searchValue">searchValue</param>
        public static int LinearSearch(int[] array, int searchValue)
        {
            int result = -1;

            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == searchValue)
                {
                    result = i;
                    break;
                }
                else { }
            }

            return result;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="searchValue">searchValue</param>
        public static bool HasElementLinear(int[] array, int searchValue)
        {
            bool result = false;

            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == searchValue)
                {
                    result = true;
                    break;
                }
                else { }
            }

            return result;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = θ(n)
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="array">Array to search</param>
        public static int MaxElementLinear(int[] array)
        {
            int maxElement = array[0];

            for (int i = 1; i < array.Length; ++i)
            {
                if (maxElement < array[i])
                {
                    maxElement = array[i];
                }
                else { }
            }

            return maxElement;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(log n)
        ///         M(n) = O(log n)
        ///     </para>
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="element">The element that is looking</param>
        /// <param name="firstIndex">First index of the array</param>
        /// <param name="lastIndex">First index of the array</param>
        public static int BinarySearchRecursively(int[] array, int element, int firstIndex, int lastIndex)
        {
            //if (array[firstIndex] > array[lastIndex])
            //    return -1;

            int middle = (lastIndex + firstIndex) / 2;

            if (lastIndex - firstIndex == 1)
            {
                if (array[lastIndex] == element)
                {
                    return lastIndex;
                }
                else if (array[firstIndex] == element)
                {
                    return firstIndex;
                }
                else
                {
                    return -1;
                }
            }
            else { }

            if (element == array[middle])
            {
                return middle;
            }
            else { }

            if (element > array[middle])
            {
                return BinarySearchRecursively(array, element, middle, lastIndex);
            }
            else
            {
                return BinarySearchRecursively(array, element, firstIndex, middle);
            }
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(log n)
        ///         M(n) = O(1)
        ///     </para>
        /// </summary>
        /// <param name="array">Array to search</param>
        /// <param name="element">The element that is looking</param>
        public static int BinarySearch(int[] array, int element)
        {
            int first = 0;
            int last = array.Length - 1;

            while (last - first != 1)
            {
                int mid = (last + first) / 2;

                if (array[mid] == element)
                {
                    return mid;
                }
                else { }

                if (element > array[mid])
                {
                    first = mid;
                }
                else
                {
                    last = mid;
                }
            }

            if (array[first] == element)
            {
                return first;
            }
            else if (array[last] == element)
            {
                return last;
            }
            else
            {
                return -1;
            }
        }
    }
}
