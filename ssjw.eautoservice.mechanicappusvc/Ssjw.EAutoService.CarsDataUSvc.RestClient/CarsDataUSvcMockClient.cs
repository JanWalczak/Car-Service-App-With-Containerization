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
            cars.Add(new CarDto() { vin = "99119914", model = "cayman", brand = "porshe", productionYear = new DateTime(2005, 12, 12), insurenceNumber = "55111571", servicesHistory = servicesHistory });
            cars.Add(new CarDto() { vin = "99115914", model = "supra", brand = "toyota", productionYear = new DateTime(2002, 10, 11), insurenceNumber = "51151571", servicesHistory = servicesHistory });
            cars.Add(new CarDto() { vin = "99219914", model = "rx7", brand = "honda", productionYear = new DateTime(2005, 11, 11), insurenceNumber = "95151571", servicesHistory = servicesHistory });
            cars.Add(new CarDto() { vin = "19119914", model = "impreza", brand = "subaru", productionYear = new DateTime(2012, 12, 12), insurenceNumber = "551532571", servicesHistory = servicesHistory });
            cars.Add(new CarDto() { vin = "131411414", model = "corsa", brand = "opel", productionYear = new DateTime(2002, 12, 12), insurenceNumber = "151532511", servicesHistory = servicesHistory });
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
