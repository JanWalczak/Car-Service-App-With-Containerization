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
    public class BodyPartsController : ControllerBase, IBodyPartDataDto
    {
        private readonly ILogger<BodyPartsController> logger;
        private readonly CarPartsData carPartData;

        public BodyPartsController(ILogger<BodyPartsController> logger)
        {
            this.logger = logger;
            carPartData = new CarPartsData();
        }

        [HttpGet]
        [Route("FindBodyPartByBodyType")]
        public List<BodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            List<BodyPart> bodyParts = this.carPartData.FindBodyPartByBodyType(bodyType);
            return bodyParts.Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindBodyPartByPrice")]
        public List<BodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<BodyPart> bodyParts = this.carPartData.FindBodyPartByPrice(minPrice, maxPrice);
            return bodyParts.Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindBodyPartByMaterial")]
        public List<BodyPartDto> FindBodyPartByMaterial(string material)
        {
            List<BodyPart> bodyParts = this.carPartData.FindBodyPartByMaterial(material);
            return bodyParts.Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAllBodyParts")]
        public List<BodyPartDto> GetAllBodyParts()
        {
            List<BodyPart> bodyParts = this.carPartData.GetAllBodyParts();
            return bodyParts.Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAvailableAndUnavailableBodyParts")]
        public List<BodyPartDto> GetAvailableAndUnavailableBodyParts()
        {
            List<BodyPart> bodyParts = this.carPartData.GetAvailableAndUnavailableBodyParts();
            return bodyParts.Select(bodyPart => bodyPart.ConvertToBodyPartDtoWithNumber()).ToList();
        }

        [HttpGet]
        [Route("GetBodyPartById")]
        public BodyPartDto GetBodyPartById(string id)
        {
            return carPartData.GetBodyPartById(id).ConvertToBodyPartDtoWithNumber();
        }

        [HttpPost]
        [Route("AddBodyPart")]
        public void AddBodyPart(BodyPartDto bodyPartDto)
        {
            carPartData.AddBodyPart(bodyPartDto.ConvertToBodyPart());
        }
    }
}
