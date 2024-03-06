namespace Ssjw.EAutoService.ClientAppUSvc.Model.Model.Services
{
    public class ExtendedRepair
    {
        public List<ExtendedRepairedPart> RepairedParts { get; set; }
        public string Id { get; set; }
        public DateTime DateOfService { get; set; }
        public string EmployeeId { get; set; }
        public string VinNumber { get; set; }
        public double Price { get; set; }
        public ExtendedRepair()
        {
        }
        public ExtendedRepair(string id, DateTime dateOfService, string emloyeeId, string vinNumber, double price,
            List<ExtendedRepairedPart> repairedParts)
        {
            this.Id = id;
            this.DateOfService = dateOfService;
            this.EmployeeId = emloyeeId;
            this.VinNumber = vinNumber;
            this.Price = price;
            this.RepairedParts = repairedParts;
        }
        public override string ToString()
        {
            string stringRepairedParts = "";

            bool isEmpty = this.RepairedParts == null;
            if (!isEmpty)
            {
                foreach (ExtendedRepairedPart part in this.RepairedParts)
                {
                    stringRepairedParts = stringRepairedParts + "\n" + part;
                }
            }
            return "Id: " + Id + " Date of service: " + DateOfService + " Employee Id: " + EmployeeId + " Vin number: " + VinNumber
                + " Price: " + Price + "\nRepaired parts:" + stringRepairedParts;
        }
    }
}
