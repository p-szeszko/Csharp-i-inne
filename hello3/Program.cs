using System.Threading;
using System;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;

    class Program
    {
        static async Task Main()
        {
		WriteLine("Przemek Szeszko");
         WriteLine(await GreetingAsync("World",3000));
		 WriteLine("Naciśnij enter...");
		 WriteLine(Environment.Version.ToString());
		 WriteLine(Environment.OSVersion.ToString());
		 ReadLine();
        }
		
		static Task <string> GreetingAsync(string name, int delay){
			return Task.Run<string>(()=>
			{
				Thread.Sleep(delay);
				return string.Format($"Hello {name}!");
			});
		}
		
    }

