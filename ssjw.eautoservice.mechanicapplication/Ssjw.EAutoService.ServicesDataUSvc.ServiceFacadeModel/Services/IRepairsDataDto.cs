namespace Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public interface IRepairsDataDto
    {
        public List<RepairDto> GetRepairByVinNumber(string vinNumber);
        public RepairDto FindRepairById(string id);
        public void AddRepair(RepairDto repairDto);
        public List<RepairDto> GetAllRepairs();
        public void RemoveRepair(string id);
        public List<RepairedPartDto> GetRepairedPartsById(string id);
        public RepairDto GetRepairEmployeeIdVinNumber(string id);
        public void CompleteRepair(string id, double price, List<RepairedPartDto> repairedParts);

        public Task AddRepairTask(RepairDto repairDto);
    }
}
