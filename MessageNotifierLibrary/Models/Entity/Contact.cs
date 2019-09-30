using System;

namespace MessageNotifierLibrary.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }

        public string Value { get; set; }

        public virtual User User { get; set; }
    }
}