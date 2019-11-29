using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class PermissionsTableConfiguration : WithUniqueNameTableConfiguration<PermissionEntity, int>
    {
        public PermissionsTableConfiguration() : base("Permissions")
        {
        }
    }
}
