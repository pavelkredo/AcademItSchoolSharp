using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable.HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] elements;
        private int changes;

        public HashTable(int capacity)
        {
            elements = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(T item)
        {
            if (Count == elements.Length)
            {
                List<T>[] temp = elements;
                elements = new List<T>[Count * 2];
                Array.Copy(temp, elements, Count);
            }

            elements[Count] = new List<T>() { item };
            Count++;
            changes++;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                Count = 0;
                changes++;
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                foreach (T element in elements[i])
                {
                    if (Equals(element, item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null || arrayIndex + Count > array.Length)
            {
                throw new ArgumentNullException("Массив не задан.");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс вне границ списка.");
            }

            for (int i = arrayIndex, j = 0; j < Count; i++, j++)
            {
                foreach (T element in elements[j])
                {
                    array[i] = element;
                    i++;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialChanges = changes;

            for (int i = 0; i < Count; i++)
            {
                if (initialChanges != changes)
                {
                    throw new InvalidOperationException("Хэш-таблица была изменена во время итерирования.");
                }

                foreach (T element in elements[i])
                {
                    yield return element;
                }
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                int index = elements[i].IndexOf(item);

                if (index != -1)
                {
                    elements[i].Remove(item);
                    changes++;
                    return true;
                }
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}