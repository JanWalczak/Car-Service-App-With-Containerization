namespace Ssjw.EAutoService.CarsDataUSvc.ConsoleApp
{
    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;

    public class ConsoleApp
    {
        private static void printCars(List<CarDto> list)
        {
            if (list != null)
            {
                foreach (CarDto car in list)
                {
                    Console.WriteLine(car.vin + " : " + car.brand + " : " + car.model + " : " + car.productionYear + " : " + car.insurenceNumber);
                    if (car.servicesHistory != null && car.servicesHistory.Count != 0)
                    {
                        foreach (var service in car.servicesHistory)
                        {
                            Console.WriteLine(service.ToString());
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private static void printCar(CarDto car)
        {
            Console.WriteLine(car.vin + " : " + car.brand + " : " + car.model + " : " + car.productionYear + " : " + car.insurenceNumber);
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            //CarsDataUSvcMockClient client = new CarsDataUSvcMockClient();\
            CarsDataUSvcClient client = new CarsDataUSvcClient();

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Getting all cars: ");

            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Getting cars by brand 'opel' :");

            printCars(client.GetCarsByBrand("opel"));

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Getting car by vin: ");
            CarDto car = client.GetCarByVin("131411414");
            printCar(car);

            Console.WriteLine("Adding car fiat punto:");
            CarDto carNew = new CarDto() {vin=  "991199221", model= "punto", brand ="fiat",productionYear= new DateTime(2008, 12, 11),insurenceNumber = "11445161",servicesHistory= new List<string>()};
            client.AddCar(carNew);
            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Adding idService(12):");
            string serviceId = "12";
            client.AddServiceToCarHistory("991199221", serviceId);
            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Removing idService(12):");
            client.RemoveServiceFromCarHistory("991199221", serviceId);
            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Deleting created fiat punto:");
            client.RemoveCarByVin("991199221");
            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Adding car by object:");

            CarDto carDto = new CarDto();
            carDto.vin = "16185";
            carDto.brand = "Audi";
            carDto.model = "Q5";
            carDto.insurenceNumber = "1416178";
            carDto.productionYear = new DateTime(2019, 05, 09, 09, 15, 00);
            List<string> listOfServices = new List<string>();
            listOfServices.Add("r61");
            listOfServices.Add("i15");
            carDto.servicesHistory = listOfServices;
            client.AddCar(carDto);
            printCars(client.GetAllCars());

            Console.WriteLine("Removing created audi by object:");
            client.RemoveCarByVin("16185");
            printCars(client.GetAllCars());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Trying to add car with errors:");

            carDto = new CarDto();
            carDto.vin = "16185";
            carDto.brand = "Audi";
            carDto.model = "Q5";
            carDto.insurenceNumber = "1416178";
            carDto.productionYear = new DateTime(2019, 05, 09, 09, 15, 00);
            listOfServices = new List<string>();
            listOfServices.Add("ilustrator");
            listOfServices.Add("error");
            carDto.servicesHistory = listOfServices;
            client.AddCar(carDto);
            printCars(client.GetAllCars());

            Console.WriteLine("Removing created audi by object:");
            client.RemoveCarByVin("16185");
            printCars(client.GetAllCars());
        }
    }
}


