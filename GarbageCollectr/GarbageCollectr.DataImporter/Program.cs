namespace GarbageCollectr.DataImporter
{
    using System;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var rows = File.ReadAllLines(@"C:\Users\Ola_Kar\Downloads\avfallstomningar0.csv");

            var row = from r in rows
                      select (r.Split(',')).ToArray();



            Console.WriteLine(row.FirstOrDefault().ElementAt(0));
            Console.ReadLine();

            // Löpnummer; Tömningsdatum; Fordonskod; Avtalskod; Avfallstyp; Händelsetyp; Avtalsbenämning; Registreringsnummer; Vikt; Enhet vikt; Postnummer


        }
    }
}
