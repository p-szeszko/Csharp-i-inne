using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Loty
{
    class Program
    {
      
        static void Main(string[] args)
        {


            wpisz();
           
              


           


        }
       static public void wpisz()
        {
           
            TimeSpan czas;
            
            var value = string.Empty;
            var buffer = new StringBuilder();
            Boolean koniec = false;
            while (!TimeSpan.TryParseExact(value, "h\\:mm", null, System.Globalization.TimeSpanStyles.None, out czas))
            {
                WriteLine("Proszę podać godzinę w formacie GG:MM : ");
                var key = Console.ReadKey(true);
                buffer.Clear();
                value = string.Empty;

                while (key.Key != ConsoleKey.Enter)
                {

                    if (key.Key == ConsoleKey.Backspace && Console.CursorLeft > 0)
                    {
                        var cli = --Console.CursorLeft;
                        buffer.Remove(cli, 1);
                        Console.CursorLeft = 0;
                        Console.Write(new String(Enumerable.Range(0, buffer.Length + 1).Select(o => ' ').ToArray()));
                        Console.CursorLeft = 0;
                        Console.Write(buffer.ToString());
                        Console.CursorLeft = cli;
                        key = Console.ReadKey(true);
                    }
                    else if (Char.IsDigit(key.KeyChar) || key.KeyChar == ':')
                    {
                        var cli = Console.CursorLeft;
                        buffer.Insert(cli, key.KeyChar);
                        Console.CursorLeft = 0;
                        Console.Write(buffer.ToString());
                        Console.CursorLeft = cli + 1;
                        key = Console.ReadKey(true);
                    }
                    else if (key.Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0)
                    {
                        Console.CursorLeft--;
                        key = Console.ReadKey(true);
                    }
                    else if (key.Key == ConsoleKey.RightArrow && Console.CursorLeft < buffer.Length)
                    {
                        Console.CursorLeft++;
                        key = Console.ReadKey(true);
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {

                        return;
                    }
                    else
                    {
                        key = Console.ReadKey(true);
                    }
                }

                value = buffer.ToString();

                

            }
            
            znajdz_3(czas);
        }
      static  public void znajdz_3(TimeSpan czas)
        {
            WriteLine();

            Informator inf = new Informator();
            TimeSpan[] loty;
            Boolean jutro = false ;
            
            for (int i = 0; i < 3; i++)
            {
                loty = inf.znajdzLot(czas);
                
                if (czas > TimeSpan.ParseExact("23:45", "h\\:mm", null, System.Globalization.TimeSpanStyles.None))
                {
                    jutro = true;
                }
                if (!jutro) {
                    WriteLine("Wylot: " + loty[0] + "   Przylot: " + loty[1]);
                    czas = loty[0].Add(new TimeSpan(0, 1, 0));

                }
                else
                {
                    WriteLine("Wylot: " + loty[0] +" ("+DateTime.Now.AddDays(1).ToShortDateString()+") "+ "   Przylot: " + loty[1] + " (" + DateTime.Now.AddDays(1).ToShortDateString() + ") ");
                    czas = loty[0].Add(new TimeSpan(0, 1, 0));
                }
            }

            wpisz();
        }
        

        }
    }

