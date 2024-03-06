namespace Ssjw.EAutoService.CarsDataUSvc.RestClient
{
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Services;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text;
    using System.Net.Http;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;

    public class CarsDataUSvcClient : ICarsDataDto
    {

        //private const string carsUSvc = "localhost:5227";

        private const string carsUSvc = "carsusvc";



        private static async Task<String> CallGetWebService(string webServiceUri)
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

        private static async Task<string> CallPostWebService(string webServiceUri, List<string> servicesHistory)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            if (servicesHistory != null)
            {
                json = JsonSerializer.Serialize(servicesHistory);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private static async Task<string> GetRequest(string controller, string method, string searchTypeV1,
    string searchTextV1, string searchTypeV2, string searchTextV2, string searchTypeV3, string searchTextV3)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}?{3}={4}&{5}={6}&{7}={8}", carsUSvc, controller, method,
                searchTypeV1, searchTextV1, searchTypeV2, searchTextV2, searchTypeV3, searchTextV3);

            string jsonResponseContent = await CallGetWebService(webServiceUri);

            return jsonResponseContent;
        }

        private static async Task<string> RemoveById(string webServiceUri)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        private static async Task<string> PostRemove(string controller, string method, string vin)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}?vin={3}",
            carsUSvc, controller, method, vin);

            string jsonResponseContent = await RemoveById(webServiceUri);

            return jsonResponseContent;
        }



        private static async Task<string> PostCar(string controller, string method, CarDto car)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}", carsUSvc, controller, method);

            string jsonResponseContent = await CallPostWebServiceCar(webServiceUri, car);

            return jsonResponseContent;
        }

        private static async Task<string> PostCarServicesHistory(string controller, string method, string vin,
    string serviceId)
        {
            string webServiceUri = String.Format("http://{0}/{1}/{2}?vin={3}&serviceId={4}", carsUSvc, controller, method, vin, serviceId);

            string jsonResponseContent = await CallPostWebService(webServiceUri, null);

            return jsonResponseContent;
        }



        public List<CarDto> GetAllCars()
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getCarsTaskString = GetRequest("Cars", "GetAllCars", "", "", "", "", "", "");

                getCarsTaskString.Wait();

                string json = getCarsTaskString.Result;

                List<CarDto> carDto = JsonSerializer.Deserialize<List<CarDto>>(json);

                return carDto;
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

        public CarDto GetCarByVin(string vin)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getCarsTaskString = GetRequest("Cars", "GetCarByVin", "vin", vin, "", "", "", "");

                getCarsTaskString.Wait();

                string json = getCarsTaskString.Result;

                CarDto carDto = JsonSerializer.Deserialize<CarDto>(json);

                return carDto;
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

        public List<CarDto> GetCarsByBrand(string brand)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> getCarsTaskString = GetRequest("Cars", "GetCarsByBrand", "brand", brand, "", "", "", "");

                getCarsTaskString.Wait();

                string json = getCarsTaskString.Result;

                List<CarDto> carDto = JsonSerializer.Deserialize<List<CarDto>>(json);

                return carDto;
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

        public void RemoveCarByVin(string vin)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postCars = PostRemove("Cars", "RemoveCarByVin", vin);

                postCars.Wait();

                string json = postCars.Result;

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

        public void AddServiceToCarHistory(string vin, string serviceId)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postCar = PostCarServicesHistory("Cars", "AddServiceToCarHistory", vin, serviceId);

                postCar.Wait();

                string json = postCar.Result;

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

        public void RemoveServiceFromCarHistory(string vin, string serviceId)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postCar = PostCarServicesHistory("Cars", "RemoveServiceFromCarHistory", vin, serviceId);

                postCar.Wait();

                string json = postCar.Result;

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

        private static async Task<string> CallPostWebServiceCar(string webServiceUri, CarDto car)
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            if (car != null)
            {
                json = JsonSerializer.Serialize(car);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(webServiceUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public void AddCar(CarDto car)
        {
            Console.WriteLine("Starting ...");
            try
            {
                Task<string> postCar = PostCar("Cars", "AddCar", car);

                postCar.Wait();

                string json = postCar.Result;

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
    }
}