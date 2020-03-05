using Extension_methods;
using System;
using System.Collections.Generic;
using static System.Console;

namespace ConsoleApp2
{
    class  Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        public static void menu()
        {
            Student lista = new Student();
            WriteLine("Podaj numer opearacji.\n1. Dodaj studenta recznie \n2. Wczytaj z pliku \n3. Sortuj po imieniu\n4. Sortuj po nazwisku\n5. Sortuj po nr albumu\n6. Sortuj po dacie\n7. Powtórzenia\n8. Czas\n9. Sortowanie całościowe\n0. Zapis do pliku\n Esc. Koniec");
            var key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.D1)
                {
                    lista.addStudent(getStudent());

                }
                else if (key.Key == ConsoleKey.D2)
                {
                    List<Stud> students = fromFile();
                    foreach (Stud stud in students)
                    {
                        lista.addStudent(stud);
                    }
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    lista.sort(1);
                    showStud(lista);
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    lista.sort(2);
                    showStud(lista);
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    lista.sort(3);
                    showStud(lista);
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    lista.sort(4);
                    showStud(lista);
                }
                else if (key.Key == ConsoleKey.D7)
                {
                    List<(string, int)> wynik = lista.Repeats();
                    for(int i=0; i<wynik.Count;i++)
                    {
                        WriteLine(wynik[i].Item1 + ": " + wynik[i].Item2);
                    }
                   }
                else if (key.Key == ConsoleKey.D8)
                {
                    List<(string, int)> wynik = lista.SameData();
                    for (int i = 0; i < wynik.Count; i++)
                    {
                        WriteLine(wynik[i].Item1 + ": " + wynik[i].Item2);
                    }
                
                  }
                else if (key.Key == ConsoleKey.D9)
                {
                    lista.sort2(5);
                    showStud(lista);
                }
                else if(key.Key==ConsoleKey.D0)
                {
                    lista.fileSave();
                }
                else { }
                WriteLine("Podaj numer opearacji.\n1. Dodaj studenta recznie \n2. Wczytaj z pliku \n3. Sortuj po imieniu\n4. Sortuj po nazwisku\n5. Sortuj po nr albumu\n6. Sortuj po dacie\n 7. Powtórzenia\n8. Czas\n9. Sortowanie całościowe\n0. Zapis do pliku\n Esc. Koniec");

                key = Console.ReadKey(true);
            }
        }
        private static Stud getStudent()
        {
            int i = 0;
            List<string> student = new List<string>(3);
            WriteLine("Podaj imie studenta:");
            student.Add(ReadLine());
            WriteLine("Podja nazwisko");
            student.Add(ReadLine());
            WriteLine("Podaj numer albumu");
            student.Add(ReadLine());
            return new Stud(student[0], student[1], Int32.Parse(student[2]), DateTime.Now);

        }
        private static List<Stud> fromFile()
        {
            string line;
            List<Stud> students = new List<Stud>();
            System.IO.StreamReader file =
    new System.IO.StreamReader(@"test.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] dane = line.Split('/');
                students.Add(new Stud(dane[0], dane[1], Int32.Parse(dane[2]), DateTime.Parse(dane[3])));
                
            }
            file.Close();
            return students;

        }

        public static void showStud(Student students)
        {
            foreach (Stud stud in students.lista_stud)
            {
                WriteLine(stud.ToString());
            }
        }
    }
}
