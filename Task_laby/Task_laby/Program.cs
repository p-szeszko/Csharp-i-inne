using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Task_laby
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
            
            test2();
            ReadLine();
        }

        public async static  void test()
        {
            wg w_g = new wg();
            Task<(string, long)> t1 = W_A("jeden", 10000000, w_g);
            Task<(string, long)> t2 = W_A("dwa", 10000000, w_g);
            Task<(string, long)> t3 = W_B("trzy", 10000000, w_g);
            Task<(string, long)> t4 = W_B("cztery", 10000000, w_g);
           var wynik= await Task.WhenAll(t1,t2,t3,t4);
            foreach((string,long) w in wynik)
            {
                WriteLine(w.Item1 + " " + w.Item2);
            }
            WriteLine(w_g.licznik);
        }
        public async static void test2()
        {
            wg w_g = new wg();
            Task<(string, long)> t1 = W_A("jeden", 10000000, w_g);
            Task<(string, long)> t2 = W_A("dwa", 10000000, w_g);
            Task<(string, long)> t3 = W_B("trzy", 10000000, w_g);
            Task<(string, long)> t4 = W_B("cztery", 10000000, w_g);
            var wynik = await Task.WhenAny(t1, t2, t3, t4).Result;
           
                WriteLine(wynik.Item1 + " " + wynik.Item2);
           
            WriteLine(w_g.licznik);
        }
        static Task<(string,long)> W_A(string name, int n, wg licz)
        {
            return Task.Run<(string,long)>(() =>
          {
              long suma = 0;
              for (int i = 0; i <= n; i++)
              {
                  suma += i;
                  licz.licznik++;
              }
              
              return (name,suma);
          });
          }
        static Task<(string, long)> W_B(string name, int n, wg licz)
        {
            return Task.Run<(string, long)>(() =>
            {
                long suma = 0;
                for (int i=n;i>=0;i--)
                {
                    suma += i;
                    licz.licznik++;
                }

                return (name, suma);
            });
        }
    }
    class wg
    {
      public  long licznik { get; set; }
     
        
    }

}
