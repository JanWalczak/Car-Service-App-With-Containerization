namespace Ssjw.EAutoService.EmployeesDataUSvc.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services;
    [TestClass]
    public class EmployeeDataUSvcTests
    {
        [TestMethod]
        public void GetEmployeeById_checkPhoneNumber()
        {
            IEmployeeDataSvc client = new EmployeeDataUSvcMockClient();
            Assert.AreEqual(client.GetEmployeeById("1").phoneNumber, "phtest1");
        }
        [TestMethod]
        public void GetEmployeeNameSurname_checkIfPhoneNumberIsNull()
        {
            IEmployeeDataSvc client = new EmployeeDataUSvcMockClient();
            Assert.AreEqual(client.GetEmployeeNameSurnameSalary("1").phoneNumber,null);
        }
    }
}