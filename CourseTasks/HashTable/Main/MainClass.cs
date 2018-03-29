using System;
using HashTable.HashTable;

namespace HashTable.Main
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(20) { 4, 7, 8, 12 };

            foreach(int element in hashTable)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            if(hashTable.Contains(4))
            {
                Console.WriteLine("Хэш-таблица содержит элемент.");
            }

            hashTable.Remove(12);

            foreach (int element in hashTable)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}
