using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDBApp.Views
{
    interface IPersonView
    {
        void CreatePerson();

        void PrintAllPeople();

        void PrintSinglePerson();

        void PrintByCity();

        void UpdatePerson();

        void DeletePerson();


    }
}
