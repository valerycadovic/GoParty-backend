using GoParty.Business.Contract.Geography.Models;

namespace GoParty.Business.Contract.Users.Models
{
    public class ShortUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string AvatarPath { get; set; }
    }
}
