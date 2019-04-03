using System;
using System.Collections.Generic;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.UserContacts.Models;

namespace GoParty.Business.Contract.Users.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Location Location { get; set; }

        public string Image { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
