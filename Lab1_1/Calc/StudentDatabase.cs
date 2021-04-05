using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    class StudentDatabase
    {
        private static int option;
        private static SortedList<int, Dictionary<string, string>> sortedDatabase = new SortedList<int, Dictionary<string, string>>();
        private static SortedList<int, IPerson> database = new SortedList<int, IPerson>();

        static void addToDatabase() 
        {
            Console.WriteLine("Podaj imię studenta");
            string name = Console.ReadLine();
            Console.WriteLine("Podaj klasę studenta");
            string classAttendace = Console.ReadLine();
            IPerson student = new Person(sortedDatabase.Count + 1, name, classAttendace);
            Dictionary<string, string> newRecord = new Dictionary<string, string>();
            newRecord.Add("name", name);
            newRecord.Add("classAttendance", classAttendace);
            sortedDatabase.Add(student.Id, newRecord);
            database.Add(student.Id, student);
            Menu("DODANO REKORD");
        }
        static void viewDatabase()
        {
            foreach (KeyValuePair<int, Dictionary<string, string>> kvp in sortedDatabase)
            {
                Console.WriteLine("Student id: " + kvp.Key);
                foreach (KeyValuePair<string, string> kvpd in kvp.Value)
                {
                    Console.WriteLine(kvpd.Key + ": " + kvpd.Value);
                }
                Console.WriteLine("------------");
            }
            Console.WriteLine("Kliknij cokolwiek aby kontynuować.");
            Console.ReadKey();
            Menu("");
        }
        static void changeDatabase(ref IPerson student, ref Dictionary<string, string> studentdt)
        {
            Console.WriteLine("Obecne imię studenta: " + student.Name);
            Console.WriteLine("Wpisz nowe lub zostaw puste aby nie aktualizować");
            string newName = Console.ReadLine();
            if(newName.Length > 0)
            {
                student.Name = newName;
                studentdt["name"] = newName;
            }
            Console.WriteLine("Obecna klasa studenta: " + student.ClassAttendance);
            Console.WriteLine("Wpisz nowe lub zostaw puste aby nie aktualizować");
            string newClass = Console.ReadLine();
            if (newClass.Length > 0)
            {
                student.ClassAttendance = newClass;
                studentdt["classAttendance"] = newClass;
            }
            Menu("ZAKTUALIZOWANO REKORD");
        }
        public static void Menu(string? message)
        {
            bool pass = true;
            while (pass)
            {
                Console.Clear();
                if (message.Length > 0)
                {
                    Console.WriteLine(message);
                }
                Console.WriteLine("         MENU         ");
                Console.WriteLine("||||||||||||||||||||||");
                Console.WriteLine("1. Dodaj rekord do bazy danych");
                Console.WriteLine("2. Zmień rekord");
                Console.WriteLine("3. Zobacz rekordy");
                Console.WriteLine("4. Powrót do kalkulatora");
                Console.WriteLine("5. Zakończ");
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
                            addToDatabase();
                            break;
                        case 2:
                            Console.WriteLine("Podaj id studenta ktorego chcesz zmienic");
                            int studentId = 0;
                            string stId = Console.ReadLine().ToString();
                            try
                            {
                                studentId = Int32.Parse(stId);
                            }
                            catch
                            {
                                Console.WriteLine("Błąd nie wpisano cyfry");
                            }
                            finally
                            {
                                IPerson person = database.GetValueOrDefault(studentId);
                                Dictionary<string, string> persondt = sortedDatabase.GetValueOrDefault(studentId);
                                if (person.Name != null)
                                {
                                    changeDatabase(ref person, ref persondt);
                                }
                            }
                            break;
                        case 3:
                            viewDatabase();
                            break;
                        case 4:
                            Program.Menu();
                            break;
                        case 5:
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
