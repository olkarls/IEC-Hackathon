namespace GarbageCollectr.DataImporter
{
    using System;

    using LINQtoCSV;

    class Collection
    {
        [CsvColumn(Name = "Löpnummer", FieldIndex = 0)]
        public string Number { get; set; }

        [CsvColumn(Name = "Tömningsdatum", FieldIndex = 1, OutputFormat = "dd MMMM yyyy")]
        public DateTime CollectedAt { get; set; }

        [CsvColumn(Name = "Fordonskod", FieldIndex = 2)]
        public string VehicleCode { get; set; }

        [CsvColumn(Name = "Avtalskod", FieldIndex = 3)]
        public string AgreementCode { get; set; }

        [CsvColumn(Name = "Avfallstyp", FieldIndex = 4)]
        public string WasteType { get; set; }

        [CsvColumn(Name = "Händelsetyp", FieldIndex = 5)]
        public string Event { get; set; }

        [CsvColumn(Name = "Avtalsbenämning", FieldIndex = 6)]
        public string Description { get; set; }

        [CsvColumn(Name = "Registreringsnummer", FieldIndex = 7)]
        public string RegistrationNumber { get; set; }

        [CsvColumn(Name = "Vikt", FieldIndex = 8)]
        public int Weight { get; set; }

        [CsvColumn(Name = "Enhet vikt", FieldIndex = 9)]
        public string Unit { get; set; }

        [CsvColumn(Name = "Postnummer", FieldIndex = 10)]
        public string PostalCode { get; set; }
    }

    // Löpnummer; Tömningsdatum; Fordonskod; Avtalskod; Avfallstyp; Händelsetyp; Avtalsbenämning; Registreringsnummer; Vikt; Enhet vikt; Postnummer
}
