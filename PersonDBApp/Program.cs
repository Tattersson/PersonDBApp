using System;
using PersonDBApp.Data;
using System.Linq;

namespace PersonDBApp
{
    class Program
    {
        static private readonly PersonTestDBContext context = new PersonTestDBContext();
        static void Main(string[] args)
        {
            PrintAllPeople();
        }

        static void PrintAllPeople()
        {
                //Use this to use the context list
            var people = context.People.ToList();

            foreach (var p in people)
            {
                Console.WriteLine($"ID: {p.Id} | FirstName: {p.FirstName} \t| LastName: {p.LastName} \t| Sex: {p.Sex}");
            }
        }
    }
}
