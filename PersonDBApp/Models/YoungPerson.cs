using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class YoungPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int? Height { get; set; }
        public string Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
