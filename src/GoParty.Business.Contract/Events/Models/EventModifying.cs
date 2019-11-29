using System;
using System.Collections.Generic;
using GoParty.Business.Contract.Geography.Models;

namespace GoParty.Business.Contract.Events.Models
{
    public class EventModifying
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public Location Location { get; set; }

        public DateTime StartTime { get; set; }

        public Guid CreatedById { get; set; }

        public List<Tag> Tags { get; set; }

        public string Image { get; set; }
    }
}
