namespace Ssjw.EAutoService.ServicesDataUSvc.RestClient
{
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.Json;

    public class ServicesDataUSvcClient : IInspectionsDataDto, IRepairsDataDto
    {
        public ServicesDataUSvcClient() { }

        private static readonly HttpClient httpClient = new HttpClient();

        //private const string webAppUrl = "localhost:5093";
        private const string webAppUrl = "servicesusvc";

        public async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }


        public async void AddInspection(InspectionDto inspectionDto)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/AddInspection", webAppUrl);

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            bool isNull = inspectionDto == null;
            if (!isNull)
            {
                json = JsonSerializer.Serialize(inspectionDto);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async void AddRepair(RepairDto repairDto)
        {
            string requestUri = String.Format("http://{0}/RepairsData/AddRepair", webAppUrl);

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            bool isNull = repairDto == null;
            if (!isNull)
            {
                json = JsonSerializer.Serialize(repairDto);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();

        }

        public InspectionDto FindInspectionById(string id)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/FindInspectionById?id={1}", webAppUrl, id);
            return SingleInspectionCall(requestUri);
        }

        public RepairDto FindRepairById(string id)
        {
            string requestUri = String.Format("http://{0}/RepairsData/FindRepairById?id={1}", webAppUrl, id);
            return SingleRepairCall(requestUri);
        }

        public List<InspectionDto> GetAllByPassedFieldInspections(bool passed)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/GetAllByPassedFieldInspections?passed={1}", webAppUrl, passed);
            return InspectionListCall(requestUri);
        }

        public List<InspectionDto> GetAllInspections()
        {
            string requestUri = String.Format("http://{0}/InspectionsData/GetAllInspections", webAppUrl);
            return InspectionListCall(requestUri);
        }

        public List<RepairDto> GetAllRepairs()
        {
            string requestUri = String.Format("http://{0}/RepairsData/GetAllRepairs", webAppUrl);
            return RepairListCall(requestUri);
        }

        public InspectionDto GetInspectionEmployeeIdVinNumber(string id)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/GetEmployeeIdVinNumber?id={1}", webAppUrl, id);
            return SingleInspectionCall(requestUri);
        }

        public List<InspectionDto> GetInspectionsByVinNumber(string vinNumber)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/GetInspectionsByVinNumber?vinNumber={1}", webAppUrl, vinNumber);
            return InspectionListCall(requestUri);
        }

        public List<RepairDto> GetRepairByVinNumber(string vinNumber)
        {
            string requestUri = String.Format("http://{0}/RepairsData/GetRepairByVinNumber?vinNumber={1}", webAppUrl,
                vinNumber);
            return RepairListCall(requestUri);
        }

        public List<RepairedPartDto> GetRepairedPartsById(string id)
        {
            List<RepairedPartDto> downloadedRepairedParts = new List<RepairedPartDto>();

            try
            {
                string requestUri = String.Format("http://{0}/RepairsData/GetRepairedPartsById?id={1}", webAppUrl, id);

                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                string correctedRepairedParts = CorrectRepair(httpResponseContent);

                downloadedRepairedParts = JsonSerializer.Deserialize<List<RepairedPartDto>>(correctedRepairedParts);

                foreach (RepairedPartDto repairedPart in downloadedRepairedParts)
                {
                    Console.WriteLine("\nCar part: " + repairedPart.CarPart + " Cause of repair: " + repairedPart.CauseOfRepair);
                }

                return downloadedRepairedParts;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("No such a repair.", exeption.Message);
            }

            return downloadedRepairedParts;
        }

        public void RemoveInspection(string id)
        {
            string requestUri = String.Format("http://{0}/InspectionsData/RemoveInspection?id={1}", webAppUrl, id);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }

        public void RemoveRepair(string id)
        {
            string requestUri = String.Format("http://{0}/RepairsData/RemoveRepair?id={1}", webAppUrl, id);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }

        public RepairDto GetRepairEmployeeIdVinNumber(string id)
        {
            string requestUri = String.Format("http://{0}/RepairsData/GetRepairEmployeeIdVinNumber?id={1}", webAppUrl,
                id);
            return SingleRepairCall(requestUri);
        }


        public RepairDto SingleRepairCall(string requestUri)
        {
            try
            {
                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                string correctedRepair = CorrectRepair(httpResponseContent);

                RepairDto repairDto = JsonSerializer.Deserialize<RepairDto>(correctedRepair);

                printRepairDto(repairDto);

                return repairDto;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("No such a repair.", exeption.Message);
            }

            return null;
        }

        public InspectionDto SingleInspectionCall(string requestUri)
        {
            try
            {
                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                string correctedInspection = CorrectInspection(httpResponseContent);

                InspectionDto inspectionDto = JsonSerializer.Deserialize<InspectionDto>(correctedInspection);

                printInspectionDto(inspectionDto);

                return inspectionDto;
            }
            catch (Exception exception)
            {
                Console.WriteLine("No such an inspection.", exception.Message);
            }

            return null;
        }


        public List<RepairDto> RepairListCall(string requestUri)
        {
            List<RepairDto> downloadedRepairs = new List<RepairDto>();

            try
            {
                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                string correctedRepairs = CorrectRepair(httpResponseContent);

                downloadedRepairs = JsonSerializer.Deserialize<List<RepairDto>>(correctedRepairs);

                foreach (RepairDto repair in downloadedRepairs)
                {
                    printRepairDto(repair);
                }

                return downloadedRepairs;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("Exception: ", exeption.Message);
            }

            return downloadedRepairs;
        }

        public List<InspectionDto> InspectionListCall(string requestUri)
        {
            List<InspectionDto> downloadedInspections = new List<InspectionDto>();

            try
            {
                Task<string> webServiceCall = CallWebService(HttpMethod.Get, requestUri);

                webServiceCall.Wait();

                string httpResponseContent = webServiceCall.Result;

                string correctedInspections = CorrectInspection(httpResponseContent);

                downloadedInspections = JsonSerializer.Deserialize<List<InspectionDto>>(correctedInspections);

                foreach (InspectionDto inspection in downloadedInspections)
                {
                    printInspectionDto(inspection);
                }

                return downloadedInspections;
            }
            catch (Exception exeption)
            {
                Console.WriteLine("Exception: ", exeption.Message);
            }

            return downloadedInspections;
        }      
        private void printInspectionDto(InspectionDto dto)
        {
            string inspectionString = "Id: " + dto.Id + " Date of service: " + dto.DateOfService + " Employee id: " + dto.EmployeeId +
                    " Vin number: " + dto.VinNumber + " Price: " + dto.Price + "\nTests passed: " + dto.TestsPassed +
                    " Inspection expiration date: " + dto.InspectionExpirationDate + " Comment: " + dto.Comment;
            Console.WriteLine("\n" + inspectionString);
        }

        private void printRepairDto(RepairDto dto)
        {
            string repairString = "Id: " + dto.Id + " Date of service: " + dto.DateOfService + " Employee id: " + dto.EmployeeId +
                    " Vin number: " + dto.VinNumber + " Price: " + dto.Price + " Repaired parts: ";

            bool isEmpty = dto.RepairedParts == null;
            if (!isEmpty)
            {
                foreach (RepairedPartDto repairedPartDto in dto.RepairedParts)
                {
                    repairString = repairString + "\nCar part: " + repairedPartDto.CarPart + " Cause of repair: " +
                        repairedPartDto.CauseOfRepair;
                }
            }

            Console.WriteLine("\n" + repairString);
        }

        public void CompleteInspection(string id, double price, bool testsPassed, string comment)
        {
            string requestUri = String.Format("https://{0}:{1}/InspectionsData/CompleteInspection?id={2}&price={3}" +
                "&testsPassed={4}&comment={5}", "localhost", 7021, id, price, testsPassed, comment);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, requestUri);

            webServiceCall.Wait();
        }

        public async void CompleteRepair(string id, double price, List<RepairedPartDto> repairedParts)
        {
            string requestUri = String.Format("https://{0}:{1}/RepairsData/CompleteRepair?id={2}&price={3}",
                "localhost", 7021, id, price);

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string json = "";

            bool isEmpty = repairedParts == null;
            if (!isEmpty)
            {
                json = JsonSerializer.Serialize(repairedParts);
            }

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, content);

            httpClient.Dispose();

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public List<string> GetServicesByEmployeeId(string employeeId)
        {
            List<string> servicesIds = new List<string>();
            List<InspectionDto> inspections = GetAllInspections();
            List<RepairDto> repairs = GetAllRepairs();

            foreach (InspectionDto inspection in inspections)
            {
                string inspectionsEmployeeId = inspection.EmployeeId;
                if (inspectionsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(inspection.Id);
                    Console.WriteLine(inspection.Id);
                }
            }

            foreach (RepairDto repair in repairs)
            {
                string repairsEmployeeId = repair.EmployeeId;
                if (repairsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(repair.Id);
                    Console.WriteLine(repair.Id);
                }
            }

            return servicesIds;
        }

        private string CorrectRepair(string repairString)
        {
            string correctedRepair = repairString;

            correctedRepair = correctedRepair.Replace("\"repairedParts\"", "\"RepairedParts\"");
            correctedRepair = correctedRepair.Replace("\"carPart\"", "\"CarPart\"");
            correctedRepair = correctedRepair.Replace("\"causeOfRepair\"", "\"CauseOfRepair\"");
            correctedRepair = correctedRepair.Replace("\"id\"", "\"Id\"");
            correctedRepair = correctedRepair.Replace("\"dateOfService\"", "\"DateOfService\"");
            correctedRepair = correctedRepair.Replace("\"employeeId\"", "\"EmployeeId\"");
            correctedRepair = correctedRepair.Replace("\"vinNumber\"", "\"VinNumber\"");
            correctedRepair = correctedRepair.Replace("\"price\"", "\"Price\"");

            return correctedRepair;
        }

        private string CorrectInspection(string inspectionString)
        {
            string correctedInspection = inspectionString;

            correctedInspection = correctedInspection.Replace("\"testsPassed\"", "\"TestsPassed\"");
            correctedInspection = correctedInspection.Replace("\"inspectionExpirationDate\"", "\"InspectionExpirationDate\"");
            correctedInspection = correctedInspection.Replace("\"comment\"", "\"Comment\"");
            correctedInspection = correctedInspection.Replace("\"id\"", "\"Id\"");
            correctedInspection = correctedInspection.Replace("\"dateOfService\"", "\"DateOfService\"");
            correctedInspection = correctedInspection.Replace("\"employeeId\"", "\"EmployeeId\"");
            correctedInspection = correctedInspection.Replace("\"vinNumber\"", "\"VinNumber\"");
            correctedInspection = correctedInspection.Replace("\"price\"", "\"Price" +
                "\"");

            return correctedInspection;
        }
    }
}