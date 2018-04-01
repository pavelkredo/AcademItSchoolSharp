using System;
using HashTable.HashTable;

namespace HashTable.Main
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(20) { 4, 7, 8, 12 };

            foreach (int element in hashTable)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            if (hashTable.Contains(7))
            {
                Console.WriteLine("Хэш-таблица содержит элемент.");
            }

            hashTable.Remove(12);

            foreach (int element in hashTable)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            int[] array = new int[10];
            hashTable.CopyTo(array, 2);

            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            HashTable<string> hashTable2 = new HashTable<string>(20) { "aa", "bb", "cc", "dd" };
            hashTable2.Add(null);

            Console.WriteLine(hashTable2.Contains(null));

            hashTable2.Remove("cc");

            foreach (string element in hashTable2)
            {
                Console.Write(element + " ");
            }
        }
    }
}
