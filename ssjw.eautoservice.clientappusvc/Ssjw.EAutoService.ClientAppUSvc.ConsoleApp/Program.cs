namespace Ssjw.EAutoService.ClientAppUSvc.ConsoleApp
{
    using Ssjw.EAutoService.ClientAppUSvc.RestClient;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;


    public class Program
    {
        private static void printExtendedBodyPartDto(List<ExtendedBodyPartDto> list)
        {
            foreach (ExtendedBodyPartDto element in list)
            {
                Console.WriteLine("Id: " + element.id + " - BodyType: " + element.bodyType + " - Colour: " + element.colour + " - Price: " + element.price);
            }
        }
        private static void printExtendedMechanicalPartDto(List<ExtendedMechanicalPartDto> list)
        {
            foreach (ExtendedMechanicalPartDto element in list)
            {
                Console.WriteLine("Id: " + element.id + " - Category: " + element.category + " - Description: " + element.description + " - Price: " + element.price);
            }
        }
        private static void printExtendedRepairDto(List<ExtendedRepairDto> list)
        {
            foreach (ExtendedRepairDto element in list)
            {
                Console.WriteLine("ID: " + element.id + " - Vin: " + element.vinNumber + " - EmployeeId: " + element.employeeId + " - DateOfService: " + element.dateOfService);
            }
        }
        private static void printExtendedLiquidDto(List<ExtendedLiquidDto> list)
        {
            foreach (ExtendedLiquidDto element in list)
            {
                Console.WriteLine("ID: " + element.id + " - Category: " + element.category + " - Density: " + element.density + " - ContainsPb: " + element.containsPb);
            }
        }
        private static void printExtendedCarDto(ExtendedCarDto car)
        {
            Console.WriteLine("Vin: " + car.vin + " - Model: " + car.model + " - ProductionYear: " + car.productionYear + " - InsurenceNumber: " + car.insurenceNumber);
            Console.WriteLine("ServicesHistoryIds: ");
            foreach (string element in car.servicesHistoryInspections)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine("--------------------- ");
        }
        private static void printCompleteClient(ExtendedClientDto l)
        {
            Console.WriteLine("name: " + l.name + "surname:" + l.surname + "phone number: " + l.phoneNumber + "idcardNumber: " + l.idCardNumber);
            if (l.vinNumbers.Count != 0)
            {
                foreach (string s in l.vinNumbers)
                {
                    Console.WriteLine(s);
                }
            }

        }
        private static void printExtendedEmployeeDto(ExtendedEmployeeDto employee)
        {
            Console.WriteLine("Id: " + employee.id + " - Name: " + employee.name + " - Surname: " +
                employee.surname + " - PhoneNumber: " + employee.phoneNumber + " - JobPosition: " + employee.jobPosition);
        }
        public static void Main(string[] args)
        {

            IClientAppSvc client = new ClientAppUSvcClient();
            IClientAppSvc clientMock = new ClientAppUSvcMockClient();

            Console.WriteLine("====================");
            Console.WriteLine("====REST CLIENT=====");
            Console.WriteLine("====================");

            Console.WriteLine("GettingAllBodyParts: ");
            List<ExtendedBodyPartDto> bodyPartsList = client.GetAllBodyParts();
            printExtendedBodyPartDto(bodyPartsList);
            Console.WriteLine();
            Console.WriteLine("GettingAllLiquids: ");
            List<ExtendedLiquidDto> liquidsList = client.GetAllLiquids();
            printExtendedLiquidDto(liquidsList);
            Console.WriteLine();
            Console.WriteLine("Getting mechanical part by price (5<x<56)");
            List<ExtendedMechanicalPartDto> mechanicalPartByPriceList = client.FindMechanicalPartByPrice(5.0m, 56.0m);
            printExtendedMechanicalPartDto(mechanicalPartByPriceList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("I'm shop customer, I'd like to see my liquids available by category fuel:");
            List<ExtendedLiquidDto> liquidRepairDto = client.FindLiquidByCategory("fuel");
            printExtendedLiquidDto(liquidRepairDto);
            Console.WriteLine();
            Console.WriteLine("I'm owner of volvo with vinNumber: 131411414 ,I'd like to see my CarInformation:");
            ExtendedCarDto ExtendedCarDto = client.GetCarInformation("131411414");
            printExtendedCarDto(ExtendedCarDto);
            Console.WriteLine();
            Console.WriteLine("Changing my personal info:");
            printCompleteClient(client.GetPersonalInformation("test1"));
            List<string> t = client.GetPersonalInformation("test1").vinNumbers;
            client.ModifyPersonalData("test1", "test1", "kamilProgram4", "KowalskiProgram15", "phoneProgram3", t);
            IClientAppSvc client2 = new ClientAppUSvcClient();
            Thread.Sleep(10000);
            ExtendedClientDto clientAfterModification = client.GetPersonalInformation("test1");
            Console.WriteLine(clientAfterModification.name);
            Console.WriteLine("name: " + clientAfterModification.name + "surname:" + clientAfterModification.surname + "phone number: " + clientAfterModification.phoneNumber + "idcardNumber: " + clientAfterModification.idCardNumber);
            printCompleteClient(clientAfterModification);
            Console.WriteLine("==== GetAllClientCar ====");
            List<ExtendedCarDto> list = client.GetAllClientCar("test3");
            foreach (ExtendedCarDto c in list)
            {
                printExtendedCarDto(c);
            }
            Console.WriteLine("====Modify Car Data ====");
            printExtendedCarDto(client.GetCarInformation("131411414"));
            List<String> services = new List<string>() { "i4", "r1", "i1" };
            client.ModifyCarData("131411414", "astratest", "opel", new DateTime(2005, 12, 12), "145716", services);
            printExtendedCarDto(client.GetCarInformation("131411414"));
            Console.WriteLine("====GetAvailableMechaics ====");
            List<ExtendedEmployeeDto> availableEmployees = new List<ExtendedEmployeeDto>();
            availableEmployees = client.GetAvailableMechanics(new DateTime(2023, 5, 28));
            foreach (ExtendedEmployeeDto e in availableEmployees)
            {
                printExtendedEmployeeDto(e);
            }
            Console.WriteLine("====Add new Client====");
            client.AddNewClient(new ExtendedClientDto() { name = "testo", surname = "tewst", idCardNumber = "2312", phoneNumber = "123456789", vinNumbers = new List<String>() { "tetsta" } });
            Console.WriteLine("====Get car Inspection History====");
            List<ExtendedInspectionDto> inspectionsList = client.GetCarInspectionHistory("131411414");
            foreach (ExtendedInspectionDto e in inspectionsList)
            {
                Console.WriteLine(e.id);
            }
            Console.WriteLine("====Get car repairs History====");
            List<ExtendedRepairDto> repairsList = client.GetCarRepairHistory("131411414");
            foreach (ExtendedRepairDto e in repairsList)
            {
                Console.WriteLine(e.id);
            }

            Console.WriteLine("====Request new inspection====");
            client.RequestNewInspection(new ExtendedInspectionDto() { testsPassed = true, inspectionExpirationDate = new DateTime(2025, 1, 1), comment = "csadsads", id = "", dateOfService = new DateTime(2025, 1, 1), employeeId = "1", vinNumber = "131411414", price = 1200 });
            Console.WriteLine("Requested");
            Console.WriteLine("====Request new repair====");
            List<ExtendedRepairedPartDto> repairedPartsDtos = new List<ExtendedRepairedPartDto> {
              new ExtendedRepairedPartDto(){carPart  = "b0", causeOfRepair = "test", ifExchanged = true}
              };
            client.RequestNewRepair(new ExtendedRepairDto() { repairedParts = repairedPartsDtos, id = "", dateOfService = new DateTime(2025, 1, 1), employeeId = "test1", vinNumber = "131411414", price = 1200 });
            Console.WriteLine("Requested");
            Console.WriteLine("====PurchaseCarPart====");
            client.PurchaseCarPart("b0");
            printExtendedBodyPartDto(client.GetAllBodyParts());
            Console.WriteLine("====AddNewCar====");
            Console.WriteLine("Added");
            Console.WriteLine("====================");
            Console.WriteLine("====MOCK CLIENT=====");
            Console.WriteLine("====================");
            Console.WriteLine("GettingAllBodyParts: ");
            List<ExtendedBodyPartDto> bodyPartsList2 = clientMock.GetAllBodyParts();
            printExtendedBodyPartDto(bodyPartsList2);
            Console.WriteLine();
            Console.WriteLine("GettingAllLiquids: ");
            List<ExtendedLiquidDto> liquidsList2 = clientMock.GetAllLiquids();
            printExtendedLiquidDto(liquidsList2);
            Console.WriteLine();
            Console.WriteLine("Getting mechanical part by price (5<x<56)");
            List<ExtendedMechanicalPartDto> mechanicalPartByPriceList2 = clientMock.FindMechanicalPartByPrice(5.0m, 56.0m);
            printExtendedMechanicalPartDto(mechanicalPartByPriceList2);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("I'm shop customer, I'd like to see my liquids available by category fuel:");
            List<ExtendedLiquidDto> liquidRepairDto2 = clientMock.FindLiquidByCategory("fuel");
            printExtendedLiquidDto(liquidRepairDto2);
            Console.WriteLine();
            Console.WriteLine("I'm owner of volvo with vinNumber: 131411414 ,I'd like to see my CarInformation:");
            ExtendedCarDto ExtendedCarDto2 = clientMock.GetCarInformation("131411414");
            printExtendedCarDto(ExtendedCarDto2);
            Console.WriteLine();
            Console.WriteLine("Changing my personal info:");
            printCompleteClient(clientMock.GetPersonalInformation("test2"));
            List<string> t2 = clientMock.GetPersonalInformation("test2").vinNumbers;
            clientMock.ModifyPersonalData("test2", "test2", "modyfikacjjoa2", "newSurnameZap1", "newPhoneNumerZap1", t2);
            printCompleteClient(clientMock.GetPersonalInformation("test2"));
            Console.WriteLine("==== GetAllClientCar ====");
            List<ExtendedCarDto> list2 = clientMock.GetAllClientCar("test2");
            foreach (ExtendedCarDto c in list2)
            {
                printExtendedCarDto(c);
            }
            Console.WriteLine("====Modify Car Data ====");
            printExtendedCarDto(clientMock.GetCarInformation("131411414"));
            List<String> services2 = new List<string>() { "i4", "r1", "i1" };
            clientMock.ModifyCarData("131411414", "astratest", "opel", new DateTime(2005, 12, 12), "145716", services2);
            printExtendedCarDto(clientMock.GetCarInformation("131411414"));
            Console.WriteLine("====GetAvailableMechaics ====");
            List<ExtendedEmployeeDto> availableEmployees2 = new List<ExtendedEmployeeDto>();
            availableEmployees2 = clientMock.GetAvailableMechanics(new DateTime(2023, 5, 28));
            foreach (ExtendedEmployeeDto e in availableEmployees2)
            {
                printExtendedEmployeeDto(e);
            }
            Console.WriteLine("====Add new Client====");
            clientMock.AddNewClient(new ExtendedClientDto() { name = "testo", surname = "tewst", idCardNumber = "2312", phoneNumber = "123456789", vinNumbers = new List<String>() { "tetsta" } });
            Console.WriteLine("Added");

            Console.WriteLine("====Get car Inspection History====");
            List<ExtendedInspectionDto> inspectionsList2 = clientMock.GetCarInspectionHistory("131411414");
            foreach (ExtendedInspectionDto e in inspectionsList2)
            {
                Console.WriteLine(e.id);
            }
            Console.WriteLine("====Get car repairs History====");
            List<ExtendedRepairDto> repairsList2 = clientMock.GetCarRepairHistory("131411414");
            foreach (ExtendedRepairDto e in repairsList2)
            {
                Console.WriteLine(e.id);
            }
            Console.WriteLine("====Request new inspection====");
            clientMock.RequestNewInspection(new ExtendedInspectionDto() { testsPassed = true, inspectionExpirationDate = new DateTime(2025, 7, 5), comment = "c", id = "i10", dateOfService = new DateTime(2023, 7, 5), employeeId = "1", vinNumber = "131411414", price = 1200 });
            Console.WriteLine("Requested");
            Console.WriteLine("====Request new repair====");
            List<ExtendedRepairedPartDto> repairedPartsDtos2 = new List<ExtendedRepairedPartDto> {
            new ExtendedRepairedPartDto(){carPart  = "b0", causeOfRepair = "test", ifExchanged = true}
            };
            clientMock.RequestNewRepair(new ExtendedRepairDto() { repairedParts = repairedPartsDtos2, id = "i10", dateOfService = new DateTime(2023, 7, 5), employeeId = "1", vinNumber = "131411414", price = 1200 });
            Console.WriteLine("Requested");
            Console.WriteLine("====PurchaseCarPart====");
            clientMock.PurchaseCarPart("b0");
            printExtendedBodyPartDto(clientMock.GetAllBodyParts());  */
        }
    }
}