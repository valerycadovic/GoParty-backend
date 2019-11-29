using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class CityEntity : IWithNameEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public virtual RegionEntity Region { get; set; }

        public virtual ICollection<UserEntity> Users { get; set; }

        public virtual ICollection<EventEntity> Events { get; set; }
    }
}
