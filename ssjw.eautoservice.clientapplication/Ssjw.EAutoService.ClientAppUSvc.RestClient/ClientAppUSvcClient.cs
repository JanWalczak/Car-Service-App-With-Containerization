namespace Ssjw.EAutoService.ClientAppUSvc.RestClient
{
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;
    using System.Text;
    using System.Text.Json;
    public class ClientAppUSvcClient : IClientAppSvc
    {


        //private const string webAppUrl = "localhost:5110";

		private const string webAppUrl = "webclientapp";

        public ClientAppUSvcClient() { }

        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> CallWebServiceWithList(HttpMethod httpMethod, string webServiceUri, List<string> services)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                string json = "";
                if (services != null)
                {
                    json = JsonSerializer.Serialize(services);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindBodyPartByBodyType?bodyType={1}", webAppUrl, bodyType);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedBodyPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedBodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindBodyPartByPrice?minPrice={1}&maxPrice={2}", webAppUrl, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedBodyPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindLiquidByCategory?category={1}", webAppUrl, category);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedLiquidDto> toReturn = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedLiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindLiquidByPrice?minPrice={1}&maxPrice={2}", webAppUrl, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedLiquidDto> toReturn = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindMechanicalPartByCategory?category={1}", webAppUrl, category);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedMechanicalPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/FindMechanicalPartByPrice?minPrice={1}&maxPrice={2}", webAppUrl, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedMechanicalPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetAllBodyParts", webAppUrl); //5110

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedBodyPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetAllLiquids", webAppUrl);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedLiquidDto> toReturn = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetAllMechanicalParts", webAppUrl);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedMechanicalPartDto> toReturn = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ExtendedCarDto GetCarInformation(string vin)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetCarInformation?vin={1}", webAppUrl, vin);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                ExtendedCarDto toReturn = JsonSerializer.Deserialize<ExtendedCarDto>(httpResponseContent);

                return toReturn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetCarInspectionHistory?vin={1}", webAppUrl, vin);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedInspectionDto> downloadedEmployee = JsonSerializer.Deserialize<List<ExtendedInspectionDto>>(httpResponseContent);

                return downloadedEmployee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetCarRepairHistory?vin={1}", webAppUrl, vin);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedRepairDto> downloadedList = JsonSerializer.Deserialize<List<ExtendedRepairDto>>(httpResponseContent);

                return downloadedList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ExtendedClientDto GetPersonalInformation(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetPersonalInformation?id={1}", webAppUrl, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                ExtendedClientDto downloadedClient = JsonSerializer.Deserialize<ExtendedClientDto>(httpResponseContent);

                return downloadedClient;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber, List<string>? vinNumbers)
        {
            string requestUri = String.Format("http://{0}/ClientApp/ModifyPersonalData?clientId={1}&newIdCard={2}&name={3}&surname={4}&phoneNumber={5}", webAppUrl,
                clientId, newIdCard, name, surname, phoneNumber);

            Task webServiceCall = CallWebServiceWithVins(HttpMethod.Post, requestUri, vinNumbers);

            webServiceCall.Wait();
        }
        public void PurchaseCarPart(string id)
        {
            string requestUri = String.Format("http://{0}/ClientApp/PurchaseCarPart?id={1}", webAppUrl, id);

            Task webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }
        public void RequestNewInspection(ExtendedInspectionDto extendedInspectionDto)
        {
            string requestUri = String.Format("http://{0}/ClientApp/RequestNewInspection", webAppUrl, extendedInspectionDto.dateOfService, extendedInspectionDto.employeeId, extendedInspectionDto.vinNumber, extendedInspectionDto.price, extendedInspectionDto.testsPassed, extendedInspectionDto.inspectionExpirationDate, extendedInspectionDto.comment);

            Task webServiceCall = CallWebServiceWithInspectionDto(HttpMethod.Post, requestUri, extendedInspectionDto);

            webServiceCall.Wait();
        }

        public async Task<string> CallWebServiceWithInspectionDto(HttpMethod httpMethod, string webServiceUri, ExtendedInspectionDto extendedInspectionDto)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (extendedInspectionDto != null)
                {
                    json = JsonSerializer.Serialize(extendedInspectionDto);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> CallWebServiceRepairedPartDto(HttpMethod httpMethod, string webServiceUri, List<ExtendedRepairedPartDto> repairedParts)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (repairedParts != null)
                {
                    json = JsonSerializer.Serialize(repairedParts);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> CallWebServiceWithVins(HttpMethod httpMethod, string webServiceUri, List<string> vins)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (vins.Count != 0)
                {
                    json = JsonSerializer.Serialize(vins);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> CallWebServiceClient(HttpMethod httpMethod, string webServiceUri, ExtendedClientDto client)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (client != null)
                {
                    json = JsonSerializer.Serialize(client);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> CallWebServiceWithServicesHistory(HttpMethod httpMethod, string webServiceUri, List<string> servicesHistory)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (servicesHistory.Count != 0)
                {
                    json = JsonSerializer.Serialize(servicesHistory);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void RequestNewRepair(ExtendedRepairDto extendedRepair)
        {
            string requestUri = String.Format("http://{0}/ClientApp/RequestNewRepair", webAppUrl);

            Task webServiceCall = CallWebServiceWithRepair(HttpMethod.Post, requestUri, extendedRepair);

            webServiceCall.Wait();
        }

        public async Task<string> CallWebServiceWithRepair(HttpMethod httpMethod, string webServiceUri, ExtendedRepairDto extendedRepair)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (extendedRepair!= null)
                {
                    json = JsonSerializer.Serialize(extendedRepair);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ExtendedCarDto> GetAllClientCar(string idCardNumber)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetAllClientCar?idCardNumber={1}", webAppUrl, idCardNumber);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedCarDto> downloadedList = JsonSerializer.Deserialize<List<ExtendedCarDto>>(httpResponseContent);
                return downloadedList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber, List<string>? servicesHistory)
        {
            string requestUri = String.Format("http://{0}/ClientApp/ModifyCarData?vin={1}&model={2}&brand={3}&productionYear={4}&insuranceNumber={5}", webAppUrl,
               vin, model, brand, productionYear, insuranceNumber);

            Task webServiceCall = CallWebServiceWithServicesHistory(HttpMethod.Post, requestUri, servicesHistory);

            webServiceCall.Wait();
        }
        public List<ExtendedEmployeeDto> GetAvailableMechanics(DateTime date)
        {
            try
            {
                string requestUri = String.Format("http://{0}/ClientApp/GetAvailableMechanics?date={1}-{2}-{3}", webAppUrl, date.Year, date.Month, date.Day);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<ExtendedEmployeeDto> downloadedList = JsonSerializer.Deserialize<List<ExtendedEmployeeDto>>(httpResponseContent);
                return downloadedList;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void AddNewClient(ExtendedClientDto client)
        {
            string requestUri = String.Format("http://{0}/ClientApp/AddNewClient", webAppUrl);

            Task webServiceCall = CallWebServiceClient(HttpMethod.Post, requestUri, client);

            webServiceCall.Wait();
        }

        public void AddCar(ExtendedCarDto extendedCarDto, string idCardNumber)
        {
            string requestUri = String.Format("http://{0}/ClientApp/AddCar", webAppUrl);

            Task webServiceCall = CallWebServiceWithExtendedCar(HttpMethod.Post, requestUri, extendedCarDto);

            webServiceCall.Wait();
        }

        public async Task<string> CallWebServiceWithExtendedCar(HttpMethod httpMethod, string webServiceUri, ExtendedCarDto extendedCarDto)
        {
            try
            {
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                string json = "";
                if (extendedCarDto != null)
                {
                    json = JsonSerializer.Serialize(extendedCarDto);
                }
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

                httpResponseMessage.EnsureSuccessStatusCode();

                string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return httpResponseContent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
