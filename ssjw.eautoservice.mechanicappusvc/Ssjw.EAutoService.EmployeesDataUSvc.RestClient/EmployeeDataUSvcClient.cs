namespace Ssjw.EAutoService.EmployeesDataUSvc.RestClient
{
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services;
    using System.Text;
    using System.Text.Json;

    public class EmployeeDataUSvcClient : IEmployeeDataSvc
    {
        public EmployeeDataUSvcClient() { }

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

        public List<EmployeeDto> GetAllEmployees()
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetAllEmployees", "localhost", 5257);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<EmployeeDto> downloadedEmployees = JsonSerializer.Deserialize<List<EmployeeDto>>(httpResponseContent);

                foreach (EmployeeDto tempEmpl in downloadedEmployees)
                    Console.WriteLine(tempEmpl.id + "\n");

                return downloadedEmployees;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddEmployeeToDB(EmployeeDto employeeDto)
        {
            string requestUri = String.Format("http://{0}:{1}/EmployeeData/AddEmployeeToDB?name={2}&surname={3}&phoneNumber={4}&jobPosition={5}&salary={6}", "localhost", 5257, employeeDto.name, employeeDto.surname, employeeDto.phoneNumber, employeeDto.jobPosition, employeeDto.salary);

            Task webServiceCall = CallWebServiceWithList(HttpMethod.Post, requestUri, employeeDto.services);

            webServiceCall.Wait();

        }

        public void RemoveEmployeeFromDB(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/RemoveEmployeeFromDB?id={2}", "localhost", 5257, id);

                Task webServiceCall = CallWebService(HttpMethod.Post, requestUri);

                webServiceCall.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public EmployeeDto GetEmployeeById(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetEmployeeById?id={2}", "localhost", 5257, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                EmployeeDto downloadedEmployee = JsonSerializer.Deserialize<EmployeeDto>(httpResponseContent);

                return downloadedEmployee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public EmployeeDto GetEmployeeNameSurnameSalary(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetEmployeeNameSurnameSalary?id={2}", "localhost", 5257, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                EmployeeDto downloadedEmployee = JsonSerializer.Deserialize<EmployeeDto>(httpResponseContent);

                return new EmployeeDto() { name = downloadedEmployee.name, surname = downloadedEmployee.surname, salary = downloadedEmployee.salary };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public EmployeeDto GetEmployeeNameSurnameSalaryServices(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetEmployeeNameSurnameSalaryServices?id={2}", "localhost", 5257, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                EmployeeDto downloadedEmployee = JsonSerializer.Deserialize<EmployeeDto>(httpResponseContent);

                return new EmployeeDto() { name = downloadedEmployee.name, surname = downloadedEmployee.surname, salary = downloadedEmployee.salary, services = downloadedEmployee.services };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public List<EmployeeDto> GetAllEmployeesWithSpecifiedPosition(string jobPosition)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetAllEmployeesWithSpecifiedPosition?jobPosition={2}", "localhost", 5257, jobPosition);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<EmployeeDto> downloadedEmployees = JsonSerializer.Deserialize<List<EmployeeDto>>(httpResponseContent);

                return downloadedEmployees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public EmployeeDto GetEmployeeSurnamePhoneNumber(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetEmployeeSurnamePhoneNumber?id={2}", "localhost", 5257, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                EmployeeDto downloadedEmployee = JsonSerializer.Deserialize<EmployeeDto>(httpResponseContent);

                return new EmployeeDto() { surname = downloadedEmployee.surname, phoneNumber = downloadedEmployee.phoneNumber };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public int GetNumberOfEmployees()
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetNumberOfEmployees", "localhost", 5257);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                return int.Parse(webServiceCall.Result);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<string> GetEmployeeServices(string id)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/GetEmployeeServices?id={2}", "localhost", 5257, id);
                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                List<string> result = JsonSerializer.Deserialize<List<string>>(httpResponseContent);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveEmployeeService(string serviceId)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/RemoveEmployeeService?serviceId={2}", "localhost", 5257, serviceId);
                Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

                webServiceCall.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        public void AddServiceToEmployee(string id, List<string> services)
        {
            try
            {
                string requestUri = String.Format("http://{0}:{1}/EmployeeData/AddServiceToEmployee?id={2}", "localhost", 5257, id);

                Task webServiceCall = CallWebServiceWithList(HttpMethod.Post, requestUri, services);

                webServiceCall.Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}