using System;
using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class Event : IWithNameEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime StartTime { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<EventSubscriber> EventSubscribers { get; set; }

        public virtual City City { get; set; }

        public virtual EventStatus Status { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual EventImage Image { get; set; }
    }
}
