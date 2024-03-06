namespace Ssjw.EAutoService.CarPartsDataUSvc.RestSVC.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.Logic;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestSvc.Controllers.Converters;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    [ApiController]
    [Route("[controller]")]
    public class MechanicalPartsController : ControllerBase, IMechanicalPartDataDto
    {
        private readonly ILogger<MechanicalPartsController> logger;
        private readonly CarPartsData carPartData;

        public MechanicalPartsController(ILogger<MechanicalPartsController> logger)
        {
            this.logger = logger;
            carPartData = new CarPartsData();
        }

        [HttpGet]
        [Route("FindMechanicalPartByDimensions")]
        public List<MechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            List<MechanicalPart> mechanicalParts = this.carPartData.FindMechanicalPartByDimensions(sizeX, sizeY, sizeZ);
            return mechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindMechanicalPartByPrice")]
        public List<MechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<MechanicalPart> mechanicalParts = this.carPartData.FindMechanicalPartByPrice(minPrice, maxPrice);
            return mechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindMechanicalPartByCategory")]
        public List<MechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            List<MechanicalPart> mechanicalParts = this.carPartData.FindMechanicalPartByCategory(category);
            return mechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAllMechanicalParts")]
        public List<MechanicalPartDto> GetAllMechanicalParts()
        {
            List<MechanicalPart> mechanicalParts = this.carPartData.GetAllMechanicalParts();
            return mechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAvailableAndUnavailableMechanicalParts")]
        public List<MechanicalPartDto> GetAvailableAndUnavailableMechanicalParts()
        {
            List<MechanicalPart> mechanicalParts = this.carPartData.GetAvailableAndUnavailableMechanicalParts();
            return mechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDtoWithNumber()).ToList();
        }

        [HttpGet]
        [Route("GetMechanicalPartById")]
        public MechanicalPartDto GetMechanicalPartById(string id)
        {
            return carPartData.GetMechanicalPartById(id).ConvertToMechanicalPartDtoWithNumber();
        }

        [HttpPost]
        [Route("AddMechanicalPart")]
        public void AddMechanicalPart(MechanicalPartDto mechanicalPartDto)
        {
            carPartData.AddMechanicalPart(mechanicalPartDto.ConvertToMechanicalPart());
        }
    }
}
