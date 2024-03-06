namespace Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model
{
    using System.Collections.Generic;

    public class EmployeeDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string jobPosition { get; set; }
        public string salary { get; set; }
        public List<string> services { get; set; }
    }
}
