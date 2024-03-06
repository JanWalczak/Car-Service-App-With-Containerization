namespace Ssjw.EAutoService.ServicesDataUSvc.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services;

    [TestClass]
    public class ServicesDataTests
    {

        [TestMethod]
        public void GetInspectionByIdTest_checkVin()
        {
            IInspectionsDataDto client = new ServicesDataUSvcMockClient();

            string vinNumber = client.FindInspectionById("i2").VinNumber;

            Assert.AreEqual("131411414", vinNumber);
        }

        [TestMethod]
        public void GetRepairById_checkPrice()
        {
            IRepairsDataDto client = new ServicesDataUSvcMockClient();

            double price = client.FindRepairById("r2").Price;
            Assert.AreEqual(400, price);
        }

        [TestMethod]
        public void GetServicesByEmployeeId_checkAmount()
        {
            ServicesDataUSvcMockClient client = new ServicesDataUSvcMockClient();

            List<string> services = client.GetServicesByEmployeeId("2");
            int servicesCount = services.Count();

            Assert.AreEqual(5, servicesCount);
        }

        [TestMethod]
        public void GetInspectionsByVinNumber_checkAmount()
        {
            IInspectionsDataDto client = new ServicesDataUSvcMockClient();

            List<InspectionDto> inspections = client.GetInspectionsByVinNumber("41414154");
            int inspectionsCount = inspections.Count();

            Assert.AreEqual(2, inspectionsCount);
        }

        [TestMethod]
        public void GetAllRepairs_checkAmount()
        {
            ServicesDataUSvcMockClient client = new ServicesDataUSvcMockClient();

            List<RepairDto> services = client.GetAllRepairs();
            int repairsCount = services.Count();

            Assert.AreEqual(6, repairsCount);
        }
    }
}