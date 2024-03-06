namespace Ssjw.EAutoService.ClientAppUSvc.RestSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ssjw.EAutoService.ClientAppUSvc.Logic;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;
    [ApiController]
    [Route("[controller]")]
    public class ClientAppController : IClientAppSvc
    {
        private readonly ILogger<ClientAppController> logger;
        private readonly ClientManager clientManager;
        public ClientAppController(ILogger<ClientAppController> logger)
        {
            this.logger = logger;
            clientManager = new ClientManager();
        }
        [HttpPost]
        [Route("AddNewClient")]
        public void AddNewClient(ExtendedClientDto client)
        {
            clientManager.AddNewClient(new ExtendedClient()
            {
                Name = client.name,
                Surname = client.surname,
                PhoneNumber = client.phoneNumber,
                IdCardNumber = client.idCardNumber,
                VinNumbers = client.vinNumbers
            });
        }
        [HttpGet]
        [Route("FindBodyPartByBodyType")]
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            List<ExtendedBodyPart> extendedBodyParts = this.clientManager.FindBodyPartByBodyType(bodyType);
            return extendedBodyParts.Select(extendedBodyPart => extendedBodyPart.ConvertToBodyPartDto()).ToList();
        }
        [HttpGet]
        [Route("FindBodyPartByPrice")]
        public List<ExtendedBodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<ExtendedBodyPart> extendedBodyParts = this.clientManager.FindBodyPartByPrice(minPrice, maxPrice);

            return extendedBodyParts.Select(extendedBodyPart => extendedBodyPart.ConvertToBodyPartDto()).ToList();
        }
        [HttpGet]
        [Route("FindLiquidByCategory")]
        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            List<ExtendedLiquid> extendedLiquids = this.clientManager.FindLiquidByCategory(category);

            return extendedLiquids.Select(extendedLiquid => extendedLiquid.ConvertToLiquidDto()).ToList();
        }
        [HttpGet]
        [Route("FindLiquidByPrice")]
        public List<ExtendedLiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            List<ExtendedLiquid> extendedLiquids = this.clientManager.FindLiquidByPrice(minPrice, maxPrice);

            return extendedLiquids.Select(extendedLiquid => extendedLiquid.ConvertToLiquidDto()).ToList();
        }
        [HttpGet]
        [Route("FindMechanicalPartByCategory")]
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            List<ExtendedMechanicalPart> extendedMechanicalParts = this.clientManager.FindMechanicalPartByCategory(category);

            return extendedMechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }
        [HttpGet]
        [Route("FindMechanicalPartByPrice")]
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<ExtendedMechanicalPart> extendedMechanicalParts = this.clientManager.FindMechanicalPartByPrice(minPrice, maxPrice);
            return extendedMechanicalParts.Select(mechanicalPart => mechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }
        [HttpGet]
        [Route("GetAllBodyParts")]
        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            List<ExtendedBodyPart> extendedBodyParts = this.clientManager.GetAllBodyParts();
            return extendedBodyParts.Select(extendedBodyPart => extendedBodyPart.ConvertToBodyPartDto()).ToList();
        }
        [HttpGet]
        [Route("GetAllClientCar")]
        public List<ExtendedCarDto> GetAllClientCar(string idCardNumber)
        {
            return DtosLogic.ConvertToExtendedCarDtoList(this.clientManager.GetAllClientCar(idCardNumber));
        }
        [HttpGet]
        [Route("GetAllLiquids")]
        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            List<ExtendedLiquid> extendedLiquids = this.clientManager.GetAllLiquids();
            return extendedLiquids.Select(extendedLiquid => extendedLiquid.ConvertToLiquidDto()).ToList();
        }
        [HttpGet]
        [Route("GetAllMechanicalParts")]
        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            List<ExtendedMechanicalPart> extendedMechanicalParts = this.clientManager.GetAllMechanicalParts();
            return extendedMechanicalParts.Select(extendedMechanicalPart =>
               extendedMechanicalPart.ConvertToMechanicalPartDto()).ToList();
        }
        [HttpGet]
        [Route("GetAvailableMechanics")]
        public List<ExtendedEmployeeDto> GetAvailableMechanics(DateTime date)
        {
            return DtosLogic.ConvertToExtendedEmployeeDtoList(this.clientManager.GetAvailableMechanics(date));
        }
        [HttpGet]
        [Route("GetCarInformation")]
        public ExtendedCarDto GetCarInformation(string vin)
        {
            ExtendedCar extendedCar = this.clientManager.GetCarInformation(vin);
            return DtosLogic.ConvertToExtendedCarDto(extendedCar);
        }
        [HttpGet]
        [Route("GetCarInspectionHistory")]
        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            List<ExtendedInspection> extendedInspections = this.clientManager.GetCarInspectionHistory(vin);
            return extendedInspections.Select(insp => insp.ConvertToCompleteInspectionDto()).ToList();
        }
        [HttpGet]
        [Route("GetCarRepairHistory")]
        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            List<ExtendedRepair> extendedRepairs = this.clientManager.GetCarRepairHistory(vin);
            return extendedRepairs.Select(rep => rep.ConvertToCompleteRepairDto()).ToList();
        }
        [HttpGet]
        [Route("GetPersonalInformation")]
        public ExtendedClientDto GetPersonalInformation(string id)
        {
            ExtendedClient extendedClient = this.clientManager.GetPersonalInformation(id);
            return DtosLogic.ConvertToCompleteClientDto(extendedClient);
        }
        [HttpPost]
        [Route("ModifyCarData")]
        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber, List<string>? servicesHistory)
        {
            this.clientManager.ModifyCarData(vin, model, brand, productionYear, insuranceNumber, servicesHistory);
        }
        [HttpPost]
        [Route("ModifyPersonalData")]
        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber, List<string>? vinNumbers)
        {
            this.clientManager.ModifyPersonalData(clientId, newIdCard, name, surname, phoneNumber, vinNumbers);
        }
        [HttpPost]
        [Route("PurchaseCarPart")]
        public void PurchaseCarPart(string id)
        {
            this.clientManager.PurchaseCarPart(id);
        }
        [HttpPost]
        [Route("RequestNewInspection")]
        public void RequestNewInspection(ExtendedInspectionDto extendedInspectionDto)
        {
            this.clientManager.RequestNewInspection(DtosLogic.CreateExtendedInspectionFromDto(extendedInspectionDto));
        }
        [HttpPost]
        [Route("RequestNewRepair")]
        public void RequestNewRepair(ExtendedRepairDto extendedRepairDto)
        {
            this.clientManager.RequestNewRepair(DtosLogic.CreateExtendedRepairFromDto(extendedRepairDto));
        }
        [HttpPost]
        [Route("AddCar")]
        public void AddCar(ExtendedCarDto extendedCarDto, string idCardNumber)
        {
            this.clientManager.AddCar(extendedCarDto, idCardNumber);
        }
    }
}