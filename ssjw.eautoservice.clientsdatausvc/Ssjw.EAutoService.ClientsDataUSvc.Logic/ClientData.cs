namespace Ssjw.EAutoService.ClientsDataUSvc.Logic
{
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Services;

    public class ClientData : IClientData
    {
        private static string clientDataFileName = "StartupData.json";
        public static List<Client> Clients = new List<Client>();

        static ClientData()
        {
            Clients = JsonReaderSaver.ReadClientsFromFile(clientDataFileName);
        }

        public List<Client> GetAllClients()
        {
            return Clients;
        }

        public void AddClientToData(Client client)
        {
            Clients.Add(client);
            JsonReaderSaver.SaveClientData();
        }

        public void RemoveClientFromData(string idCardNumber)
        {
            Client removedClient = FindClientByIdCard(idCardNumber);

            bool isNull = removedClient == null;
            if (!isNull)
            {
                Clients.Remove(removedClient);
            }

            JsonReaderSaver.SaveClientData();
        }

        public Client FindClientByIdCard(string idCardNumber)
        {
            foreach (Client client in Clients)
            {
                string clientsIdCardNumber = client.IdCardNumber;
                if (clientsIdCardNumber.Equals(idCardNumber))
                {
                    return client;
                }
            }

            Console.WriteLine("Client with " + idCardNumber + " doesn't exist!");
            return null;
        }

        public Client GetClientsNameSurname(string idCardNumber)
        {
            Client client = FindClientByIdCard(idCardNumber);
            return client;
        }

        public Client GetClientsSurnamePhoneNumber(string idCardNumber)
        {
            Client client = FindClientByIdCard(idCardNumber);
            return client;
        }

        public List<string> GetAllIds()
        {
            List<string> idCardNumbers = new List<string>();

            foreach (Client clientIterator in Clients)
            {
                idCardNumbers.Add(clientIterator.IdCardNumber);
            }

            return idCardNumbers;
        }

        public void AddCarToClient(string idCardNumber, string vinNumber)
        {
            Client foundClient = FindClientByIdCard(idCardNumber);

            bool isNull = foundClient == null;
            if (!isNull)
            {
                foundClient.VinNumbers.Add(vinNumber);
                JsonReaderSaver.SaveClientData();
            }
        }
    }
}
