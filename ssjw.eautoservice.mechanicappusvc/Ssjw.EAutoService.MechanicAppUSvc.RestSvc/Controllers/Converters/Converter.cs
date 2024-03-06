namespace Ssjw.EAutoService.MechanicAppUSvc.RestSvc.Controllers.Converters
{
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;

    public static class Converter
    {
        public static ExtendedPropertyDto ConvertToPropertyDto(this ExtendedProperty property)
        {
            return new ExtendedPropertyDto() { name = property.Name, description = property.Description };
        }

        public static ExtendedBodyPartDto ConvertToBodyPartDto(this ExtendedBodyPart bodyParts)
        {
            return new ExtendedBodyPartDto() { id = bodyParts.Id, bodyType = bodyParts.BodyType, material = bodyParts.Material, price = bodyParts.Price, colour = bodyParts.Colour };
        }

        public static ExtendedLiquidDto ConvertToLiquidDto(this ExtendedLiquid liquids)
        {
            return new ExtendedLiquidDto() { id = liquids.Id, category = liquids.Category, density = liquids.Density, containsPb = liquids.ContainsPb, price = liquids.Price };
        }

        public static ExtendedMechanicalPartDto ConvertToMechanicalPartDto(this ExtendedMechanicalPart mechanicalParts)
        {
            return new ExtendedMechanicalPartDto() { id = mechanicalParts.Id, category = mechanicalParts.Category, price = mechanicalParts.Price, sizeX = mechanicalParts.SizeX, sizeY = mechanicalParts.SizeY, sizeZ = mechanicalParts.SizeZ, description = mechanicalParts.Description };
        }

        public static ExtendedOtherPropertiesDto ConvertToFullOtherPropertiesDto(this ExtendedOtherProperties otherProperties)
        {
            List<ExtendedPropertyDto> propertiesDto = new List<ExtendedPropertyDto>();
            foreach (ExtendedProperty property in otherProperties.Properties)
            {
                propertiesDto.Add(property.ConvertToPropertyDto());
            }
            ExtendedOtherPropertiesDto otherPropertiesDto = new ExtendedOtherPropertiesDto();
            otherPropertiesDto.properties = propertiesDto;
            return otherPropertiesDto;
        }

        public static ExtendedBodyPart ConvertToBodyPart(this ExtendedBodyPartDto bodyPartsDto)
        {
            return new ExtendedBodyPart(bodyPartsDto.id, bodyPartsDto.bodyType, bodyPartsDto.material, bodyPartsDto.price, bodyPartsDto.colour, bodyPartsDto.counter, bodyPartsDto.otherPropertiesDto.ConvertToOtherProperties());
        }

        public static ExtendedLiquid ConvertToLiquid(this ExtendedLiquidDto liquidsDto)
        {
            return new ExtendedLiquid(liquidsDto.id, liquidsDto.category, liquidsDto.density, liquidsDto.containsPb, liquidsDto.price, liquidsDto.counter, liquidsDto.otherPropertiesDto.ConvertToOtherProperties());
        }
        public static ExtendedMechanicalPart ConvertToMechanicalPart(this ExtendedMechanicalPartDto mechanicalPartsDto)
        {
            return new ExtendedMechanicalPart(mechanicalPartsDto.id, mechanicalPartsDto.category, mechanicalPartsDto.price, mechanicalPartsDto.sizeX, mechanicalPartsDto.sizeY, mechanicalPartsDto.sizeZ, mechanicalPartsDto.description, mechanicalPartsDto.counter, mechanicalPartsDto.otherPropertiesDto.ConvertToOtherProperties());
        }

        public static ExtendedProperty ConvertToProperty(this ExtendedPropertyDto propertyDto)
        {
            return new ExtendedProperty(propertyDto.name, propertyDto.description);
        }

        public static ExtendedOtherProperties ConvertToOtherProperties(this ExtendedOtherPropertiesDto otherProperties)
        {
            List<ExtendedPropertyDto> propertiesDto = otherProperties.properties;
            List<ExtendedProperty> properties = new List<ExtendedProperty>();
            foreach (ExtendedPropertyDto propertyDto in propertiesDto)
            {
                properties.Add(propertyDto.ConvertToProperty());
            }
            return new ExtendedOtherProperties(properties);
        }

        public static ExtendedClientDto ConvertToCompleteClientDto(this ExtendedClient client)
        {
            return new ExtendedClientDto() { idCardNumber = client.IdCardNumber, name = client.Name, phoneNumber = client.PhoneNumber, surname = client.Surname, vinNumbers = client.VinNumbers };
        }

        public static ExtendedInspectionDto ConvertToCompleteInspectionDto(this ExtendedInspection inspection)
        {
            return new ExtendedInspectionDto()
            {
                id = inspection.Id,
                comment = inspection.Comment,
                dateOfService = inspection.DateOfService,
                employeeId = inspection.EmployeeId,
                inspectionExpirationDate = inspection.InspectionExpirationDate,
                price = inspection.Price,
                testsPassed = inspection.TestsPassed,
                vinNumber = inspection.VinNumber
            };
        }

        public static ExtendedRepairDto ConvertToCompleteRepairDto(this ExtendedRepair repair)
        {
            List<ExtendedRepairedPartDto> parts = new List<ExtendedRepairedPartDto>();

            foreach (var part in repair.RepairedParts)
            {
                parts.Add(new ExtendedRepairedPartDto() { carPart = part.CarPart, causeOfRepair = part.CauseOfRepair });
            }

            return new ExtendedRepairDto() { vinNumber = repair.VinNumber, dateOfService = repair.DateOfService, employeeId = repair.EmployeeId, price = repair.Price, id = repair.Id, repairedParts = parts };
        }

        public static List<ExtendedRepairedPart> CreateRepairedPartsFromDto(List<ExtendedRepairedPartDto> list)
        {
            return list.Select(list => new ExtendedRepairedPart(list.carPart, list.causeOfRepair)).ToList();
        }

        public static List<ExtendedRepairedPartDto> CreateDtoFromRepairedParts(List<ExtendedRepairedPart> list)
        {
            List<ExtendedRepairedPartDto> dtos = new List<ExtendedRepairedPartDto>();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dtos.Add(new ExtendedRepairedPartDto()
                    {
                        carPart = list[i].CarPart,
                        causeOfRepair = list[i].CauseOfRepair,
                    });
                }
            }
            return dtos;
        }

        public static ExtendedCarDto ConvertToCompleteCarDto(this ExtendedCar car)
        {
            List<string> inspections = new List<string>();
            List<string> repairs = new List<string>();

            foreach (ExtendedInspection insp in car.ServicesHistoryInspections)
            {
                inspections.Add(insp.Id);
            }

            foreach (ExtendedRepair rep in car.ServicesHistoryRepairs)
            {
                repairs.Add(rep.Id);
            }


            return new ExtendedCarDto()
            {
                brand = car.Brand,
                insurenceNumber = car.InsurenceNumber,
                model = car.Model,
                productionYear = car.ProductionYear,
                vin = car.Vin,
                servicesHistoryInspections = inspections,
                servicesHistoryRepairs = repairs
            };
        }

        public static ExtendedRepairedPart CreateRepairedPartFromOneDto(ExtendedRepairedPartDto dto)
        {
            return new ExtendedRepairedPart(dto.carPart, dto.causeOfRepair);
        }

        public static ExtendedRepairedPartDto CreateDtoFromOneRepairedPart(ExtendedRepairedPart part)
        {
            return new ExtendedRepairedPartDto()
            {
                carPart = part.CarPart,
                causeOfRepair = part.CauseOfRepair
            };
        }
    }
}
