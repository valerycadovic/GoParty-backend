using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class PermissionsTableConfiguration : WithNameTableConfiguration<Permission, int>
    {
        public PermissionsTableConfiguration() : base("Permissions")
        {
        }
    }
}
