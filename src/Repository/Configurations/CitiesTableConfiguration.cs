using System.ComponentModel.DataAnnotations.Schema;
using Repository.Configurations.Base;
using Repository.Contract.Entities;

namespace Repository.Configurations
{
    public class CitiesTableConfiguration : WithNameTableConfiguration<CityEntity, int>
    {
        public CitiesTableConfiguration() : base("Cities")
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}