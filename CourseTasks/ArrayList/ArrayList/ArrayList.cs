using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayList.ArrayList
{
    public class List<T> : IList<T>
    {
        private T[] elements;

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
            }
        }

        public int Count { get; set; }

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
            if (IndexOf(item) == -1)
            {
                return false;
            }

            return true;
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
                    throw new SystemException("Список был изменен во время итерирования.");
                }

                yield return elements[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ReferenceEquals(elements[i], item) || elements[i].Equals(item))
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

            T[] temp = new T[Count];
            Array.Copy(elements, temp, Count);

            for (int i = 0, j = 0; i <= Count; i++)
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

            Count++;
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

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Указываемый индекс вне диапозона списка.");
            }

            T[] temp = new T[Count];
            Array.Copy(elements, temp, Count);
            elements = new T[Capacity];

            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                if (i == index && index != Count - 1)
                {
                    j++;
                }

                elements[i] = temp[j];
            }

            Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            if (Count == Capacity)
            {
                throw new IndexOutOfRangeException("Количество элементов равно размерности.");
            }

            T[] temp = elements;
            elements = new T[Count];
            Array.Copy(temp, elements, Count);
        }
    }
}