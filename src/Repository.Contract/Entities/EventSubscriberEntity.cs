using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Contract.Entities
{
    public class EventSubscriberEntity
    {
        [Key]
        [Column(Order = 0)]
        public Guid SubscriberId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid EventId { get; set; }

        [ForeignKey(nameof(SubscriberId))]
        public virtual UserEntity Subscriber { get; set; }

        [ForeignKey(nameof(EventId))]
        public virtual EventEntity Event { get; set; }
    }
}
