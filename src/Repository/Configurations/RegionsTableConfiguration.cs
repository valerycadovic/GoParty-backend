using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class RegionsTableConfiguration : WithNameTableConfiguration<Region, int>
    {
        public RegionsTableConfiguration() : base("Regions")
        {
            HasMany(e => e.Cities).WithRequired(e => e.Region);
        }
    }
}
