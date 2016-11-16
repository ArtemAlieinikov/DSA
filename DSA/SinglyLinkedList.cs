using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    /// <summary>
    /// Interface which include basic LinkedList functionality.
    /// </summary>
    /// <typeparam name="T">Type of linkedList data.</typeparam>
    /// <remarks>SinglyLinkedNode - node of linked list.</remarks>
    interface ISinglyLinkedList<T> : IEnumerable<T>, IEnumerator<T>
    {
        void AddFirst(T data);
        void AddLast(T data);

        SinglyLinkedNode<T> GetFirst { get; }
        SinglyLinkedNode<T> GetLast { get; }

        bool Remove(T data);

        int Count { get; }
        bool IsEmpty { get; }

        bool Contains(T data);

        void Clear();
    }

    /// <summary>
    /// Element that is node.
    /// </summary>
    /// <typeparam name="T">Type of linkedList data.</typeparam>
    public class SinglyLinkedNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedNode<T> Next { get; set; }

        public SinglyLinkedNode(T Data)
        {
            this.Data = Data;
        }
    }

    /// <summary>
    /// Singly linked list.
    /// </summary>
    /// <typeparam name="T">Type of data of list node</typeparam>
    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        private SinglyLinkedNode<T> head;
        private SinglyLinkedNode<T> tail;

        private int _count;

        //Field which uses for foreach realization.
        public SinglyLinkedNode<T> enumeratorNode;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (_count == 0);
            }
        }

        public SinglyLinkedNode<T> GetFirst
        {
            get
            {
                return head;
            }
        }

        public SinglyLinkedNode<T> GetLast
        {
            get
            {
                return tail;
            }
        }

        //The method that sets the enumerator node in the head node.
        private void SetEnumeratorNode()
        {
            enumeratorNode = head;
        }

        /// <summary>
        /// T(n) = θ(1);
        /// </summary>
        /// <param name="data">Data which adds in the list</param>
        public void AddFirst(T data)
        {
            SinglyLinkedNode<T> node = new SinglyLinkedNode<T>(data);
            ++_count;

            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head = node;
            }

            this.SetEnumeratorNode();
        }

        /// <summary>
        /// T(n) = θ(1);
        /// </summary>
        /// <param name="data">Data which adds in the list</param>
        public void AddLast(T data)
        {
            SinglyLinkedNode<T> node = new SinglyLinkedNode<T>(data);
            ++_count;

            if (tail == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }

            this.SetEnumeratorNode();
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         T(n) = Ω(1)
        ///     </pama>
        /// </summary>
        /// <param name="data">Node data on which it is removed</param>
        /// <returns>boolean - remove an item or not</returns>
        public bool Remove(T data)
        {
            SinglyLinkedNode<T> current = head;
            SinglyLinkedNode<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous == null)
                    {
                        head = current.Next;

                        if (head == null)
                        {
                            tail = null;
                        }

                        this.SetEnumeratorNode();
                    }
                    else
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }

                    --_count;
                    return true;
                }
                else { }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        ///     <para>
        ///         T(n) = O(n)
        ///         T(n) = Ω(1)
        ///     </pama>
        /// </summary>
        /// <param name="data">Node data on which it is removed</param>
        /// <returns>boolean - whether the list contains the desired element</returns>
        public bool Contains(T data)
        {
            bool result = false;
            SinglyLinkedNode<T> iteratorNode = head;

            while (iteratorNode != null)
            {
                if (iteratorNode.Data.Equals(data))
                {
                    result = true;
                    break;
                }
                else { }

                iteratorNode = iteratorNode.Next;
            }

            return result;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            _count = 0;
        }

        //The beginning of the IEnumerator<T> interface realisation
        //which also include IEnumerator and IDisposable.
        public T Current
        {
            get
            {
                T item = enumeratorNode.Data;
                enumeratorNode = enumeratorNode.Next;
                return item;
            }
        }

        public bool MoveNext()
        {
            if (_count <= 0 || enumeratorNode == null)
            {
                this.Reset();
                return false;
            }
            else
            {
                //enumeratorNode = enumeratorNode.Next;
                return true;
            }
        }

        public void Reset()
        {
            this.SetEnumeratorNode();
        }

        //The IEnumerator interface realisation.
        object IEnumerator.Current
        {
            get
            {
                return enumeratorNode.Data;
            }
        }

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

        //The IDisposable interface realisation.
        public void Dispose()
        { }

        /// <summary>
        /// Checks whether fixated list. Does the list has a loop.
        /// T(n) = O(n)
        /// </summary>
        /// <param name="firstNode">Show the link to the head node</param>
        /// <returns>boolean - does the list of the loop.</returns>
        public bool hasCircle(SinglyLinkedNode<T> firstNode)
        {
            SinglyLinkedNode<T> slowIterator = firstNode;
            SinglyLinkedNode<T> fastIterator = firstNode;

            while (true)
            {
                for (int i = 0; i < 2; ++i)
                {
                    fastIterator = fastIterator.Next;

                    if (fastIterator == null)
                    {
                        return false;
                    }
                    else { }

                    if (slowIterator == fastIterator)
                    {
                        return true;
                    }
                    else { }
                }

                slowIterator = slowIterator.Next;
            }
        }

        /// <summary>
        ///     <para>
        ///         Get node by number from the end of list.
        ///         T(n) = O(n);
        ///     </para>
        /// </summary>
        /// <param name="nodePositionFromEnd"></param>
        /// <returns>Seeking element, in SinglyLinkedNode format.</returns>
        /// <exception cref="System.FormatException">Throw when the argument is greater than the length of the list.</exception>
        public SinglyLinkedNode<T> GetNodeByNumberFromEnd(int nodePositionFromEnd)
        {
            if (nodePositionFromEnd > Count || nodePositionFromEnd <= 0)
            {
                throw new FormatException("Selected position is incorrect");
            }
            else { }

            SinglyLinkedNode<T> aimNode = GetFirst;
            SinglyLinkedNode<T> lastNode = GetFirst;

            while (nodePositionFromEnd > 0)
            {
                lastNode = lastNode.Next;
                --nodePositionFromEnd;
            }

            while (lastNode != null)
            {
                aimNode = aimNode.Next;
                lastNode = lastNode.Next;
            }

            return aimNode;
        }
    }
}
