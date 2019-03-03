using System;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class EventImagesTableConfiguration : WithNameTableConfiguration<EventImage, Guid>
    {
        public EventImagesTableConfiguration() : base("EventImages")
        {
        }
    }
}
