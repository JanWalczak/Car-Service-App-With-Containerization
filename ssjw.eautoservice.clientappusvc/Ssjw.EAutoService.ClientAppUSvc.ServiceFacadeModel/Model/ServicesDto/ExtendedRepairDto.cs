namespace Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto
{
    public class ExtendedRepairDto
    {
        public List<ExtendedRepairedPartDto> repairedParts { get; set; }
        public string id { get; set; }
        public DateTime dateOfService { get; set; }
        public string employeeId { get; set; }
        public string vinNumber { get; set; }
        public double price { get; set; }
    }
}
