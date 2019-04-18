using System;
using System.Collections.Generic;
using GoParty.Business.Contract.Geography.Models;
using GoParty.Business.Contract.Users.Models;

namespace GoParty.Business.Contract.Events.Models
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Location Location { get; set; }

        public DateTime StartTime { get; set; }

        public ShortUser CreatedBy { get; set; }

        public List<Tag> Tags { get; set; }

        public string Image { get; set; }

        public int QuantityJoined { get; set; }
    }
}
