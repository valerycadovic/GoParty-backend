using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Users.Services
{
    public interface IUserRetrievingService
    {
        Task<User> GetByName(string name);

        Task<User> GetShortByName(string name);
    }
}
