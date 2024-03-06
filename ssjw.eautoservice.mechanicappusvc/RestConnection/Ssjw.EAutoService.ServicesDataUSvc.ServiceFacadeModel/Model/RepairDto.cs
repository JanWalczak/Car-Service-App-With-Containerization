namespace Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects
{
    public class RepairDto
    {
        public string Id { get; set; }
        public DateTime DateOfService { get; set; }
        public string EmployeeId { get; set; }
        public string VinNumber { get; set; }
        public double Price { get; set; }
        public List<RepairedPartDto> RepairedParts { get; set; }
    }
}
