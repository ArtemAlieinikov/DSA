using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    ///     <para>
    ///         A binary heap is a heap data structure. Binary heaps are a common way of implementing priority queues.
    ///         The binary heap was introduced by J. W. J. Williams in 1964, as a data structure for the heapsort.
    ///     </para>
    /// </summary>
    public class BinaryHeap : IEnumerable
    {
        private List<int> heap;

        public int GetSize
        {
            get
            {
                return heap.Capacity;
            }
        }

        public BinaryHeap()
        {
            heap = new List<int>();
        }

        public BinaryHeap(int[] collection)
        {
            heap = new List<int>(collection);
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
                throw new FormatException("Wrong index");
            }
            else { }

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
            else { }
        }

        /// <summary>
        ///     <para>
        ///         Operation which building heap from random set of numbers.
        ///         It works on the basis of operation Heapifi(ShiftDown).
        ///         This should work for the elements of the sequence from (n / 2 - 1) to 0 (indexes).
        ///         
        ///         T(n) = O(n), where n - (0...(n / 2 - 1)) for elements which have descendants.
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
        ///         Операция, которая опускает на более низкий уровень элемент, если он меньше
        ///         своих потомков, а именно меняется местами с найбольшим потомком.
        ///         
        ///         T(n) = O(log n), where n - numbers of elements in heap.
        ///     </para>
        /// </summary>
        /// <param name="indexOfElement">Index of element</param>
        private void Heapify(int indexOfElement)
        {
            int leftChild = 2 * indexOfElement + 1;
            int rightChild = 2 * indexOfElement + 2;
            int large = indexOfElement;

            if (leftChild < heap.Count - 1 && heap[leftChild] > heap[large])
            {
                large = leftChild;
            }
            else { }

            if (rightChild < heap.Count - 1 && heap[rightChild] > heap[large])
            {
                large = rightChild;
            }
            else { }

            if (large != indexOfElement)
            {
                int temp = heap[large];
                heap[large] = heap[indexOfElement];
                heap[indexOfElement] = temp;

                Heapify(large);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        ///     <para>
        ///         ShiftUP - operation whih ups element if it larger than his parent(father).
        ///         Using when we change element or add new element in heap.
        ///         Операция, которая подымает на более высокий уровень элемент если он больше
        ///         родителя, а именно меняется с ним местами.
        ///         
        ///         T(n) = O(log n), where n - numbers of elements in heap.
        ///     </para>
        /// </summary>
        /// <param name="indexOfElement">Index of element</param>
        private void ShiftUp(int indexOfElement)
        {
            int parentIndex = (indexOfElement - 1) / 2;

            if (heap[parentIndex] < heap[indexOfElement])
            {
                int temp = heap[parentIndex];
                heap[parentIndex] = heap[indexOfElement];
                heap[indexOfElement] = temp;

                ShiftUp(parentIndex);
            }
            else { }
        }

        public IEnumerator GetEnumerator()
        {
            return this.heap.GetEnumerator();
        }
    }
}
