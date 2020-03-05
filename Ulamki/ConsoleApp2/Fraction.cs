using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    /// <summary>Klasa do przechowywania unformacji o ulamku. Licznik, mianownik i liczbe calkowitą. Posiada zdefiniowane podstaweowe operacje arytmetyczne.</summary>
    class Fraction
    {
        public int Numerator;
        public int Denominator;
        public int normal=0;
        public static Fraction Zero = new Fraction(0, 0);
        /// <summary>Konstruktor, przyjmujacy dwie liczby calkowite</summary>
        /// <param name="numerator">Licznik</param>
        /// <param name="denominator">Mianownik</param>
        public Fraction(int numerator, int denominator)
        {
            this.Numerator = numerator;
            this.Denominator = denominator;

           
            if (this.Denominator < 0)
            { 
                this.Numerator = -this.Numerator;
                this.Denominator = -this.Denominator;
            }
        }

        /// <summary>
        ///   <para>Konstruktor kopiujacy ulamka</para>
        /// </summary>
        /// <param name="fraction">Ulamek</param>
        public Fraction(Fraction fraction)
        {
            this.Numerator = fraction.Numerator;
            this.Denominator = fraction.Denominator;
        }
        /// <summary>Funkcja zwracajaca najwyższy wspolny dzielnik, dwoch cyfr calkowitych</summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private static int getGCD(int a, int b)
        {
            
            a = Math.Abs(a);
            b = Math.Abs(b);

            
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }
        /// <summary>Funkcja zamieniajaca ulamek niewlasciwy na ulamek wlasciwy</summary>
        public void ChangeNormal()
        {
            while (Numerator > Denominator)
            {
                normal = Numerator / Denominator;
                Numerator = Numerator % Denominator;
                
            }
        }
        /// <summary>Funkcja redukujaca ulamek</summary>
        public Fraction GetReduced()
        {
            
            Fraction modifiedFraction = this;

            int gcd = 0;
            while (Math.Abs(gcd = getGCD(modifiedFraction.Numerator, modifiedFraction.Denominator)) != 1)
            {
                modifiedFraction.Numerator /= gcd;
                modifiedFraction.Denominator /= gcd;
            }

           
            if (modifiedFraction.Denominator < 0)
            {
                modifiedFraction.Numerator = -this.Numerator;
                modifiedFraction.Denominator = -this.Denominator;
            }

            return modifiedFraction;
        }
        /// <summary>funkcja zwracajaca najmniejszy wspolny mianownik z dwoch liczb calkowitych</summary>
        /// <param name="a">liczba calkowita</param>
        /// <param name="b">liczba calkowita</param>
        private static int getLCD(int a, int b)
        {
            
            return (a * b) / getGCD(a, b);
        }
        /// <summary>
        ///   <para>Funkcja zwracajaca ulamek odwrotny</para>
        /// </summary>
        public Fraction GetReciprocal() 
        {
           
            return new Fraction(this.Denominator, this.Numerator);
        }

        /// <summary>Funkcja wykonuje operacje na ulamku by pasowal do podanego mianownika</summary>
        /// <param name="targetDenominator"></param>
        public Fraction ToDenominator(int targetDenominator)
        {
            
            Fraction modifiedFraction = this;

            
            if (targetDenominator < this.Denominator)
                return modifiedFraction;

            
            if (targetDenominator % this.Denominator != 0)
                return modifiedFraction;

            if (this.Denominator != targetDenominator)
            {
                int factor = targetDenominator / this.Denominator;
                modifiedFraction.Denominator = targetDenominator;
                modifiedFraction.Numerator *= factor;
            }

            return modifiedFraction;
        }

        /// <summary>
        ///   <para>Funkcja jest przeciazonym operatorem dodawania, zwraca nowy obiekt Fraction</para>
        ///   <para></para>
        /// </summary>
        /// <param name="fraction1"></param>
        /// <param name="fraction2"></param>
        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.normal!=0)
            {
                fraction1.Numerator = fraction1.Numerator+( fraction1.Numerator * fraction1.normal);
                fraction1.normal = 0;
            }
            if (fraction2.normal != 0)
            {
                fraction2.Numerator =fraction2.Numerator+( fraction2.Numerator * fraction2.normal);
                fraction2.normal = 0;
            }

            if (fraction1.Denominator == 0)
                return fraction2;
            else if (fraction2.Denominator == 0)
                return fraction1;

            
            int lcd = getLCD(fraction1.Denominator, fraction2.Denominator);

           
            fraction1 = fraction1.ToDenominator(lcd);
            fraction2 = fraction2.ToDenominator(lcd);

            
            return new Fraction(fraction1.Numerator + fraction2.Numerator, lcd).GetReduced();
        }

        /// <summary>Funkcja przeciążająca operator odejmowania, przyjmuje dwa obiekty Fraction</summary>
        /// <param name="fraction1"></param>
        /// <param name="fraction2"></param>
        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.normal != 0)
            {
                fraction1.Numerator = fraction1.Numerator + (fraction1.Numerator * fraction1.normal);
                fraction1.normal = 0;
            }
            if (fraction2.normal != 0)
            {
                fraction2.Numerator = fraction2.Numerator + (fraction2.Numerator * fraction2.normal);
                fraction2.normal = 0;
            }

            int lcd = getLCD(fraction1.Denominator, fraction2.Denominator);

           
            fraction1 = fraction1.ToDenominator(lcd);
            fraction2 = fraction2.ToDenominator(lcd);

            
            return new Fraction(fraction1.Numerator - fraction2.Numerator, lcd).GetReduced();
        }

        /// <summary>Funkcja przeciążająca operator mnożenia, przyjmuje dwa ulamki i zwraca nowy</summary>
        /// <param name="fraction1"></param>
        /// <param name="fraction2"></param>
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.normal != 0)
            {
                fraction1.Numerator = fraction1.Numerator + (fraction1.Numerator * fraction1.normal);
                fraction1.normal = 0;
            }
            if (fraction2.normal != 0)
            {
                fraction2.Numerator = fraction2.Numerator + (fraction2.Numerator * fraction2.normal);
                fraction2.normal = 0;
            }
            int numerator = fraction1.Numerator * fraction2.Numerator;
            int denominator = fraction1.Denominator * fraction2.Denominator;

            return new Fraction(numerator, denominator).GetReduced();
        }

        /// <summary>Funkcja przeciążająca operator dzielenia, przyjmuje dwa obiekty Fraction i zwraca nowy</summary>
        /// <param name="fraction1"></param>
        /// <param name="fraction2"></param>
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.normal != 0)
            {
                fraction1.Numerator = fraction1.Numerator + (fraction1.Numerator * fraction1.normal);
                fraction1.normal = 0;
            }
            if (fraction2.normal != 0)
            {
                fraction2.Numerator = fraction2.Numerator + (fraction2.Numerator * fraction2.normal);
                fraction2.normal = 0;
            }

            int numerator = fraction1.Numerator * fraction2.Denominator;
            int denominator = fraction1.Denominator * fraction2.Numerator;
            return new Fraction(numerator, denominator).GetReduced();
        }


    }
}
