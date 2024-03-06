namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Model
{

    public class Inspection : Service
    {
        public bool TestsPassed { get; set; }
        public DateTime InspectionExpirationDate { get; set; }
        public string Comment { get; set; }


        public Inspection() { }


        public Inspection(bool testsPassed, DateTime inspectionExpirationDate, string comment)
        {
            this.TestsPassed = testsPassed;
            this.InspectionExpirationDate = inspectionExpirationDate;
            this.Comment = comment;
        }


        public Inspection(string id, DateTime dateOfService, string employeeId, string vinNumber, double price,
            bool testsPassed, DateTime inspectionExpirationDate, string comment) : base(id, dateOfService, employeeId, vinNumber, price)
        {
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
