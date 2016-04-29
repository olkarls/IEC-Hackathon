namespace GarbageCollectr.Web.Business
{
    using System;

    public class Statistic
    {
        public string PostalCode { get; set; }

        public string WasteType { get; set; }

        public int TotalWeight { get; set; }

        public DateTime CollectedAt { get; set; }
    }
}