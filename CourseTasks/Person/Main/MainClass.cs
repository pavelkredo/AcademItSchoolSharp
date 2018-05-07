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
            var personList = new List<Person.Person>
            {
                new Person.Person("Петр", 22),
                new Person.Person("Светлана", 35),
                new Person.Person("Евгений", 26),
                new Person.Person("Сергей", 15),
                new Person.Person("Петр", 26),
                new Person.Person("Диана", 12)
            };

            var nameList = personList.Select(x => x.Name).Distinct().ToList();
            nameList.ForEach(Console.WriteLine);

            Console.WriteLine();

            var ageList = personList.Select(x => x.Age).Where(x => x < 18).ToList();
            var averageAge = ageList.Average();
            Console.WriteLine(averageAge);

            Console.WriteLine();

            var dictionary = personList.GroupBy(x => x.Name, x => x.Age).ToDictionary(x => x.Key, x => x.Average());

            foreach (var variable in dictionary)
            {
                Console.WriteLine(variable.Key + " " + variable.Value);
            }

            Console.WriteLine();

            var newPersonList = personList.Where(x => x.Age >= 20 && x.Age <= 45).OrderByDescending(x => x.Age).ToList();
            newPersonList.ForEach(x => Console.WriteLine(x.Name + " " + x.Age));
        }
    }
}