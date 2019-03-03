using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class Country : IWithNameEntity<short>
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
