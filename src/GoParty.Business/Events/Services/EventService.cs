using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Events.Models;
using GoParty.Business.Contract.Events.Services;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.Geography.Services;
using GoParty.Business.Core.Extensions;
using GoParty.Business.Events.Models;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Events.Services
{
    public class EventService : IEventRetrievingService, IEventModifyingService
    {
        #region Dependencies

        private readonly IEventRepository _eventRepository;

        private readonly ILocationRetrievingService _locationRetrievingService;

        private readonly ICityRepository _cityRepository;

        private readonly IUserRepository _userRepository;

        public EventService(
            IEventRepository eventRepository,
            IUserRepository userRepository,
            ICityRepository cityRepository,
            ILocationRetrievingService locationRetrievingService)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _locationRetrievingService = locationRetrievingService;
        }

        #endregion

        public async Task<Event> GetByIdAsync(Guid id)
        {
            EventEntity eventEntity = await _eventRepository.GetByIdAsync(id);

            return Mapper.Map<EventEntity, Event>(eventEntity);
        }

        public async Task<List<Event>> GetBatchSortedByLocation(
            int cityId, int startIndex = 0, int? count = null)
        {
            Location location = await _locationRetrievingService.GetById(cityId);
            var sortedEvents = GetAllSortedByLocation(location);

            var result = sortedEvents;

            if (count != null)
            {
                result = sortedEvents.Batch(startIndex, count.Value);
            }

            var events = await result.ToListAsync();
            var quantities = await GetSubscribersCounts(result).ToListAsync();
            
            var eventWithQuantities = events.Zip(quantities, (e, q) => new EventWithQuantity
            {
                Event = e,
                QuantitySubscribed = q
            });

            return eventWithQuantities.Select(Mapper.Map<EventWithQuantity, Event>).ToList();
        }

        private IQueryable<int> GetSubscribersCounts(IQueryable<EventEntity> eventEntities)
        {
            return eventEntities.Select(n => n.EventSubscribers.Count);
        }

        private IQueryable<EventEntity> GetAllSortedByLocation(Location location)
        {
            var events = _eventRepository.GetAll();

            var cityEvents = events
                .Where(e => e.City.Id == location.City.Id);

            var otherRgionEvents = events
                .Where(e => e.City.Region.Id == location.Region.Id)
                .Except(cityEvents);

            var regionEvents = cityEvents.Concat(otherRgionEvents);

            var otherCountryEvents = events
                .Where(e => e.City.Region.Country.Id == location.Country.Id)
                .Except(regionEvents);  

            var otherEvents = events
                .Except(otherCountryEvents.Concat(regionEvents));

            return regionEvents.Concat(otherCountryEvents).Concat(otherEvents);
        }

        public async Task<Event> AddAsync(EventModifying @event)
        {
            UserEntity user = await _userRepository.GetByIdAsync(@event.CreatedById);
            CityEntity city = await _cityRepository.GetByIdAsync(@event.Location.City.Id);

            EventEntity eventEntity = Mapper.Map<EventModifying, EventEntity>(@event);

            eventEntity.Status = EventStatus.Pending;
            eventEntity.City = city;
            eventEntity.CreatedBy = user;
            eventEntity.ModifiedBy = user;

            EventEntity result = _eventRepository.Add(eventEntity);

            await _eventRepository.CommitAsync();

            return Mapper.Map<EventEntity, Event>(result);
        }

        public async Task<Event> EditAsync(EventModifying @event)
        {
            throw new NotImplementedException();
        }
    }
}
