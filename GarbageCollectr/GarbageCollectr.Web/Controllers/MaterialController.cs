namespace GarbageCollectr.Web.Controllers
{
    using System;

    using GarbageCollectr.Web.Business;
    using GarbageCollectr.Web.Data;
    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.Mvc;
    using Microsoft.Net.Http.Headers;
    using Microsoft.WindowsAzure.Storage;

    [Route("/uploads")]
    public class MaterialController : Controller
    {
        private ApplicationDbContext DbContext;

        public MaterialController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allMaterial = new MaterialManager(this.DbContext).GetAll();

            return new JsonResult(allMaterial);
        }

        [HttpPost]
        public IActionResult AddMaterialToThing(string thing, Guid materialId)
        {
            new MaterialManager(this.DbContext).AddMaterialToThing(thing, materialId);

            return new EmptyResult();
        }
    }
}
