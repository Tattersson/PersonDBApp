using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonPhoneTbs = new HashSet<PersonPhoneTb>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string EyeColor { get; set; }
        public int? ShoeSize { get; set; }
        public int? Height { get; set; }

        public virtual ICollection<PersonPhoneTb> PersonPhoneTbs { get; set; }
    }
}
