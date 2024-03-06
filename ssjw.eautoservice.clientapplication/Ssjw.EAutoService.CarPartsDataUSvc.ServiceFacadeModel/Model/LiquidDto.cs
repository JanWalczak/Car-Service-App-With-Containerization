namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model
{
    public class LiquidDto
    {
        public string id { get; set; }
        public string category { get; set; }
        public int density { get; set; }
        public bool containsPb { get; set; }
        public decimal price { get; set; }
        public int counter { get; set; }
        public OtherPropertiesDto otherPropertiesDto { get; set; }
    }
}
