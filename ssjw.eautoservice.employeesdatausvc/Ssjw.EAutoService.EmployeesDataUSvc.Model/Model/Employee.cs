namespace Ssjw.EAutoService.EmployeesDataUSvc.Model.Model
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string JobPosition { get; set; }
        public string Salary { get; set; }
        public List<string> Services { get; set; }

        [JsonConstructor]
        public Employee(string id, string name, string surname, string phoneNumber, string jobPosition, string salary, List<string> services)
        {
            Id = id;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            JobPosition = jobPosition;
            Salary = salary;
            Services = services;
        }
        public Employee(string name, string surname, string phoneNumber, string jobPosition, string salary, List<string> services)
        {
            Id = "";
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            JobPosition = jobPosition;
            Salary = salary;
            Services = services;
        }
        public override string ToString()
        {
            string ts = "Id:" + Id + "Name: " + Name + " " + "Surname: " + Surname + " Phone Number: " + PhoneNumber + " Job Position: " + JobPosition
                + " salary: " + Salary;
            foreach (string i in Services)
            {
                ts += i;
                ts += ",";
            }
            return ts;
        }
    }
}
