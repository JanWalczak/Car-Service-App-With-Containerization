namespace Ssjw.EAutoService.ClientsDataUSvc.RestSvc.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Ssjw.EAutoService.ClientsDataUSvc.Logic;
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services;


    [ApiController]
    [Route("[controller]")]
    public class ClientDataController : ControllerBase, IClientDataSvc
    {
        private readonly ILogger<ClientDataController> logger;
        private ClientData clientData;

        public ClientDataController(ILogger<ClientDataController> logger)
        {
            this.logger = logger;
            clientData = new ClientData();
        }

        [HttpPost]
        [Route("AddClientToData")]
        public void AddClientToData(ClientDto clientDto)
        {
            clientData.AddClientToData(DtosLogic.CreateClientFromOneDto(clientDto));
        }

        [HttpGet]
        [Route("FindClientByIdCard")]
        public ClientDto FindClientByIdCard(string idCardNumber)
        {
            Client foundClient = clientData.FindClientByIdCard(idCardNumber);
            return DtosLogic.CreateDtoFromOneClient(foundClient);
        }

        [HttpPost]
        [Route("AddCarToClient")]
        public void AddCarToClient(string idCardNumber, string vinNumber)
        {
            clientData.AddCarToClient(idCardNumber, vinNumber);
        }

        [HttpPost]
        [Route("RemoveClientFromData")]
        public void RemoveClientFromData(string idCardNumber)
        {
            clientData.RemoveClientFromData(idCardNumber);
        }

        [HttpGet]
        [Route("GetAllClients")]
        public List<ClientDto> GetAllClients()
        {
            return DtosLogic.CreateDtoFromClients(clientData.GetAllClients());
        }

        [HttpGet]
        [Route("GetClientsNameSurname")]
        public ClientDto GetClientsNameSurname(string idCardNumber)
        {
            Client foundClient = clientData.FindClientByIdCard(idCardNumber);

            ClientDto clientDto = new ClientDto()
            {
                Name = foundClient.Name,
                Surname = foundClient.Surname
            };

            return clientDto;
        }

        [HttpGet]
        [Route("GetClientsSurnamePhoneNumber")]
        public ClientDto GetClientsSurnamePhoneNumber(string idCardNumber)
        {
            Client foundClient = clientData.FindClientByIdCard(idCardNumber);

            ClientDto clientDto = new ClientDto()
            {
                Surname = foundClient.Surname,
                PhoneNumber = foundClient.PhoneNumber
            };

            return clientDto;
        }

        [HttpGet]
        [Route("GetAllIds")]
        public List<string> GetAllIds()
        {
            return clientData.GetAllIds();
        }
    }
}
