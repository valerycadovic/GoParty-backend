using System.ComponentModel.DataAnnotations.Schema;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class RegionsTableConfiguration : WithNameTableConfiguration<RegionEntity, int>
    {
        public RegionsTableConfiguration() : base("Regions")
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasMany(e => e.Cities).WithRequired(e => e.Region);
        }
    }
}
