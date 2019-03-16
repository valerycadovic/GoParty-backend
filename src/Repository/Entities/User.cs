using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class User : IWithName
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual City City { get; set; }

        public virtual UserImage Image { get; set; }

        public virtual ICollection<Event> EventsCreatedBy { get; set; }

        public virtual ICollection<Event> EventsModifiedBy { get; set; }

        public virtual ICollection<EventSubscriber> EventsSubscribed { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
