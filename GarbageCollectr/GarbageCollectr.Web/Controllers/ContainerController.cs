namespace GarbageCollectr.Web.Controllers
{
    using System;

    using GarbageCollectr.Web.Business;
    using GarbageCollectr.Web.Data;
    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Net.Http.Headers;
    using Microsoft.WindowsAzure.Storage;

    [Route("/container")]
    public class ContainerController : Controller
    {
        private ApplicationDbContext DbContext;

        public ContainerController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var container = new ContainerManager(this.DbContext).Get(id);

            return new JsonResult(container);
        }
    }
}
