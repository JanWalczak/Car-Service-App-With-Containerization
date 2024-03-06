namespace Ssjw.EAutoService.EmployeesDataUSvc.ConsoleApp
{
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            EmployeeDataUSvcClient employeeSvc = new EmployeeDataUSvcClient();

            Console.WriteLine("Num of employees at start: " + employeeSvc.GetNumberOfEmployees().ToString());
            employeeSvc.GetAllEmployees();
            List<string> services = new List<string>
            {
                "test1",
                "test2",
                "test3"
            };
            employeeSvc.AddEmployeeToDB(new EmployeeDto() { name = "ntest4", surname = "surtest4", phoneNumber = "123456789", jobPosition = "mechanic", salary = "1500", services = services });
            Console.WriteLine("after adding employee with surname surtest4:");
            employeeSvc.GetAllEmployees();
            Console.WriteLine("Having removed employee with surname surtest4:");
            employeeSvc.RemoveEmployeeFromDB("4");
            employeeSvc.GetAllEmployees();
            Console.WriteLine("show employee services with id 3:");
            List<string> servicesofEmployee3 = employeeSvc.GetEmployeeServices("3");
            foreach (string i in servicesofEmployee3)
            {
                Console.WriteLine(i);
            }
            EmployeeDto employeeSurnamePhoneNumber = employeeSvc.GetEmployeeSurnamePhoneNumber("3");
            Console.WriteLine("EmployeeSurnamePhoneNumber id 3:");
            Console.WriteLine(employeeSurnamePhoneNumber.surname, employeeSurnamePhoneNumber.phoneNumber);
            Console.WriteLine("Number of employees: " + employeeSvc.GetNumberOfEmployees().ToString());
            Console.WriteLine("EmployeeNameSurnameSalary id 3:");
            Console.WriteLine(employeeSvc.GetEmployeeNameSurnameSalary("3").name + employeeSvc.GetEmployeeNameSurnameSalary("3").surname + employeeSvc.GetEmployeeNameSurnameSalary("3").phoneNumber);
            employeeSvc.AddEmployeeToDB(new EmployeeDto() { name = "ntest5", surname = "surtest5", phoneNumber = "123456789", jobPosition = "mechanic", salary = "1500", services = services });
            employeeSvc.AddEmployeeToDB(new EmployeeDto() { name = "ntest6", surname = "surtest6", phoneNumber = "123456789", jobPosition = "mechanic", salary = "1500", services = services });
            Console.WriteLine("Show only mechanics:");
            foreach (EmployeeDto t in employeeSvc.GetAllEmployeesWithSpecifiedPosition("mechanic"))
            {
                Console.WriteLine(t.id + t.name + t.surname + t.jobPosition);
            }
            employeeSvc.RemoveEmployeeService("test2");
            Console.WriteLine("After remvoing service test2 from all employees:");
            foreach (EmployeeDto dtoTemp in employeeSvc.GetAllEmployees())
            {
                foreach (string s in dtoTemp.services)
                {
                    Console.WriteLine(dtoTemp.id + " " + s);
                }
            }
            List<string> servicesToAdd = new List<string>
            {
                "test1dod",
                "test2dod",
                "test3dod"
            };
            employeeSvc.AddServiceToEmployee("3", servicesToAdd);
            Console.WriteLine("After adding, services in employee with id = 3");
            foreach (string s in employeeSvc.GetEmployeeById("3").services)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("----------MOCK CLIENT----------");
            EmployeeDataUSvcMockClient mockemployeeSvc = new EmployeeDataUSvcMockClient();
            Console.WriteLine("Num of employees: " + mockemployeeSvc.GetNumberOfEmployees().ToString());
            foreach (EmployeeDto t in mockemployeeSvc.GetAllEmployees())
            {
                Console.WriteLine(t.id + t.name + t.surname);
            }
            mockemployeeSvc.AddEmployeeToDB(new EmployeeDto() { name = "test3", surname = "test3", phoneNumber = "123456789", jobPosition = "mechanic2", salary = "1234", services = services });
            Console.WriteLine("after adding: ");
            foreach (EmployeeDto t in mockemployeeSvc.GetAllEmployees())
            {
                Console.WriteLine(t.id + t.name + t.surname);
            }
            mockemployeeSvc.RemoveEmployeeFromDB("2");
            Console.WriteLine("after removing employee with id 3:");
            foreach (EmployeeDto t in mockemployeeSvc.GetAllEmployees())
            {
                Console.WriteLine(t.id + t.name + t.surname);
            }
            Console.WriteLine("Show just mechanic2: ");
            foreach (EmployeeDto t in mockemployeeSvc.GetAllEmployeesWithSpecifiedPosition("mechanic2"))
            {
                Console.WriteLine(t.id + t.name + t.surname + t.jobPosition.ToString());
            }
            mockemployeeSvc.RemoveEmployeeService("test2");
            Console.WriteLine("After remvoing service test2 from all employees:");
            foreach (EmployeeDto t in mockemployeeSvc.GetAllEmployees())
            {
                foreach (string s in t.services)
                {
                    Console.WriteLine(t.id + " " + s);
                }
            }
            mockemployeeSvc.AddServiceToEmployee("3", servicesToAdd);
            Console.WriteLine("After adding, services in employee with id = 3");
            foreach (string s in mockemployeeSvc.GetEmployeeById("3").services)
            {
                Console.WriteLine(s);
            }
        }
    }
}