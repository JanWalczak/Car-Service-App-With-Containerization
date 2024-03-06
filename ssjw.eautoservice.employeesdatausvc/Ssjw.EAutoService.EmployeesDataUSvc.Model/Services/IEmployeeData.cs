namespace Ssjw.EAutoService.EmployeesDataUSvc.Model.Services
{
    using System.Collections.Generic;
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Model;
    public interface IEmployeeData
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployeeToDB(Employee employee);
        public void RemoveEmployeeFromDB(string id);
        public Employee GetEmployeeById(string id);
        public Employee GetEmployeeNameSurnameSalary(string id);
        public Employee GetEmployeeNameSurnameSalaryServices(string id);
        public List<Employee> GetAllEmployeesWithSpecifiedPosition(string jobPosition);
        public Employee GetEmployeeSurnamePhoneNumber(string id);
        public int GetNumberOfEmployees();
        public List<string> GetEmployeeServices(string id);
        public void RemoveEmployeeService(string serviceId);
        public void AddServiceToEmployee(string id, List<string> services);
    }
}
