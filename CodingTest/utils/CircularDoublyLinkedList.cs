using System;
using System.Collections;
using System.Collections.Generic;

namespace CodingTest.utils
{
    class Item<T>
    {
        public T Data { get; set; }
        public int Index { get; set; }

        public Item<T> Previous { get; set; }

        public Item<T> Next { get; set; }

        public Item(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Data = data;
        }
        public override string ToString() => Data.ToString();
    }
    /// <summary>
    /// Circular Doubly Linked List.
    /// </summary>
    class CircularDoublyLinkedList<T> : IEnumerable<T>
    {
        private Item<T> Head;
        private int count;
        public int Count => count;
        public CircularDoublyLinkedList() => Clear();

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (count == 0)
            {
                SetHeadItem(data);

                return;
            }

            Item<T> item = new Item<T>(data)
            {
                Next = Head,
                Previous = Head.Previous
            };

            Head.Previous.Next = item;
            Head.Previous = item;
            item.Index = count;
            count++;
        }

        public Item<T> Get(int index, Item<T> current = null)
        {
            current ??= Head;

            bool isRight = index > -1 ? true : false;

            int i = 0;
            while (true)
            {
                if (i == index)
                {
                    return current;
                }

                if (isRight)
                {
                    ++i;
                    current = current.Next;
                }
                else
                {
                    --i;
                    current = current.Previous;
                }
            }

            return null;
        }

        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (Head.Data.Equals(data))
            {
                RemoveItem(Head);
                Head = Head.Next;

                return;
            }

            Item<T> current = Head;

            for (int i = count; i > 0; i--)
            {
                if (current?.Data.Equals(data) == true)
                {
                    RemoveItem(current);
                }

                current = current.Next;
            }
        }

        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                Item<T> current = Head;

                for (int i = count; i > 0; i--)
                {
                    if (current?.Data.Equals(target) == true)
                    {
                        Item<T> item = new Item<T>(data);

                        current.Next.Previous = item;
                        item.Previous = current;
                        item.Next = current.Next;
                        current.Next = item;

                        count++;

                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
        }

        public string Contains(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            Item<T> current = Head;

            while (current != Head)
            {
                if (current.Data.Equals(data))
                {
                    return $"Element {data} is in the list.";
                }
                current = current.Next;
            }

            return $"Element {data} is not in the list.";
        }

        public void Clear()
        {
            Head = null;
            count = 0;
        }

        public void RemoveItem(Item<T> current)
        {
            current.Next.Previous = current.Previous;
            current.Previous.Next = current.Next;
            count--;
        }

        private void SetHeadItem(T data)
        {
            Head = new Item<T>(data);

            Head.Next = Head;
            Head.Previous = Head;
            Head.Index = count;
            count = 1;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Item<T> current = Head;

            for (int i = 0; i < count * 2; i++)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this).GetEnumerator();
    }


}
