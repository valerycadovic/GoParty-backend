using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class EventStatusesTableConfiguration : WithNameTableConfiguration<EventStatus, int>
    {
        public EventStatusesTableConfiguration() : base("EventStatuses")
        {
        }
    }
}
