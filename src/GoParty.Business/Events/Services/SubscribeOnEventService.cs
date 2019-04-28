using System;
using System.Linq;
using System.Threading.Tasks;
using GoParty.Business.Contract.Core.Exceptions;
using GoParty.Business.Contract.Events.Services;
using Repository.Contract.Entities;
using Repository.Contract.Repositories;

namespace GoParty.Business.Events.Services
{
    public class SubscribeOnEventService : ISubscribeOnEventService
    {
        #region Dependencies

        private readonly IUserRepository _userRepository;

        private readonly IEventRepository _eventRepository;

        public SubscribeOnEventService(
            IUserRepository userRepository,
            IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        #endregion

        public async Task Subscribe(Guid userId, Guid eventId)
        {
            UserEntity user = await _userRepository.GetByIdAsync(userId);
            EventEntity @event = await _eventRepository.GetByIdAsync(eventId);

            EventSubscriberEntity eventSubscriber = new EventSubscriberEntity
            {
                Event = @event,
                Subscriber = user
            };

            user.EventsSubscribed.Add(eventSubscriber);

            try
            {
                await _userRepository.CommitAsync();
            }
            catch (Exception e)
            {
                throw new MessageException($"User {user.Name} is already subscribed on this event", e);
            }
        }

        public async Task Unsubscribe(Guid userId, Guid eventId)
        {
            UserEntity user = await _userRepository.GetByIdAsync(userId);

            EventSubscriberEntity eventSubscriber =
                user.EventsSubscribed.FirstOrDefault(e => e.EventId == eventId && e.SubscriberId == userId);

            if (eventSubscriber is null)
            {
                throw new MessageException($"User {user.Name} is not subscribed on this event");
            }

            user.EventsSubscribed.Remove(eventSubscriber);

            await _userRepository.CommitAsync();
        }
    }
}
