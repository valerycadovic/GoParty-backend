using System.Data.Entity.ModelConfiguration;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class EventSubscribersTableConfiguration : EntityTypeConfiguration<EventSubscriberEntity>
    {
        public EventSubscribersTableConfiguration()
        {
            HasRequired(e => e.Event).WithMany(e => e.EventSubscribers).WillCascadeOnDelete(false);
            HasRequired(e => e.Subscriber).WithMany(e => e.EventsSubscribed).WillCascadeOnDelete(false);
        }
    }
}
