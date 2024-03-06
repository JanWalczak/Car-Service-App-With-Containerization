namespace Ssjw.EAutoService.ClientsDataUSvc.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services;

    [TestClass]
    public class ClientsDataUSvcTests
    {
        [TestMethod]
        public void GetClientById_checkSurname()
        {
            IClientDataSvc client = new ClientDataUSvcMockClient();

            ClientDto clientDto = client.FindClientByIdCard("test1");

            Assert.AreEqual("Kowalski", clientDto.Surname);
        }

        [TestMethod]
        public void GetClientNameSurname_checkIfPhoneNumberIsNull()
        {
            IClientDataSvc client = new ClientDataUSvcMockClient();

            ClientDto clientDto = client.GetClientsNameSurname("test1");

            Assert.AreEqual(null, clientDto.PhoneNumber);
        }

        [TestMethod]
        public void GetClientsSurnamePhoneNumber_checkSurname()
        {
            IClientDataSvc client = new ClientDataUSvcMockClient();

            ClientDto clientDto = client.GetClientsSurnamePhoneNumber("test1");

            Assert.AreEqual("Kowalski", clientDto.Surname);
        }

        [TestMethod]
        public void GetAllClients_checkAmount()
        {
            IClientDataSvc client = new ClientDataUSvcMockClient();

            List<ClientDto> clients = client.GetAllClients();
            int clientsCount = clients.Count;

            Assert.AreEqual(3, clientsCount);
        }

        [TestMethod]
        public void RemoveClientFromData_checkAmount()
        {
            IClientDataSvc client = new ClientDataUSvcMockClient();

            List<ClientDto> clients = client.GetAllClients();
            int clientsCount = clients.Count;

            Assert.AreEqual(3, clientsCount);

            client.RemoveClientFromData("test1");

            clients = client.GetAllClients();
            clientsCount = clients.Count;

            Assert.AreEqual(2, clientsCount);
        }
    }
}