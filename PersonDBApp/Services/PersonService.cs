using PersonDBApp.Models;
using PersonDBApp.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Services
{
    class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService()
        {
            _personRepository = new PersonRepository();
        }

        public Person Create(Person person)
        {
            var createdPerson = _personRepository.CreatePerson(person);
            return createdPerson;
        }

        public void Delete(long id)
        {
            var delPerson = _personRepository.Read(id);

            if (delPerson != null)
            {
                _personRepository.DeletePerson(delPerson);
            }
            else
            {
                Console.WriteLine("Cannot be made");
            }

       
        }

        public List<Person> Read()
        {
            var people = _personRepository.Read();
            return people;
        }

        public Person Read(long id)
        {
            var person = _personRepository.Read(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _personRepository.Read(city);
            return people;
        }

        public Person Update(long id, Person person)
        {
            var dbPerson = _personRepository.Read(id);
            if (dbPerson != null)
            {
                person.Id = id;
                var updPerson =_personRepository.UpdatePerson(person);
                return updPerson;
            }
            else
            {
                Console.WriteLine("There were no person using that id.");
                Console.WriteLine("Try adding one!!");
                Console.WriteLine($"ID tried: {dbPerson}");
                return null;
            }
        }
    }
}
