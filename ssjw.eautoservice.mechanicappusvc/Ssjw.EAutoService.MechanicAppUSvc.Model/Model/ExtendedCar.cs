namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model
{
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services;

    public class ExtendedCar
    {
        public string Vin { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime ProductionYear { get; set; }
        public string InsurenceNumber { get; set; }
        public List<ExtendedInspection> ServicesHistoryInspections { get; set; }
        public List<ExtendedRepair> ServicesHistoryRepairs { get; set; }

        public ExtendedCar(string vin, string model, string brand, DateTime productionYear, string insurenceNumber, List<ExtendedInspection> servicesHistoryInspections,
            List<ExtendedRepair> servicesHistoryRepairs)
        {
            this.Vin = vin;
            this.Model = model;
            this.Brand = brand;
            this.ProductionYear = productionYear;
            this.InsurenceNumber = insurenceNumber;
            this.ServicesHistoryInspections = servicesHistoryInspections;
            this.ServicesHistoryRepairs = servicesHistoryRepairs;
        }

        public ExtendedCar() { }

        public ExtendedCar(string vin, string model, string brand)
        {
            this.Vin = vin;
            this.Model = model;
            this.Brand = brand;
        }

        public override string ToString()
        {
            return Vin + " : " + Model + " : " + Brand;
        }
    }
}
