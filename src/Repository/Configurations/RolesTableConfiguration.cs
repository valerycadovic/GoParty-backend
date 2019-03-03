using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class RolesTableConfiguration : WithNameTableConfiguration<Role, int>
    {
        public RolesTableConfiguration() : base("Roles")
        {
            HasMany(e => e.Permissions).WithMany(e => e.Roles);
        }
    }
}
