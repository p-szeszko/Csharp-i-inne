using System;
using System.Text;

namespace hello1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			Console.OutputEncoding=Encoding.GetEncoding("UTF-8");
			Console.WriteLine("czyli: Witaj Świecie!");
			DateTime dt= DateTime.Now;
			Console.WriteLine("Aktualna data/czas:{0}",dt);
			Console.WriteLine(Environment.Version.ToString());
			Console.WriteLine(Environment.OSVersion.ToString());
        }
    }
}
