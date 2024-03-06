namespace Ssjw.EAutoService.CarPartsDataUSvc.Tests
{
 
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;


    [TestClass]
    public class RestClientTests
    {
        [TestMethod]
        public void FindMechanicalPartByPrice_ThereAreTwoMatches()
        {
            CarPartsDataUSvcMockClient client = new CarPartsDataUSvcMockClient();
            
            int actualNumber = client.FindMechanicalPartByPrice(2.0m,50.7m).Count;

            int expectedNumber = 2;

            Assert.AreEqual( expectedNumber,actualNumber, "MechanicalParts found count should be {0} and not {1}", expectedNumber,actualNumber);

        }

        [TestMethod]
        public void GetNumberOfAvailableParts_ThereAre1000Matches()
        {
            CarPartsDataUSvcMockClient client = new CarPartsDataUSvcMockClient();

            int actualNumber = client.GetNumberOfAvailableParts("l1");

            int expectedNumber = 1000;

            Assert.AreEqual(expectedNumber, actualNumber, "MechanicalParts found count should be {0} and not {1}", expectedNumber, actualNumber);

        }

    }
}
