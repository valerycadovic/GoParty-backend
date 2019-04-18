using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class ContactsTableConfiguration : BaseTableConfiguration<ContactEntity, Guid>
    {
        public ContactsTableConfiguration() : base("Contacts")
        {
            Property(e => e.Value).IsRequired(); 
        }
    }
}
