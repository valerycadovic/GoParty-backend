using System;
using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class EventEntity : IWithNameEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime StartTime { get; set; }

        public virtual UserEntity CreatedBy { get; set; }

        public virtual UserEntity ModifiedBy { get; set; }

        public virtual ICollection<EventSubscriberEntity> EventSubscribers { get; set; }

        public virtual CityEntity City { get; set; }

        public virtual EventStatusEntity Status { get; set; }

        public virtual ICollection<TagEntity> Tags { get; set; }
        
        public virtual ImageEntity Image { get; set; }
    }
}
