using PersonDBApp.Data;
using PersonDBApp.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersonTestDBContext _context;

        public PersonRepository()
        {
            _context = new PersonTestDBContext();
        }
        
        public Person CreatePerson(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return person;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void DeletePerson(Person person)
        {
            try
            {
                _context.Remove(person);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Remove cannot be made" + ex);
                
            }
        }
        public List<Person> Read()
        {
            var people = _context.People.ToList();
            return people;

        }

        public Person Read(long id)
        {
            var person = _context.People.Find(id);
            return person;
        }

        public List<Person> Read(string city)
        {
            var people = _context.People.Where(p => p.City == city).ToList();
            return people;
        }

        public Person UpdatePerson(Person person)
        {
            try
            {
                _context.People.Update(person);
                _context.SaveChanges();
                return person;
            }catch (Exception ex)
            {
                Console.WriteLine("Update cannot be done" + ex);
                return null;
            }
        }

    }
}
