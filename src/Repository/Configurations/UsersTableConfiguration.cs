using System;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class UsersTableConfiguration : WithNameTableConfiguration<User, Guid>
    {
        public UsersTableConfiguration() : base("Users")
        {
            Property(e => e.Login).IsRequired();
            Property(e => e.Password).IsRequired();
            HasMany(e => e.Contacts).WithRequired(e => e.User);
            HasRequired(e => e.City).WithMany(e => e.Users);
            HasMany(e => e.Roles).WithMany(e => e.Users);
            HasOptional(e => e.Image).WithOptionalPrincipal();
        }
    }
}
