using System.Collections.Generic;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Events.Models
{
    public class EventWithSubscribers
    {
        public Event Event { get; set; }

        public List<ShortUser> Subscribers { get; set; }
    }
}
