namespace Ssjw.EAutoService.CarsDataUSvc.Tests
{

    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using System.Reflection;

    [TestClass]
    public class RestClientTests
    {
        [TestMethod]
        public void GetAllCars_LoopForVolvoBrandCars_ThereAre2Founds()
        {
            CarsDataUSvcMockClient client = new CarsDataUSvcMockClient();

            List<CarDto> cars = client.GetAllCars();
            int actual = 0;
            foreach (CarDto car in cars)
            {
                if (car.brand.ToLower() == "volvo") {
                    actual++;
                }
            }
            int expected = 2;

            Assert.AreEqual(expected, actual, "Volvo Cars found count should be {0} and not {1}", expected, actual);
        }

        [TestMethod]
        public void AddingCar_CheckIfCarWithAddedVinNumberIsFound_CheckIfItIsSkoda()
        {
            CarsDataUSvcMockClient client = new CarsDataUSvcMockClient();
            client.AddCar(new CarDto() { vin = "1414", model="Superb", brand="Skoda", productionYear = new DateTime(2002,12,12),
                insurenceNumber = "124314", servicesHistory = new List<string>() });

            CarDto carFound = client.GetCarByVin("1414");
            
            string actualBrand = carFound.brand;

            string expectedBrand = "Skoda";

            Assert.AreEqual(expectedBrand, actualBrand, "Brand  {0} should be found and not {1}", expectedBrand, actualBrand);
        }
    }
}