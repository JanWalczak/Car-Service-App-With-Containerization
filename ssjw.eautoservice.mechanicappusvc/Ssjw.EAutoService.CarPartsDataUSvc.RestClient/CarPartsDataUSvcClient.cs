namespace Ssjw.EAutoService.CarPartsDataUSvc.RestClient
{
    using System.Text.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public class CarPartsDataUSvcClient : ICarPartsDataUSvcClient
    {
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

        private static async Task<string> GetRequest(string webServiceHost, string webServicePort, string controller, string method, string searchTypeV1,
            string searchTextV1, string searchTypeV2, string searchTextV2, string searchTypeV3, string searchTextV3)
        {
            string webServiceUri = String.Format("https://{0}:{1}/{2}/{3}?{4}={5}&{6}={7}&{8}={9}", webServiceHost, webServicePort, controller, method,
                searchTypeV1, searchTextV1, searchTypeV2, searchTextV2, searchTypeV3, searchTextV3);

            string jsonResponseContent = await CallGetWebService(webServiceUri);

            return jsonResponseContent;
        }

        private static async Task<string> PostRequest(string webServiceHost, string webServicePort, string controller, string method, string searchTypeV1,
            string searchTextV1, string searchTypeV2, string searchTextV2, string json)
        {
            string webServiceUri = String.Format("https://{0}:{1}/{2}/{3}?{4}={5}&{6}={7}",
                webServiceHost, webServicePort, controller, method, searchTypeV1, searchTextV1, searchTypeV2, searchTextV2);

            string jsonResponseContent = await CallPostWebService(webServiceUri, json);

            return jsonResponseContent;
        }

        public List<BodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "FindBodyPartByBodyType", "bodyType", bodyType, "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<BodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<BodyPartDto>>(json);

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

        public void AddBodyPart(BodyPartDto bodyPartDto)
        {
            if (bodyPartDto.id == null)
            {
                bodyPartDto.id = "0";
            }
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postBodyPart = PostRequest("localhost", "7197", "BodyParts", "AddBodyPart", "", "", "", "", JsonSerializer.Serialize(bodyPartDto));

                postBodyPart.Wait();

                string json = postBodyPart.Result;

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

        public List<BodyPartDto> GetAllBodyParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "GetAllBodyParts", "", "", "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<BodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<BodyPartDto>>(json);

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

        public BodyPartDto GetBodyPartById(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "GetBodyPartById", "id", id, "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                BodyPartDto bodyPartDto = JsonSerializer.Deserialize<BodyPartDto>(json);

                return bodyPartDto;
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

        public List<BodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "FindBodyPartByPrice", "minPrice", minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), "maxPrice", maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<BodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<BodyPartDto>>(json);

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

        public List<BodyPartDto> FindBodyPartByMaterial(string material)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "FindBodyPartByMaterial", "material", material, "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<BodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<BodyPartDto>>(json);

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

        public List<LiquidDto> FindLiquidByCategory(string category)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "FindLiquidByCategory", "category", category, "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<LiquidDto> liquidsDto = JsonSerializer.Deserialize<List<LiquidDto>>(json);

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

        public void AddLiquid(LiquidDto liquidDto)
        {
            if (liquidDto.id == null)
            {
                liquidDto.id = "0";
            }
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postLiquid = PostRequest("localhost", "7197", "Liquids", "AddLiquid", "", "", "", "", JsonSerializer.Serialize(liquidDto));

                postLiquid.Wait();

                string json = postLiquid.Result;

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

        public List<LiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "FindLiquidByPrice", "minPrice", minPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), "maxPrice", maxPrice.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture), "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<LiquidDto> liquidsDto = JsonSerializer.Deserialize<List<LiquidDto>>(json);

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

        public List<LiquidDto> FindLiquidByDensity(int density)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "FindLiquidByDensity", "density", density.ToString(), "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<LiquidDto> liquidsDto = JsonSerializer.Deserialize<List<LiquidDto>>(json);

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

        public List<LiquidDto> GetAllLiquids()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "GetAllLiquids", "", "", "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<LiquidDto> liquidsDto = JsonSerializer.Deserialize<List<LiquidDto>>(json);

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

        public LiquidDto GetLiquidById(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "GetLiquidById", "id", id, "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                LiquidDto liquidDto = JsonSerializer.Deserialize<LiquidDto>(json);

                return liquidDto;
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

        public List<MechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "FindMechanicalPartByCategory", "category", category, "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<MechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<MechanicalPartDto>>(json);

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

        public void AddMechanicalPart(MechanicalPartDto mechanicalPartDto)
        {
            if (mechanicalPartDto.id == null)
            {
                mechanicalPartDto.id = "0";
            }
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postMechanicalPart = PostRequest("localhost", "7197", "MechanicalParts", "AddMechanicalPart", "", "", "", "", JsonSerializer.Serialize(mechanicalPartDto));

                postMechanicalPart.Wait();

                string json = postMechanicalPart.Result;

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

        public List<MechanicalPartDto> GetAllMechanicalParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "GetAllMechanicalParts", "", "", "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<MechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<MechanicalPartDto>>(json);

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

        public MechanicalPartDto GetMechanicalPartById(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "GetMechanicalPartById", "id", id, "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                MechanicalPartDto mechanicalPartDto = JsonSerializer.Deserialize<MechanicalPartDto>(json);

                return mechanicalPartDto;
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

        public List<MechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "FindMechanicalPartByDimensions",
                    "sizeX", sizeX.ToString(), "sizeY", sizeY.ToString(), "sizeZ", sizeZ.ToString());

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<MechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<MechanicalPartDto>>(json);

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

        public List<MechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "FindMechanicalPartByPrice",
                    "minPrice", minPrice.ToString(), "maxPrice", maxPrice.ToString(), "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<MechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<MechanicalPartDto>>(json);

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

        public List<BodyPartDto> GetAvailableAndUnavailableBodyParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getBodyPartsTaskString = GetRequest("localhost", "7197", "BodyParts", "GetAvailableAndUnavailableBodyParts", "", "", "", "", "", "");

                getBodyPartsTaskString.Wait();

                string json = getBodyPartsTaskString.Result;

                List<BodyPartDto> bodyPartsDto = JsonSerializer.Deserialize<List<BodyPartDto>>(json);

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

        public List<LiquidDto> GetAvailableAndUnavailableLiquids()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getLiquidsTaskString = GetRequest("localhost", "7197", "Liquids", "GetAvailableAndUnavailableLiquids", "", "", "", "", "", "");

                getLiquidsTaskString.Wait();

                string json = getLiquidsTaskString.Result;

                List<LiquidDto> liquidsDto = JsonSerializer.Deserialize<List<LiquidDto>>(json);

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

        public List<MechanicalPartDto> GetAvailableAndUnavailableMechanicalParts()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getMechanicalPartsTaskString = GetRequest("localhost", "7197", "MechanicalParts", "GetAvailableAndUnavailableMechanicalParts", "", "", "", "", "", "");

                getMechanicalPartsTaskString.Wait();

                string json = getMechanicalPartsTaskString.Result;

                List<MechanicalPartDto> mechanicalPartsDto = JsonSerializer.Deserialize<List<MechanicalPartDto>>(json);

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

        public void RemoveCarPart(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postRemoveCarPart = PostRequest("localhost", "7197", "CarParts", "RemoveCarPart", "id", id, "", "", "");

                postRemoveCarPart.Wait();

                string json = postRemoveCarPart.Result;

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

        public void DeleteCarPart(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postDeleteCarPart = PostRequest("localhost", "7197", "CarParts", "DeleteCarPart", "id", id, "", "", "");

                postDeleteCarPart.Wait();

                string json = postDeleteCarPart.Result;

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

        public void ChangeNumberOfAvailableParts(string id, int number)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postChangeNumber = PostRequest("localhost", "7197", "CarParts", "ChangeNumberOfAvailableParts", "id", id, "number", number.ToString(), "");

                postChangeNumber.Wait();

                string json = postChangeNumber.Result;

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

        public int GetNumberOfAvailableParts(string id)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getNumberOfAvailableParts = GetRequest("localhost", "7197", "CarParts", "GetNumberOfAvailableParts", "id", id, "", "", "", "");

                getNumberOfAvailableParts.Wait();

                string json = getNumberOfAvailableParts.Result;

                int mechanicalPartsDto = JsonSerializer.Deserialize<int>(json);

                return mechanicalPartsDto;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                return -1;
            }
            finally
            {
                Console.WriteLine("Finished.");
            }
        }
    }
}


