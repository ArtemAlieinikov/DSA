using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    class QueueTest<T>
    {
        private T[] buffer;
        private int head, tail;

        public bool IsEmpty
        {
            get 
            { 
                return head == tail; 
            }
        }

        public bool IsFull
        {
            get 
            { 
                return ((head - tail + buffer.Length) % buffer.Length == 1); 
            }
        }

        public QueueTest(int size)
        {
            buffer = new T[size + 1];
            head = 0;
            tail = 0;
        }

        public T Dequeue()
        {
            T result;

            if(head == tail)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            else { }
            
            result = buffer[head++];

            if(head == buffer.Length)
            {
                head = 0;
            }
            else { }

            return result;
        }

        public void Enqueue(T item)
        {
            if ((head - tail + buffer.Length) % buffer.Length == 1)
            {
                throw new InvalidOperationException("Queue is full");
            }
            else { }

            buffer[tail++] = item;

            if(tail == buffer.Length)
            {
                tail = 0;
            }
            else { }
        }
    }
}
