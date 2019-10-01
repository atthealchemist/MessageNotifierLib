using System;
using System.Collections.Generic;

namespace MessageNotifierLibrary.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
    }
}