namespace Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto
{
    public class ExtendedInspectionDto
    {
        public bool testsPassed { get; set; }
        public DateTime inspectionExpirationDate { get; set; }
        public string comment { get; set; }
        public string id { get; set; }
        public DateTime dateOfService { get; set; }
        public string employeeId { get; set; }
        public string vinNumber { get; set; }
        public double price { get; set; }
    }
}
