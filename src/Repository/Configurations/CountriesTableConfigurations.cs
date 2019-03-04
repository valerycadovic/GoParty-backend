using System.ComponentModel.DataAnnotations.Schema;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class CountriesTableConfigurations : WithNameTableConfiguration<Country, short>
    {
        public CountriesTableConfigurations() : base("Countries")
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(e => e.Id).HasColumnType("SMALLINT");
            HasMany(e => e.Regions).WithRequired(e => e.Country);
        }
    }
}
