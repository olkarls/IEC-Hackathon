namespace GarbageCollectr.DataImporter
{
    using System;

    using GarbageCollectr.DataImporter.Data;

    using LINQtoCSV;

    class Program
    {
        static void Main(string[] args)
        {
            var inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = true
            };

            var cc = new CsvContext();
            var collections = cc.Read<Collection>(@"C:\Users\Ola_Kar\Downloads\avfallstomningar0.csv", inputFileDescription);

            using (var db = new ApplicationDbContext())
            {
                foreach (var collection in collections)
                {
                    if (collection.Weight > 0)
                    {
                        db.GarbageCollections.Add(new GarbageCollection
                        {
                            Id = Guid.NewGuid(),
                            PostalCode = collection.PostalCode,
                            WasteType = collection.WasteType,
                            Weight = collection.Weight,
                            CollectedAt = collection.CollectedAt,
                            AgreementCode = collection.AgreementCode,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now
                        });

                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
