using System;
using System.Collections.Generic;
using System.Text;


namespace Extension_methods
{
     static class Extension
    {
       public static List<(string, int)> Repeats(this ConsoleApp2.Student stud)
        {
            List<(string, int)> wynik = new List<(string, int)>();
            int counter = 0;
            List<string> powtorzenia = new List<string>();
            for (int i = 0; i < stud.lista_stud.Count; i++)
            {
                if (!powtorzenia.Contains(stud.lista_stud[i].nazwisko))
                {
                    counter = 0;
                    powtorzenia.Add(stud.lista_stud[i].nazwisko);
                    for (int j = 0; j < stud.lista_stud.Count; j++)
                    {

                        if (stud.lista_stud[j].nazwisko.Equals(stud.lista_stud[i].nazwisko))
                        {

                            counter++;
                        }
                    }
                    if (counter > 1)
                    {
                        wynik.Add((stud.lista_stud[i].nazwisko, counter));
                    }
                }
            }
            return wynik;
        }


        public static List<(string, int)> SameData(this ConsoleApp2.Student stud)
        {
            List<(string, int)> wynik = new List<(string, int)>();
            int counter = 0;
            List<string> powtorzenia = new List<string>();
            for (int i = 0; i < stud.lista_stud.Count; i++)
            {
                if (!powtorzenia.Contains(stud.lista_stud[i].data.ToShortDateString() + stud.lista_stud[i].data.ToShortTimeString()))
                {
                    counter = 0;
                    powtorzenia.Add(stud.lista_stud[i].data.ToShortDateString() + stud.lista_stud[i].data.ToShortTimeString());
                    for (int j = 0; j < stud.lista_stud.Count; j++)
                    {

                        if (stud.lista_stud[j].data.ToShortDateString().Equals(stud.lista_stud[i].data.ToShortDateString()) && stud.lista_stud[j].data.ToShortTimeString().Equals(stud.lista_stud[i].data.ToShortTimeString()) && j != i)
                        {

                            counter++;
                        }

                    }
                    if (counter > 1)
                    {
                        wynik.Add((stud.lista_stud[i].data.ToShortDateString() + stud.lista_stud[i].data.ToShortTimeString(), counter));
                    }
                }
            }
            return wynik;
        }
    }

}
