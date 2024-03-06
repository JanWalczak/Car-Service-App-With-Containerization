namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model
{
    public class MechanicalPartDto
    {
        public string id { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public double sizeX { get; set; }
        public double sizeY { get; set; }
        public double sizeZ { get; set; }
        public string description { get; set; }
        public int counter { get; set; }
        public OtherPropertiesDto otherPropertiesDto { get; set; }
    }
}
