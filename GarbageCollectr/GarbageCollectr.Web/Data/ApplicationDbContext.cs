namespace GarbageCollectr.Web.Data
{
    using GarbageCollectr.Web.Data.Models;

    using Microsoft.Data.Entity;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Thing> Things { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Container> Containers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
