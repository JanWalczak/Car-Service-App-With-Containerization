namespace Ssjw.EAutoService.ClientsDataUSvc.Model.Model
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }
        public List<string> VinNumbers { get; set; }

        public Client(string name, string surname, string phoneNumber, string idCardNumber, List<string> vinNumbers)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            IdCardNumber = idCardNumber;
            VinNumbers = vinNumbers;
        }

        public Client()
        {
        }

        public override string ToString()
        {
            string toString = "Name: " + Name + " " + "Surname: " + Surname + " Phone Number: " + PhoneNumber + " Id Card Number: "
                + IdCardNumber + " Vin Numbers: ";

            bool isEmpty = VinNumbers == null;
            if (!isEmpty)
            {
                for (int i = 0; i < VinNumbers.Count; i++)
                {
                    toString = toString + VinNumbers[i] + ", ";
                }
            }

            return toString;
        }
    }
}