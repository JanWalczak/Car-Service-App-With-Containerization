namespace Ssjw.EAutoService.ServicesDataUSvc.WebSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ssjw.EAutoService.ServicesDataUSvc.Logic;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services;


    [ApiController]
    [Route("[controller]")]
    public class InspectionsDataController : ControllerBase, IInspectionsDataDto
    {
        private readonly ILogger<InspectionsDataController> logger;
        private ServicesData servicesData;

        public InspectionsDataController(ILogger<InspectionsDataController> logger)
        {
            this.logger = logger;
            this.servicesData = new ServicesData();
        }

        [HttpGet]
        [Route("GetInspectionsByVinNumber")]
        public List<InspectionDto> GetInspectionsByVinNumber(string vinNumber)
        {
            return DtosLogic.CreateDtoFromInspections(servicesData.GetInspectionsByVinNumber(vinNumber));
        }

        [HttpGet]
        [Route("FindInspectionById")]
        public InspectionDto FindInspectionById(string id)
        {
            bool isNull = servicesData.FindInspectionById(id) == null;
            if (!isNull)
            {
                return DtosLogic.CreateDtoFromOneInspection(servicesData.FindInspectionById(id));
            }

            return null;
        }

        [HttpPost]
        [Route("AddInspection")]
        public void AddInspection(InspectionDto inspectionDto)
        {
            servicesData.AddInspection(DtosLogic.CreateInspectionFromOneDto(inspectionDto));
        }

        [HttpGet]
        [Route("GetAllInspections")]
        public List<InspectionDto> GetAllInspections()
        {
            return DtosLogic.CreateDtoFromInspections(servicesData.GetAllInspections());
        }

        [HttpGet]
        [Route("GetAllByPassedFieldInspections")]
        public List<InspectionDto> GetAllByPassedFieldInspections(bool passed)
        {
            return DtosLogic.CreateDtoFromInspections(servicesData.GetAllByPassedFieldInspections(passed));
        }

        [HttpPost]
        [Route("RemoveInspection")]
        public void RemoveInspection(string id)
        {
            servicesData.RemoveInspection(id);
        }

        [HttpGet]
        [Route("GetEmployeeIdVinNumber")]
        public InspectionDto GetInspectionEmployeeIdVinNumber(string id)
        {
            bool isNull = servicesData.GetInspectionEmployeeIdVinNumber(id) == null;
            if (!isNull)
            {
                return DtosLogic.CreateDtoFromOneInspection(servicesData.GetInspectionEmployeeIdVinNumber(id));
            }

            return null;
        }

        [HttpPost]
        [Route("CompleteInspection")]
        public void CompleteInspection(string id, double price, bool testsPassed, string comment)
        {
            servicesData.CompleteInspection(id, price, testsPassed, comment);
        }
    }
}
