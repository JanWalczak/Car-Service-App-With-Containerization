namespace Ssjw.EAutoService.ClientsDataUSvc.RestSvc.Controllers
{
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;

    public class DtosLogic
    {
        public static List<Client> CreateClientsFromDto(List<ClientDto> clientDtoList)
        {
            return clientDtoList.Select(
                list => new Client(list.Name, list.Surname, list.PhoneNumber, list.IdCardNumber, list.VinNumbers)).ToList();
        }

        public static List<ClientDto> CreateDtoFromClients(List<Client> clientList)
        {
            List<ClientDto> clientDtoList = new List<ClientDto>();

            foreach (Client client in clientList)
            {
                clientDtoList.Add(new ClientDto()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    PhoneNumber = client.PhoneNumber,
                    IdCardNumber = client.IdCardNumber,
                    VinNumbers = client.VinNumbers
                });
            }

            return clientDtoList;
        }

        public static Client CreateClientFromOneDto(ClientDto clientDto)
        {
            return new Client(clientDto.Name, clientDto.Surname, clientDto.PhoneNumber, clientDto.IdCardNumber, clientDto.VinNumbers);
        }

        public static ClientDto CreateDtoFromOneClient(Client clientDto)
        {
            return new ClientDto()
            {
                Name = clientDto.Name,
                Surname = clientDto.Surname,
                PhoneNumber = clientDto.PhoneNumber,
                IdCardNumber = clientDto.IdCardNumber,
                VinNumbers = clientDto.VinNumbers
            };
        }
    }
}
