namespace Ssjw.EAutoService.EmployeesDataUSvc.Logic
{
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Services;
    public class EmployeeData : IEmployeeData
    {
        private static string FileName = "StartEmployeeData.json";
        public static List<Employee> listOfEmployees = new List<Employee>();
        private static int employeeId = 0;

        static EmployeeData()
        {
            listOfEmployees = ReaderSaver.ReadEmployeesFromFile(FileName);
            employeeId = int.Parse(listOfEmployees.Last().Id);
            employeeId++;
        }
        public void AddEmployeeToDB(Employee employee)
        {
            listOfEmployees.Add(new Employee(employeeId.ToString(), employee.Name, employee.Surname, employee.PhoneNumber, employee.JobPosition, employee.Salary, employee.Services));
            employeeId++;
            ReaderSaver.SaveEmployeeData();
        }
        public Employee GetEmployeeById(string id)
        {
            foreach (Employee employee in listOfEmployees)
            {
                if (employee.Id.Equals(id))
                {
                    return employee;
                }
            }
            return null;
        }
        public List<Employee> GetAllEmployees()
        {
            return listOfEmployees;
        }
        public Employee GetEmployeeNameSurnameSalary(string id)
        {
            return GetEmployeeById(id);
        }
        public Employee GetEmployeeNameSurnameSalaryServices(string id)
        {
            return GetEmployeeById(id);
        }
        public Employee GetEmployeeSurnamePhoneNumber(string id)
        {
            return GetEmployeeById(id);
        }
        public int GetNumberOfEmployees()
        {
            return listOfEmployees.Count;
        }
        public List<Employee> GetAllEmployeesWithSpecifiedPosition(string jobPosition)
        {
            List<Employee> tempEmployeesList = new List<Employee>();
            foreach (Employee employee in listOfEmployees)
            {
                if (employee.JobPosition.Equals(jobPosition))
                {
                    tempEmployeesList.Add(employee);
                }
            }
            return tempEmployeesList;
        }

        public void RemoveEmployeeFromDB(string id)
        {
            Employee tempEmplyee = GetEmployeeById(id);
            listOfEmployees.Remove(tempEmplyee);
            ReaderSaver.SaveEmployeeData();
        }
        public List<string> GetEmployeeServices(string id)
        {
            List<string> toReturn = new List<string>();
            if (GetEmployeeById(id) == null) return null;
            if (GetEmployeeById(id).Services != null)
            {
                toReturn = GetEmployeeById(id).Services;

                foreach (string i in toReturn)
                {
                    Console.WriteLine("Service: " + i);
                }
                return toReturn;
            }
            else
            {
                return null;
            }
        }
        public void RemoveEmployeeService(string serviceId)
        {
            foreach (Employee e in listOfEmployees)
            {
                if (e.Services.Contains(serviceId))
                {
                    e.Services.Remove(serviceId);
                }
            }
            ReaderSaver.SaveEmployeeData();
        }
        public void AddServiceToEmployee(string id, List<string> services)
        {
            Employee e = GetEmployeeById(id);
            foreach (string s in services)
            {
                e.Services.Add(s);
            }
            ReaderSaver.SaveEmployeeData();
        }
    }
}