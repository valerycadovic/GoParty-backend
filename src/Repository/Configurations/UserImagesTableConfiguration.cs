using System;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class UserImagesTableConfiguration : WithNameTableConfiguration<UserImage, Guid>
    {
        public UserImagesTableConfiguration() : base("UserImages")
        {
        }
    }
}
