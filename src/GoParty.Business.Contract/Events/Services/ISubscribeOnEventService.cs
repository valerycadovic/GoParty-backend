using System;
using System.Threading.Tasks;

namespace GoParty.Business.Contract.Events.Services
{
    public interface ISubscribeOnEventService
    {
        Task Subscribe(Guid userId, Guid eventId);

        Task Unsubscribe(Guid userId, Guid eventId);
    }
}
