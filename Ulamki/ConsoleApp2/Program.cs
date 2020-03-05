using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetOperation();
        }

        /// <summary>Funkcja do obslugi menu kalkulatora</summary>
        public static void GetOperation()
        {
            WriteLine("Podaj numer opearacji.\n1. Dodawanie \n2. Odejmowanie\n3. Mnożenie\n4. Dzielenie\n5. Skróć\n6.Zamień na właściwy ułamek\n Esc. Koniec");
            var key= Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.D1)
                {
                    List<int> fractions = getFractions(2);
                    
                    Fraction frac1 = new Fraction(fractions[0], fractions[1]);
                    Fraction frac2 = new Fraction(fractions[2], fractions[3]);
                    frac1 = frac1 + frac2;
                    WriteLine(frac1.Numerator + "/" + frac1.Denominator);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    List<int> fractions = getFractions(2);

                    Fraction frac1 = new Fraction(fractions[0], fractions[1]);
                    Fraction frac2 = new Fraction(fractions[2], fractions[3]);
                    frac1 = frac1 - frac2;
                    WriteLine(frac1.Numerator + "/" + frac1.Denominator);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    List<int> fractions = getFractions(2);

                    Fraction frac1 = new Fraction(fractions[0], fractions[1]);
                    Fraction frac2 = new Fraction(fractions[2], fractions[3]);
                    frac1 = frac1 * frac2;
                    WriteLine(frac1.Numerator + "/" + frac1.Denominator);
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    List<int> fractions = getFractions(2);

                    Fraction frac1 = new Fraction(fractions[0], fractions[1]);
                    Fraction frac2 = new Fraction(fractions[2], fractions[3]);
                    frac1 = frac1 / frac2;
                    WriteLine(frac1.Numerator + "/" + frac1.Denominator);
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    List<int> fractions = getFractions(1);
                    Fraction frac = new Fraction(fractions[0], fractions[1]);
                    frac = frac.GetReduced();
                    WriteLine("Zredukowany ulamek: " + frac.Numerator + "/" + frac.Denominator);
                }
                else if (key.Key == ConsoleKey.D6)
                {
                    List<int> fractions = getFractions(1);
                    Fraction frac = new Fraction(fractions[0], fractions[1]);
                    frac.ChangeNormal();
                    WriteLine("Wlasciwy ulamek: " +frac.normal+" "+ frac.Numerator + "/" + frac.Denominator);
                }
                else { }
                WriteLine("Podaj numer opearacji.\n1. Dodawanie \n2. Odejmowanie\n3. Mnożenie\n4. Dzielenie\n5. Skróć\n6.Zamień na właściwy ułamek\n Esc. Koniec");
                key = Console.ReadKey(true);
                
               
            }
        }
        /// <summary>Funkcja pobierajaca ulamki od uzytkownika</summary>
        /// <param name="amount"></param>
        private static List<int> getFractions(int amount)
        {
            int i = 0;
            List<int> fractions = new List<int>(amount*2);
            while(i<amount)
            {
                WriteLine("Podaj ulamek " + (i + 1)+" w formacie licznik/mianownik:");
                string fraction=ReadLine();
                string [] frac=fraction.Split('/');
                if(frac.Length!=2)
                {
                    WriteLine("Podalez zły ułamek");
                    
                }
                else
                if (Int32.Parse(frac[1]) == 0)
                {
                    WriteLine("Podałeś 0 jako mianownik, sprobuj jeszcze raz");
                }
                else
                {
                    fractions.Add(Int32.Parse(frac[0]));
                    fractions.Add(Int32.Parse(frac[1]));
                    i++;
                }
                


            }
            return fractions;
        }
    }
}
