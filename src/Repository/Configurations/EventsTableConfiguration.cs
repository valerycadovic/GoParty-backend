using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class EventsTableConfiguration : WithNameTableConfiguration<EventEntity, Guid>
    {
        public EventsTableConfiguration() : base("Events")
        {
            HasRequired(e => e.CreatedBy).WithMany(e => e.EventsCreatedBy).WillCascadeOnDelete(false);
            HasRequired(e => e.ModifiedBy).WithMany(e => e.EventsModifiedBy).WillCascadeOnDelete(false);
            HasRequired(e => e.City).WithMany(e => e.Events);
            HasOptional(e => e.Image).WithOptionalDependent();
            HasMany(e => e.Tags).WithMany(e => e.Events);
            Property(e => e.Address).IsRequired();
            Property(e => e.Description).IsRequired();
        }
    }
}
