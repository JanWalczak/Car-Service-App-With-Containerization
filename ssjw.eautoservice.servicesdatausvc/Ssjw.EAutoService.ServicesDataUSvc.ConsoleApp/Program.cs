namespace Ssjw.EAutoService.ServicesDataUSvc.ConsoleApp
{
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Client");
            ServicesDataUSvcClient client = new ServicesDataUSvcClient();

            Console.WriteLine("\nInspections:\n");

            Console.WriteLine("\nGetting all inspections");
            client.GetAllInspections();

            Console.WriteLine("\nAdding inspection");
            InspectionDto inspectionDto = new InspectionDto()
            {
                Id = "i",
                DateOfService = new DateTime(2023, 2, 3),
                EmployeeId = "2",
                VinNumber = "11111661",
                Price = 0,
                TestsPassed = false,
                InspectionExpirationDate = new DateTime(2023, 2, 3),
                Comment = ""
            };
            client.AddInspection(inspectionDto);

            Console.WriteLine("Searching for inspection by id:");
            client.FindInspectionById("i2");
            client.FindInspectionById("16");

            Console.WriteLine("\nGetting inspections by vin number");
            client.GetInspectionsByVinNumber("131411414");
            client.GetInspectionsByVinNumber("123456789");

            Console.WriteLine("\nCompleting inspection");
            client.CompleteInspection("i7", 5000.20, true, "All fine");
            client.CompleteInspection("28", 5000.20, true, "All fine");

            Console.WriteLine("\nGetting all inspections");
            client.GetAllInspections();

            Console.WriteLine("\nRemoving inspection");
            client.RemoveInspection("i7");
            client.RemoveInspection("test");

            Console.WriteLine("\nGetting inspection by passed tests field");
            client.GetAllByPassedFieldInspections(true);

            Console.WriteLine("\nGetting inspection's eployee id and vin number");
            client.GetInspectionEmployeeIdVinNumber("i1");
            client.GetInspectionEmployeeIdVinNumber("15");

            Console.WriteLine("\nGetting all inspections");
            client.GetAllInspections();


            Console.WriteLine("\n\nRepairs:\n");

            Console.WriteLine("Getting all repairs");
            client.GetAllRepairs();

            Console.WriteLine("\nAdding repair");
            RepairDto repair = new RepairDto()
            {
                Id = "r",
                DateOfService = new DateTime(2023, 5, 5),
                EmployeeId = "1",
                VinNumber = "11111661",
                Price = 0,
                RepairedParts = new List<RepairedPartDto>()
            };
            client.AddRepair(repair);

            Console.WriteLine("\nSearching reapair by id");
            client.FindRepairById("r2");
            client.FindRepairById("92");

            Console.WriteLine("\nGetting repair by vin number");
            client.GetRepairByVinNumber("131411414");
            client.GetRepairByVinNumber("123456789");

            Console.WriteLine("\nGetting all repairs");
            client.GetAllRepairs();

            Console.WriteLine("\nCompleting repair");
            client.CompleteRepair("r7", 6023.8, new List<RepairedPartDto> {
                new RepairedPartDto { CarPart = "m3", CauseOfRepair = "Broken" } });
            client.CompleteRepair("98", 6023.8, new List<RepairedPartDto> {
                new RepairedPartDto { CarPart = "m3", CauseOfRepair = "Broken" } });

            Console.WriteLine("\nGetting repaired parts by rapair's id");
            client.GetRepairedPartsById("r3");
            client.GetRepairedPartsById("55");

            Console.WriteLine("\nGetting repair's employee id and vin number");
            client.GetRepairEmployeeIdVinNumber("r2");
            client.GetRepairEmployeeIdVinNumber("s4");

            Console.WriteLine("\nGetting all repairs");
            client.GetAllRepairs();

            Console.WriteLine("\nRemoving repair");
            client.RemoveRepair("r7");
            client.RemoveRepair("44");

            Console.WriteLine("\nGetting all services' ids by employee id");
            client.GetServicesByEmployeeId("2");
            client.GetServicesByEmployeeId("test");

            Console.WriteLine("\nGetting all repairs");
            client.GetAllRepairs();


            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.Write("\n\n\nMock client");
            ServicesDataUSvcMockClient mock = new ServicesDataUSvcMockClient();

            Console.WriteLine("\nInspections:\n");

            Console.WriteLine("\nGetting all inspections");
            mock.GetAllInspections();

            Console.WriteLine("\nAdding inspection");
            InspectionDto inspectionDto2 = new InspectionDto()
            {
                Id = "i",
                DateOfService = new DateTime(2023, 2, 3),
                EmployeeId = "2",
                VinNumber = "11111661",
                Price = 0,
                TestsPassed = false,
                InspectionExpirationDate = new DateTime(2023, 2, 3),
                Comment = ""
            };
            mock.AddInspection(inspectionDto2);

            Console.WriteLine("Searching for inspection by id:");
            mock.FindInspectionById("i2");
            mock.FindInspectionById("17");

            Console.WriteLine("\nGetting inspections by vin number");
            mock.GetInspectionsByVinNumber("131411414");
            mock.GetInspectionsByVinNumber("123456789");

            Console.WriteLine("\nCompleting inspection");
            mock.CompleteInspection("i7", 5000.20, true, "All fine");
            mock.CompleteInspection("66", 5000.20, true, "All fine");

            Console.WriteLine("\nGetting all inspections");
            mock.GetAllInspections();

            Console.WriteLine("\nRemoving inspection");
            mock.RemoveInspection("i7");
            mock.RemoveInspection("19");

            Console.WriteLine("\nGetting inspection by passed tests field");
            mock.GetAllByPassedFieldInspections(true);

            Console.WriteLine("\nGetting inspection's eployee id and vin number");
            mock.GetInspectionEmployeeIdVinNumber("i1");
            mock.GetInspectionEmployeeIdVinNumber("test");

            Console.WriteLine("\nGetting all inspections");
            mock.GetAllInspections();


            Console.WriteLine("\n\nRepairs:\n");

            Console.WriteLine("Getting all repairs");
            mock.GetAllRepairs();

            Console.WriteLine("\nAdding repair");
            RepairDto repair2 = new RepairDto()
            {
                Id = "r",
                DateOfService = new DateTime(2023, 5, 5),
                EmployeeId = "1",
                VinNumber = "11111661",
                Price = 0,
                RepairedParts = new List<RepairedPartDto>()
            };
            mock.AddRepair(repair2);

            Console.WriteLine("\nSearching reapair by id");
            mock.FindRepairById("r2");
            mock.FindRepairById("test");

            Console.WriteLine("\nGetting repair by vin number");
            mock.GetRepairByVinNumber("131411414");
            mock.GetRepairByVinNumber("929288392");

            Console.WriteLine("\nGetting all repairs");
            mock.GetAllRepairs();

            Console.WriteLine("\nCompleting repair");
            mock.CompleteRepair("r7", 6023.8, new List<RepairedPartDto> {
                new RepairedPartDto { CarPart = "m3", CauseOfRepair = "Broken" } });
            mock.CompleteRepair("test", 6023.8, new List<RepairedPartDto> {
                new RepairedPartDto { CarPart = "m3", CauseOfRepair = "Broken" } });

            Console.WriteLine("\nGetting repaired parts by rapair's id");
            mock.GetRepairedPartsById("r3");
            mock.GetRepairedPartsById("6161");

            Console.WriteLine("\nGetting repair's employee id and vin number");
            mock.GetRepairEmployeeIdVinNumber("r2");
            mock.GetRepairEmployeeIdVinNumber("i10");

            Console.WriteLine("\nGetting all repairs");
            mock.GetAllRepairs();

            Console.WriteLine("\nRemoving repair");
            mock.RemoveRepair("r7");
            mock.RemoveRepair("i10");

            Console.WriteLine("\nGetting all services' ids by employee id");
            mock.GetServicesByEmployeeId("2");
            mock.GetServicesByEmployeeId("test");

            Console.WriteLine("\nGetting all repairs");
            mock.GetAllRepairs();
        }
    }
}
