using System;
using System.Collections;
using System.Collections.Generic;

namespace Calc
{
    class Program
    {
        private static int option;
        public static Queue<List<string>> History = new Queue<List<string>>();

        static void Main(string[] args)
        {
            Menu();
        }
        static void toBinary()
        {
            bool problem = true;
            int value = 0;
            while (problem)
            {

                Console.WriteLine("Przeliczanie z dwójkowego na dziesiętny");
                Console.WriteLine("Wpisz liczbę...");
                string rkb = Console.ReadLine();
                Stack numbers = new Stack(rkb.ToCharArray());
                try
                {
                    problem = false;
                    int count = 0;
                    foreach (var number in numbers) 
                    {
                        Int32 n = Convert.ToInt32(number.ToString());
                        if(n == 1 || n == 0)
                        {
                            value += (int)Math.Pow(2, count) * n;
                            count++;
                            
                        } 
                        else
                        {
                            problem = true;
                        }
                    }
                    if (!problem)
                    {
                        Console.WriteLine("Wynik to: " + value);
                        addToHistory(rkb, value);
                        Console.WriteLine();
                        Console.WriteLine("Czy chcesz obliczyć inną liczbę? t/N");
                        char opt = Console.ReadKey().KeyChar;
                        if(opt == 't')
                        {
                            toBinary();
                        }
                        else if (opt == 'n')
                        {
                            Menu();
                        }
                        else
                        {
                            Menu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Błędny zapis liczby!! Wpisz tylko 1 i  0");
                    }

                }
                catch
                {
                    Console.WriteLine("Podaj same cyfry!!");
                    problem = true;
                }

            }


        }
        static void addToHistory(string line, int val)
        {
            List<string> list = new List<string>();
            list.Add(line);
            list.Add(val.ToString());
            History.Enqueue(list);
        }

        static void showHistory()
        {
            Console.Clear();
            Console.WriteLine("HISTORIA");
            foreach (var list in History)
            {
                Console.WriteLine(list[0] + " => " + list[1]);
            }
            Console.WriteLine("Kliknij cokolwiek aby wrócić do menu.");
            Console.ReadKey();
            Menu();
        }
        public static void Menu()
        {
            bool pass = true;
            while (pass)
            {
                Console.Clear();
                Console.WriteLine("         MENU         ");
                Console.WriteLine("||||||||||||||||||||||");
                Console.WriteLine("1. Przelicz z systemu dwójkowego na dziesiętny");
                Console.WriteLine("2. Do bazy danych studentów");
                Console.WriteLine("3. Zobacz historię");
                Console.WriteLine("4. Zakończ");
                string rk = Console.ReadLine().ToString();
                try
                {
                    option = Int32.Parse(rk);
                    Console.WriteLine(option);
                }
                catch
                {
                    Console.WriteLine("Błąd proszę wpisać cyfrę");
                }
                finally
                {
                    pass = false;
                    switch (option)
                    {
                        case 1:
                            toBinary();
                            break;
                        case 2:
                            StudentDatabase.Menu("");
                            break;
                        case 3:
                            showHistory();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Nie ma takiej opcji");
                            pass = true;
                            Console.WriteLine("Wciśnij dowolny przycisk aby powrócić do menu");
                            Console.ReadKey();
                            break;
                    }
                }

            }
        }
    }
}
