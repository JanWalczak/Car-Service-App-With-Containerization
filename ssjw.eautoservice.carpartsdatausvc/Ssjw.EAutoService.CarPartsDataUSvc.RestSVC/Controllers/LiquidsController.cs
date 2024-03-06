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
    public class LiquidsController : ControllerBase, ILiquidDataDto
    {
        private readonly ILogger<LiquidsController> logger;
        private readonly CarPartsData carPartData;

        public LiquidsController(ILogger<LiquidsController> logger)
        {
            this.logger = logger;
            carPartData = new CarPartsData();
        }

        [HttpGet]
        [Route("FindLiquidByCategory")]
        public List<LiquidDto> FindLiquidByCategory(string category)
        {
            List<Liquid> liquids = this.carPartData.FindLiquidByCategory(category);
            return liquids.Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("FindLiquidByPrice")]
        public List<LiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            List<Liquid> liquids = this.carPartData.FindLiquidByPrice(minPrice, maxPrice);
            return liquids.Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("FindLiquidByDensity")]
        public List<LiquidDto> FindLiquidByDensity(int density)
        {
            List<Liquid> liquids = this.carPartData.FindLiquidByDensity(density);
            return liquids.Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("GetAllLiquids")]
        public List<LiquidDto> GetAllLiquids()
        {
            List<Liquid> liquids = carPartData.GetAllLiquids();
            return liquids.Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("GetAvailableAndUnavailableLiquids")]
        public List<LiquidDto> GetAvailableAndUnavailableLiquids()
        {
            List<Liquid> liquids = carPartData.GetAvailableAndUnavailableLiquids();
            return liquids.Select(liquid => liquid.ConvertToLiquidDtoWithNumber()).ToList();
        }

        [HttpGet]
        [Route("GetLiquidById")]
        public LiquidDto GetLiquidById(string id)
        {
            return carPartData.GetLiquidById(id).ConvertToLiquidDtoWithNumber();
        }

        [HttpPost]
        [Route("AddLiquid")]
        public void AddLiquid(LiquidDto liquidDto)
        {
            carPartData.AddLiquid(liquidDto.ConvertToLiquid());
        }
    }
}
