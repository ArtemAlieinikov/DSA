using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// Interface which include basic dynamic array functionality.
    /// </summary>
    /// <typeparam name="T">Type of array element.</typeparam>
    interface IDynamicArray<T>
    {
        //The number of elements that can contain an array
        int Capacity
        {
            get;
            //set;
        }

        //The number of elements in the array
        int Count
        {
            get;
            //set;
        }

        //Индексатор для доступа к элементам массива
        T this[int index]
        {
            get;
            set;
        }

        //The method to add an element to the end of the array
        void Add(T item);
    }

    /// <summary>
    ///  Enum to install an array of growth rate.
    /// </summary>
    enum growth : byte 
    { 
        oneAndHalf, 
        twice, 
        three 
    }

    /// <summary>
    ///  This class implements the basic version of a dynamic array.
    /// </summary>
    class DynamicArray<T> : IDynamicArray<T>, IEnumerator<T>, IEnumerable<T>
    {
        int arrayIndex; //array index, and also the number of elements in the array
        int capacity; //size of the array (number of elements as the array may contain)
        int enumaratorIndex;
        
        T[] buffer;
        growth growthRate;

        public int Capacity
        {
            get { return capacity; }
            //set { throw new Exception ("You can not change capasity parameter"); }
        }

        public int Count
        {
            get { return arrayIndex + 1; }
            //set { throw new Exception("You can not change count parameter"); }
        }

        public DynamicArray (int arraySize) : this (arraySize, growth.twice)
        { }

        public DynamicArray(int arraySize, growth growthRate)
        {
            if (arraySize < 0)
                throw new Exception("Cannot create an array with a negative size");

            buffer = new T[arraySize];
            this.growthRate = growthRate;

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
                this.bufferGrowth();

            ++arrayIndex;
            buffer[arrayIndex] = item;
        }

        /// <summary>
        /// Method which increases the capacity of the array 
        /// to the specified growth rate.
        /// </summary>
        void bufferGrowth()
        {
            T[] newBuffer;

            switch (growthRate)
            {
                case growth.oneAndHalf:
                    capacity = (int)(capacity * 1.5);
                    break;

                case growth.twice:
                    capacity = capacity * 2;
                    break;

                case growth.three:
                    capacity = capacity * 3;
                    break;
            }

            newBuffer = new T[capacity];

            for (int i = 0; i <= buffer.Length - 1; ++i)
                newBuffer[i] = buffer[i];

            buffer = newBuffer;
        }

        public T this[int index]
        {
            get
            {
                if((index < 0) || (index > arrayIndex))
                {
                    throw new Exception("Incorrect index");
                }

                return buffer[index];
            }

            set
            {
                if ((index < 0) || (index > capacity))
                {
                    throw new Exception("Incorrect index");
                }

                arrayIndex = index;
                buffer[index] = value;
            }
        }

        //The beginning of the IEnumerator<T> interface realisation
        //which also include IEnumerator and IDisposable.
        public bool MoveNext()
        {
            if(++enumaratorIndex > arrayIndex)
            {
                this.Reset();
                return false;
            }

            return true;
        }

        public void Reset()
        { enumaratorIndex = -1; }

        public T Current
        {
            get { return buffer[enumaratorIndex]; }
        }

        //The IEnumerator interface realisation.
        object IEnumerator.Current
        {
            get { return Current; }
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
