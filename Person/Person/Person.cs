using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person : IComparable<Person>
    {
        // właściwość
        public string Name;
        // właściwość
        public int Age { get; set; }
        public Person(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        public static int ComparePersons(Person p1, Person p2) // uwaga – patrz wykład!
        {
            return p1.Age.CompareTo(p2.Age);
        }
        public static int MyReverse(Person p1, Person p2) // uwaga – patrz wykład!
        {
            return ComparePersons(p2, p1);
        }
        public override string ToString()
        {
            return Name.ToString() + ",\t" + Age.ToString();
        }

        public int CompareTo(Person other)
        {
            var ret = String.Compare(this.Name, other.Name);
            if (ret == 0)
                return this.Age.CompareTo(other.Age);
            else
                return ret;
        }

       
    }

    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {


            return x.CompareTo(y);

        }
    }
}
        

