using System;
using static System.Console;
using System.IO;

namespace L3_z3
{
    class Program
    {
        static int count;
        static StreamReader sr;
        const string name = @"E:\C3/tekst1.txt";
        static void Main(string[] args)
        {
            count = 0;
            try
            {
                sr = new StreamReader(name);
                ReadLines();
                sr.Close();
                WriteLine($"\nLiczna linii: {count}\n");
            }
            catch (Exception e)
            {
                WriteLine("Komunikat systemowy: " + e.Message + "\n");
            }
            ReadLine();
        }
        static void ReadLines()
        {
            String textLine = sr.ReadLine();
            if(textLine!=null)
            {
                WriteLine(textLine);
                count++;
                ReadLines();
            }
        }
    }
}
