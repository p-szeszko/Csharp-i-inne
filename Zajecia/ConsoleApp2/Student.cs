using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Extension_methods;

namespace ConsoleApp2
{
    class Student
    {
        public List<Stud> lista_stud;

        Func<Stud, Stud, int>[] del_table =
        {

            Stud.CompareByName,
            Stud.CompareBySurname,
            Stud.CompareByAlbum,
            Stud.CompareByDate,
            Stud.CompareAll
    };

        public delegate int delegat(Stud stud1, Stud stud2);
        delegat[] operacje =
        {
            (stud1,stud2)=>String.Compare(stud1.imie,stud2.imie),
            Stud.CompareBySurname,
            Stud.CompareByAlbum,
            delegate (Stud stud1, Stud stud2){return DateTime.Compare(stud1.data, stud2.data); },
            Stud.CompareAll
        };

        public Student()
        {
            this.lista_stud = new List<Stud>();

        }

        public void addStudent(string imie, string nazwisko, int album, DateTime data)
        {
            lista_stud.Add(new Stud(imie, nazwisko, album, data));
        }

        public void addStudent(Stud stud)
        {
            lista_stud.Add(stud);
        }


        public List<Stud> sort(int i)
        {
            switch (i)
            {
                case 1:
                    lista_stud.Sort((stud1, stud2) => del_table[0](stud1, stud2));
                    break;
                case 2:
                    lista_stud.Sort((stud1, stud2) => del_table[1](stud1, stud2));
                    break;
                case 3:
                    lista_stud.Sort((stud1, stud2) => del_table[2](stud1, stud2));
                    break;
                case 4:
                    lista_stud.Sort((stud1, stud2) => (DateTime.Compare(stud1.data, stud2.data)));
                    break;
                case 5:
                    lista_stud.Sort(Stud.CompareAll);
                    break;


            }
            return lista_stud;
        }
        public List<Stud> sort2(int i)
        {


            switch (i)
            {
                case 1:
                    lista_stud.Sort((stud1, stud2) => operacje[0](stud1, stud2));
                    break;
                case 2:
                    lista_stud.Sort((stud1, stud2) => operacje[1](stud1, stud2));
                    break;
                case 3:
                    lista_stud.Sort((stud1, stud2) => operacje[2](stud1, stud2));
                    break;
                case 4:
                    lista_stud.Sort((stud1, stud2) => operacje[3](stud1, stud2));
                    break;
                case 5:
                    lista_stud.Sort((stud1, stud2) => operacje[4](stud1, stud2));
                    break;


            }
            return lista_stud;
        }

        public void fileSave()
        {
            lista_stud.Sort((stud1, stud2) => del_table[4](stud1, stud2));
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"test.txt");
            foreach (Stud s in lista_stud)
            {
                file.WriteLine(s.ToStringD());
            }
            file.Close();
            lista_stud.Clear();
        }
    }
    class Stud
    {


        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int album { get; set; }
        public DateTime data { get; set; }
        public Stud(string imie, string nazwisko, int album, DateTime data)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.album = album;
            this.data = data;
        }

        public static int CompareByName(Stud stud1, Stud stud2) => String.Compare(stud1.imie, stud2.imie);

        public static int CompareBySurname(Stud stud1, Stud stud2) => String.Compare(stud1.nazwisko, stud2.nazwisko);

        public static int CompareByAlbum(Stud stud1, Stud stud2) => stud1.album.CompareTo(stud2.album);


        public static int CompareByDate(Stud stud1, Stud stud2) => DateTime.Compare(stud1.data, stud2.data);

        public static int CompareAll(Stud stud1, Stud stud2) => (String.Compare(stud1.imie, stud2.imie) != 0) ? String.Compare(stud1.imie, stud2.imie) : ((String.Compare(stud1.nazwisko, stud2.nazwisko) != 0)
            ? String.Compare(stud1.nazwisko, stud2.nazwisko) : DateTime.Compare(stud1.data, stud2.data));





        public override string ToString()
        {
            return this.imie + " " + this.nazwisko + " " + this.album + " " + this.data;
        }
        public string ToStringD()
        {
            return this.imie + "/" + this.nazwisko + "/" + this.album + "/" + this.data;
        }
    }


}

