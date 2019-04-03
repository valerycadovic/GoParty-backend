using System.Threading.Tasks;
using GoParty.Business.Contract.Events.Models;

namespace GoParty.Business.Contract.Events.Services
{
    public interface IEventModifyingService
    {
        Task<Event> AddAsync(EventModifying @event);

        Task<Event> EditAsync(EventModifying @event);
    }
}
