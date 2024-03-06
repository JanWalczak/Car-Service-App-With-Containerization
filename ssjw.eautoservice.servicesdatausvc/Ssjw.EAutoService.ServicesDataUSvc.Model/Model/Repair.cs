namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Model
{
    public class Repair : Service
    {
        public List<RepairedPart> RepairedParts { get; set; }

        public Repair()
        {
        }

        public Repair(string id, DateTime dateOfService, string emloyeeId, string vinNumber, double price, List<RepairedPart> repairedParts)
            : base(id, dateOfService, emloyeeId, vinNumber, price)
        {
            this.RepairedParts = repairedParts;
        }


        public override string ToString()
        {
            string stringRepairedParts = "";

            bool isEmpty = this.RepairedParts == null;
            if (!isEmpty)
            {
                foreach (RepairedPart part in this.RepairedParts)
                {
                    stringRepairedParts = stringRepairedParts + "\n" + part;
                }
            }
            return "Id: " + Id + " Date of service: " + DateOfService + " Employee Id: " + EmployeeId + " Vin number: " + VinNumber
                + " Price: " + Price + "\nRepaired parts:" + stringRepairedParts;
        }
    }
}
