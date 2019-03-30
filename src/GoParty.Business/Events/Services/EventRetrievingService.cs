using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GoParty.Business.Contract.Events.Models;
using GoParty.Business.Contract.Events.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Events.Services
{
    public class EventRetrievingService : IEventRetrievingService
    {
        private readonly IEventRepository _eventRepository;

        public EventRetrievingService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            IEnumerable<EventEntity> events = await _eventRepository.GetAllAsync();

            return events.Select(Mapper.Map<EventEntity, Event>).ToList();
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            EventEntity result = await _eventRepository.GetByIdAsync(id);

            return Mapper.Map<EventEntity, Event>(result);
        }
    }
}
