using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable.HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        List<T>[] elements;
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
            elements[Count] = new List<T>() { item };
            Count++;
        }

        public void Clear()
        {
            Count = 0;
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
            int originalCount = Count;

            for (int i = 0; i < Count; i++)
            {
                if (originalCount != Count)
                {
                    throw new SystemException("Хэш-таблица была изменена во время итерирования.");
                }

                foreach (T element in elements[i])
                {
                    yield return element;
                }
            }
        }

        public bool Remove(T item)
        {
            bool isCoincidence = false;

            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                foreach (T element in elements[i])
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
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}