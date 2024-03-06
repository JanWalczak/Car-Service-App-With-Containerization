namespace Ssjw.EAutoService.ClientAppUSvc.Model.Model.Services
{
    public class ExtendedInspection
    {
        public bool TestsPassed { get; set; }
        public DateTime InspectionExpirationDate { get; set; }
        public string Comment { get; set; }
        public string Id { get; set; }
        public DateTime DateOfService { get; set; }
        public string EmployeeId { get; set; }
        public string VinNumber { get; set; }
        public double Price { get; set; }
        public ExtendedInspection() { }
        public ExtendedInspection(bool testsPassed, DateTime inspectionExpirationDate, string comment)
        {
            this.TestsPassed = testsPassed;
            this.InspectionExpirationDate = inspectionExpirationDate;
            this.Comment = comment;
        }
        public ExtendedInspection(string id, DateTime dateOfService, string employeeId, string vinNumber, double price,
            bool testsPassed, DateTime inspectionExpirationDate, string comment)
        {
            this.Id = id;
            this.DateOfService = dateOfService;
            this.EmployeeId = employeeId;
            this.VinNumber = vinNumber;
            this.Price = price;
            this.TestsPassed = testsPassed;
            this.InspectionExpirationDate = inspectionExpirationDate;
            this.Comment = comment;
        }
        public override string ToString()
        {
            return "Id: " + Id + " Date of service: " + DateOfService + " Employee Id: " + EmployeeId + " Vin number: " + VinNumber + " Price: "
                + Price + "\nTest passed: " + TestsPassed + " Expiration date of inspection: " + InspectionExpirationDate + " Comment: " + Comment;
        }
    }
}
