using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class EventStatus : IWithNameEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
