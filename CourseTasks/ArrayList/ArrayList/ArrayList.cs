using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayList.ArrayList
{
    public class List<T> : IList<T>
    {
        private T[] elements;
        private int capacity = 10;
        private int count;
        private bool isReadOnly = false;

        public List()
        {
            elements = new T[capacity];
        }

        public List(IEnumerable<T> collection)
        {
            elements = new T[collection.Count()];
            capacity = elements.Length;

            int i = 0;
            foreach (T element in collection)
            {
                elements[i] = element;
                i++;
                count++;
            }
        }

        public List(int capacity)
        {
            elements = new T[capacity];
            this.capacity = capacity;
        }

        public T this[int index]
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set { isReadOnly = value; }
        }

        private void IncreaseCapacity()
        {
            capacity *= 2;
            T[] temp = elements;
            elements = new T[capacity];
            Array.Copy(temp, elements, count);
        }

        public void Add(T item)
        {
            if (count == capacity)
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

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (elements[i].Equals(item))
                {
                    return i;
                }
            }
            throw new ArgumentNullException("Элемент не найден.");
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }
            else if (count == capacity)
            {
                IncreaseCapacity();
            }

            T[] temp = new T[count];
            Array.Copy(elements, temp, count);

            for (int i = 0, j = 0; i <= count; i++)
            {
                if (i == index)
                {
                    elements[i] = item;                   
                }
                else
                {
                    elements[i] = temp[j];
                    j++;
                }
            }
            count++;
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

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }

            T[] temp = new T[count];
            Array.Copy(elements, temp, count);
            elements = new T[capacity];

            for (int i = 0, j = 0; j < count; i++, j++)
            {
                if (i == index && index != count - 1)
                {
                    j++;
                }

                elements[i] = temp[j];
            }
            count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
