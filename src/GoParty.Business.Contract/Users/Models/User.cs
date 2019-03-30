using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.UserContacts.Models;

namespace GoParty.Business.Contract.Users.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public Location Location { get; set; }

        public string AvatarPath { get; set; }

        public Contacts Contacts { get; set; }
    }
}
