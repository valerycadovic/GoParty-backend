using System.ComponentModel.DataAnnotations.Schema;
using Repository.Configurations.Base;
using Repository.Entities;

namespace Repository.Configurations
{
    public class CitiesTableConfiguration : WithNameTableConfiguration<City, int>
    {
        public CitiesTableConfiguration() : base("Cities")
        {
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}