using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable.HashTable
{
    public class HashTable<T> : ICollection<T>
    {
        T[] elements;
        int count;
        int capacity;
        bool isReadOnly = false;

        public HashTable(int capacity)
        {
            this.capacity = capacity;
            elements = new T[capacity];
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }

        public void IncreaseCapacity()
        {
            capacity *= 2;
            T[] temp = elements;
            elements = new T[capacity];
            Array.Copy(temp, elements, count);
        }

        public void Add(T item)
        {
            if(count == capacity)
            {
                IncreaseCapacity();
            }

            elements[count] = item;
            count++;
        }

        public void Clear()
        {
            elements = new T[capacity];
            count = 0;
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
            if (arrayIndex < 0 || arrayIndex > count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }

            int length = arrayIndex + array.Length;

            while (length > capacity)
            {
                IncreaseCapacity();
            }

            if (length > count)
            {
                count = length;
            }

            for (int i = arrayIndex, j = 0; i < length; i++, j++)
            {
                elements[i] = array[j];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return elements[i];
            }
        }

        public bool Remove(T item)
        {
            T[] temp = new T[count];
            Array.Copy(elements, temp, count);
            elements = new T[capacity];
            bool isCoincidence = false;

            for (int i = 0, j = 0; j < count; i++, j++)
            {
                if (temp[i].Equals(item))
                {
                    j++;
                    isCoincidence = true;
                }

                elements[i] = temp[j];

                if (j == count - 1 && isCoincidence)
                {
                    count--;
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
