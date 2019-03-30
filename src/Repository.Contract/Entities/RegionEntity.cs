using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class RegionEntity : IWithNameEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual CountryEntity Country { get; set; }

        public virtual ICollection<CityEntity> Cities { get; set; }
    }
}
