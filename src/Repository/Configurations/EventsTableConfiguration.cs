using System;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class EventsTableConfiguration : WithNameTableConfiguration<Event, Guid>
    {
        public EventsTableConfiguration() : base("Events")
        {
            HasRequired(e => e.CreatedBy).WithMany(e => e.EventsCreatedBy).WillCascadeOnDelete(false);
            HasRequired(e => e.ModifiedBy).WithMany(e => e.EventsModifiedBy).WillCascadeOnDelete(false);
            HasRequired(e => e.Status).WithMany(e => e.Events);
            HasRequired(e => e.City).WithMany(e => e.Events);
            HasRequired(e => e.Image).WithRequiredPrincipal();
            HasMany(e => e.Tags).WithMany(e => e.Events);
            Property(e => e.Address).IsRequired();
            Property(e => e.Description).IsRequired();
        }
    }
}
