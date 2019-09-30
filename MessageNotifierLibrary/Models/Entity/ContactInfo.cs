using System;
using System.Collections.Generic;

namespace MessageNotifierLibrary.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }

        public readonly Dictionary<string, string> Pattern = new Dictionary<string, string>
        {
            ["SMS"] = "'mask': '+9 999 999-99-99'",
            ["Email"] = "'alias': 'email'"
        };

        public ContactType Type { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
