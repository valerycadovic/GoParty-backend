﻿using System.Collections.Generic;
using Repository.Entities.Contract;

namespace Repository.Entities
{
    public class Region : IWithNameEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
