namespace Ssjw.EAutoService.MechanicAppUSvc.RestClient
{
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;
    using System.Text;
    using System.Text.Json;

    public class MechanicAppUSvcClient : IMechanicAppDto
    {
        //private const string webAppUrl = "localhost:5147";
        private const string webAppUrl = "webmechanicapp";
        private static async Task<string> CallGetWebService(string webServiceUri)
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, webServiceUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private static async Task<string> GetRequest(string controller, string method, string searchTypeV1,
            string searchTextV1, string searchTypeV2, string searchTextV2, string searchTypeV3, string searchTextV3)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}?{3}={4}&{5}={6}&{7}={8}", webAppUrl, controller, method,
                searchTypeV1, searchTextV1, searchTypeV2, searchTextV2, searchTypeV3, searchTextV3);

            string jsonResponseContent = await CallGetWebService(webServiceUri);

            return jsonResponseContent;
        }

        private static async Task<string> CallPostWebService(string webServiceUri, string json)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }
        private static async Task<string> PostRequest(string controller, string method, string searchTypeV1,
    string searchTextV1, string searchTypeV2, string searchTextV2, string searchTypeV3, string searchTextV3, string searchTypeV4, string searchTextV4, string json)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}?{3}={4}&{5}={6}&{7}={8}&{9}={10}",
                webAppUrl, controller, method, searchTypeV1, searchTextV1, searchTypeV2, searchTextV2, searchTypeV3, searchTextV3, searchTypeV4, searchTextV4);

            string jsonResponseContent = await CallPostWebService(webServiceUri, json);

            return jsonResponseContent;
        }

        public List<ExtendedCarDto> GetPersonalCars(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getPersonalCars = GetRequest("MechanicApp", "GetPersonalCars", "id", id, "", "", "", "");

                getPersonalCars.Wait();

                string json = getPersonalCars.Result;

                List<ExtendedCarDto> extendedCarsDto = JsonSerializer.Deserialize<List<ExtendedCarDto>>(json);

                return extendedCarsDto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public ExtendedCarDto GetCarByVinNumber(string vinNumber)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getCarTask = GetRequest("MechanicApp", "GetCarByVinNumber", "vinNumber", vinNumber, "", "", "", "");

                getCarTask.Wait();

                string json = getCarTask.Result;

                ExtendedCarDto extendedCarDto = JsonSerializer.Deserialize<ExtendedCarDto>(json);

                return extendedCarDto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getInspectionTask = GetRequest("MechanicApp", "GetCarInspectionHistory", "vin", vin, "", "", "", "");

                getInspectionTask.Wait();

                string json = getInspectionTask.Result;

                List<ExtendedInspectionDto> extendedInspectionDtos = JsonSerializer.Deserialize<List<ExtendedInspectionDto>>(json);

                return extendedInspectionDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getRepairTask = GetRequest("MechanicApp", "GetCarRepairHistory", "vin", vin, "", "", "", "");

                getRepairTask.Wait();

                string json = getRepairTask.Result;

                List<ExtendedRepairDto> extendedRepairDtos = JsonSerializer.Deserialize<List<ExtendedRepairDto>>(json);

                return extendedRepairDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedRepairDto> GetPersonalRepairSchedule(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getPersonalRepairScheduleTask = GetRequest("MechanicApp", "GetPersonalRepairSchedule", "id", id, "", "", "", "");

                getPersonalRepairScheduleTask.Wait();

                string json = getPersonalRepairScheduleTask.Result;

                List<ExtendedRepairDto> extendedRepairDtos = JsonSerializer.Deserialize<List<ExtendedRepairDto>>(json);

                return extendedRepairDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedInspectionDto> GetPersonalInspectionSchedule(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getPersonalInspectionScheduleTask = GetRequest("MechanicApp", "GetPersonalInspectionSchedule", "id", id, "", "", "", "");

                getPersonalInspectionScheduleTask.Wait();

                string json = getPersonalInspectionScheduleTask.Result;

                List<ExtendedInspectionDto> extendedInspectionDtos = JsonSerializer.Deserialize<List<ExtendedInspectionDto>>(json);

                return extendedInspectionDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public void FinishRepair(string idService, double price, List<ExtendedRepairedPartDto> repairedParts)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postTask = PostRequest("MechanicApp", "FinishRepair", "idService", idService, "price", price.ToString(), "", "", "", "", JsonSerializer.Serialize(repairedParts));

                postTask.Wait();

                string json = postTask.Result;

                Console.WriteLine(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public void FinishInspection(string idService, double price, bool testsPassed, string comment)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postTask = PostRequest("MechanicApp", "FinishInspection", "idService", idService, "price", price.ToString(), "testsPassed", testsPassed.ToString(), "comment", comment, "");

                postTask.Wait();

                string json = postTask.Result;

                Console.WriteLine(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedClientDto> GetAllClients()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getAllClientsTask = GetRequest("MechanicApp", "GetAllClients", "", "", "", "", "", "");

                getAllClientsTask.Wait();

                string json = getAllClientsTask.Result;

                List<ExtendedClientDto> extendedClientDtos = JsonSerializer.Deserialize<List<ExtendedClientDto>>(json);

                return extendedClientDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public ExtendedClientDto GetClientInformation(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getClientInfo = GetRequest("MechanicApp", "GetClientInformation", "id", id, "", "", "", "");

                getClientInfo.Wait();

                string json = getClientInfo.Result;

                ExtendedClientDto completeClientDto = JsonSerializer.Deserialize<ExtendedClientDto>(json);

                return completeClientDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("MechanicApp", "GetAllMechanicalParts", "", "", "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<ExtendedMechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(json);

                return mechanicalPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("MechanicApp", "GetAllBodyParts", "", "", "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<ExtendedBodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(json);

                return bodyPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("MechanicApp", "GetAllLiquids", "", "", "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<ExtendedLiquidDto> liquidsDto = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(json);

                return liquidsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedBodyPartDto> FindBodyPartByMaterial(string material)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("MechanicApp", "FindBodyPartByMaterial", "material", material, "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<ExtendedBodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(json);

                return bodyPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("MechanicApp", "FindBodyPartByBodyType", "bodyType", bodyType, "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<ExtendedBodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<ExtendedBodyPartDto>>(json);

                return bodyPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public void UseCarPart(string carPartId)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postTask = PostRequest("MechanicApp", "UseCarPart", "carPartId", carPartId, "", "", "", "", "", "", "");

                postTask.Wait();

                string json = postTask.Result;

                Console.WriteLine(json);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("MechanicApp", "FindMechanicalPartByDimensions",
                    "sizeX", sizeX.ToString(), "sizeY", sizeY.ToString(), "sizeZ", sizeZ.ToString());

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<ExtendedMechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(json);

                return mechanicalPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("MechanicApp", "FindMechanicalPartByCategory", "category", category, "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<ExtendedMechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<ExtendedMechanicalPartDto>>(json);

                return mechanicalPartsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedLiquidDto> FindLiquidByDensity(int density)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("MechanicApp", "FindLiquidByDensity", "density", density.ToString(), "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<ExtendedLiquidDto> liquidsDto = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(json);

                return liquidsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }

        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("MechanicApp", "FindLiquidByCategory", "category", category, "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<ExtendedLiquidDto> liquidsDto = JsonSerializer.Deserialize<List<ExtendedLiquidDto>>(json);

                return liquidsDto;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return null;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }
    }
}