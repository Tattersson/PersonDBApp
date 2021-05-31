﻿using System;
using System.Collections.Generic;
using System.Text;
using PersonDBApp.Models;
using PersonDBApp.Services;
using PersonDBApp.Views;

namespace PersonDBApp
{
    class PersonView : IPersonView
    {
        private readonly IPersonService _personService;

        public PersonView()
        {
            _personService = new PersonService();
        }

        public void CreatePerson()
        {
            Person newPerson = new Person();
            newPerson.FirstName = "Test";
            newPerson.LastName = "Person";
            newPerson.City = "Lappeenranta";

            newPerson = _personService.Create(newPerson);

            if (newPerson != null)
            {
                Console.WriteLine("New person added.");
            }
            else
            {
                Console.WriteLine("New person was unabled to add.");
            }
        }

        public void DeletePerson()
        {
            Console.Write("What ID you want to delete? -> ");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            SinglePrinter(person);
        }

        public void PrintAllPeople()
        {
            //Use this to use the context list
            var people = _personService.Read();
            Printer(people);

        }

        public void PrintByCity()
        {
            Console.Write("What city to look for? -> ");
            string city = Console.ReadLine();
            var people = _personService.Read(city);
            Printer(people);
            
        }

        public void PrintSinglePerson()
        {
            Console.Write("What ID number? -> ");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);

            SinglePrinter(person);
        }

        public void UpdatePerson()
        {
            Console.WriteLine("What ID you want to update? -> ");
            long id = Convert.ToInt64(Console.ReadLine());
            var person = _personService.Read(id);
            SinglePrinter(person);

            Console.WriteLine("Give Firstname: ");
            person.FirstName = Console.ReadLine();
            Console.WriteLine("Give LastName: ");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Sex: ");
            person.Sex = Console.ReadLine();
            Console.WriteLine("Place to live: ");
            person.City = Console.ReadLine();

            _personService.Update(id, person);


        }

        private void Printer(List<Person> people)
        { 
            

            foreach (var p in people)
            {
                Console.WriteLine($"ID: {p.Id} \t| FirstName: {p.FirstName} \t| LastName: {p.LastName} \t| Sex: {p.Sex} \t| City: {p.City}");
            }
        }
        private void SinglePrinter(Person p)
        {
            Console.WriteLine($"ID: {p.Id} \t| FirstName: {p.FirstName} \t| LastName: {p.LastName} \t| Sex: {p.Sex} \t| City: {p.City}");
        }

    }

}
