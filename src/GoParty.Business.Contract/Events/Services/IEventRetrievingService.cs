using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoParty.Business.Contract.Events.Models;

namespace GoParty.Business.Contract.Events.Services
{
    public interface IEventRetrievingService
    {
        Task<List<Event>> GetBatchSortedByLocation(
            int cityId, int startIndex = 0, int? count = null);

        Task<Event> GetByIdAsync(Guid id);
    }
}
