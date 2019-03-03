using System.Collections.Generic;

namespace Repository.Entities
{
    public class Country
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
