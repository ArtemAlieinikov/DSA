using System;
using System.Collections;
using System.Collections.Generic;

namespace DSA
{
    /// <summary>
    ///     <para>
    ///         A binary heap is a heap data structure. Binary heaps are a common way of implementing priority queues.
    ///     </para>
    /// </summary>
    public class BinaryHeap : IEnumerable
    {
        private readonly List<int> heap;

        public int GetSize => heap.Capacity;

        public BinaryHeap()
        {
            heap = new List<int>();
        }

        public BinaryHeap(int[] elements)
        {
            heap = new List<int>(elements);

            BuildHeap(); //Also we can say ShiftDown
        }

        /// <summary>
        ///     <para>
        ///         Add new element in heap. Than the tree balancing.
        ///         
        ///         T(n) = O(log n)
        ///     </para>
        /// </summary>
        /// <param name="element"></param>
        public void Add(int element)
        {
            if (heap.Capacity == 0)
            {
                heap.Add(element);
            }
            else
            {
                heap.Add(element);

                ShiftUp(heap.Count - 1);
            }
        }

        /// <summary>
        ///     <para>
        ///         Peek the max element. 
        ///         Берем максимальный элемент, но не извлекаем.
        ///         
        ///         T(n) = O(1);
        ///     </para>
        /// </summary>
        /// <returns>Max element of heap.</returns>
        public int PeekMax()
        {
            return heap[0];
        }

        /// <summary>
        ///     <para>
        ///         Removing the max element. Then restore the property of tree.
        ///         Извлекаем элемент. Затем востанавливаем свойство дерева.
        ///         
        ///         T(n) = O(log n)
        ///     </para>
        /// </summary>
        /// <returns>Max element of heap.</returns>
        public int PopMax()
        {
            int result = heap[0];

            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            Heapify(0);

            return result;
        }

        /// <summary>
        ///     T(n) = O(log n).
        /// </summary>
        /// <param name="index">Index of element you want to change</param>
        /// <param name="value">New value</param>
        public void ChangeElement(int index, int value)
        {
            if ((index > heap.Count - 1) || (index < 0))
            {
                throw new ArgumentOutOfRangeException("Wrong index");
            }

            if (heap[index] > value)
            {
                heap[index] = value;

                Heapify(index);
            }
            else if (heap[index] < value)
            {
                heap[index] = value;

                ShiftUp(index);
            }
        }

        /// <summary>
        ///     <para>
        ///         Operation which building heap from random set of numbers.
        ///         It works on the basis of operation Heapifi(ShiftDown).
        ///         This should work for the elements of the sequence from (n / 2 - 1) to 0 (indexes).
        ///
        ///         T(n) = O(n)
        ///     </para>
        /// </summary>
        private void BuildHeap()
        {
            for (int i = (heap.Count / 2 - 1); i >= 0; --i)
            {
                Heapify(i);
            }
        }

        /// <summary>
        ///     <para>
        ///         Heapify - ShiftDown.
        ///         Operation which downs element if it less than his max value descendant.
        ///         
        ///         T(n) = O(log n), where n - numbers of elements in heap.
        ///     </para>
        /// </summary>
        /// <param name="startIndex">Index to start</param>
        private void Heapify(int startIndex)
        {
            var parentIndex = startIndex;
            var leftChildIndex = 2 * startIndex + 1;
            var rightChildIndex = 2 * startIndex + 2;

            if (leftChildIndex < heap.Count - 1 && heap[leftChildIndex] > heap[parentIndex])
            {
                parentIndex = leftChildIndex;
            }

            if (rightChildIndex < heap.Count - 1 && heap[rightChildIndex] > heap[parentIndex])
            {
                parentIndex = rightChildIndex;
            }

            if (parentIndex != startIndex)
            {
                var temp = heap[parentIndex];
                heap[parentIndex] = heap[startIndex];
                heap[startIndex] = temp;

                Heapify(parentIndex);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        ///     <para>
        ///         ShiftUP - operation which ups element if it larger than his parent.
        ///         Using when we change element or add new element in heap.
        ///         
        ///         T(n) = O(log n), where n - numbers of elements in heap.
        ///     </para>
        /// </summary>
        /// <param name="startIndex">Index to start</param>
        private void ShiftUp(int startIndex)
        {
            int parentIndex = (startIndex - 1) / 2;

            if (heap[parentIndex] < heap[startIndex])
            {
                var temp = heap[parentIndex];
                heap[parentIndex] = heap[startIndex];
                heap[startIndex] = temp;

                ShiftUp(parentIndex);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return heap.GetEnumerator();
        }
    }
}
