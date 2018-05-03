using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Person;

namespace Person.Main
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Person.Person> personList = new List<Person.Person>
            {
            new Person.Person("Петр", 22),
            new Person.Person("Светлана", 35),
            new Person.Person("Евгений", 26),
            new Person.Person("Сергей", 15),
            new Person.Person("Петр", 26),
            new Person.Person("Диана", 12)
            };


            List<string> nameList = personList.Select(x => x.Name).Distinct().ToList();
            nameList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();

            List<int> ageList = personList.Select(x => x.Age).ToList();
            double averageAge = ageList.Where(x => x < 18).Average();
            Console.WriteLine(averageAge);

            Console.WriteLine();

            Dictionary<string, double> dictionary = personList.GroupBy(x => x.Name, y => y.Age).ToDictionary(x => x.Key, y => y.Average());

            foreach (var variable in dictionary)
            {
                Console.WriteLine(variable.Key + " " + variable.Value);
            }

            Console.WriteLine();

            List<Person.Person> newPersonList = personList.Where(x => x.Age >= 20 && x.Age <= 45).OrderByDescending(x => x.Age).ToList();
            newPersonList.ForEach(x => Console.WriteLine(x.Name + " " + x.Age));
        }
    }
}
