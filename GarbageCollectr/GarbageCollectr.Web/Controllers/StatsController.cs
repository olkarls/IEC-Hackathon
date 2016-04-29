namespace GarbageCollectr.Web.Controllers
{
    using GarbageCollectr.Web.Business;
    using GarbageCollectr.Web.Data;

    using Microsoft.AspNet.Mvc;

    [Route("/stats")]
    public class StatsController
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StatsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(string postalCode)
        {
            var manager = new StatsManager(this.applicationDbContext);

            var stats = manager.GetStatsForPostalCode(postalCode);

            return new JsonResult(stats);
        }
    }
}
