using System.ComponentModel.DataAnnotations.Schema;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class RegionsTableConfiguration : WithNameTableConfiguration<Region, int>
    {
        public RegionsTableConfiguration() : base("Regions")
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasMany(e => e.Cities).WithRequired(e => e.Region);
        }
    }
}
