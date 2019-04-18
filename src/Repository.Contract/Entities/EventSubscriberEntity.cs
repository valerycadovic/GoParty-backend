using System;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class EventSubscriberEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public virtual UserEntity Subscriber { get; set; }

        public virtual EventEntity Event { get; set; }
    }
}
