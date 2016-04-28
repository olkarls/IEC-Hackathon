namespace GarbageCollectr.DataImporter.Data
{
    using System;

    public class GarbageCollection
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CollectedAt { get; set; }

        public string WasteType { get; set; }

        public int Weight { get; set; }

        public string PostalCode { get; set; }

        public string AgreementCode { get; set; }
    }
}
