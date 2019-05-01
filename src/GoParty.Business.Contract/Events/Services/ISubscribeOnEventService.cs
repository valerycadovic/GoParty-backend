using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Events.Services
{
    public interface ISubscribeOnEventService
    {
        Task Subscribe(Guid userId, Guid eventId);

        Task Unsubscribe(Guid userId, Guid eventId);

        Task<List<User>> GetSubscribers(Guid eventId);
    }
}
