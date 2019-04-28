using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using GoParty.Business.Contract.Events.Models;
using GoParty.Business.Contract.Events.Services;
using GoParty.Business.Contract.Users.Models;
using GoParty.Business.Contract.Users.Services;
using Ninject;

namespace GoParty.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        #region Dependencies

        [Inject]
        public IEventRetrievingService EventRetrievingService { get; set; }

        [Inject]
        public IEventModifyingService EventModifyingService { get; set; }

        [Inject]
        public IUserRetrievingService UserRetrievingService { get; set; }

        [Inject]
        public ISubscribeOnEventService SubscribeOnEventService { get; set; }

        #endregion

        [HttpGet]
        [Route("")]
        public async Task<List<Event>> GetAll()
        {
            var (start, count) = ParseGetAllHeaders(Request.Headers);

            User currentUser = await UserRetrievingService.GetByUserName(User.Identity.Name);

            int cityId = currentUser.Location.City.Id;

            return await EventRetrievingService.GetBatchSortedByLocation(cityId, start, count);
        }

        [HttpPost]
        [Route("")]
        public async Task<Event> AddEvent([FromBody] EventModifying e)
        {
            Event result = await EventModifyingService.AddAsync(e);

            return result;
        }

        [HttpPost]
        [Route("Subscribe/{eventId:guid}")]
        public async Task SubscribeOnEvent([FromUri] Guid eventId)
        {
            User currentUser = await UserRetrievingService.GetByUserName(User.Identity.Name);

            await SubscribeOnEventService.Subscribe(currentUser.Id, eventId);
        }

        [HttpPost]
        [Route("Unsubscribe/{eventId:guid}")]
        public async Task UnsubscribeFromEvent([FromUri] Guid eventId)
        {
            User currentUser = await UserRetrievingService.GetByUserName(User.Identity.Name);

            await SubscribeOnEventService.Unsubscribe(currentUser.Id, eventId);
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
                throw new ArgumentException($"header has invalid format {headerValue}");
            }

            return result;
        }
    }
}