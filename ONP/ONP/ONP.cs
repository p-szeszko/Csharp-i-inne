using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ONP
{
    /// <summary>Klasa sużąca do obliczania dzialan zapisanych przy pomocy ONP</summary>
    class ONP
    {
        /// <summary>Konstruktor klasy ONP.</summary>
        public ONP()
        {

        }


        /// <summary>Metoda wczytująca ciąg ONP i uruchamiająca funkcję obliczającą ten ciąg.</summary>
        public void onp_read()
        {
            WriteLine("Podaj ciąg ONP:");
            string onp = ReadLine();
            calculate_onp(onp);
        }


        /// <summary>
        /// Metoda pobiera ciąg ONP, oblicza jego wynik, wypisuje go i uruchamia funkcję wczytującą kolejny ciąg ONP. Metoda operuje na stosie.
        /// Wpisanie znaku/operatora innego niż: {*,/,+,-,=} lub cyfry powoduje przerwanie dziaania programu.
        /// </summary>
        /// <param name="onp">Ciąg ONP, w ktorym symbole muszę być oddzielone spacją</param>
        public void calculate_onp(string onp)
        {
            string[] symbols = onp.Split(' ');
            int number;
            Stack<int> stack = new Stack<int>();
            foreach (string symbol in symbols)
            {

                if (Int32.TryParse(symbol, out number))
                {
                    stack.Push(number);
                }
                else
                if (symbol == "+" || symbol == "-" || symbol == "/" || symbol == "*" || symbol == "=")
                {
                    switch (symbol)
                    {
                        case "=":
                            {
                                WriteLine("Wynik wyrazenia: " + stack.Pop());
                                stack.Clear();
                                onp_read();
                                break;
                            }
                        case "*":
                            {
                                stack.Push(stack.Pop() * stack.Pop());
                                break;
                            }
                        case "/":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() / number);
                                break;
                            }
                        case "+":
                            {
                                stack.Push(stack.Pop() + stack.Pop());
                                break;
                            }
                        case "-":
                            {
                                number = stack.Pop();
                                stack.Push(stack.Pop() - number);
                                break;
                            }

                    }

                }
                else
                {
                    return;
                }
            }
        }
    }
}
