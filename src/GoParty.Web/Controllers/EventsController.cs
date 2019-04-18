using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        //[Authorize]
        public async Task<List<Event>> GetAll()
        {
            var (start, count) = ParseGetAllHeaders(Request.Headers);

            // GOPARTY-1: replace with CurrentUser.CityId
            const int minskId = 0;

            return await EventRetrievingService.GetBatchSortedByLocation(minskId, start, count);
        }

        [HttpPost]
        //[Authorize]
        public async Task<Event> AddEvent([FromBody] EventModifying e)
        {
            Event result = await EventModifyingService.AddAsync(e);

            return result;
        }

        private (int start, int? count) ParseGetAllHeaders(HttpRequestHeaders headers)
        {
            string startValue = headers.GetValues("start").FirstOrDefault() ?? "0";
            string countValue = headers.GetValues("count").FirstOrDefault();

            return (ParseHeaderValue(startValue), countValue != null ? ParseHeaderValue(countValue) : (int?)null);
        }

        private int ParseHeaderValue(string headerValue)
        {
            if (!int.TryParse(headerValue, out int result))
            {
                throw new ArgumentException($"start header has invalid format {headerValue}");
            }

            return result;
        }
    }
}