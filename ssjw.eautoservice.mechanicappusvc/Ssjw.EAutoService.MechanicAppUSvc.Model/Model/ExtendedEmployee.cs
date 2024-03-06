namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model
{
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services;

    public class ExtendedEmployee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string JobPosition { get; set; }
        public string Id { get; set; }
        public string Salary { get; set; }
        public List<ExtendedInspection> ServicesInspection { get; set; }
        public List<ExtendedRepair> ServicesRepair { get; set; }


        public ExtendedEmployee(string id, string name, string surname, string phoneNumber, string jobPosition, string salary,
            List<ExtendedInspection> servicesInspection, List<ExtendedRepair> servicesRepair)
        {
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phoneNumber;
            this.JobPosition = jobPosition;
            this.Salary = salary;
            this.ServicesInspection = servicesInspection;
            this.ServicesRepair = servicesRepair;
        }

        public override string ToString()
        {
            return "Name: " + Name + " " + "Surname: " + Surname + " Phone Number: " + PhoneNumber + " Job Position: " + JobPosition + " salary: " + Salary + " id:" + Id;
        }
    }
}