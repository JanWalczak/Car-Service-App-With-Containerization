namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Services
{
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Model;

    public interface IInspectionsData
    {
        public List<Inspection> GetInspectionsByVinNumber(string vinNumber);
        public Inspection FindInspectionById(string id);
        public void AddInspection(Inspection inspection);
        public List<Inspection> GetAllInspections();
        public List<Inspection> GetAllByPassedFieldInspections(bool passed);
        public void RemoveInspection(string id);
        public Inspection GetInspectionEmployeeIdVinNumber(string id);
        public void CompleteInspection(string id, double price, bool testsPassed, string comment);
    }
}