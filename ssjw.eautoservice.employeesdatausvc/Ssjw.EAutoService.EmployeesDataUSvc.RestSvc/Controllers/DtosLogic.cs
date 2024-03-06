namespace Ssjw.EAutoService.EmployeesDataUSvc.RestSvc.Controllers
{
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using System.Collections.Generic;
    public class DtosLogic
    {
        public static List<Employee> CreateEmployeesFromDTO(List<EmployeeDto> list)
        {
            return list.Select(list => new Employee(list.id, list.name, list.surname, list.phoneNumber, list.jobPosition, list.salary, list.services)).ToList();
        }
        public static List<EmployeeDto> CreateDTOFromEmployees(List<Employee> list)
        {
            List<EmployeeDto> dtos = new List<EmployeeDto>();

            for (int i = 0; i < list.Count; i++)
            {
                dtos.Add(new EmployeeDto()
                {
                    id = list[i].Id,
                    name = list[i].Name,
                    surname = list[i].Surname,
                    phoneNumber = list[i].PhoneNumber,
                    jobPosition = list[i].JobPosition,
                    salary = list[i].Salary,
                    services = list[i].Services
                });
            }

            return dtos;
        }
        public static Employee CreateEmployeeFromOneDTO(EmployeeDto dto)
        {
            return new Employee(dto.id, dto.name, dto.surname, dto.phoneNumber, dto.jobPosition, dto.salary, dto.services);
        }
        public static EmployeeDto CreateDTOFromOneEmployee(Employee tempEmployee)
        {
            return new EmployeeDto()
            {
                id = tempEmployee.Id,
                name = tempEmployee.Name,
                surname = tempEmployee.Surname,
                phoneNumber = tempEmployee.PhoneNumber,
                jobPosition = tempEmployee.JobPosition,
                salary = tempEmployee.Salary,
                services = tempEmployee.Services
            };
        }
    }
}
