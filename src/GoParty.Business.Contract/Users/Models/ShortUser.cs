using System;

namespace GoParty.Business.Contract.Users.Models
{
    public class ShortUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }
    }
}
