namespace Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model
{
    public class ExtendedCarDto
    {
        public string vin { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public DateTime productionYear { get; set; }
        public string insurenceNumber { get; set; }
        public List<string> servicesHistoryInspections { get; set; }
        public List<string> servicesHistoryRepairs { get; set; }
    }
}