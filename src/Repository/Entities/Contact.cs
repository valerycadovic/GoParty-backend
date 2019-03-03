using System;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class Contact : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public virtual User User { get; set; }

        public virtual ContactType ContactType { get; set; }
    }
}
