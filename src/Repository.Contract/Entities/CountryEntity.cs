using System.Collections.Generic;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class CountryEntity : IWithNameEntity<short>
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }

        public virtual ICollection<RegionEntity> Regions { get; set; }
    }
}
