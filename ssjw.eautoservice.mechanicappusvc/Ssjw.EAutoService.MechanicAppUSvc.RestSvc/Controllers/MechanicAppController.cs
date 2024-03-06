namespace Ssjw.EAutoService.MechanicAppUSvc.RestSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ssjw.EAutoService.MechanicAppUSvc.Logic;
    using Ssjw.EAutoService.MechanicAppUSvc.RestSvc.Controllers.Converters;
    using System.Collections.Generic;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;

    [ApiController]
    [Route("[controller]")]
    public class MechanicAppController : IMechanicAppDto
    {
        private readonly ILogger<MechanicAppController> logger;
        private readonly MechanicManager mechanicManager;

        public MechanicAppController(ILogger<MechanicAppController> logger)
        {
            this.logger = logger;
            mechanicManager = new MechanicManager();
        }

        [HttpGet]
        [Route("GetPersonalCars")]
        public List<ExtendedCarDto> GetPersonalCars(string id)
        {
            return mechanicManager.GetPersonalCars(id).Select(car => car.ConvertToCompleteCarDto()).ToList();
        }

        [HttpGet]
        [Route("GetCarByVinNumber")]
        public ExtendedCarDto GetCarByVinNumber(string vinNumber)
        {
            return mechanicManager.GetCarByVinNumber(vinNumber).ConvertToCompleteCarDto();
        }

        [HttpGet]
        [Route("GetCarInspectionHistory")]
        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            return mechanicManager.GetCarInspectionHistory(vin).Select(inspection => inspection.ConvertToCompleteInspectionDto()).ToList();
        }

        [HttpGet]
        [Route("GetCarRepairHistory")]
        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            return mechanicManager.GetCarRepairHistory(vin).Select(repair => repair.ConvertToCompleteRepairDto()).ToList();
        }

        [HttpGet]
        [Route("GetPersonalRepairSchedule")]
        public List<ExtendedRepairDto> GetPersonalRepairSchedule(string id)
        {
            return mechanicManager.GetPersonalRepairSchedule(id).Select(repair => repair.ConvertToCompleteRepairDto()).ToList();
        }

        [HttpGet]
        [Route("GetPersonalInspectionSchedule")]
        public List<ExtendedInspectionDto> GetPersonalInspectionSchedule(string id)
        {
            return mechanicManager.GetPersonalInspectionSchedule(id).Select(inspection => inspection.ConvertToCompleteInspectionDto()).ToList();
        }

        [HttpPost]
        [Route("FinishRepair")]
        public void FinishRepair(string idService, double price, List<ExtendedRepairedPartDto> repairedParts)
        {
            mechanicManager.FinishRepair(idService, price, Converter.CreateRepairedPartsFromDto(repairedParts));
        }

        [HttpPost]
        [Route("FinishInspection")]
        public void FinishInspection(string idService, double price, bool testsPassed, string comment)
        {
            mechanicManager.FinishInspection(idService, price, testsPassed, comment);
        }

        [HttpGet]
        [Route("GetAllClients")]
        public List<ExtendedClientDto> GetAllClients()
        {
            return mechanicManager.GetAllClients().Select(client => client.ConvertToCompleteClientDto()).ToList();
        }

        [HttpGet]
        [Route("GetClientInformation")]
        public ExtendedClientDto GetClientInformation(string id)
        {
            return mechanicManager.GetClientInformation(id).ConvertToCompleteClientDto();
        }

        [HttpGet]
        [Route("GetAllMechanicalParts")]
        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            return mechanicManager.GetAllMechanicalParts().Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAllBodyParts")]
        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            return mechanicManager.GetAllBodyParts().Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("GetAllLiquids")]
        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            return mechanicManager.GetAllLiquids().Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("FindBodyPartByMaterial")]
        public List<ExtendedBodyPartDto> FindBodyPartByMaterial(string material)
        {
            return mechanicManager.FindBodyPartByMaterial(material).Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindBodyPartByBodyType")]
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            return mechanicManager.FindBodyPartByBodyType(bodyType).Select(bodyPart => bodyPart.ConvertToBodyPartDto()).ToList();
        }

        [HttpPost]
        [Route("UseCarPart")]
        public void UseCarPart(string carPartId)
        {
            mechanicManager.UseCarPart(carPartId);
        }

        [HttpGet]
        [Route("FindMechanicalPartByDimensions")]
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            return mechanicManager.FindMechanicalPartByDimensions(sizeX, sizeY, sizeZ).Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindMechanicalPartByCategory")]
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            return mechanicManager.FindMechanicalPartByCategory(category).Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }

        [HttpGet]
        [Route("FindLiquidByDensity")]
        public List<ExtendedLiquidDto> FindLiquidByDensity(int density)
        {
            return mechanicManager.FindLiquidByDensity(density).Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }

        [HttpGet]
        [Route("FindLiquidByCategory")]
        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            return mechanicManager.FindLiquidByCategory(category).Select(liquid => liquid.ConvertToLiquidDto()).ToList();
        }
    }
}