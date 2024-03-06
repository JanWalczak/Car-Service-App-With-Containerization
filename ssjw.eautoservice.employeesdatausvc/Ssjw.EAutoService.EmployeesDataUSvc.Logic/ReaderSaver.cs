namespace Ssjw.EAutoService.EmployeesDataUSvc.Logic
{
    using Ssjw.EAutoService.EmployeesDataUSvc.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    public class ReaderSaver
    {
        private static string EmployeeDataFileName = "StartEmployeeData.json";
        public static void SaveEmployeeData()
        {
            File.WriteAllText(EmployeeDataFileName, JsonSerializer.Serialize(EmployeeData.listOfEmployees));
        }
        public static List<Employee> ReadEmployeesFromFile(string fileName)
        {
            try
            {
                string jsonString = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<List<Employee>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
