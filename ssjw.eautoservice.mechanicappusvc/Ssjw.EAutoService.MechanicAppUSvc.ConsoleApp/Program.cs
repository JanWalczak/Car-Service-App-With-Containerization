namespace Ssjw.EAutoService.MechanicAppUSvc.ConsoleApp
{

    using Ssjw.EAutoService.MechanicAppUSvc.RestClient;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;

    public class Program
    {

        private static void PrintAllBodyPart(List<ExtendedBodyPartDto> bodyPartDtos)
        {
            foreach (var partDto in bodyPartDtos)
            {
                Console.WriteLine("ID:" + partDto.id + " -- Material:" + partDto.material + " -- Colour:" + partDto.colour + " -- BodyType:" + partDto.bodyType + " -- Price:" + partDto.price);
            }
        }

        private static void PrintAllLiquid(List<ExtendedLiquidDto> LiquidDtos)
        {
            foreach (var partDto in LiquidDtos)
            {
                Console.WriteLine("ID:" + partDto.id + " -- Category:" + partDto.category + " -- Density:" + partDto.density + " -- ContainsPb:" + partDto.containsPb + " -- Price:" + partDto.price );
            }
        }

        private static void PrintAllMechanicalPart(List<ExtendedMechanicalPartDto> mechanicalPartDtos)
        {
            foreach (var partDto in mechanicalPartDtos)
            {
                Console.WriteLine("ID:" + partDto.id + " -- " + "Category:" + partDto.category + " -- " +" SizeX:"+ partDto.sizeX + " -- SizeY:" + partDto.sizeY + " -- SizeZ:" + partDto.sizeZ + " -- Description:" + partDto.description + " -- Price:" + partDto.price );
            }
        }

        public static void Main(string[] args)
        {
            IMechanicAppDto client = new MechanicAppUSvcMockClient();
            
            //IMechanicAppDto client = new MechanicAppUSvcClient();
            
            Console.Write("==== GetPersonalCars Test ====\n");
            List<ExtendedCarDto> carDtos = client.GetPersonalCars("2");
            foreach(ExtendedCarDto car in carDtos)
            {
                if (car.vin != null)
                {
                    Console.WriteLine("vin : " + car.vin + " brand : " + car.brand + " model : " + car.model);
                }
            }

            Console.WriteLine();

            Console.Write("==== GetCarByVinNumber Test ====\n");
            ExtendedCarDto carDto = client.GetCarByVinNumber("41414154");
            Console.WriteLine("vin : "+ carDto.vin + " brand : " + carDto.brand + " model : " + carDto.model);
            Console.WriteLine();


            //GetCarInspectionHistory
            Console.Write("==== GetCarInspectionHistory Test ====\n");
            List<ExtendedInspectionDto> carInspectionHistory = client.GetCarInspectionHistory("41414154");
            foreach (ExtendedInspectionDto insp in carInspectionHistory)
            {
                Console.WriteLine("id : " + insp.id + " vinNumber : " + insp.vinNumber + " comment : " + insp.comment + " date : " + insp.dateOfService +" price : " + insp.price);
            }


            Console.WriteLine();

            //  GetCarRepairHistory
            Console.Write("==== GetCarRepairHistory Test ====\n");
            List<ExtendedRepairDto> carRepairHistory = client.GetCarRepairHistory("41414154");
            foreach (ExtendedRepairDto repair in carRepairHistory)
            {
                Console.WriteLine("id : " + repair.id + " vinNumber : " + repair.vinNumber + " employeeId : " + repair.employeeId + " date : " + repair.dateOfService);
            }

            Console.WriteLine();

            ////     GetPersonalRepairSchedule
            Console.Write("==== GetPersonalRepairSchedule Test ====\n");
            List<ExtendedRepairDto> personalRepairs = client.GetPersonalRepairSchedule("2");
            foreach (ExtendedRepairDto repair in personalRepairs)
            {
                Console.WriteLine("id : " + repair.id + " vinNumber : " + repair.vinNumber + " employeeId : " + repair.employeeId + " date : " + repair.dateOfService);
            }

            Console.WriteLine();

            ////    GetPersonalInspectionSchedule
            Console.Write("==== GetPersonalInspectionSchedule Test ====\n");
            List<ExtendedInspectionDto> personalInspections = client.GetPersonalInspectionSchedule("2");
            foreach (ExtendedInspectionDto insp in personalInspections)
            {
                Console.WriteLine("id : " + insp.id + " vinNumber : " + insp.vinNumber + " comment : " + insp.comment + " date : " + insp.dateOfService);
            }

            Console.WriteLine();

           
           // Try this at MOCK

            ////  FinishInspection
            //Console.Write("==== FinishInspection Test ====\n");
            //client.FinishInspection("i4",1200.5,true,"Everything is fine");


            Console.WriteLine();

            //  GetAllClients
            Console.Write("==== GetAllClients Test ====\n");
            List<ExtendedClientDto> allClient = client.GetAllClients();
            foreach(ExtendedClientDto c in allClient)
            {
                Console.WriteLine("IdCardNumber : "  + c.idCardNumber + " Name : " + c.name + " Surname : " + c.surname);
            }


            Console.WriteLine();

            //  GetClientInformation
            Console.Write("==== GetClientInformation Test ====\n");
            ExtendedClientDto getClientInformation = client.GetClientInformation("test1");
            Console.WriteLine("IdCardNumber : " + getClientInformation.idCardNumber + " Name : " + getClientInformation.name + " Surname : " + getClientInformation.surname);


            Console.WriteLine();

            //  GetAllMechanicalParts
            Console.Write("==== GetAllMechanicalParts Test ====\n");
            List<ExtendedMechanicalPartDto> allMechanicalParts = client.GetAllMechanicalParts();
            PrintAllMechanicalPart(allMechanicalParts);

            Console.WriteLine();

            //  GetAllBodyParts
            Console.Write("==== GetAllBodyParts Test ====\n");
            List<ExtendedBodyPartDto> allBodyParts = client.GetAllBodyParts();
            PrintAllBodyPart(allBodyParts);



            Console.WriteLine();

            //  GetAllLiquids
            Console.Write("==== GetAllLiquids Test ====\n");
            List<ExtendedLiquidDto> allLiquids = client.GetAllLiquids();
            PrintAllLiquid(allLiquids);


            Console.WriteLine();

            //  FindBodyPartByMaterial

            Console.Write("==== FindBodyPartByMaterial Test ====\n");
            List<ExtendedBodyPartDto> bodyPartsByMaterial = client.FindBodyPartByMaterial("steel");
            PrintAllBodyPart(bodyPartsByMaterial);

            Console.WriteLine();

            //  FindBodyPartByBodyType
            Console.Write("==== FindBodyPartByBodyType Test ====\n");
            List<ExtendedBodyPartDto> bodyPartsByBodyType = client.FindBodyPartByBodyType("medium");
            PrintAllBodyPart(bodyPartsByBodyType);



            Console.WriteLine();

            //  UseCarPart
            Console.Write("==== UseCarPart Test ====\n");
            client.UseCarPart("m2");


            Console.WriteLine();

            //  FindMechanicalPartByDimensions
            Console.Write("==== FindMechanicalPartByDimensions Test ====\n");
            List<ExtendedMechanicalPartDto> mechanicalPartsByDimensions = client.FindMechanicalPartByDimensions(2,2,24);
            PrintAllMechanicalPart(mechanicalPartsByDimensions);


            Console.WriteLine();

            //  FindMechanicalPartByCategory
            Console.Write("==== FindMechanicalPartByCategory Test ====\n");
            List<ExtendedMechanicalPartDto> mechanicalPartsByCategory = client.FindMechanicalPartByCategory("Plate");
            PrintAllMechanicalPart(mechanicalPartsByCategory);


            Console.WriteLine();

            //  FindLiquidByDensity
            Console.Write("==== FindLiquidByDensity Test ====\n");
            List<ExtendedLiquidDto> liquidsByDensity = client.FindLiquidByDensity(15);
            PrintAllLiquid(liquidsByDensity);


            Console.WriteLine();

            //  FindLiquidByCategory
            Console.Write("==== FindLiquidByCategory Test ====\n");
            List<ExtendedLiquidDto> liquidsByCategory= client.FindLiquidByCategory("Fuel");
            PrintAllLiquid(liquidsByCategory);
        }
    }
}