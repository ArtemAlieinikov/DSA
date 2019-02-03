using System;
using System.Collections;
using System.Collections.Generic;

namespace DSA
{
    /// <summary>
    /// Interface which include basic dynamic array functionality.
    /// </summary>
    /// <typeparam name="T">Type of array element.</typeparam>
    interface IDynamicArray<T>
    {
        //The number of elements that can contain an array
        int Capacity { get; }

        //The number of elements in the array
        int Count { get; }

        //Индексатор для доступа к элементам массива
        T this[int index] { get; set; }

        //The method to add an element to the end of the array
        void Add(T item);
    }

    /// <summary>
    ///  Enum to install an array of growth rate.
    /// </summary>
    public enum ScaleIndex : byte 
    { 
        oneAndHalf, 
        twice, 
        three
    }

    /// <summary>
    ///  This class implements the basic version of a dynamic array.
    /// </summary>
    public class DynamicArray<T> : IDynamicArray<T>, IEnumerator<T>, IEnumerable<T>
    {
        private int arrayIndex; //array index, and also the number of elements in the array
        private int capacity; //size of the array (number of elements as the array may contain)
        private int enumaratorIndex;

        private T[] buffer;
        private ScaleIndex growthRate;

        public int Capacity
        {
            get 
            { 
                return capacity; 
            }
        }

        public int Count
        {
            get 
            { 
                return arrayIndex + 1; 
            }
        }

        public DynamicArray (int arraySize) 
            : this (arraySize, ScaleIndex.twice)
        { }

        public DynamicArray(int arraySize, ScaleIndex scaleIndex)
        {
            if (arraySize < 0)
            {
                throw new ArgumentException("Cannot create an array with a negative size");
            }

            buffer = new T[arraySize];
            growthRate = scaleIndex;

            arrayIndex = -1;
            capacity = buffer.Length;

            enumaratorIndex = -1;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         T(n) = Ω(1)
        ///     </pama>
        /// </summary>
        /// <param name="item">Added element</param>
        public void Add(T item)
        {
            if (arrayIndex == capacity - 1)
            {
                BufferGrowth();
            }

            ++arrayIndex;
            buffer[arrayIndex] = item;
        }

        /// <summary>
        /// Method which increases the capacity of the array 
        /// to the specified growth rate.
        /// </summary>
        private void BufferGrowth()
        {
            T[] newBuffer;

            switch (growthRate)
            {
                case ScaleIndex.oneAndHalf:
                    capacity = (int)(capacity * 1.5);
                    break;

                case ScaleIndex.twice:
                    capacity *= 2;
                    break;

                case ScaleIndex.three:
                    capacity *= 3;
                    break;
            }

            newBuffer = new T[capacity];

            for (int i = 0; i <= buffer.Length - 1; ++i)
            { 
                newBuffer[i] = buffer[i];
            }

            buffer = newBuffer;
        }

        public T this[int index]
        {
            get
            {
                if((index < 0) || (index > arrayIndex))
                {
                    throw new ArgumentOutOfRangeException("Incorrect index");
                }

                return buffer[index];
            }

            set
            {
                if ((index < 0) || (index > capacity))
                {
                    throw new ArgumentOutOfRangeException("Incorrect index");
                }

                arrayIndex = index;
                buffer[index] = value;
            }
        }

        //The beginning of the IEnumerator<T> interface realisation
        //which also include IEnumerator and IDisposable.
        public bool MoveNext()
        {
            var result = true;

            if(++enumaratorIndex > arrayIndex)
            {
                Reset();

                result = false;
            }

            return result;
        }

        public void Reset()
        { 
            enumaratorIndex = -1; 
        }

        public T Current
        {
            get 
            { 
                return buffer[enumaratorIndex]; 
            }
        }

        //The IEnumerator interface realisation.
        object IEnumerator.Current
        {
            get 
            {
                return Current; 
            }
        }

        //The IDisposable interface realisation.
        void IDisposable.Dispose() { }

        //The IEnumerable<T> interface realisation.
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        //The IEnumerable interface realisation.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
