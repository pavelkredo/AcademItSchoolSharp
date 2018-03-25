using System;
using HashTable.HashTable;
using System.Collections.Generic;

namespace HashTable.Main
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            HashTable<List<int>> hashTable = new HashTable<List<int>>(20);
            List<int> list1 = new List<int> { 2, 3, 5 };
            List<int> list2 = new List<int> { 4, 7, 10 };
            List<int> list3 = new List<int> { 12, 5, 13 };

            hashTable.Add(list1);
            hashTable.Add(list2);
            hashTable.Add(list3);

            foreach(List<int> element in hashTable)
            {
                Console.WriteLine(element);
            }
        }
    }
}
