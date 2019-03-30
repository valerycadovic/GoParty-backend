using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class RolesTableConfiguration : WithNameTableConfiguration<RoleEntity, int>
    {
        public RolesTableConfiguration() : base("Roles")
        {
            HasMany(e => e.Permissions).WithMany(e => e.Roles);
            Property(p => p.Name)
                .HasColumnAnnotation("Index", new IndexAnnotation(new[] {
                        new IndexAttribute("Index") { IsUnique = true }
                    }
                ))
                .HasMaxLength(50);
        }
    }
}
