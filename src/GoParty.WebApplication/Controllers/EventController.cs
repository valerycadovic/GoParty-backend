using GoParty.Business.Contract.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using GoParty.Business.Contract.Events.Services;
using Ninject;

namespace GoParty.WebApplication.Controllers
{
    public class EventController : ApiController
    {
        [Inject]
        public IEventRetrievingService EventRetrievingService { get; set; }

        [HttpGet]
        public async Task<List<Event>> GetAll()
        {
            return await EventRetrievingService.GetAllAsync();
        }
    }
}
