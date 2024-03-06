namespace Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Ssjw.EAutoService.EmployeesDataUSvc.Logic;
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services;

    [ApiController]
    [Route("[controller]")]
    public class EmployeeDataController : ControllerBase, IEmployeeDataSvc
    {

        private readonly ILogger<EmployeeDataController> logger;
        private EmployeeData employeeData;
        public EmployeeDataController(ILogger<EmployeeDataController> logger)
        {
            this.logger = logger;
            employeeData = new EmployeeData();
        }

        [HttpPost]
        [Route("AddEmployeeToDB")]
        public void AddEmployeeToDB(EmployeeDto employeeDto)
        {
            try
            {
                employeeData.AddEmployeeToDB(DtosLogic.CreateEmployeeFromOneDTO(employeeDto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public EmployeeDto GetEmployeeById(string id)
        {
            Employee foundEmployee = employeeData.GetEmployeeById(id);
            if (foundEmployee == null)
            {
                return new EmployeeDto();
            }
            else
            {
                return DtosLogic.CreateDTOFromOneEmployee(foundEmployee);
            }

        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public List<EmployeeDto> GetAllEmployees()
        {
            try
            {
                return DtosLogic.CreateDTOFromEmployees(employeeData.GetAllEmployees());
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetAllEmployeesWithSpecifiedPosition")]
        public List<EmployeeDto> GetAllEmployeesWithSpecifiedPosition(string jobPosition)
        {
            try
            {
                return DtosLogic.CreateDTOFromEmployees(employeeData.GetAllEmployeesWithSpecifiedPosition(jobPosition));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetEmployeeNameSurnameSalary")]
        public EmployeeDto GetEmployeeNameSurnameSalary(string id)
        {
            try
            {
                Employee tempEmp = employeeData.GetEmployeeById(id);
                if (tempEmp == null) return null;
                EmployeeDto readyDtoClient = new EmployeeDto() { name = tempEmp.Name, surname = tempEmp.Surname, salary = tempEmp.Salary };
                return readyDtoClient;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        [HttpGet]
        [Route("GetEmployeeNameSurnameSalaryServices")]
        public EmployeeDto GetEmployeeNameSurnameSalaryServices(string id)
        {
            try
            {
                Employee tempEmp = employeeData.GetEmployeeById(id);
                if (tempEmp == null) return null;
                EmployeeDto readyDtoClient = new EmployeeDto() { name = tempEmp.Name, surname = tempEmp.Surname, salary = tempEmp.Salary, services = tempEmp.Services };
                return readyDtoClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetEmployeeSurnamePhoneNumber")]
        public EmployeeDto GetEmployeeSurnamePhoneNumber(string id)
        {
            try
            {
                Employee tempEmp = employeeData.GetEmployeeById(id);
                if (tempEmp == null) return null;
                EmployeeDto readyDtoClient = new EmployeeDto() { surname = tempEmp.Surname, phoneNumber = tempEmp.PhoneNumber };
                return readyDtoClient;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpGet]
        [Route("GetNumberOfEmployees")]
        public int GetNumberOfEmployees()
        {
            try
            {
                return employeeData.GetNumberOfEmployees();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        [HttpPost]
        [Route("RemoveEmployeeFromDB")]
        public void RemoveEmployeeFromDB(string id)
        {
            try
            {
                employeeData.RemoveEmployeeFromDB(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [HttpGet]
        [Route("GetEmployeeServices")]
        public List<string> GetEmployeeServices(string id)
        {
            try
            {
                if (employeeData.GetEmployeeServices(id) != null)
                {
                    return employeeData.GetEmployeeServices(id);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("RemoveEmployeeService")]
        public void RemoveEmployeeService(string serviceId)
        {
            try
            {
                employeeData.RemoveEmployeeService(serviceId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        [HttpPost]
        [Route("AddServiceToEmployee")]
        public void AddServiceToEmployee(string id, List<string> services)
        {
            try
            {
                employeeData.AddServiceToEmployee(id, services);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
