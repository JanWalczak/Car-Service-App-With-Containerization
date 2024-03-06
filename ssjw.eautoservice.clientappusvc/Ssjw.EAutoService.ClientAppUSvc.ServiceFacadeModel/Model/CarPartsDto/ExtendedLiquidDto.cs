namespace Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto
{
    public class ExtendedLiquidDto
    {
        public string id { get; set; }
        public string category { get; set; }
        public int density { get; set; }
        public bool containsPb { get; set; }
        public decimal price { get; set; }
        public int counter { get; set; }
        public ExtendedOtherPropertiesDto otherPropertiesDto { get; set; }
    }
}
