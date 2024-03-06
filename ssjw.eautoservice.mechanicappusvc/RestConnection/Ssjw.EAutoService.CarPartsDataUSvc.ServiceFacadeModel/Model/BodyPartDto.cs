namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model
{
    public class BodyPartDto
    {
        public string id { get; set; }
        public string bodyType { get; set; }
        public string material { get; set; }
        public decimal price { get; set; }
        public string colour { get; set; }
        public int counter { get; set; }
        public OtherPropertiesDto otherPropertiesDto { get; set; }
    }
}

