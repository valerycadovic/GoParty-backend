using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class CitiesTableConfiguration : WithNameTableConfiguration<City, int>
    {
        public CitiesTableConfiguration() : base("Cities")
        {
        }
    }
}