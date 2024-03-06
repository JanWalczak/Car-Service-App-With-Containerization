namespace Ssjw.EAutoService.ServicesDataUSvc.WebSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ssjw.EAutoService.ServicesDataUSvc.Logic;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services;

    [ApiController]
    [Route("[controller]")]
    public class RepairsDataController : ControllerBase, IRepairsDataDto
    {
        private readonly ILogger<RepairsDataController> logger;
        private ServicesData servicesData;

        public RepairsDataController(ILogger<RepairsDataController> logger)
        {
            this.logger = logger;
            this.servicesData = new ServicesData();
        }

        [HttpPost]
        [Route("AddRepair")]
        public void AddRepair(RepairDto repairDto)
        {
            servicesData.AddRepair(DtosLogic.CreateRepairFromOneDto(repairDto));
        }

        [HttpGet]
        [Route("FindRepairById")]
        public RepairDto FindRepairById(string id)
        {
            bool isNull = servicesData.FindRepairById(id) == null;
            if (!isNull)
            {
                return DtosLogic.CreateDtoFromOneRepair(servicesData.FindRepairById(id));
            }

            return null;
        }

        [HttpGet]
        [Route("GetAllRepairs")]
        public List<RepairDto> GetAllRepairs()
        {
            return DtosLogic.CreateDtoFromRepairs(servicesData.GetAllRepairs());
        }

        [HttpGet]
        [Route("GetRepairByVinNumber")]
        public List<RepairDto> GetRepairByVinNumber(string vinNumber)
        {
            return DtosLogic.CreateDtoFromRepairs(servicesData.GetRepairByVinNumber(vinNumber));
        }

        [HttpGet]
        [Route("GetRepairedPartsById")]
        public List<RepairedPartDto> GetRepairedPartsById(string id)
        {
            return DtosLogic.CreateDtoFromRepairedParts(servicesData.GetRepairedPartsById(id));
        }

        [HttpPost]
        [Route("RemoveRepair")]
        public void RemoveRepair(string id)
        {
            servicesData.RemoveRepair(id);
        }

        [HttpGet]
        [Route("GetRepairEmployeeIdVinNumber")]
        public RepairDto GetRepairEmployeeIdVinNumber(string id)
        {
            bool isNull = servicesData.GetRepairEmployeeIdVinNumber(id) == null;
            if (!isNull)
            {
                return DtosLogic.CreateDtoFromOneRepair(servicesData.GetRepairEmployeeIdVinNumber(id));
            }

            return null;
        }

        [HttpPost]
        [Route("CompleteRepair")]
        public void CompleteRepair(string id, double price, List<RepairedPartDto> repairedParts)
        {
            servicesData.CompleteRepair(id, price, DtosLogic.CreateRepairedPartsFromDto(repairedParts));
        }
    }
}
