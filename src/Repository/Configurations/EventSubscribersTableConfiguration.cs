using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class EventSubscribersTableConfiguration : BaseTableConfiguration<EventSubscriberEntity, Guid>
    {
        public EventSubscribersTableConfiguration() : base("EventSubscribers")
        {
            HasRequired(e => e.Event).WithMany(e => e.EventSubscribers).WillCascadeOnDelete(false);
            HasRequired(e => e.Subscriber).WithMany(e => e.EventsSubscribed).WillCascadeOnDelete(false);
        }
    }
}
