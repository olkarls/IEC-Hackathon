namespace GarbageCollectr.Web.Data.Models
{
    using System;

    public class GarbageCollection : Entity
    {
        public DateTime CollectedAt { get; set; }

        public string WasteType { get; set; }

        public int Weight { get; set; }

        public string PostalCode { get; set; }

        public string AgreementCode { get; set; }
    }
}
