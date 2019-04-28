using System.Threading.Tasks;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Users.Services
{
    public interface IUserModifyingService
    {
        Task<User> UpdateAsync(User user);
    }
}
