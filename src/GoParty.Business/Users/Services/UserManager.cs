using Microsoft.AspNet.Identity;
using System;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Users.Services
{
    public class UserManager : UserManager<User, Guid>
    {
        public UserManager(IUserStore<User, Guid> store) : base(store)
        {
        }
    }
}
