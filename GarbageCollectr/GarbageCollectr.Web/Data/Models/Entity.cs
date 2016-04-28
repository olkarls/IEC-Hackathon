namespace GarbageCollectr.Web.Data.Models
{
    using System;

    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
