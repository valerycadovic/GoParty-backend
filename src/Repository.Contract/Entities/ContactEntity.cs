using System;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class ContactEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public int ContactType { get; set; }

        public virtual UserEntity User { get; set; }
    }
}
