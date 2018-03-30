using ArrayList.ArrayList;
using System;

namespace ArrayList.Main
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>(3) { 3, 5, 7, 10 };

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            int[] array = new int[25];
            list.CopyTo(array, 2);

            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            List<string> list2 = new List<string>(5) { "aa", "bb", "cc" };
            Console.WriteLine(list2.IndexOf(null));

            list.Insert(1, 4);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list2.Insert(1, "ee");

            foreach (string element in list2)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.Remove(5);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.RemoveAt(0);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            if(list.Contains(4))
            {
                Console.WriteLine("Список содержит элемент.");
            }

            System.Collections.Generic.List<int> list3 = new System.Collections.Generic.List<int>() { 3, 6, 8, 15, 20 };

            list.Insert(2, 20);

            foreach(int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.RemoveAt(2);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.Insert(3, 0);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
        }
    }
}