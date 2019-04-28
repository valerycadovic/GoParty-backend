using System;
using System.Collections.Generic;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.UserContacts.Models;

namespace GoParty.Web.Models
{
    public class ProfileModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public Location Location { get; set; }

        public string Image { get; set; }

        public List<Contact> Contacts { get; set; }

        public bool IsSelf { get; set; }
    }
}