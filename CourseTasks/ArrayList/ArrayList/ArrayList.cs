using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayList.ArrayList
{
    public class List<T> : IList<T>
    {
        private T[] elements;
        private int changes;

        public List()
        {
            elements = new T[10];
        }

        public List(IEnumerable<T> collection)
        {
            elements = new T[collection.Count()];

            int i = 0;

            foreach (T element in collection)
            {
                elements[i] = element;
                i++;
                Count++;
            }
        }

        public List(int capacity)
        {
            elements = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
                }

                return elements[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
                }

                elements[index] = value;
                changes++;
            }
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return elements.Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        private void IncreaseCapacity()
        {
            T[] temp = elements;
            elements = new T[Capacity * 2];
            Array.Copy(temp, elements, Count);
        }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            elements[Count] = item;
            Count++;
            changes++;
        }

        public void Clear()
        {
            Count = 0;
            changes++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) == -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = arrayIndex, j = 0; j < Count; i++, j++)
            {
                array[i] = elements[j];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int temp = changes;

            for (int i = 0; i < Count; i++)
            {
                if (temp != changes)
                {
                    throw new SystemException("Список был изменен во время итерирования.");
                }

                yield return elements[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(elements[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }
            else if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            T temp1 = default(T);
            bool isInsert = false;

            for (int i = 0; i <= Count; i++)
            {
                if (i == index)
                {
                    temp1 = elements[i];
                    elements[i] = item;
                    isInsert = true;
                }
                else if (isInsert)
                {
                    T temp2 = elements[i];
                    elements[i] = temp1;
                    temp1 = temp2;
                }
            }

            Count++;
            changes++;
        }

        public bool Remove(T item)
        {
            bool isCoincidence = false;

            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                if (elements[i].Equals(item))
                {
                    j++;
                    isCoincidence = true;
                }

                elements[i] = elements[j];

                if (j == Count - 1 && isCoincidence)
                {
                    Count--;
                    changes++;
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }

            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                if (i == index && index != Count - 1)
                {
                    j++;
                }

                elements[i] = elements[j];
            }

            Count--;
            changes++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            T[] temp = elements;
            elements = new T[Count];
            Array.Copy(temp, elements, Count);
        }
    }
}