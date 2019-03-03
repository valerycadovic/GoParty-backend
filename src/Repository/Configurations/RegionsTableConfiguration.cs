using System.Data.Entity.ModelConfiguration;
using Repository.Entities;

namespace Repository.Configurations
{
    public class RegionsTableConfiguration : EntityTypeConfiguration<Region>
    {
        public RegionsTableConfiguration()
        {
            ToTable("Regions").HasKey(e => e.Id);
            HasMany(e => e.Cities).WithRequired(e => e.Region);
        }
    }
}
