namespace Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto
{
    public class ExtendedMechanicalPartDto
    {
        public string id { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
        public double sizeX { get; set; }
        public double sizeY { get; set; }
        public double sizeZ { get; set; }
        public string description { get; set; }
        public int counter { get; set; }
        public ExtendedOtherPropertiesDto otherPropertiesDto { get; set; }
    }
}
