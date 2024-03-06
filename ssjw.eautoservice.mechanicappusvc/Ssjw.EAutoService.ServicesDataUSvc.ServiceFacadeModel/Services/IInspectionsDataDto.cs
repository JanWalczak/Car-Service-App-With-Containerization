namespace Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public interface IInspectionsDataDto
    {
        public List<InspectionDto> GetInspectionsByVinNumber(string vinNumber);
        public InspectionDto FindInspectionById(string id);
        public void AddInspection(InspectionDto inspectionDto);
        public List<InspectionDto> GetAllInspections();
        public List<InspectionDto> GetAllByPassedFieldInspections(bool passed);
        public void RemoveInspection(string id);
        public InspectionDto GetInspectionEmployeeIdVinNumber(string id);
        public void CompleteInspection(string id, double price, bool testsPassed, string comment);
    }
}
