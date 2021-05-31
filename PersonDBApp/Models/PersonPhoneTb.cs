using System;
using System.Collections.Generic;

#nullable disable

namespace PersonDBApp.Models
{
    public partial class PersonPhoneTb
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public string Phonenumber { get; set; }
        public bool? Active { get; set; }

        public virtual Person User { get; set; }
    }
}
