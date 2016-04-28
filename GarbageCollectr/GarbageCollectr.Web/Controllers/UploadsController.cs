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
    public class UploadsController : Controller
    {
        private ApplicationDbContext DbContext;

        public UploadsController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create(IFormFile file)
        {
            if (file.Length > 0)
            {
                var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                var filename = Guid.NewGuid() + parsedContentDisposition.FileName;

                var container = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=garbagecollectrstorage;AccountKey=wrhFgNhmUkCl+VtrIAxsGbgR5Gjl6+MgqIqCsiIfACkzB/4x5TFhojt9U4W4bEazRS61oS++jM7CF++L25COww==").CreateCloudBlobClient().GetContainerReference("Images");
                container.CreateIfNotExists();
                
                var blockBlob = container.GetBlockBlobReference(filename);

                using (var fileStream = file.OpenReadStream())
                {
                    blockBlob.UploadFromStream(fileStream);
                }

                var result = CognitiveServicesCaller.AnalyzeImage(filename, "96595dcf7af241c6a97da31fab5919ec");

                return new JsonResult(result);
            }

            return new BadRequestResult();
        }
    }
}
