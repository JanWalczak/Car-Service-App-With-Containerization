namespace Ssjw.EAutoService.ClientAppUSvc.Tests
{
    using Ssjw.EAutoService.ClientAppUSvc.RestClient;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;

    [TestClass]
    public class RestClientTests
    {
        [TestMethod]
        public void GetAvailableMechanicsTest()
        {
            ClientAppUSvcMockClient client = new ClientAppUSvcMockClient();
            List<ExtendedEmployeeDto> avaiableMechanicsList = client.GetAvailableMechanics(new DateTime(2020, 12, 12));
            int avaiableMechanicsThatDay = 3;
            Assert.AreEqual(avaiableMechanicsList.Count, avaiableMechanicsThatDay);
        }
    }
}