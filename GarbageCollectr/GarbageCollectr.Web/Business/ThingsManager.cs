using System.Collections.Generic;
using System.Linq;
using GarbageCollectr.Web.Data;
using GarbageCollectr.Web.Data.Models;
using Microsoft.Data.Entity;

namespace GarbageCollectr.Web.Business
{
    public class ThingsManager
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ThingsManager(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }

        public Thing[] GetThingFromTags(CognitiveServicesCaller.Tag[] tags)
        {
            tags = tags.OrderBy(t => t.Confidence).ToArray();
            foreach (var tag in tags)
            {

                var dbThings = _applicationDbContext.Things.Include(t => t.Material.Container).Where(t => t.TagName == tag.Name);
                if (dbThings.Any())
                {
                    return dbThings.ToArray();
                }
            }

            return new List<Thing>().ToArray();
        }
    }
}
