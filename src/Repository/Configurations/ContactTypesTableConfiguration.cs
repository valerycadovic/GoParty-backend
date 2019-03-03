using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class ContactTypesTableConfiguration : WithNameTableConfiguration<ContactType, int>
    {
        public ContactTypesTableConfiguration() : base("ContactTypes")
        {
        }
    }
}
