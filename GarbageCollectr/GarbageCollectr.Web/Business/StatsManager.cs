namespace GarbageCollectr.Web.Business
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    using GarbageCollectr.Web.Data;

    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Metadata.Internal;

    public class StatsManager
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StatsManager(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IEnumerable<object> GetStatsForPostalCode(string postalCode)
        {
            // var sql = "select PostalCode, WasteType, CollectedAt, SUM(Weight) as TotalWeight from GarbageCollection where PostalCode = 'p0' group by PostalCode, WasteType, CollectedAt order by CollectedAt desc, WasteType";
            // var stats = this.applicationDbContext.Database.ExecuteSqlCommand(sql, postalCode);

            var results = this.applicationDbContext.GarbageCollections
                .Where(x => x.PostalCode == postalCode)
                .OrderByDescending(x => x.CollectedAt).ThenBy(x => x.WasteType)
                .GroupBy(x => new { x.PostalCode, x.CollectedAt, x.WasteType })
                .Select(cl => new
                {
                    PostalCode = cl.Key.PostalCode,
                    TotalWeight = cl.Sum(x => x.Weight),
                    CollectedAt = cl.Key.CollectedAt,
                    WasteType = cl.Key.WasteType
                });

            return results;                                      
        }
    }
}
