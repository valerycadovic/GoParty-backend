using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class ContactType : IWithNameEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
