using PersonDBApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Services
{
    interface IPersonService
    {
        Person Create(Person person);

        List<Person> Read();

        Person Read(long id);

        List<Person> Read(string city);

        Person Update(long id, Person person);

        void Delete(long id);
    }
}
