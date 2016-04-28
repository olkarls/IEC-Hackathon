using System.Collections.Generic;
using System.Linq;
using GarbageCollectr.Web.Data;
using GarbageCollectr.Web.Data.Models;

namespace GarbageCollectr.Web.Business
{
    public class ThingsManager
    {
        public Thing[] GetThingFromTags(ApplicationDbContext appDbContext, CognitiveServicesCaller.Tag[] tags)
        {
            tags = tags.OrderBy(t => t.Confidence).ToArray();
            foreach (var tag in tags)
            {

                var dbThings = appDbContext.Things.Where(t => t.TagName == tag.Name);
                if (dbThings.Any())
                {
                    return dbThings.ToArray();
                }
            }

            return new List<Thing>().ToArray();
        }
    }
}
