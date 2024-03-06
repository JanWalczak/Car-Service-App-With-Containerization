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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindBodyPartByBodyType?bodyType={2}", "localhost", 7152, bodyType);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindBodyPartByPrice?minPrice={2}&maxPrice={3}", "localhost", 7152, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindLiquidByCategory?category={2}", "localhost", 7152, category);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindLiquidByPrice?minPrice={2}&maxPrice={3}", "localhost", 7152, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindMechanicalPartByCategory?category={2}", "localhost", 7152, category);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/FindMechanicalPartByPrice?minPrice={2}&maxPrice={3}", "localhost", 7152, minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture));

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetAllBodyParts", "localhost", 7152); //5110

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetAllLiquids", "localhost", 7152);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetAllMechanicalParts", "localhost", 7152);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetCarInformation?vin={2}", "localhost", 7152, vin);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetCarInspectionHistory?vin={2}", "localhost", 7152, vin);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetCarRepairHistory?vin={2}", "localhost", 7152, vin);

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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetPersonalInformation?id={2}", "localhost", 7152, id);

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
            string requestUri = String.Format("https://{0}:{1}/ClientApp/ModifyPersonalData?clientId={2}&newIdCard={3}&name={4}&surname={5}&phoneNumber={6}", "localhost", 7152,
                clientId, newIdCard, name, surname, phoneNumber);

            Task webServiceCall = CallWebServiceWithVins(HttpMethod.Post, requestUri, vinNumbers);

            webServiceCall.Wait();
        }
        public void PurchaseCarPart(string id)
        {
            string requestUri = String.Format("https://{0}:{1}/ClientApp/PurchaseCarPart?id={2}", "localhost", 7152, id);

            Task webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }
        public void RequestNewInspection(ExtendedInspectionDto extendedInspectionDto)
        {
            string requestUri = String.Format("https://{0}:{1}/ClientApp/RequestNewInspection", "localhost", 7152, extendedInspectionDto.dateOfService, extendedInspectionDto.employeeId, extendedInspectionDto.vinNumber, extendedInspectionDto.price, extendedInspectionDto.testsPassed, extendedInspectionDto.inspectionExpirationDate, extendedInspectionDto.comment);

            //Task webServiceCall = CallWebService(HttpMethod.Post, requestUri);
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
            string requestUri = String.Format("https://{0}:{1}/ClientApp/RequestNewRepair", "localhost", 7152);

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
                if (extendedRepair != null)
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
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetAllClientCar?idCardNumber={2}", "localhost", 7152, idCardNumber);

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
            string requestUri = String.Format("https://{0}:{1}/ClientApp/ModifyCarData?vin={2}&model={3}&brand={4}&productionYear={5}&insuranceNumber={6}", "localhost", 7152,
               vin, model, brand, productionYear, insuranceNumber);

            Task webServiceCall = CallWebServiceWithServicesHistory(HttpMethod.Post, requestUri, servicesHistory);

            webServiceCall.Wait();
        }
        public List<ExtendedEmployeeDto> GetAvailableMechanics(DateTime date)
        {
            try
            {
                string requestUri = String.Format("https://{0}:{1}/ClientApp/GetAvailableMechanics?date={2}-{3}-{4}", "localhost", 7152, date.Year, date.Month, date.Day);

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
            string requestUri = String.Format("https://{0}:{1}/ClientApp/AddNewClient", "localhost", 7152);

            Task webServiceCall = CallWebServiceClient(HttpMethod.Post, requestUri, client);

            webServiceCall.Wait();
        }

        public void AddCar(ExtendedCarDto extendedCarDto, string idCardNumber)
        {
            string requestUri = String.Format("https://{0}:{1}/ClientApp/AddCar?idCardNumber={2}", "localhost", 7152, idCardNumber);

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
