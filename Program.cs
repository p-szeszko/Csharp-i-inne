using static System.Console;
using static System.Text.Encoding;
namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
			OutputEncoding=GetEncoding("UTF-8");
			WriteLine("Witaj Świecie!");
			WriteLine("Salve Mundi!");
			WriteLine("Olá Mundo!");
			WriteLine("Hallo Welt!");
			WriteLine("привет мир!");
        }
    }
}
