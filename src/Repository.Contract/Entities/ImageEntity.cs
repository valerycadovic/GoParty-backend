using System;
using Repository.Contract.Entities.Contract;

namespace Repository.Contract.Entities
{
    public class ImageEntity : IWithNameEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
