namespace Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects
{
    public class InspectionDto
    {
        public string Id { get; set; }
        public DateTime DateOfService { get; set; }
        public string EmployeeId { get; set; }
        public string VinNumber { get; set; }
        public double Price { get; set; }
        public bool TestsPassed { get; set; }
        public DateTime InspectionExpirationDate { get; set; }
        public string Comment { get; set; }
    }
}
