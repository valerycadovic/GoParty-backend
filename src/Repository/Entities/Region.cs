using System.Collections.Generic;

namespace Repository.Entities
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
