namespace Ssjw.EAutoService.EmployeesDataUSvc.RestClient
{
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services;
    using System.Collections.Generic;

    public class EmployeeDataUSvcMockClient : IEmployeeDataSvc
    {
        public List<EmployeeDto> mockEmployeeList = new List<EmployeeDto>();

        private int counter = 3;
        public EmployeeDataUSvcMockClient()
        {
            
            mockEmployeeList.Add(new EmployeeDto() { id = "1", name = "ntest1", surname = "sntest1", phoneNumber = "phtest1", jobPosition = "jptest1", salary = "saltest1", services = new List<string> { "i1", "i2", "r1", "r2" } });
            mockEmployeeList.Add(new EmployeeDto() { id = "2", name = "ntest2", surname = "sntest2", phoneNumber = "phtest2", jobPosition = "jptest2", salary = "saltest2", services = new List<string> { "i3", "i4", "r3", "r4" } });
            mockEmployeeList.Add(new EmployeeDto() { id = "3", name = "ntest3", surname = "sntest3", phoneNumber = "phtest3", jobPosition = "jptest3", salary = "saltest3", services = new List<string> { "i5", "i6", "r5", "r6" } });
        }

        public void AddEmployeeToDB(EmployeeDto employeeDto)
        {
            mockEmployeeList.Add(new EmployeeDto() { id = this.counter.ToString(), name = employeeDto.name, surname = employeeDto.surname, phoneNumber = employeeDto.phoneNumber, jobPosition = employeeDto.jobPosition, salary = employeeDto.salary, services = employeeDto.services });
            counter++;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            return mockEmployeeList;
        }

        public List<EmployeeDto> GetAllEmployeesWithSpecifiedPosition(string jobPosition)
        {
            List<EmployeeDto> tempEmployeesList = new List<EmployeeDto>();
            foreach (EmployeeDto employeet in mockEmployeeList)
            {
                if (employeet.jobPosition.Equals(jobPosition))
                {
                    tempEmployeesList.Add(employeet);
                }
            }
            return tempEmployeesList;
        }

        public EmployeeDto GetEmployeeById(string id)
        {
            foreach (EmployeeDto employee in mockEmployeeList)
            {
                if (employee.id.Equals(id))
                {
                    return employee;
                }
            }
            return null;
        }

        public EmployeeDto GetEmployeeNameSurnameSalary(string id)
        {
            EmployeeDto tempEmployee = GetEmployeeById(id);
            return new EmployeeDto() { name = tempEmployee.name, surname = tempEmployee.surname, salary = tempEmployee.salary };
        }

        public EmployeeDto GetEmployeeNameSurnameSalaryServices(string id)
        {
            EmployeeDto tempEmployee = GetEmployeeById(id);
            return new EmployeeDto() { name = tempEmployee.name, surname = tempEmployee.surname, salary = tempEmployee.salary, services = tempEmployee.services };
        }

        public EmployeeDto GetEmployeeSurnamePhoneNumber(string id)
        {
            EmployeeDto tempEmployee = GetEmployeeById(id);
            return new EmployeeDto() { surname = tempEmployee.surname, phoneNumber = tempEmployee.phoneNumber };
        }

        public int GetNumberOfEmployees()
        {
            return mockEmployeeList.Count;
        }

        public void RemoveEmployeeFromDB(string id)
        {
            mockEmployeeList.Remove(GetEmployeeById(id));
        }

        public List<string> GetEmployeeServices(string id)
        {
            List<string> employeeServices = new List<string>();
            employeeServices = GetEmployeeById(id).services;
            return employeeServices;
        }

        public void RemoveEmployeeService(string serviceId)
        {

            foreach (EmployeeDto e in mockEmployeeList)
            {
                if (e.services.Contains(serviceId))
                {
                    e.services.Remove(serviceId);
                }
            }
        }
        public void AddServiceToEmployee(string id, List<string> services)
        {
            EmployeeDto tempEmployee = GetEmployeeById(id);
            foreach (string s in services)
            {
                tempEmployee.services.Add(s);
            }

        }
    }
}
