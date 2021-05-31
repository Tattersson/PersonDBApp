using System;
using PersonDBApp.Data;
using System.Linq;
using PersonDBApp.Views;

namespace PersonDBApp
{
    class Program
    {
        static private readonly PersonTestDBContext context = new PersonTestDBContext();
        static private readonly IPersonView _personView = new PersonView();

        static void Main(string[] args)
        {
            //PrintAllPeople();

            string choice = null;

            do
            {
                choice = UserInterface();
                switch (choice.ToUpper())
                {
                    case "C":
                        _personView.CreatePerson();
                        break;
                    case "R":
                        _personView.PrintAllPeople();
                        break;
                    case "U":
                        _personView.UpdatePerson();
                        break;
                    case "D":
                        _personView.DeletePerson();
                        break;
                    case "R1":
                        _personView.PrintSinglePerson();
                        break;
                    case "R2":
                        _personView.PrintByCity();
                        break;
                }
                Console.WriteLine("Press ENTER to continue.");
                Console.ReadLine();
            }
            while (choice.ToUpper() != "X");

        }
            static string UserInterface()
            {
            Console.WriteLine("Database example");
            Console.WriteLine("[C] - Add new person.");
            Console.WriteLine("[R] - Print all people.");
            Console.WriteLine("[U] - Update person info. - Update coming soon!");
            Console.WriteLine("[D] - Remove a person. - Update coming soon!");
            Console.WriteLine("[R1]- Print person.");
            Console.WriteLine("[R2]- Print people from a city.");
            Console.WriteLine("[X] - EXIT.");
            return Console.ReadLine();
            }
    }
}
