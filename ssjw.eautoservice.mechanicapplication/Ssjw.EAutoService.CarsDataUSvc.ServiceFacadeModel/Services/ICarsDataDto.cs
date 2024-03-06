namespace Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;

    public interface ICarsDataDto
    {
        public List<CarDto> GetAllCars();
        public void AddCar(CarDto car);
        public List<CarDto> GetCarsByBrand(string brand);
        public CarDto GetCarByVin(string vin);
        public void RemoveCarByVin(string vin);
        public void AddServiceToCarHistory(string vin, string serviceId);
        public void RemoveServiceFromCarHistory(string vin, string serviceId);
    }
}
