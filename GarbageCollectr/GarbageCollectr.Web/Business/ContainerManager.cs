using System;
using System.Linq;
using GarbageCollectr.Web.Data;
using GarbageCollectr.Web.Data.Models;

namespace GarbageCollectr.Web.Business
{
    public class ContainerManager
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ContainerManager(ApplicationDbContext appDbContext)
        {
            _applicationDbContext = appDbContext;
        }

        public Container Get(Guid id)
        {
            return _applicationDbContext.Containers.SingleOrDefault(c => c.Id == id);
        }
    }
}
