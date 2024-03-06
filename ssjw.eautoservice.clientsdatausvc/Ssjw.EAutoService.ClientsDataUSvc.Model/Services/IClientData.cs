namespace Ssjw.EAutoService.ClientsDataUSvc.Model.Services
{
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Model;

    public interface IClientData
    {
        public List<Client> GetAllClients();
        public void AddClientToData(Client client);
        public void RemoveClientFromData(string idCardNumber);
        public Client FindClientByIdCard(string idCardNumber);
        public Client GetClientsNameSurname(string idCardNumber);
        public Client GetClientsSurnamePhoneNumber(string idCardNumber);
        public List<string> GetAllIds();
        public void AddCarToClient(string idCardNumber, string vinNumber);
    }
}