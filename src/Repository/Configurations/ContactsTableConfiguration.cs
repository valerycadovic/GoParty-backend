using System;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class ContactsTableConfiguration : BaseTableConfiguration<Contact, Guid>
    {
        public ContactsTableConfiguration() : base("Contacts")
        {
            HasRequired(e => e.ContactType).WithMany(e => e.Contacts);
            Property(e => e.Value).IsRequired();
        }
    }
}
