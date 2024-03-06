namespace Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Ssjw.EAutoService.CarPartsDataUSvc.Logic;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services;

    [ApiController]
    [Route("[controller]")]
    public class CarPartsController : ControllerBase, ICarPartsDto
    {
        private readonly ILogger<CarPartsController> logger;
        private readonly CarPartsData carPartData;

        public CarPartsController(ILogger<CarPartsController> logger)
        {
            this.logger = logger;
            carPartData = new CarPartsData();
        }

        [HttpPost]
        [Route("RemoveCarPart")]
        public void RemoveCarPart(string id)
        {
            carPartData.RemoveCarPart(id);
        }

        [HttpPost]
        [Route("DeleteCarPart")]
        public void DeleteCarPart(string id)
        {
            carPartData.DeleteCarPart(id);
        }

        [HttpPost]
        [Route("ChangeNumberOfAvailableParts")]
        public void ChangeNumberOfAvailableParts(string id, int number)
        {
            carPartData.ChangeNumberOfAvailableParts(id, number);
        }

        [HttpGet]
        [Route("GetNumberOfAvailableParts")]
        public int GetNumberOfAvailableParts(string id)
        {
            return carPartData.GetNumberOfAvailableParts(id);
        }
    }
}
