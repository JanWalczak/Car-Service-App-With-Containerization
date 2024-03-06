namespace Ssjw.EAutoService.MechanicAppUSvc.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ssjw.EAutoService.MechanicAppUSvc.RestClient;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;

    [TestClass]
    public class MechanicAppUSvcTests
    {
        [TestMethod]
        public void GetAllClients_test()
        {
            IMechanicAppDto client = new MechanicAppUSvcMockClient();
            Assert.AreEqual(client.GetAllClients().Count(), 3);
        }
    }
}