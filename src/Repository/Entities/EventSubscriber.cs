using System;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class EventSubscriber : IEntity<Guid>
    {
        public Guid Id { get; set; }

        public virtual User Subscriber { get; set; }

        public virtual Event Event { get; set; }
    }
}
