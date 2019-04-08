using System;
using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class UserEntity : IWithNameEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Image { get; set; }

        public virtual CityEntity City { get; set; }

        public virtual ICollection<EventEntity> EventsCreatedBy { get; set; }

        public virtual ICollection<EventEntity> EventsModifiedBy { get; set; }

        public virtual ICollection<EventSubscriberEntity> EventsSubscribed { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }

        public virtual ICollection<ContactEntity> Contacts { get; set; }
    }
}
