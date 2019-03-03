using System;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class EventImage : IWithNameEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
