namespace Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model
{
    public class ExtendedEmployeeDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string jobPosition { get; set; }
        public string id { get; set; }
        public string salary { get; set; }
        public List<string> servicesInspection { get; set; }
        public List<string> servicesRepair { get; set; }
    }
}
