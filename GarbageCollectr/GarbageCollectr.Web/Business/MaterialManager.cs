using System;
using System.Linq;
using GarbageCollectr.Web.Data;
using GarbageCollectr.Web.Data.Models;
using Microsoft.Data.Entity;

namespace GarbageCollectr.Web.Business
{
    public class MaterialManager
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MaterialManager(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }

        public Material[] GetAll()
        {
            return _applicationDbContext.Materials.Include(m => m.Container).ToArray();
        }

        public void AddMaterialToThing(string thingName, Guid materialId)
        {
            var combinationExist = _applicationDbContext.Things.SingleOrDefault(t => t.TagName == thingName && t.MaterialId == materialId);

            if (combinationExist != null)
            {
                return;
            }

            var material = _applicationDbContext.Materials.Single(m => m.Id == materialId);
            var newThing = new Thing
            {
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                MaterialId = material.Id,
                TagName = thingName,
                UpdatedAt = DateTime.Now
            };

            _applicationDbContext.Things.Add(newThing);

        }
    }
}
