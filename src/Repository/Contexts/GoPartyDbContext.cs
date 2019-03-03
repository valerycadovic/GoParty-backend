using System.Data.Entity;
using Repository.Entities;

namespace Repository.Contexts
{
    public class GoPartyDbContext : DbContext
    {
        #region Tables

        public DbSet<City> Cities { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }

        #endregion

        public GoPartyDbContext() : base("GoPartyDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var assembly = this.GetType().Assembly;

            modelBuilder.Configurations.AddFromAssembly(assembly);
            modelBuilder.Conventions.AddFromAssembly(assembly);
        }
    }
}
