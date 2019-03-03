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

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventImage> EventImages { get; set; }

        public DbSet<EventStatus> EventStatuses { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserImage> UserImages { get; set; }

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
