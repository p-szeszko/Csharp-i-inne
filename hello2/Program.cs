using System;
using static System.Console;
using static System.Text.Encoding;

namespace hello2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
			OutputEncoding=GetEncoding("UTF-8");
			WriteLine("czyli: Witaj Świecie!");
			WriteLine($"Aktualna data/czas: {DateTime.Now}");
			WriteLine(Environment.Version.ToString());
			WriteLine(Environment.OSVersion.ToString());
        }
    }
}
