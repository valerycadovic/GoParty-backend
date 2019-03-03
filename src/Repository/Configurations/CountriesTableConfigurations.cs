using System.Data.Entity.ModelConfiguration;
using Repository.Entities;

namespace Repository.Configurations
{
    public class CountriesTableConfigurations : EntityTypeConfiguration<Country>
    {
        public CountriesTableConfigurations()
        {
            ToTable("Countries").HasKey(e => e.Id);
            Property(e => e.Id).HasColumnType("SMALLINT");
            HasMany(e => e.Regions).WithRequired(e => e.Country);
        }
    }
}
