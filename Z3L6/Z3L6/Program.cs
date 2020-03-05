using System;
using System.IO;
using static System.Console;

namespace Z3L6
{
    class Program
    {
        static void Main(string[] args)
        {
            int zmienna;
            WriteLine("Podaj naturalną liczbę dwucyfrową:");
            while(!Int32.TryParse(ReadLine(), out zmienna)||zmienna<10||zmienna>99)
            {
                WriteLine("Podaj naturalną zmienną dwucyfrową:");
            }
            int dzies=zmienna/10;
            int x=zmienna%10;
            if (zmienna<20)
            switch (zmienna)
            {
                case 10:
                    WriteLine("Dziesięć");
                    break;
                case 11:
                    WriteLine("Jedenaście");
                    break;
                case 12:
                    WriteLine("Dwanaście");
                    break;
                case 13:
                    WriteLine("Trzynaście");
                    break;
                case 14:
                    WriteLine("Czternaście");
                    break;
                case 15:
                    WriteLine("Pietnaście");
                    break;
                case 16:
                    WriteLine("Szesnaście");
                    break;
                case 17:
                    WriteLine("Siedemnaście");
                    break;
                case 18:
                    WriteLine("Osiemnaście");
                    break;
                case 19:
                    WriteLine("Dziewietnaście");
                    break;
            }
            else
            {
                switch (dzies)
                {
                    case 2:
                        Write("Dwadzieścia");
                        break;
                    case 3:
                        Write("Trzydzieści");
                        break;
                    case 4:
                        Write("Czterdzieści");
                        break;
                    case 5:
                        Write("Piędździesiąt");
                        break;
                    case 6:
                        Write("Sześćdziesiąt");
                        break;
                    case 7:
                        Write("Siedemdziesiąt");
                        break;
                    case 8:
                        Write("Osiemdziesiąt");
                        break;
                    case 9:
                        Write("Dziewiędziesiąt");
                        break;
                }
                switch (x)
                {
                    case 1:
                        WriteLine("1");
                        break;
                    case 2:
                        WriteLine("dwa");
                        break;
                    case 3:
                        WriteLine("trzy");
                        break;
                    case 4:
                        WriteLine("cztery");
                        break;
                    case 5:
                        WriteLine("pięć");
                        break;
                    case 6:
                        WriteLine("sześć");
                        break;
                    case 7:
                        WriteLine("siedem");
                        break;
                    case 8:
                        WriteLine("osiem");
                        break;
                    case 9:
                        WriteLine("dziewięć");
                        break;
                }
            }
        }
    }
}
