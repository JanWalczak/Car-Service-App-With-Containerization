namespace Ssjw.EAutoService.CarsDataUSvc.Model.Model
{
    public class Car
    {
        public string Vin { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public DateTime ProductionYear { get; set; }
        public string InsurenceNumber { get; set; }
        public List<string> ServicesHistory { get; set; }

        public Car(string vin, string model, string brand, DateTime productionYear, string insurenceNumber, List<string> servicesHistory)
        {
            this.Vin = vin;
            this.Model = model;
            this.Brand = brand;
            this.ProductionYear = productionYear;
            this.InsurenceNumber = insurenceNumber;
            this.ServicesHistory = servicesHistory;
        }

        public Car() { }

        public Car(string vin, string model, string brand)
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
