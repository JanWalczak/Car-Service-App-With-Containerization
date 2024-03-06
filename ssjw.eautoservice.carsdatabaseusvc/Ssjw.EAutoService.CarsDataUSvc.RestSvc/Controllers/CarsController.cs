namespace Ssjw.EAutoService.CarsDataUSvc.RestSvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Ssjw.EAutoService.CarsDataUSvc.Logic;
    using Ssjw.EAutoService.CarsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.CarsDataUSvc.RestSvc.Controllers.Converters;

    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase, ICarsDataDto
    {
        private readonly ILogger<CarsController> logger;
        private readonly CarsData carsData;

        public CarsController(ILogger<CarsController> logger)
        {
            this.logger = logger;
            carsData = new CarsData();
        }

        [HttpPost]
        [Route("AddCar")]
        public void AddCar(CarDto car)
        {
            Car fullCar = DataConverter.ConvertToCar(car);
            carsData.AddCar(fullCar);
        }

        [HttpPost]
        [Route("AddServiceToCarHistory")]
        public void AddServiceToCarHistory(string vin, string serviceId)
        {
            carsData.AddServiceToCarHistory(vin, serviceId);
        }

        [HttpGet]
        [Route("GetAllCars")]
        public List<CarDto> GetAllCars()
        {
            List<Car> cars = this.carsData.GetAllCars();
            return cars.Select(car => car.ConvertToFullCarDto()).ToList();
        }

        [HttpGet]
        [Route("GetCarByVin")]
        public CarDto GetCarByVin(string vin)
        {
            return carsData.GetCarByVin(vin).ConvertToFullCarDto();
        }

        [HttpGet]
        [Route("GetCarsByBrand")]
        public List<CarDto> GetCarsByBrand(string brand)
        {
            List<Car> cars = carsData.GetCarsByBrand(brand);
            return cars.Select(car => car.ConvertToFullCarDto()).ToList();
        }

        [HttpPost]
        [Route("RemoveCarByVin")]
        public void RemoveCarByVin(string vin)
        {
            carsData.RemoveCarByVin(vin);
        }

        [HttpPost]
        [Route("RemoveServiceFromCarHistory")]
        public void RemoveServiceFromCarHistory(string vin, string serviceId)
        {
            carsData.RemoveServiceFromCarHistory(vin, serviceId);
        }
    }
}
