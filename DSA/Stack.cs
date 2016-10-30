using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class StackTest<T>
    {
        int index;
        T[] buffer;

        public int Capacity 
        {
            get { return buffer.Length; }
        }

        public int Count
        {
            get { return index < 0 ? 0 : index + 1; }
        }

        public StackTest(int size)
        {
            if (size <= 0) { size = 1; }
            else { }

            index = -1;
            buffer = new T[size];
        }

        public void Push(T item)
        {
            if (index < buffer.Length - 1)
            {
                buffer[++index] = item;
            }
            else
            {
                throw new InvalidOperationException("There is no place in stack");
            }
        }

        public T Pop()
        {
            if(index < 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else { }

            return buffer[index--];
        }

        public T Peek()
        {
            if(index < 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            else { }

            return buffer[index];
        }

        public void Clear()
        {
            index = -1;
        }
    }
}
