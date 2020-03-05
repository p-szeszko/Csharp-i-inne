using System;
using System.Threading;
using static  System.Console;
namespace CEvent1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dealer = new CarDealer();

            var michal = new Consumer("Michal");
            var ela = new Consumer("Ela");
            var kalina = new Consumer("Kalina");
            dealer.NewCarInfo += ela.NewCarIsHere;
            dealer.RaiseNewCarInfo("Honda/Accord");
            Thread.Sleep(3000);

            dealer.NewCarInfo -= michal.NewCarIsHere;
            dealer.NewCarInfo += kalina.NewCarIsHere;
            dealer.RaiseNewCarInfo("Opel/Corsa");
            Thread.Sleep(3000);
            dealer.NewCarInfo -= kalina.NewCarIsHere;
            dealer.NewCarInfo -= ela.NewCarIsHere;


            dealer.RaiseNewCarInfo("Opel/Insignia");
            Thread.Sleep(1000);

            WriteLine("To już koniec...nikt nie czeka!");
        }
        public class CarInfoEventArgs : EventArgs
        {
            public CarInfoEventArgs(string car) { this.Car = car; }

            public string Car { get; private set; }
        }
        class CarDealer
        {         // reprezentuje metodę, która obsłuży zdarzenie 'NewCarInfo'         // zdarzenie dostarcza dane       
            public event EventHandler<CarInfoEventArgs> NewCarInfo;

            public void RaiseNewCarInfo(string car)
            {
                Console.WriteLine("\nDealer, nowe auto: {0}", car);
                NewCarInfo?.Invoke(this, new CarInfoEventArgs(car));
            }
        }
        public class Consumer
        {
            private string name;

            public Consumer(string name) { this.name = name; }

            public void NewCarIsHere(object sender, CarInfoEventArgs e) { Console.WriteLine("\tInfo dla {0}; jest nowe auto: {1}", name, e.Car); }
        }


    }
}
