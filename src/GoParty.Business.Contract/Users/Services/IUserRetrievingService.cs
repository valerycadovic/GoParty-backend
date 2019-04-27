using System;
using System.Threading.Tasks;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Users.Services
{
    public interface IUserRetrievingService
    {
        Task<User> GetById(Guid id);

        Task<ShortUser> GetShortById(Guid id);

        Task<User> GetByUserName(string userName);
    }
}
