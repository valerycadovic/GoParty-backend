using System.Data.Entity;
using Repository.Contract.Entities;

namespace Repository.Contexts
{
    public class GoPartyDbContext : DbContext
    {
        #region Tables

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<RegionEntity> Regions { get; set; }

        public DbSet<CountryEntity> Countries { get; set; }

        public DbSet<ContactEntity> Contacts { get; set; }

        public DbSet<EventEntity> Events { get; set; }

        public DbSet<PermissionEntity> Permissions { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ImageEntity> UserImages { get; set; }

        #endregion

        public GoPartyDbContext() : base("GoPartyDb")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<GoPartyDbContext, Migrations.Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var assembly = this.GetType().Assembly;

            modelBuilder.Configurations.AddFromAssembly(assembly);
            modelBuilder.Conventions.AddFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
