namespace Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model
{
    public class CarDto
    {
        public string vin { get; set; }
        public string model { get; set; }
        public string brand { get; set; }
        public DateTime productionYear { get; set; }
        public string insurenceNumber { get; set; }
        public List<string> servicesHistory { get; set; }
    }
}