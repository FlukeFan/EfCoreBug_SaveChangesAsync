using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SaveChangesAsyncTests
{
    public class DemoContext : DbContext
    {
        private static bool _created;

        public DemoContext()
        {
            if (!_created)
                lock (typeof(DemoContext))
                    if (!_created)
                    {
                        Database.EnsureDeleted();
                        Database.EnsureCreated();
                        _created = true;
                    }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var cn = new SqlConnectionStringBuilder
            {
                ConnectionString = "Server=.;Database=AsyncDemo;Trusted_Connection=True",
                ConnectTimeout = 5, // so tests fail quicker
                MaxPoolSize = 30,
            }.ConnectionString;

            optionsBuilder.UseSqlServer(cn, o => o.CommandTimeout(5));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // turn off cascading deletes
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<EntityA> AEntities { get; set; }
        public DbSet<EntityB> BEntities { get; set; }
    }

}
