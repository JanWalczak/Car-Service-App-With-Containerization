namespace Ssjw.EAutoService.ClientsDataUSvc.RestClient
{
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services;

    public class ClientDataUSvcMockClient : IClientDataSvc
    {
        private List<ClientDto> clientDtos = new List<ClientDto>();
        public ClientDataUSvcMockClient()
        {
            clientDtos.Add(new ClientDto()
            {
                Name = "Kamil",
                Surname = "Kowalski",
                PhoneNumber = "123456789",
                IdCardNumber = "test1",
                VinNumbers = new List<string> { "41414154" }
            });

            clientDtos.Add(new ClientDto()
            {
                Name = "Marian",
                Surname = "Nowak",
                PhoneNumber = "098765432",
                IdCardNumber = "test2",
                VinNumbers = new List<string> { "131411414" }
            });

            clientDtos.Add(new ClientDto()
            {
                Name = "Andrzej",
                Surname = "Wiśniewski",
                PhoneNumber = "135790864",
                IdCardNumber = "test3",
                VinNumbers = new List<string> { "11111661" }
            });
        }

        public void AddClientToData(ClientDto clientDto)
        {
            clientDtos.Add(clientDto);
        }

        public ClientDto FindClientByIdCard(string idCardNumber)
        {
            foreach (ClientDto clientDto in clientDtos)
            {
                string clientsIdCardNumber = clientDto.IdCardNumber;
                if (clientsIdCardNumber.Equals(idCardNumber))
                {
                    printClientDto(clientDto);
                    return clientDto;
                }
            }

            Console.WriteLine("Client with " + idCardNumber + " doesn't exist!");
            return null;
        }

        public List<ClientDto> GetAllClients()
        {
            foreach (ClientDto clientDto in clientDtos)
            {
                printClientDto(clientDto);
            }

            return clientDtos;
        }

        public void AddCarToClient(string idCardNumber, string vinNumber)
        {
            ClientDto foundClient = FindClientByIdCard(idCardNumber);

            bool isNull = foundClient == null;
            if (!isNull)
            {
                foundClient.VinNumbers.Add(vinNumber);
            }
        }

        public List<string> GetAllIds()
        {
            List<string> idCardNumbers = new List<string>();

            foreach (ClientDto clientDto in clientDtos)
            {
                Console.WriteLine(clientDto.IdCardNumber + "\n");
                idCardNumbers.Add(clientDto.IdCardNumber);
            }

            return idCardNumbers;
        }

        public ClientDto GetClientsNameSurname(string idCardNumber)
        {
            foreach (ClientDto clientDto in clientDtos)
            {
                string clientsIdCardNumber = clientDto.IdCardNumber;
                if (clientsIdCardNumber.Equals(idCardNumber))
                {
                    ClientDto foundClientDto = new ClientDto() { Name = clientDto.Name, Surname = clientDto.Surname };
                    printClientDto(foundClientDto);
                    return foundClientDto;
                }
            }

            return null;
        }

        public ClientDto GetClientsSurnamePhoneNumber(string idCardNumber)
        {
            foreach (ClientDto clientDto in clientDtos)
            {
                string clientsIdCardNumber = clientDto.IdCardNumber;
                if (clientsIdCardNumber.Equals(idCardNumber))
                {
                    ClientDto foundClientDto = new ClientDto() { Surname = clientDto.Surname, PhoneNumber = clientDto.PhoneNumber };
                    printClientDto(foundClientDto);
                    return foundClientDto;
                }
            }

            return null;
        }

        public void RemoveClientFromData(string idCardNumber)
        {
            ClientDto removedClient = new ClientDto();

            foreach (ClientDto clientDto in clientDtos)
            {
                string clientsIdCardNumber = clientDto.IdCardNumber;
                if (clientsIdCardNumber.Equals(idCardNumber))
                {
                    removedClient = clientDto;
                }
            }

            clientDtos.Remove(removedClient);
        }

        private void printClientDto(ClientDto clientDto)
        {
            string toString = "Name: " + clientDto.Name + " " + "Surname: " + clientDto.Surname + " Phone Number: "
                + clientDto.PhoneNumber + " Id Card Number: " + clientDto.IdCardNumber + " Vin Numbers: ";

            bool isEmpty = clientDto.VinNumbers == null;
            if (!isEmpty)
            {
                for (int i = 0; i < clientDto.VinNumbers.Count; i++)
                {
                    toString = toString + clientDto.VinNumbers[i] + ", ";
                }
            }

            Console.WriteLine(toString + "\n");
        }
    }
}
