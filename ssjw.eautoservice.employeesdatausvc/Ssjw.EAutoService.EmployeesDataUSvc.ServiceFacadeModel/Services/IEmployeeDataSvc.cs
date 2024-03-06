namespace Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services
{
    using System.Collections.Generic;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    public interface IEmployeeDataSvc
    {
        public List<EmployeeDto> GetAllEmployees();
        public void AddEmployeeToDB(EmployeeDto employeeDto);
        public void RemoveEmployeeFromDB(string id);
        public EmployeeDto GetEmployeeById(string id);
        public EmployeeDto GetEmployeeNameSurnameSalary(string id);
        public EmployeeDto GetEmployeeNameSurnameSalaryServices(string id);
        public List<EmployeeDto> GetAllEmployeesWithSpecifiedPosition(string jobPosition);
        public EmployeeDto GetEmployeeSurnamePhoneNumber(string id);
        public int GetNumberOfEmployees();
        public List<string> GetEmployeeServices(string id);
        public void RemoveEmployeeService(string serviceId);
        public void AddServiceToEmployee(string id, List<string> services);
    }
}
