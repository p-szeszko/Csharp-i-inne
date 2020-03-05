using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var syn = new SpeechSynthesizer();
            syn.SpeakAsync(lb.Text);
        }

        private void read(object sender, RoutedEventArgs e)
        {
            lb.Text = "Dziala";

            int zmienna;

            if (!Int32.TryParse(tb.Text, out zmienna) || zmienna < 10 || zmienna > 99)
            {
                lb.Text = "Nie poprawna liczba";
                tb.Text = "";
            }
            else
            {
                string wynik = "";
                int dzies = zmienna / 10;
                int x = zmienna % 10;
                if (zmienna < 20)
                {
                    switch (zmienna)
                    {
                        case 10:
                            wynik = "Dziesięć";
                            break;
                        case 11:
                            wynik = "Jedenaście";
                            break;
                        case 12:
                            wynik = "Dwanaście";
                            break;
                        case 13:
                            wynik = "Trzynaście";
                            break;
                        case 14:
                            wynik = "Czternaście";
                            break;
                        case 15:
                            wynik = "Pietnaście";
                            break;
                        case 16:
                            wynik = "Szesnaście";
                            break;
                        case 17:
                            wynik = "Siedemnaście";
                            break;
                        case 18:
                            wynik = "Osiemnaście";
                            break;
                        case 19:
                            wynik = "Dziewietnaście";
                            break;
                    }
                    lb.Text = wynik;
                }
                else
                {
                    switch (dzies)
                    {
                        case 2:
                            wynik = "Dwadzieścia";
                            break;
                        case 3:
                            wynik = "Trzydzieści";
                            break;
                        case 4:
                            wynik = "Czterdzieści";
                            break;
                        case 5:
                            wynik = "Piędździesiąt";
                            break;
                        case 6:
                            wynik = "Sześćdziesiąt";
                            break;
                        case 7:
                            wynik = "Siedemdziesiąt";
                            break;
                        case 8:
                            wynik = "Osiemdziesiąt";
                            break;
                        case 9:
                            wynik = "Dziewiędziesiąt";
                            break;
                    }
                    switch (x)
                    {
                        case 1:
                            wynik = wynik + "jeden";
                            break;
                        case 2:
                            wynik = wynik + "dwa";
                            break;
                        case 3:
                            wynik = wynik + "trzy";
                            break;
                        case 4:
                            wynik = wynik + "cztery";
                            break;
                        case 5:
                            wynik = wynik + "pięć";
                            break;
                        case 6:
                            wynik = wynik + "sześć";
                            break;
                        case 7:
                            wynik = wynik + "siedem";
                            break;
                        case 8:
                            wynik = wynik + "osiem";
                            break;
                        case 9:
                            wynik = wynik + "dziewięć";
                            break;
                    }

                    lb.Text = wynik;
                }
            }
        }
    }
    }

