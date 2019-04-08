using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using GoParty.Business.Contract.Events.Models;
using GoParty.Business.Contract.Events.Services;
using Ninject;

namespace GoParty.Web.Controllers
{
    public class EventsController : ApiController
    {
        [Inject]
        public IEventRetrievingService EventRetrievingService { get; set; }

        [Inject]
        public IEventModifyingService EventModifyingService { get; set; }

        [HttpGet]
        public async Task<List<Event>> GetAll()
        {
            return await EventRetrievingService.GetBatchSortedByLocation(0);
        }

        [HttpPost]
        public async Task<Event> AddEvent([FromBody] EventModifying e)
        {
            Event result = await EventModifyingService.AddAsync(e);

            return result;
        }
    }
}