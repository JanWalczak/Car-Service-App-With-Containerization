namespace Ssjw.EAutoService.CarsDataUSvc.Logic
{
    using Ssjw.EAutoService.CarsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarsDataUSvc.Model.Services;

    public class CarsData : ICarsData
    {
        public static List<Car> cars = new List<Car>();
        private static CarsDataReaderSaver readerSaver;

        private static readonly object locker = new object();

        static CarsData()
        {
            readerSaver = new CarsDataReaderSaver();

            lock (CarsData.locker)
            {
                readerSaver.ReadFiles();
            }
        }

        private static Boolean vinCheck(string vin)
        {
            foreach (Car car in cars)
            {
                if (car.Vin == vin) return false;
            }
            return true;
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }

        public Car GetCarByVin(string vin)
        {

            foreach (Car car in cars)
            {
                if (car.Vin == vin)
                {
                    return car;
                }
            }
            return null;
        }

        public List<Car> GetCarsByBrand(string brand)
        {
            List<Car> carsByBrand = new List<Car>();
            foreach (Car car in cars)
            {
                if (car.Brand.Equals(brand)) carsByBrand.Add(car);
            }
            return carsByBrand;
        }

        public void RemoveCarByVin(string vin)
        {
            if (GetCarByVin(vin) != null)
            {
                cars.Remove(GetCarByVin(vin));
                readerSaver.WriteFiles();
            }
            else
            {
                Console.WriteLine("Car with this vin does not exist!");
            }
        }

        public void AddServiceToCarHistory(string vin, string serviceId)
        {
            if (GetCarByVin(vin).ServicesHistory == null) GetCarByVin(vin).ServicesHistory = new List<string>();

            if (GetCarByVin(vin) != null && !GetCarByVin(vin).ServicesHistory.Contains(serviceId))
            {
                GetCarByVin(vin).ServicesHistory.Add(serviceId);
                readerSaver.WriteFiles();
            }
            else
            {
                Console.WriteLine("Error occured!");
            }
        }

        public void RemoveServiceFromCarHistory(string vin, string serviceId)
        {
            if (GetCarByVin(vin) != null && GetCarByVin(vin).ServicesHistory.Contains(serviceId))
            {
                GetCarByVin(vin).ServicesHistory.Remove(serviceId);
                readerSaver.WriteFiles();
            }
            else
            {
                Console.WriteLine("Error occured!");
            }
        }

        public void AddCar(Car car)
        {
            foreach (string service in car.ServicesHistory)
            {
                service.ToLower();
                if (service.StartsWith("r") || service.StartsWith("i") && int.TryParse(service.Substring(1), out int number))
                {
                    continue;
                }
                Console.WriteLine("Something went wrong!");
                return;
            }

            if (GetCarByVin(car.Vin) == null)
            {
                cars.Add(car);
                readerSaver.WriteFiles();
            }
            else
            {
                Console.WriteLine("Something went wrong!");
            }
        }
    }
}