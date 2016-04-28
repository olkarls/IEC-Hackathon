using System;
using GarbageCollectr.Web.Business;
using Xunit;

namespace GarbageCollectr.UnitTests2
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {

        [Fact]
        public void UniTest1()
        {
            var result = CognitiveServicesCaller.AnalyzeImage("http://dreamatico.com/data_images/girl/girl-8.jpg",
                "96595dcf7af241c6a97da31fab5919ec");

            Assert.NotNull(result);
            Assert.NotNull(result.Tags[0]);
            Console.WriteLine(result.Tags[0]);
        }
    }
}
