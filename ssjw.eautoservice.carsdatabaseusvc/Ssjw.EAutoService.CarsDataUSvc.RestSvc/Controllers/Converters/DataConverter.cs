namespace Ssjw.EAutoService.CarsDataUSvc.RestSvc.Controllers.Converters
{
    using Ssjw.EAutoService.CarsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;

    public static class DataConverter
    {
        public static CarDto ConvertToFullCarDto(this Car car)
        {
            return new CarDto() { vin = car.Vin, model = car.Model, brand = car.Brand, productionYear = car.ProductionYear, insurenceNumber = car.InsurenceNumber, servicesHistory = car.ServicesHistory };
        }

        public static Car ConvertToCar(this CarDto carDto)
        {
            return new Car(carDto.vin, carDto.model, carDto.brand, carDto.productionYear, carDto.insurenceNumber, carDto.servicesHistory);
        }
    }
}
