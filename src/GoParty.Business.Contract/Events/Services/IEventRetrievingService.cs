using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.Events.Models;

namespace GoParty.Business.Contract.Events.Services
{
    public interface IEventRetrievingService
    {
        Task<List<Event>> GetAllAsync();

        Task<Event> GetByIdAsync(Guid id);
    }
}
