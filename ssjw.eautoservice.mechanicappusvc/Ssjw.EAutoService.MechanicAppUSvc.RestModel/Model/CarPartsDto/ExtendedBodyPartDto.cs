namespace Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto
{
    public class ExtendedBodyPartDto
    {
        public string id { get; set; }
        public string bodyType { get; set; }
        public string material { get; set; }
        public decimal price { get; set; }
        public string colour { get; set; }
        public int counter { get; set; }
        public ExtendedOtherPropertiesDto otherPropertiesDto { get; set; }
    }
}
