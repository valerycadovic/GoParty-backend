using System;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class UserImagesTableConfiguration : WithNameTableConfiguration<ImageEntity, Guid>
    {
        public UserImagesTableConfiguration() : base("UserImages")
        {
        }
    }
}
