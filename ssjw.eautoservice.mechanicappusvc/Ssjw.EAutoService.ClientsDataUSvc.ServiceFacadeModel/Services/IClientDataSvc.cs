namespace Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;

    public interface IClientDataSvc
    {
        public List<ClientDto> GetAllClients();
        public void AddClientToData(ClientDto clientDto);
        public void RemoveClientFromData(string idCardNumber);
        public ClientDto FindClientByIdCard(string idCardNumber);
        public ClientDto GetClientsNameSurname(string idCardNumber);
        public ClientDto GetClientsSurnamePhoneNumber(string idCardNumber);
        public List<string> GetAllIds();
    }
}
