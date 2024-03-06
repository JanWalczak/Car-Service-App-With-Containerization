namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Model
{
    public abstract class Service
    {
        public string Id { get; set; }
        public DateTime DateOfService { get; set; }
        public string EmployeeId { get; set; }
        public string VinNumber { get; set; }
        public double Price { get; set; }

        public Service()
        {

        }

        protected Service(string id, DateTime dateOfService, string employeeId, string vinNumber, double price)
        {
            this.Id = id;
            this.DateOfService = dateOfService;
            this.EmployeeId = employeeId;
            this.VinNumber = vinNumber;
            this.Price = price;
        }
    }
}
