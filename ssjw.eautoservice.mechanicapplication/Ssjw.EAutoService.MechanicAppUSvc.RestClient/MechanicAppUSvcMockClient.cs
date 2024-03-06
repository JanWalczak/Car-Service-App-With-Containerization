namespace Ssjw.EAutoService.MechanicAppUSvc.RestClient
{
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public class MechanicAppUSvcMockClient : IMechanicAppDto
    {
        CarsDataUSvcMockClient carsDataUSvcClient = new CarsDataUSvcMockClient();
        EmployeeDataUSvcMockClient employeeDataUSvcClient = new EmployeeDataUSvcMockClient();
        ServicesDataUSvcMockClient servicesDataUSvcClient = new ServicesDataUSvcMockClient();
        ClientDataUSvcMockClient clientDataUSvcClient = new ClientDataUSvcMockClient();
        CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

        public List<ExtendedCarDto> GetPersonalCars(string id)
        {
            List<string> vinList = new List<string>();
            List<ExtendedCarDto> foundCars = new List<ExtendedCarDto>();

            bool employeeServicesIsEmpty = employeeDataUSvcClient.GetEmployeeServices(id) == null && employeeDataUSvcClient.GetEmployeeServices(id).Count != 0;

            if (!employeeServicesIsEmpty)
            {
                foreach (string serviceId in employeeDataUSvcClient.GetEmployeeServices(id))
                {
                    if (serviceId[0] == 'i')
                    {
                        InspectionDto foundInspection = servicesDataUSvcClient.FindInspectionById(serviceId);
                        bool employeeHasThisInspection = foundInspection.EmployeeId != null;
                        if (employeeHasThisInspection)
                        {
                            if (!vinList.Contains(foundInspection.VinNumber))
                                vinList.Add(foundInspection.VinNumber);
                        }
                    }
                    else if (serviceId[0] == 'r')
                    {
                        RepairDto foundRepair = servicesDataUSvcClient.FindRepairById(serviceId);
                        bool employeeHasThisRepair = foundRepair.EmployeeId != null;
                        if (employeeHasThisRepair)
                        {
                            if (!vinList.Contains(foundRepair.VinNumber))
                                vinList.Add(foundRepair.VinNumber);
                        }
                    }
                }

                bool vinListIsEmpty = vinList.Count == 0;

                if (!vinListIsEmpty)
                {
                    foreach (string vin in vinList)
                    {
                        CarDto carDto = new CarDto();

                        if (carsDataUSvcClient.GetCarByVin(vin) != null)
                        {
                            carDto = carsDataUSvcClient.GetCarByVin(vin);
                        }
                        List<string> inspections = new List<string>();
                        List<string> repairs = new List<string>();

                        bool servicesHistoryIsNull = carDto.servicesHistory == null;

                        if (!servicesHistoryIsNull)
                        {
                            foreach (string serviceId in carDto.servicesHistory)
                            {
                                if (serviceId[0] == 'i')
                                {
                                    bool inspectionIsNotNull = servicesDataUSvcClient.FindInspectionById(serviceId) != null;
                                    if (inspectionIsNotNull)
                                    {
                                        inspections.Add(serviceId);
                                    }
                                }
                                else if (serviceId[0] == 'r')
                                {
                                    bool repairIsNotNull = servicesDataUSvcClient.FindRepairById(serviceId) != null;
                                    if (repairIsNotNull)
                                    {
                                        repairs.Add(serviceId);
                                    }
                                }
                            }
                        }

                        foundCars.Add(new ExtendedCarDto() { vin = carDto.vin, model = carDto.model, brand = carDto.brand, productionYear = carDto.productionYear, insurenceNumber = carDto.insurenceNumber, servicesHistoryInspections = inspections, servicesHistoryRepairs = repairs });
                    }
                }
            }

            return foundCars;
        }

        public ExtendedCarDto GetCarByVinNumber(string vin)
        {
            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);

            List<string> completeInspections = new List<string>();
            List<string> completeRepairs = new List<string>();

            foreach (string idNumber in carDto.servicesHistory)
            {
                if (idNumber[0] == 'i')
                {
                    completeInspections.Add(idNumber);
                }
                else if (idNumber[0] == 'r')
                {
                    completeRepairs.Add(idNumber);
                }
            }

            ExtendedCarDto completeCar = new ExtendedCarDto() { vin = carDto.vin, model = carDto.model, brand = carDto.brand, productionYear = carDto.productionYear, insurenceNumber = carDto.insurenceNumber, servicesHistoryInspections = completeInspections, servicesHistoryRepairs = completeRepairs };
            return completeCar;
        }

        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);
            List<ExtendedInspectionDto> completeInspections = new List<ExtendedInspectionDto>();
            bool carIsNotNull = carsDataUSvcClient.GetCarByVin(vin) != null;

            if (carIsNotNull)
            {
                foreach (string inspectionId in carDto.servicesHistory)
                {
                    if (inspectionId[0] == 'i')
                    {
                        bool inspectionIsNotNull = servicesDataUSvcClient.FindInspectionById(inspectionId) != null;
                        if (inspectionIsNotNull)
                        {
                            InspectionDto inspectionDto = servicesDataUSvcClient.FindInspectionById(inspectionId);
                            completeInspections.Add(new ExtendedInspectionDto()
                            {
                                id = inspectionDto.Id,
                                dateOfService = inspectionDto.DateOfService,
                                employeeId = inspectionDto.EmployeeId,
                                vinNumber = inspectionDto.VinNumber,
                                price = inspectionDto.Price,
                                testsPassed = inspectionDto.TestsPassed,
                                inspectionExpirationDate = inspectionDto.InspectionExpirationDate,
                                comment = inspectionDto.Comment
                            });
                        }
                    }
                }
            }

            return completeInspections;
        }

        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);
            List<ExtendedRepairDto> completeRepairs = new List<ExtendedRepairDto>();

            bool carIsNotNull = carsDataUSvcClient.GetCarByVin(vin) != null;

            if (carIsNotNull)
            {
                foreach (string repairId in carDto.servicesHistory)
                {
                    if (repairId[0] == 'r')
                    {
                        bool repairIsNotNull = servicesDataUSvcClient.FindRepairById(repairId) != null;
                        if (repairIsNotNull)
                        {
                            RepairDto repairDto = servicesDataUSvcClient.FindRepairById(repairId);

                            List<ExtendedRepairedPartDto> repairedParts = new List<ExtendedRepairedPartDto>();

                            foreach (RepairedPartDto repairedPartDto in repairDto.RepairedParts)
                            {
                                repairedParts.Add(new ExtendedRepairedPartDto() { carPart = repairedPartDto.CarPart, causeOfRepair = repairedPartDto.CauseOfRepair });
                            }

                            completeRepairs.Add(new ExtendedRepairDto()
                            {
                                id = repairDto.Id,
                                dateOfService = repairDto.DateOfService,
                                employeeId = repairDto.EmployeeId,
                                vinNumber = repairDto.VinNumber,
                                price = repairDto.Price,
                                repairedParts = repairedParts
                            });
                        }
                    }
                }
            }

            return completeRepairs;
        }

        public List<ExtendedRepairDto> GetPersonalRepairSchedule(string id)
        {
            List<string> allServiceIds = servicesDataUSvcClient.GetServicesByEmployeeId(id);

            List<RepairDto> repairDtoList = new List<RepairDto>();
            EmployeeDto employee = employeeDataUSvcClient.GetEmployeeById(id);

            foreach (string serviceId in allServiceIds)
            {
                bool personalId = serviceId[0] == 'r' && employee.services.Contains(serviceId);
                if (personalId)
                {
                    repairDtoList.Add(servicesDataUSvcClient.FindRepairById(serviceId));
                }
            }

            List<ExtendedRepairDto> completeRepairs = new List<ExtendedRepairDto>();

            foreach (RepairDto repairDto in repairDtoList)
            {
                List<ExtendedRepairedPartDto> repairedPartsList = new List<ExtendedRepairedPartDto>();

                foreach (RepairedPartDto repairedPartDto in repairDto.RepairedParts)
                {
                    repairedPartsList.Add(new ExtendedRepairedPartDto() { carPart = repairedPartDto.CarPart, causeOfRepair = repairedPartDto.CauseOfRepair });
                }

                completeRepairs.Add(new ExtendedRepairDto()
                {
                    id = repairDto.Id,
                    dateOfService = repairDto.DateOfService,
                    employeeId = repairDto.EmployeeId,
                    vinNumber = repairDto.VinNumber,
                    price = repairDto.Price,
                    repairedParts = repairedPartsList
                });
            }

            return completeRepairs;
        }

        public List<ExtendedInspectionDto> GetPersonalInspectionSchedule(string id)
        {
            List<string> allServiceIds = servicesDataUSvcClient.GetServicesByEmployeeId(id);

            List<InspectionDto> inspectionDtoList = new List<InspectionDto>();
            EmployeeDto employee = employeeDataUSvcClient.GetEmployeeById(id);

            foreach (string serviceId in allServiceIds)
            {
                bool personalId = serviceId[0] == 'i' && employee.services.Contains(serviceId);
                if (personalId)
                {
                    inspectionDtoList.Add(servicesDataUSvcClient.FindInspectionById(serviceId));
                }
            }

            List<ExtendedInspectionDto> completeInspections = new List<ExtendedInspectionDto>();

            foreach (InspectionDto inspectionDto in inspectionDtoList)
            {
                completeInspections.Add(new ExtendedInspectionDto()
                {
                    id = inspectionDto.Id,
                    dateOfService = inspectionDto.DateOfService,
                    employeeId = inspectionDto.EmployeeId,
                    vinNumber = inspectionDto.VinNumber,
                    price = inspectionDto.Price,
                    testsPassed = inspectionDto.TestsPassed,
                    inspectionExpirationDate = inspectionDto.InspectionExpirationDate,
                    comment = inspectionDto.Comment
                });
            }

            return completeInspections;
        }

        public void FinishRepair(string idService, double price, List<ExtendedRepairedPartDto> repairedParts)
        {
            RepairDto repairDto = servicesDataUSvcClient.FindRepairById(idService);

            List<RepairedPartDto> repairedPartDtos = new List<RepairedPartDto>();

            foreach (ExtendedRepairedPartDto repairedPart in repairedParts)
            {
                repairedPartDtos.Add(new RepairedPartDto() { CarPart = repairedPart.carPart, CauseOfRepair = repairedPart.causeOfRepair });
            }

            servicesDataUSvcClient.CompleteRepair(idService, price, repairedPartDtos);
            carsDataUSvcClient.AddServiceToCarHistory(repairDto.VinNumber, repairDto.Id);
            employeeDataUSvcClient.RemoveEmployeeService(repairDto.Id);
        }

        public void FinishInspection(string idService, double price, bool testsPassed, string comment)
        {
            InspectionDto inspectionDto = servicesDataUSvcClient.FindInspectionById(idService);

            servicesDataUSvcClient.CompleteInspection(inspectionDto.Id, price, testsPassed, comment);
            carsDataUSvcClient.AddServiceToCarHistory(inspectionDto.VinNumber, inspectionDto.Id);
            employeeDataUSvcClient.RemoveEmployeeService(inspectionDto.Id);
        }

        public List<ExtendedClientDto> GetAllClients()
        {
            List<ClientDto> clientsDto = clientDataUSvcClient.GetAllClients();
            List<ExtendedClientDto> completeClients = new List<ExtendedClientDto>();
            foreach (ClientDto clientDto in clientsDto)
            {
                completeClients.Add(new ExtendedClientDto()
                {
                    name = clientDto.Name,
                    surname = clientDto.Surname,
                    phoneNumber = clientDto.PhoneNumber,
                    idCardNumber = clientDto.IdCardNumber,
                    vinNumbers = clientDto.VinNumbers
                });
            }
            return completeClients;
        }

        public ExtendedClientDto GetClientInformation(string idCardNumber)
        {
            ClientDto clientDto = clientDataUSvcClient.FindClientByIdCard(idCardNumber);

            return new ExtendedClientDto()
            {
                name = clientDto.Name,
                surname = clientDto.Surname,
                phoneNumber = clientDto.PhoneNumber,
                idCardNumber = clientDto.IdCardNumber,
                vinNumbers = clientDto.VinNumbers
            };
        }

        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.GetAllMechanicalParts();

            List<ExtendedMechanicalPartDto> mechanicalParts = new List<ExtendedMechanicalPartDto>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                mechanicalParts.Add(new ExtendedMechanicalPartDto()
                {
                    id = mechanicalPartDto.id,
                    category = mechanicalPartDto.category,
                    price = mechanicalPartDto.price,
                    sizeX = mechanicalPartDto.sizeX,
                    sizeY = mechanicalPartDto.sizeY,
                    sizeZ = mechanicalPartDto.sizeZ,
                    description = mechanicalPartDto.description,
                    counter = mechanicalPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return mechanicalParts;
        }

        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.GetAllBodyParts();

            List<ExtendedBodyPartDto> bodyParts = new List<ExtendedBodyPartDto>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                bodyParts.Add(new ExtendedBodyPartDto()
                {
                    id = bodyPartDto.id,
                    bodyType = bodyPartDto.bodyType,
                    material = bodyPartDto.material,
                    price = bodyPartDto.price,
                    colour = bodyPartDto.colour,
                    counter = bodyPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return bodyParts;
        }

        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.GetAllLiquids();

            List<ExtendedLiquidDto> liquids = new List<ExtendedLiquidDto>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                liquids.Add(new ExtendedLiquidDto()
                {
                    id = liquidDto.id,
                    category = liquidDto.category,
                    density = liquidDto.density,
                    containsPb = liquidDto.containsPb,
                    price = liquidDto.price,
                    counter = liquidDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return liquids;
        }

        public List<ExtendedBodyPartDto> FindBodyPartByMaterial(string material)
        {
            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.FindBodyPartByMaterial(material); ;
            List<ExtendedBodyPartDto> bodyParts = new List<ExtendedBodyPartDto>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                bodyParts.Add(new ExtendedBodyPartDto()
                {
                    id = bodyPartDto.id,
                    bodyType = bodyPartDto.bodyType,
                    material = bodyPartDto.material,
                    price = bodyPartDto.price,
                    colour = bodyPartDto.colour,
                    counter = bodyPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return bodyParts;
        }

        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.FindBodyPartByBodyType(bodyType);
            List<ExtendedBodyPartDto> bodyParts = new List<ExtendedBodyPartDto>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                bodyParts.Add(new ExtendedBodyPartDto()
                {
                    id = bodyPartDto.id,
                    bodyType = bodyPartDto.bodyType,
                    material = bodyPartDto.material,
                    price = bodyPartDto.price,
                    colour = bodyPartDto.colour,
                    counter = bodyPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return bodyParts;
        }

        public void UseCarPart(string carPartId)
        {
            if (carPartsDataUSvcClient.GetNumberOfAvailableParts(carPartId) != 0)
            {
                carPartsDataUSvcClient.RemoveCarPart(carPartId);
            }
        }

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.FindMechanicalPartByDimensions(sizeX, sizeY, sizeZ);
            List<ExtendedMechanicalPartDto> mechanicalParts = new List<ExtendedMechanicalPartDto>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                mechanicalParts.Add(new ExtendedMechanicalPartDto()
                {
                    id = mechanicalPartDto.id,
                    category = mechanicalPartDto.category,
                    price = mechanicalPartDto.price,
                    sizeX = mechanicalPartDto.sizeX,
                    sizeY = mechanicalPartDto.sizeY,
                    sizeZ = mechanicalPartDto.sizeZ,
                    description = mechanicalPartDto.description,
                    counter = mechanicalPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return mechanicalParts;
        }

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.FindMechanicalPartByCategory(category);
            List<ExtendedMechanicalPartDto> mechanicalParts = new List<ExtendedMechanicalPartDto>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                mechanicalParts.Add(new ExtendedMechanicalPartDto()
                {
                    id = mechanicalPartDto.id,
                    category = mechanicalPartDto.category,
                    price = mechanicalPartDto.price,
                    sizeX = mechanicalPartDto.sizeX,
                    sizeY = mechanicalPartDto.sizeY,
                    sizeZ = mechanicalPartDto.sizeZ,
                    description = mechanicalPartDto.description,
                    counter = mechanicalPartDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return mechanicalParts;
        }

        public List<ExtendedLiquidDto> FindLiquidByDensity(int density)
        {
            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.FindLiquidByDensity(density);
            List<ExtendedLiquidDto> liquids = new List<ExtendedLiquidDto>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                liquids.Add(new ExtendedLiquidDto()
                {
                    id = liquidDto.id,
                    category = liquidDto.category,
                    density = liquidDto.density,
                    containsPb = liquidDto.containsPb,
                    price = liquidDto.price,
                    counter = liquidDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return liquids;
        }

        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.FindLiquidByCategory(category);
            List<ExtendedLiquidDto> liquids = new List<ExtendedLiquidDto>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherPropertiesDto otherProperties = new ExtendedOtherPropertiesDto();

                otherProperties.properties = new List<ExtendedPropertyDto>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.properties.Add(new ExtendedPropertyDto() { name = property.name, description = property.description });
                }

                liquids.Add(new ExtendedLiquidDto()
                {
                    id = liquidDto.id,
                    category = liquidDto.category,
                    density = liquidDto.density,
                    containsPb = liquidDto.containsPb,
                    price = liquidDto.price,
                    counter = liquidDto.counter,
                    otherPropertiesDto = otherProperties
                });
            }
            return liquids;
        }
    }
}
