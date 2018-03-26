using ArrayList.ArrayList;
using System;

namespace ArrayList.Main
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>(3) { 3, 5, 8, 10 };

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            int[] array = { 2, 4, 6, 7 };
            list.CopyTo(array, 4);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.Insert(8, 12);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Индекс элемента равен: " + list.IndexOf(12));

            list.Remove(3);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            list.RemoveAt(7);

            foreach (int element in list)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();

            List<string> list2 = new List<string> { "abc", null, "cba" };
            Console.WriteLine(list2.IndexOf(null));
        }
    }
}