using System;
using System.Collections.Generic;
using static System.Console;
using System.Text;
namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
        }
        public static void start()
        {
            PersonComparer comp = new PersonComparer();
            OutputEncoding = Encoding.GetEncoding("UTF-8");
            WriteLine("Demo kolekcji List<T> instantowanej typem 'Person'");
            List<Person> listOfPers = new List<Person>()
                    {
                    new Person("Adam", 23),
                    new Person("Adam",21),
                    new Person("Ewa", 20),
                    new Person("Jola", 21),
                    new Person("Tola", 22),
                    new Person("Tola",25)
                    };
            
            listOfPers.Sort();
            List<Person> input = new List<Person>()
            {
                new Person("Borys",26),
                new Person("Krzysztof",20)
            };
            listOfPers.InsertRange(5, input);
            foreach (Person p in listOfPers)
            {
                WriteLine(p.ToString());
            }
            WriteLine(listOfPers.BinarySearch(new Person("Tola",25),comp));
            WriteLine(listOfPers.Find(x => x.Name.Contains("Tola")));
            
            
           /* WriteLine("Lista 1:");
            foreach (Person p in listOfPers)
                WriteLine(p.ToString());
            listOfPers.Sort(Person.ComparePersons); // uwaga – patrz wykład!
            WriteLine("\nLista 2 - posortowana:");
            foreach (Person p in listOfPers)
                WriteLine(p.ToString());
            listOfPers.Add(new Person("Ola", 22));
            listOfPers.Insert(2, new Person("Marek", 22));
            WriteLine("\nLista 3 - uzup. o 2 osoby:");
            foreach (Person p in listOfPers)
                WriteLine(p.ToString());
            Person wit = new Person("Witold", 22);
            listOfPers.Add(wit);
            listOfPers.Sort(Person.MyReverse); // uwaga – patrz wykład!
            WriteLine("\nLista 4 - uzup. o 1 osobę i posort. odwrotnie:");
            foreach (Person p in listOfPers)
                WriteLine(p.ToString());
            WriteLine($"\nTyp: {listOfPers.GetType()}");
            WriteLine($"\nPojemność: {listOfPers.Capacity}");
            WriteLine($"\nLiczność: {listOfPers.Count}");*/
        }
    }
}
