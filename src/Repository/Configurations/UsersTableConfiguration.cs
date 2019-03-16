using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Repository.Entities;

namespace Repository.Configurations
{
    public class UsersTableConfiguration : EntityTypeConfiguration<User>
    {
        public UsersTableConfiguration()
        {
            ToTable("Users");
            HasKey(e => e.Login);
            Property(e => e.Login).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(e => e.Password).IsRequired();
            HasMany(e => e.Contacts).WithRequired(e => e.User);
            HasRequired(e => e.City).WithMany(e => e.Users);
            HasMany(e => e.Roles).WithMany(e => e.Users);
            HasOptional(e => e.Image).WithOptionalDependent();
        }
    }
}
