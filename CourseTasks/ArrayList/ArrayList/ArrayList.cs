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
            get
            {
                return elements.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("Новый размер списка должен быть больше количества элементов.");
                }

                T[] temp = elements;
                elements = new T[value];
                Array.Copy(temp, elements, Count);
            }
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
            if (Count != 0)
            {
                Count = 0;
                changes++;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Массив не создан.");
            }

            if (arrayIndex < 0 || arrayIndex + Count > Capacity)
            {
                throw new ArgumentOutOfRangeException("Индекс вне границ списка.");
            }

            for (int i = arrayIndex, j = 0; j < Count; i++, j++)
            {
                array[i] = elements[j];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialChanges = changes;

            for (int i = 0; i < Count; i++)
            {
                if (initialChanges != changes)
                {
                    throw new InvalidOperationException("Список был изменен во время итерирования.");
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

            Array.Copy(elements, index, elements, index + 1, elements.Length - index - 1);
            elements[index] = item;

            Count++;
            changes++;
        }

        public bool Remove(T item)
        {
            for (int i = 0, j = 0; j < Count; i++, j++)
            {
                if (elements[i].Equals(item))
                {
                    Array.Copy(elements, i + 1, elements, i, elements.Length - i - 1);
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

            Array.Copy(elements, index + 1, elements, index, elements.Length - index - 1);
            Count--;
            changes++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            if (Count != Capacity)
            {
                T[] temp = elements;
                elements = new T[Count];
                Array.Copy(temp, elements, Count);
            }
        }
    }
}