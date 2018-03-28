using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable.HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        T[] elements;

        public HashTable(int capacity)
        {
            elements = new T[capacity];
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

        public void IncreaseCapacity()
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
        }

        public void Clear()
        {
            if (Count == 0)
            {
                throw new ArgumentNullException("Список пуст.");
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T element in elements)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }

            int length = arrayIndex + array.Length;

            while (length > Capacity)
            {
                IncreaseCapacity();
            }

            if (length > Count)
            {
                Count = length;
            }

            for (int i = arrayIndex, j = 0; i < length; i++, j++)
            {
                elements[i] = array[j];
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

                yield return elements[i];
            }
        }

        public bool Remove(T item)
        {
            T[] temp = new T[Count];
            Array.Copy(elements, temp, Count);
            elements = new T[Capacity];
            bool isCoincidence = false;

            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                if (temp[i].Equals(item))
                {
                    j++;
                    isCoincidence = true;
                }

                elements[i] = temp[j];

                if (j == Count - 1 && isCoincidence)
                {
                    Count--;
                    return true;
                }
            }

            throw new ArgumentNullException("Элемент не найден.");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}