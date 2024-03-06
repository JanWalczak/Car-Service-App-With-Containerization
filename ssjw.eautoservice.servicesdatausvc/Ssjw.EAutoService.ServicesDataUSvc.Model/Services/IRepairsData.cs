namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Services
{
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Model;

    public interface IRepairsData
    {
        public List<Repair> GetRepairByVinNumber(string vinNumber);
        public Repair FindRepairById(string id);
        public void AddRepair(Repair repair);
        public List<Repair> GetAllRepairs();
        public void RemoveRepair(string id);
        public List<RepairedPart> GetRepairedPartsById(string id);
        public Repair GetRepairEmployeeIdVinNumber(string id);
        public void CompleteRepair(string id, double price, List<RepairedPart> repairedParts);
    }
}
