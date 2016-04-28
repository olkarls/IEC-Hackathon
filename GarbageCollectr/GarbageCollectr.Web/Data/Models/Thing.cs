namespace GarbageCollectr.Web.Data.Models
{
    using System;

    public class Thing : Entity
    {
        public string TagName { get; set; }

        public Guid MaterialId { get; set; }
    }
}
