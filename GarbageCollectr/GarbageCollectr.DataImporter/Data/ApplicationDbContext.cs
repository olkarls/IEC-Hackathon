namespace GarbageCollectr.DataImporter.Data
{
    using Microsoft.Data.Entity;
    public class ApplicationDbContext : DbContext
    {
        public DbSet<GarbageCollection> GarbageCollections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:garbagecollectr.database.windows.net,1433;Database=GarbageCollectr;User ID=GCadmin@garbagecollectr;Password=Rrwa_?LGSFyR$7YB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
