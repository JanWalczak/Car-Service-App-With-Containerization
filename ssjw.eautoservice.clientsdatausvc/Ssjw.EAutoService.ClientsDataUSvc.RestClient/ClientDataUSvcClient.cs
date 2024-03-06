namespace Ssjw.EAutoService.ClientsDataUSvc.RestClient
{
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services;
    using System.Text;
    using System.Text.Json;

    public class ClientDataUSvcClient : IClientDataSvc
    {
        public ClientDataUSvcClient()
        {
        }

        //private const string webAppUrl = "localhost:5003";
        private const string webAppUrl = "clientsdatausvc";

        private static readonly HttpClient httpClient = new HttpClient();

        private async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public List<ClientDto> GetAllClients()
        {
            string requestUri = String.Format("http://{0}/ClientData/GetAllClients", webAppUrl);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

            webServiceCall.Wait();

            string httpResponseContent = webServiceCall.Result;

            string correctedResponse = CorrectJsonProperties(httpResponseContent);

            List<ClientDto> downloadedClients = JsonSerializer.Deserialize<List<ClientDto>>(correctedResponse);

            foreach (ClientDto client in downloadedClients)
            {
                printClientDto(client);
            }

            return downloadedClients;
        }

        public async void AddClientToData(ClientDto clientDto)
        {
            string requestUri = String.Format("http://{0}/ClientData/AddClientToData", webAppUrl);

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            bool isNull = clientDto == null;
            if (!isNull)
            {
                json = JsonSerializer.Serialize(clientDto);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public void RemoveClientFromData(string idCardNumber)
        {
            string requestUri = String.Format("http://{0}/ClientData/RemoveClientFromData?idCardNumber={1}",
                webAppUrl, idCardNumber);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }

        public void AddCarToClient(string idCardNumber, string vinNumber)
        {
            string requestUri = String.Format("http://{0}/ClientData/AddCarToClient?idCardNumber={1}&vinNumber={2}",
                webAppUrl, idCardNumber, vinNumber);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }

        public ClientDto FindClientByIdCard(string idCardNumber)
        {
            string requestUri = String.Format("http://{0}/ClientData/FindClientByIdCard?idCardNumber={1}",
                webAppUrl, idCardNumber);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

            webServiceCall.Wait();

            string httpResponseContent = webServiceCall.Result;

            string correctedResponse = CorrectJsonProperties(httpResponseContent);

            ClientDto clientDto = JsonSerializer.Deserialize<ClientDto>(correctedResponse);

            printClientDto(clientDto);

            return clientDto;
        }

        public ClientDto GetClientsNameSurname(string idCardNumber)
        {
            string requestUri = String.Format("http://{0}/ClientData/GetClientsNameSurname?idCardNumber={1}",
                webAppUrl, idCardNumber);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

            webServiceCall.Wait();

            string httpResponseContent = webServiceCall.Result;

            string correctedResponse = CorrectJsonProperties(httpResponseContent);

            ClientDto downloadedClient = JsonSerializer.Deserialize<ClientDto>(correctedResponse);

            printClientDto(downloadedClient);

            return downloadedClient;
        }

        public ClientDto GetClientsSurnamePhoneNumber(string idCardNumber)
        {
            string requestUri = String.Format("http://{0}/ClientData/GetClientsSurnamePhoneNumber?idCardNumber={1}",
                webAppUrl, idCardNumber);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

            webServiceCall.Wait();

            string httpResponseContent = webServiceCall.Result;

            string correctedResponse = CorrectJsonProperties(httpResponseContent);

            ClientDto downloadedClient = JsonSerializer.Deserialize<ClientDto>(correctedResponse);

            printClientDto(downloadedClient);

            return downloadedClient;
        }

        public List<string> GetAllIds()
        {
            string requestUri = String.Format("http://{0}/ClientData/GetAllIds", webAppUrl);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

            webServiceCall.Wait();

            string httpResponseContent = webServiceCall.Result;

            List<string> idCardNumbers = JsonSerializer.Deserialize<List<string>>(httpResponseContent);

            for (int i = 0; i < idCardNumbers.Count; i++)
            {
                Console.WriteLine(idCardNumbers[i] + "\n");
            }

            return idCardNumbers;
        }

        private void printClientDto(ClientDto clientDto)
        {
            string dtoClientString = "Name: " + clientDto.Name + " " + "Surname: " + clientDto.Surname + " Phone Number: " +
                clientDto.PhoneNumber + " Id Card Number: " + clientDto.IdCardNumber + " Vin numbers: ";

            bool isEmpty = clientDto.VinNumbers == null;
            if (!isEmpty)
            {
                for (int i = 0; i < clientDto.VinNumbers.Count; i++)
                {
                    dtoClientString = dtoClientString + clientDto.VinNumbers[i] + ", ";
                }
            }

            Console.WriteLine(dtoClientString + "\n");
        }

        private string CorrectJsonProperties(string jsonResponse)
        {
            string correctedResposne = jsonResponse.Replace("\"name\"", "\"Name\"");
            correctedResposne = correctedResposne.Replace("\"surname\"", "\"Surname\"");
            correctedResposne = correctedResposne.Replace("\"phoneNumber\"", "\"PhoneNumber\"");
            correctedResposne = correctedResposne.Replace("\"idCardNumber\"", "\"IdCardNumber\"");
            correctedResposne = correctedResposne.Replace("\"vinNumbers\"", "\"VinNumbers\"");

            return correctedResposne;
        }
    }
}