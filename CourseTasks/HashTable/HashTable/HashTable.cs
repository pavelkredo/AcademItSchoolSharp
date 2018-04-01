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

        public int GetIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % elements.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (elements[index] == null)
            {
                elements[index] = new List<T>() { item };
            }
            else
            {
                elements[index].Add(item);
            }

            Count++;
            changes++;
        }

        public void Clear()
        {
            if (Count != 0)
            {
                elements = new List<T>[elements.Length];
                Count = 0;
                changes++;
            }
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (elements[index] != null)
            {
                return elements[index].Contains(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Массив не задан.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс вне границ массива.");
            }
            else if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException("Недостаточный размер передаваемого массива.");
            }

            int i = arrayIndex;

            foreach (T element in this)
            {
                array[i] = element;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialChanges = changes;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null)
                {
                    foreach (T element in elements[i])
                    {
                        if (initialChanges != changes)
                        {
                            throw new InvalidOperationException("Хэш-таблица была изменена во время итерирования.");
                        }

                        yield return element;
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (elements[index] != null)
            {
                return elements[index].Remove(item);
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}