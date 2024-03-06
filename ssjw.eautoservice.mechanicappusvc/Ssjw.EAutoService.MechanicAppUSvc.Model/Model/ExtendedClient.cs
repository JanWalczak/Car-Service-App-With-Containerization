namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model
{
    public class ExtendedClient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }
        public List<string> VinNumbers { get; set; }

        public ExtendedClient(string name, string surname, string phoneNumber, string idCardNumber, List<string> vinNumbers)
        {
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.IdCardNumber = idCardNumber;
            this.VinNumbers = vinNumbers;
        }

        public ExtendedClient()
        { }
        

        public override string ToString()
        {
            string ts = "Name: " + Name + " " + "Surname: " + Surname + " Phone Number: " + PhoneNumber + " Id Card Number: " + IdCardNumber
                + " Vin Numbers: ";
            bool isEmpty = VinNumbers == null;
            if (!isEmpty)
            {
                for (int i = 0; i < VinNumbers.Count; i++)
                {
                    ts = ts + VinNumbers[i] + ", ";
                }
            }

            return ts;
        }
    }
}
