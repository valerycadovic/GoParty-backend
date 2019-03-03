using System.Data.Entity.ModelConfiguration;
using Repository.Entities;

namespace Repository.Configurations
{
    public class CitiesTableConfiguration : EntityTypeConfiguration<City>
    {
        public CitiesTableConfiguration()
        {
            ToTable("Cities").HasKey(e => e.Id);
        }
    }
}