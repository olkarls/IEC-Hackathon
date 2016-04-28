namespace GarbageCollectr.Web.Data.Models
{
    using System;

    public class Material : Entity
    {
        public string Name { get; set; }

        public Guid ContainerId { get; set; }

        public Container Container { get; set; }
    }
}
