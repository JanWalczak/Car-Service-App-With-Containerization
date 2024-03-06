namespace Ssjw.EAutoService.CarsDataUSvc.Model.Services
{
    using Ssjw.EAutoService.CarsDataUSvc.Model.Model;

    public interface ICarsData
    {
        public List<Car> GetAllCars();
        public void AddCar(Car car);
        public List<Car> GetCarsByBrand(string brand);
        public Car GetCarByVin(string vin);
        public void RemoveCarByVin(string vin);
        public void AddServiceToCarHistory(string vin, string serviceId);
        public void RemoveServiceFromCarHistory(string vin, string serviceId);
    }
}
