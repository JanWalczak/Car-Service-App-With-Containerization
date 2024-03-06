namespace Ssjw.EAutoService.CarPartsDataUSvc.ConsoleApp
{
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;
    using System;
    using System.Collections.Generic;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public class Program
    {
        private static void PrintAllBodyPart(List<BodyPartDto> bodyPartDtos)
        {
            foreach (var partDto in bodyPartDtos)
            {
                Console.WriteLine(partDto.id + " : " + partDto.material + " : " + partDto.colour + " : " + partDto.bodyType + " : " + partDto.price + " : " + partDto.counter);
            }
        }

        private static void PrintAllLiquid(List<LiquidDto> LiquidDtos)
        {
            foreach (var partDto in LiquidDtos)
            {
                Console.WriteLine(partDto.id + " : " + partDto.category + " : " + partDto.density + " : " + partDto.containsPb + " : " + partDto.price + " : " + partDto.counter);
            }
        }

        private static void PrintAllMechanicalPart(List<MechanicalPartDto> mechanicalPartDtos)
        {
            foreach (var partDto in mechanicalPartDtos)
            {
                Console.WriteLine(partDto.id + " : " + partDto.category + " : " + partDto.sizeX + " : " + partDto.sizeY + " : " + partDto.sizeZ + " : " + partDto.description + " : " + partDto.price + " : " + partDto.counter);
            }
        }

        public static void Main(string[] args)
        {
            ICarPartsDataUSvcClient client = CarPartsDataUSvcClientFactory.GetCarPartsDataUSvcClient(true);

            OtherPropertiesDto otherProperties = new OtherPropertiesDto();

            otherProperties.properties = new List<PropertyDto>
            {
                new PropertyDto() { name = "name1", description = "desc1" },
                new PropertyDto() { name = "name2", description = "desc2" }
            };

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Body Part tests");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAllBodyParts test");

            PrintAllBodyPart(client.GetAllBodyParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAvailableAndUnavailableBodyParts test ");

            PrintAllBodyPart(client.GetAvailableAndUnavailableBodyParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindBodyPartByBodyType test");

            PrintAllBodyPart(client.FindBodyPartByBodyType("medium"));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindBodyPartByMaterial test");

            PrintAllBodyPart(client.FindBodyPartByMaterial("steel"));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindBodyPartByPrice test");

            PrintAllBodyPart(client.FindBodyPartByPrice(5.0m, 25.0m));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetBodyPartById test");

            BodyPartDto test = client.GetBodyPartById("b1");
            Console.WriteLine(test.id + " : " + test.otherPropertiesDto.properties.First().name);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("AddBodyPart test");

            client.AddBodyPart(new BodyPartDto() { bodyType = "bodytypetest", material = "client", price = 21.12m, colour = "purple", counter = 12, otherPropertiesDto = otherProperties });

            Console.WriteLine("----------------------------------------");
            PrintAllBodyPart(client.GetAvailableAndUnavailableBodyParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Liquid tests");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAllLiquids test");

            PrintAllLiquid(client.GetAllLiquids());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAvailableAndUnavailableLiquids test");

            PrintAllLiquid(client.GetAvailableAndUnavailableLiquids());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindLiquidByDensity test");

            PrintAllLiquid(client.FindLiquidByDensity(20));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindLiquidByCategory test");

            PrintAllLiquid(client.FindLiquidByCategory("Fuel"));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindLiquidByPrice test");

            PrintAllLiquid(client.FindLiquidByPrice(19.0m, 21.0m));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetLiquidById test");

            LiquidDto testLiquid = client.GetLiquidById("l1");
            Console.WriteLine(testLiquid.id + " : " + testLiquid.otherPropertiesDto.properties.First().name);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetLiquidById test");

            client.AddLiquid(new LiquidDto() { category = "fuel", density = 12, containsPb = false, price = 23.1m, counter = 12, otherPropertiesDto = otherProperties });

            Console.WriteLine("----------------------------------------");

            PrintAllLiquid(client.GetAvailableAndUnavailableLiquids());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Mechanical Part tests");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAllMechanicalParts test");

            PrintAllMechanicalPart(client.GetAllMechanicalParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetAvailableAndUnavailableMechanicalParts test");

            PrintAllMechanicalPart(client.GetAvailableAndUnavailableMechanicalParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindMechanicalPartByCategory test");

            PrintAllMechanicalPart(client.FindMechanicalPartByCategory("Gear"));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindMechanicalPartByDimensions test");

            PrintAllMechanicalPart(client.FindMechanicalPartByDimensions(5, 5, 25));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("FindMechanicalPartByPrice test");

            PrintAllMechanicalPart(client.FindMechanicalPartByPrice(5, 20));

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("GetMechanicalPartById test");

            MechanicalPartDto testMechanical = client.GetMechanicalPartById("m1");
            Console.WriteLine(testMechanical.id + " : " + testMechanical.otherPropertiesDto.properties.First().name);

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("AddMechanicalPart test");

            client.AddMechanicalPart(new MechanicalPartDto() { category = "part", price = 23, sizeX = 1, sizeY = 1, sizeZ = 1, description = "test", counter = 12, otherPropertiesDto = otherProperties });

            Console.WriteLine("----------------------------------------");

            PrintAllMechanicalPart(client.GetAvailableAndUnavailableMechanicalParts());

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Car Part tests");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("ChangeNumberOfAvailableParts tests");
            Console.WriteLine("----------------------------------------");
            client.ChangeNumberOfAvailableParts("l3", 150);

            Console.WriteLine("GetNumberOfAvailableParts tests");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine(client.GetNumberOfAvailableParts("l3"));

            Console.WriteLine("RemoveCarPart tests");
            Console.WriteLine("----------------------------------------");

            client.RemoveCarPart("l3");

            Console.WriteLine("GetNumberOfAvailableParts tests");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine(client.GetNumberOfAvailableParts("l3"));

            Console.WriteLine("DeleteCarPart tests");
            Console.WriteLine("----------------------------------------");

            client.DeleteCarPart("l3");
            client.DeleteCarPart("m3");
            client.DeleteCarPart("b4");

            PrintAllBodyPart(client.GetAvailableAndUnavailableBodyParts());
            PrintAllMechanicalPart(client.GetAvailableAndUnavailableMechanicalParts());
            PrintAllLiquid(client.GetAvailableAndUnavailableLiquids());
        }
    }
}


