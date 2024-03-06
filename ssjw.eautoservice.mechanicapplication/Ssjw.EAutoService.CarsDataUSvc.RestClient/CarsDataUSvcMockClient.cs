namespace Ssjw.EAutoService.CarsDataUSvc.RestClient
{
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Services;

    public class CarsDataUSvcMockClient : ICarsDataDto
    {
        List<CarDto> cars = new List<CarDto>();

        public CarsDataUSvcMockClient()
        {
            List<string> servicesHistory = new List<string>();
            servicesHistory.Add("i4");
            servicesHistory.Add("i1");
            servicesHistory.Add("r1");
            cars.Add(new CarDto() { vin = "41414154", model = "astra", brand = "opel", productionYear = new DateTime(2005, 12, 12), insurenceNumber = "145716", servicesHistory = servicesHistory });
            servicesHistory = new List<string>();
            servicesHistory.Add("i2");
            servicesHistory.Add("r2");
            servicesHistory.Add("r4");
            servicesHistory.Add("r5");
            cars.Add(new CarDto() { vin = "131411414", model = "s60", brand = "volvo", productionYear = new DateTime(2015, 04, 02), insurenceNumber = "681867195154", servicesHistory = servicesHistory });
            servicesHistory = new List<string>();
            servicesHistory.Add("i3");
            servicesHistory.Add("i5");
            servicesHistory.Add("i6");
            servicesHistory.Add("r3");
            servicesHistory.Add("r6");
            cars.Add(new CarDto() { vin = "11111661", model = "octavia", brand = "skoda", productionYear = new DateTime(2012, 03, 01), insurenceNumber = "89991100561", servicesHistory = servicesHistory });
            servicesHistory = new List<string>();
            cars.Add(new CarDto() { vin = "1111111", model = "740", brand = "volvo", productionYear = new DateTime(1990, 05, 03), insurenceNumber = "11551", servicesHistory = servicesHistory });

            cars.Add(new CarDto() { vin = "9991191", model = "911", brand = "Porshe", productionYear = new DateTime(2022, 05, 05), insurenceNumber = "1100141", servicesHistory = servicesHistory });
        }
        public void AddCar(CarDto car)
        {
            foreach (string service in car.servicesHistory)
            {
                service.ToLower();
                if (service.StartsWith("r") || service.StartsWith("i") && int.TryParse(service.Substring(1), out int number))
                    continue;

                Console.WriteLine("Something went wrong!");
                return;
            }

            if (GetCarByVin(car.vin) == null)
            {
                cars.Add(car);
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        public void AddCarMan(string vin, string model, string brand, DateTime productionYear, string insurenceNumber, List<string> servicesHistory)
        {
            cars.Add(new CarDto() { vin = vin, model = model, brand = brand, productionYear = productionYear, insurenceNumber = insurenceNumber, servicesHistory = servicesHistory });
        }

        public void AddServiceToCarHistory(string vin, string serviceId)
        {
            CarDto car = cars.Find(car => car.vin == vin);
            if (car != null) car.servicesHistory.Add(serviceId);
        }

        public List<CarDto> GetAllCars()
        {
            return cars;
        }

        public CarDto GetCarByVin(string vin)
        {
            return cars.Find(car => car.vin == vin);
        }

        public List<CarDto> GetCarsByBrand(string brand)
        {
            List<CarDto> carsByBrand = new List<CarDto>();
            foreach (CarDto car in cars)
            {
                if (car.brand.Equals(brand))
                {
                    carsByBrand.Add(car);
                }
            }
            return carsByBrand;
        }

        public void RemoveCarByVin(string vin)
        {
            if (cars.Find(car => car.vin == vin) != null) cars.Remove(cars.Find(car => car.vin == vin));
        }

        public void RemoveServiceFromCarHistory(string vin, string serviceId)
        {
            CarDto car = cars.Find(car => car.vin == vin);
            if (car != null && car.servicesHistory.Contains(serviceId)) car.servicesHistory.Remove(serviceId);
        }
    }
}
