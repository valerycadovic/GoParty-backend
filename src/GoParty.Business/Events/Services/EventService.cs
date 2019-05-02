using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Core.Exceptions;
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
            var sortedEvents = await GetAllSortedByLocationAsync(location);

            if (count != null)
            {
                sortedEvents = sortedEvents.Batch(startIndex, count.Value).ToList();
            }

            IEnumerable<EventWithQuantity> eventWithQuantities = sortedEvents.Zip(
                sortedEvents.Select(e => e.EventSubscribers.Count),
                (e, q) => new EventWithQuantity
                {
                    Event = e,
                    QuantitySubscribed = q
                });

            return eventWithQuantities.Select(Mapper.Map<EventWithQuantity, Event>).ToList();
        }

        public async Task<Event> AddAsync(EventModifying @event)
        {
            try
            {
                EventEntity eventEntity = Mapper.Map<EventModifying, EventEntity>(@event);
                eventEntity.Status = EventStatus.Pending;
                UserEntity user = Mapper.Map<Guid, UserEntity>(@event.CreatedBy);

                eventEntity.ModifiedBy = user;
                eventEntity.CreatedBy = user;

                EventEntity result = _eventRepository.Add(eventEntity);

                await _eventRepository.CommitAsync();

                return Mapper.Map<EventEntity, Event>(result);
            }
            catch (InvalidOperationException exception)
            {
                throw new MessageException("Error while adding event", exception);
            }
        }

        private async Task<List<EventEntity>> GetAllSortedByLocationAsync(Location location)
        {
            var events = await _eventRepository.GetAll().ToListAsync();

            var cityEvents = events
                .Where(e => e.City.Id == location.City.Id)
                .OrderByDescending(e => e.EventSubscribers.Count)
                .ToList();

            var otherRgionEvents = events
                .Where(e => e.City.Region.Id == location.Region.Id)
                .Except(cityEvents)
                .OrderByDescending(e => e.EventSubscribers.Count)
                .ToList();

            var regionEvents = cityEvents.Concat(otherRgionEvents).ToList();

            var otherCountryEvents = events
                .Where(e => e.City.Region.Country.Id == location.Country.Id)
                .Except(regionEvents)
                .OrderByDescending(e => e.EventSubscribers.Count)
                .ToList();

            var otherEvents = events
                .Except(otherCountryEvents.Concat(regionEvents))
                .OrderByDescending(e => e.EventSubscribers.Count)
                .ToList();

            return regionEvents.Concat(otherCountryEvents).Concat(otherEvents).ToList();
        }
    }
}
