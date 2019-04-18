using Repository.Contract.Entities;

namespace GoParty.Business.Events.Models
{
    public class EventWithQuantity
    {
        public EventEntity Event { get; set; }

        public int QuantitySubscribed { get; set; }
    }
}
