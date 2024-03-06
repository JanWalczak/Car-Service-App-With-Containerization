namespace Ssjw.EAutoService.CarPartsDataUSvc.RestClient
{
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;
    using System.Collections.Generic;

    public class CarPartsDataUSvcMockClient : ICarPartsDataUSvcClient
    {
        List<BodyPartDto> bodyParts = new List<BodyPartDto>();
        List<MechanicalPartDto> mechanicalParts = new List<MechanicalPartDto>();
        List<LiquidDto> liquids = new List<LiquidDto>();

        int bodyPartCounter;
        int liquidCounter;
        int mechanicalPartCounter;

        public CarPartsDataUSvcMockClient()
        {
            bodyPartCounter = 4;
            liquidCounter = 3;
            mechanicalPartCounter = 3;

            bodyParts.Add(new BodyPartDto() { id = "b0", bodyType = "large", material = "steel", price = 24.99m, colour = "red", counter = 100, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Brand", description = "Nissan" }, } } });
            bodyParts.Add(new BodyPartDto() { id = "b1", bodyType = "small", material = "steel", price = 14.99m, colour = "red", counter = 1000, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Brand", description = "Nissan" }, } } });
            bodyParts.Add(new BodyPartDto() { id = "b2", bodyType = "medium", material = "carbon", price = 149.99m, colour = "red", counter = 100, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Brand", description = "Nissan" }, } } });
            bodyParts.Add(new BodyPartDto() { id = "b3", bodyType = "small", material = "carbon", price = 12m, colour = "pink", counter = 0, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Brand", description = "Ferrari" }, } } });

            liquids.Add(new LiquidDto() { id = "l0", category = "Fuel", density = 20, containsPb = true, price = 440m, counter = 1000, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Usage", description = "Suvs only" }, } } });
            liquids.Add(new LiquidDto() { id = "l1", category = "Not-Fuel", density = 5, containsPb = true, price = 20m, counter = 1000, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Usage", description = "Cleaning" }, } } });
            liquids.Add(new LiquidDto() { id = "l2", category = "Fuel", density = 15, containsPb = false, price = 123m, counter = 10, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Usage", description = "Racing" }, } } });

            mechanicalParts.Add(new MechanicalPartDto() { id = "m0", category = "Gear", price = 40.12m, sizeX = 12, sizeY = 32, sizeZ = 34, description = "Good grid", counter = 0, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Type", description = "Engine" }, } } });
            mechanicalParts.Add(new MechanicalPartDto() { id = "m1", category = "Pole", price = 10m, sizeX = 2, sizeY = 2, sizeZ = 24, description = "Long one", counter = 15, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Type", description = "Stearing" }, } } });
            mechanicalParts.Add(new MechanicalPartDto() { id = "m2", category = "Pleat", price = 250m, sizeX = 250, sizeY = 10, sizeZ = 4, description = "Large one", counter = 14, otherPropertiesDto = new OtherPropertiesDto() { properties = new List<PropertyDto> { new PropertyDto() { name = "Type", description = "Under" }, } } });
        }

        public void AddBodyPart(BodyPartDto bodyPartDto)
        {
            string id = "b" + bodyPartCounter;
            bodyPartDto.id = id;
            bodyParts.Add(bodyPartDto);
            bodyPartCounter++;
        }

        public void AddLiquid(LiquidDto liquidDto)
        {
            string id = "l" + liquidCounter;
            liquidDto.id = id;
            liquids.Add(liquidDto);
            liquidCounter++;
        }

        public void AddMechanicalPart(MechanicalPartDto mechanicalPartDto)
        {
            string id = "m" + mechanicalPartCounter;
            mechanicalPartDto.id = id;
            mechanicalParts.Add(mechanicalPartDto);
            mechanicalPartCounter++;
        }

        public void ChangeNumberOfAvailableParts(string id, int number)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPartDto mechanicalPart = GetMechanicalPartById(id);
                        mechanicalPart.counter = number;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPartDto bodyPart = GetBodyPartById(id);
                        bodyPart.counter = number;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        LiquidDto liquid = GetLiquidById(id);
                        liquid.counter = number;
                    }
                    break;
            }
        }

        public void DeleteCarPart(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPartDto mechanicalPart = GetMechanicalPartById(id);
                        mechanicalParts.Remove(mechanicalPart);
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPartDto bodyPart = GetBodyPartById(id);
                        bodyParts.Remove(bodyPart);
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        LiquidDto liquid = GetLiquidById(id);
                        liquids.Remove(liquid);
                    }
                    break;
            }
        }

        public List<BodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            List<BodyPartDto> bodyPartDtos = new List<BodyPartDto>();
            foreach (BodyPartDto bodyPart in bodyParts)
            {
                if (bodyPart.bodyType == bodyType)
                {
                    bodyPartDtos.Add(bodyPart);
                }
            }
            return bodyPartDtos;
        }

        public List<BodyPartDto> FindBodyPartByMaterial(string material)
        {
            List<BodyPartDto> bodyPartDtos = new List<BodyPartDto>();
            foreach (BodyPartDto bodyPart in bodyParts)
            {
                if (bodyPart.material == material)
                {
                    bodyPartDtos.Add(bodyPart);
                }
            }
            return bodyPartDtos;
        }

        public List<BodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<BodyPartDto> bodyPartDtos = new List<BodyPartDto>();
            foreach (BodyPartDto bodyPart in bodyParts)
            {
                if (bodyPart.price >= minPrice && bodyPart.price <= maxPrice)
                {
                    bodyPartDtos.Add(bodyPart);
                }
            }
            return bodyPartDtos;
        }

        public List<LiquidDto> FindLiquidByCategory(string category)
        {
            List<LiquidDto> liquidDtos = new List<LiquidDto>();
            foreach (LiquidDto liquid in liquids)
            {
                if (liquid.category == category)
                {
                    liquidDtos.Add(liquid);
                }
            }
            return liquidDtos;
        }

        public List<LiquidDto> FindLiquidByDensity(int density)
        {
            List<LiquidDto> liquidDtos = new List<LiquidDto>();
            foreach (LiquidDto liquid in liquids)
            {
                if (liquid.density == density)
                {
                    liquidDtos.Add(liquid);
                }
            }
            return liquidDtos;
        }

        public List<LiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            List<LiquidDto> liquidDtos = new List<LiquidDto>();
            foreach (LiquidDto liquid in liquids)
            {
                if (liquid.price >= minPrice && liquid.price <= maxPrice)
                {
                    liquidDtos.Add(liquid);
                }
            }
            return liquidDtos;
        }

        public List<MechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            List<MechanicalPartDto> mechanicalPartDtos = new List<MechanicalPartDto>();
            foreach (MechanicalPartDto mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.category == category)
                {
                    mechanicalPartDtos.Add(mechanicalPart);
                }
            }
            return mechanicalPartDtos;
        }

        public List<MechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            List<MechanicalPartDto> mechanicalPartDtos = new List<MechanicalPartDto>();
            foreach (MechanicalPartDto mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.sizeX == sizeX && mechanicalPart.sizeY == sizeY && mechanicalPart.sizeZ == sizeZ)
                {
                    mechanicalPartDtos.Add(mechanicalPart);
                }
            }
            return mechanicalPartDtos;
        }

        public List<MechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<MechanicalPartDto> mechanicalPartDtos = new List<MechanicalPartDto>();
            foreach (MechanicalPartDto mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.price >= minPrice && mechanicalPart.price <= maxPrice)
                {
                    mechanicalPartDtos.Add(mechanicalPart);
                }
            }
            return mechanicalPartDtos;
        }

        public List<BodyPartDto> GetAllBodyParts()
        {
            List<BodyPartDto> availableBodyParts = new List<BodyPartDto>();
            foreach (BodyPartDto bodyPart in bodyParts)
            {
                if (bodyPart.counter != 0)
                {
                    availableBodyParts.Add(bodyPart);
                }
            }
            return availableBodyParts;
        }

        public List<LiquidDto> GetAllLiquids()
        {
            List<LiquidDto> availableLiquids = new List<LiquidDto>();
            foreach (LiquidDto liquid in liquids)
            {
                if (liquid.counter != 0)
                {
                    availableLiquids.Add(liquid);
                }
            }
            return availableLiquids;
        }

        public List<MechanicalPartDto> GetAllMechanicalParts()
        {
            List<MechanicalPartDto> availableMechanicalParts = new List<MechanicalPartDto>();
            foreach (MechanicalPartDto mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.counter != 0)
                {
                    availableMechanicalParts.Add(mechanicalPart);
                }
            }
            return availableMechanicalParts;
        }

        public List<BodyPartDto> GetAvailableAndUnavailableBodyParts()
        {
            return bodyParts;
        }

        public List<LiquidDto> GetAvailableAndUnavailableLiquids()
        {
            return liquids;
        }

        public List<MechanicalPartDto> GetAvailableAndUnavailableMechanicalParts()
        {
            return mechanicalParts;
        }

        public BodyPartDto GetBodyPartById(string id)
        {
            return bodyParts.Find(b => b.id == id);
        }

        public LiquidDto GetLiquidById(string id)
        {
            return liquids.Find(l => l.id == id);
        }

        public MechanicalPartDto GetMechanicalPartById(string id)
        {
            return mechanicalParts.Find(m => m.id == id);
        }

        public int GetNumberOfAvailableParts(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPartDto mechanicalPart = GetMechanicalPartById(id);
                        return mechanicalPart.counter;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPartDto bodyPart = GetBodyPartById(id);
                        return bodyPart.counter;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        LiquidDto liquid = GetLiquidById(id);
                        return liquid.counter;
                    }
                    break;
            }
            return -1;
        }

        public void RemoveCarPart(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPartDto mechanicalPart = GetMechanicalPartById(id);
                        mechanicalPart.counter--;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPartDto bodyPart = GetBodyPartById(id);
                        bodyPart.counter--;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        LiquidDto liquid = GetLiquidById(id);
                        liquid.counter--;
                    }
                    break;
            }
        }
    }
}
