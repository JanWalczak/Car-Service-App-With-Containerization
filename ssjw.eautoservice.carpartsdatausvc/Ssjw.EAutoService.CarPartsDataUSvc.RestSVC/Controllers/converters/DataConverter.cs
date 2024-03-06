namespace Ssjw.EAutoService.CarPartsDataUSvc.RestSvc.Controllers.Converters
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public static class DataConverter
    {
        public static BodyPartDto ConvertToBodyPartDto(this BodyPart bodyPart)
        {
            return new BodyPartDto() { id = bodyPart.Id, bodyType = bodyPart.BodyType, material = bodyPart.Material, price = bodyPart.Price, colour = bodyPart.Colour, otherPropertiesDto = bodyPart.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static LiquidDto ConvertToLiquidDto(this Liquid liquid)
        {
            return new LiquidDto() { id = liquid.Id, category = liquid.Category, density = liquid.Density, containsPb = liquid.ContainsPb, price = liquid.Price, otherPropertiesDto = liquid.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static MechanicalPartDto ConvertToMechanicalPartDto(this MechanicalPart mechanicalPart)
        {
            return new MechanicalPartDto() { id = mechanicalPart.Id, category = mechanicalPart.Category, price = mechanicalPart.Price, sizeX = mechanicalPart.SizeX, sizeY = mechanicalPart.SizeY, sizeZ = mechanicalPart.SizeZ, description = mechanicalPart.Description, otherPropertiesDto = mechanicalPart.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static PropertyDto ConvertToPropertyDto(this Property property)
        {
            return new PropertyDto() { name = property.Name, description = property.Description };
        }

        public static BodyPartDto ConvertToBodyPartDtoWithNumber(this BodyPart bodyPart)
        {
            return new BodyPartDto() { id = bodyPart.Id, bodyType = bodyPart.BodyType, material = bodyPart.Material, price = bodyPart.Price, colour = bodyPart.Colour, counter = bodyPart.Counter, otherPropertiesDto = bodyPart.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static LiquidDto ConvertToLiquidDtoWithNumber(this Liquid liquid)
        {
            return new LiquidDto() { id = liquid.Id, category = liquid.Category, density = liquid.Density, containsPb = liquid.ContainsPb, price = liquid.Price, counter = liquid.Counter, otherPropertiesDto = liquid.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static MechanicalPartDto ConvertToMechanicalPartDtoWithNumber(this MechanicalPart mechanicalPart)
        {
            return new MechanicalPartDto() { id = mechanicalPart.Id, category = mechanicalPart.Category, price = mechanicalPart.Price, sizeX = mechanicalPart.SizeX, sizeY = mechanicalPart.SizeY, sizeZ = mechanicalPart.SizeZ, description = mechanicalPart.Description, counter = mechanicalPart.Counter, otherPropertiesDto = mechanicalPart.OtherProperties.ConvertToOtherPropertiesDto() };
        }

        public static OtherPropertiesDto ConvertToOtherPropertiesDto(this OtherProperties otherProperties)
        {
            List<PropertyDto> propertiesDto = new List<PropertyDto>();
            foreach (Property property in otherProperties.Properties)
            {
                propertiesDto.Add(property.ConvertToPropertyDto());
            }

            OtherPropertiesDto otherPropertiesDto = new OtherPropertiesDto();
            otherPropertiesDto.properties = propertiesDto;
            return otherPropertiesDto;
        }

        public static BodyPart ConvertToBodyPart(this BodyPartDto bodyPartsDto)
        {
            return new BodyPart(bodyPartsDto.id, bodyPartsDto.bodyType, bodyPartsDto.material, bodyPartsDto.price, bodyPartsDto.colour, bodyPartsDto.counter, bodyPartsDto.otherPropertiesDto.ConvertToOtherProperties());
        }

        public static Liquid ConvertToLiquid(this LiquidDto liquidsDto)
        {
            return new Liquid(liquidsDto.id, liquidsDto.category, liquidsDto.density, liquidsDto.containsPb, liquidsDto.price, liquidsDto.counter, liquidsDto.otherPropertiesDto.ConvertToOtherProperties());
        }
        public static MechanicalPart ConvertToMechanicalPart(this MechanicalPartDto mechanicalPartsDto)
        {
            return new MechanicalPart(mechanicalPartsDto.id, mechanicalPartsDto.category, mechanicalPartsDto.price, mechanicalPartsDto.sizeX, mechanicalPartsDto.sizeY, mechanicalPartsDto.sizeZ, mechanicalPartsDto.description, mechanicalPartsDto.counter, mechanicalPartsDto.otherPropertiesDto.ConvertToOtherProperties());
        }

        public static Property ConvertToProperty(this PropertyDto propertyDto)
        {
            return new Property(propertyDto.name, propertyDto.description);
        }

        public static OtherProperties ConvertToOtherProperties(this OtherPropertiesDto otherProperties)
        {
            List<PropertyDto> propertiesDto = otherProperties.properties;
            List<Property> properties = new List<Property>();
            foreach (PropertyDto propertyDto in propertiesDto)
            {
                properties.Add(propertyDto.ConvertToProperty());
            }
            return new OtherProperties(properties);
        }
    }
}
