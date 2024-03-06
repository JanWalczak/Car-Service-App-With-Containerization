namespace Ssjw.EAutoService.ClientAppUSvc.RestClient
{
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public class ClientAppUSvcMockClient : IClientAppSvc
    {
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType)
        {
            CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

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

        public List<ExtendedBodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<BodyPartDto> bodyPartDtos = new List<BodyPartDto>();
            List<ExtendedBodyPartDto> extendedBodyPartDtoList = new List<ExtendedBodyPartDto>();
            CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient client = new CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient();
            bodyPartDtos = client.FindBodyPartByPrice(minPrice, maxPrice);
            foreach (BodyPartDto bodyPartsDto in bodyPartDtos)
            {
                extendedBodyPartDtoList.Add(new ExtendedBodyPartDto() { id = bodyPartsDto.id, bodyType = bodyPartsDto.bodyType, material = bodyPartsDto.material, price = bodyPartsDto.price, colour = bodyPartsDto.colour, counter = bodyPartsDto.counter });
            }
            return extendedBodyPartDtoList;
        }

        public List<ExtendedLiquidDto> FindLiquidByCategory(string category)
        {
            CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

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

        public List<ExtendedLiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            List<LiquidDto> LiquidDtos = new List<LiquidDto>();
            List<ExtendedLiquidDto> ExtendedLiquidDtosList = new List<ExtendedLiquidDto>();
            CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient client = new CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient();
            LiquidDtos = client.FindLiquidByPrice(minPrice, maxPrice);
            foreach (LiquidDto liquidsDto in LiquidDtos)
            {
                ExtendedLiquidDtosList.Add(new ExtendedLiquidDto() { id = liquidsDto.id, category = liquidsDto.category, density = liquidsDto.density, containsPb = liquidsDto.containsPb, price = liquidsDto.price, counter = liquidsDto.counter });
            }
            return ExtendedLiquidDtosList;
        }

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category)
        {
            CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

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

        public List<ExtendedMechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<MechanicalPartDto> mechanicalPartDtos = new List<MechanicalPartDto>();
            List<ExtendedMechanicalPartDto> extendedMechanicalPartDtoList = new List<ExtendedMechanicalPartDto>();
            CarPartsDataUSvcMockClient client = new CarPartsDataUSvcMockClient();
            mechanicalPartDtos = client.FindMechanicalPartByPrice(minPrice, maxPrice);
            foreach (MechanicalPartDto mechanicalPartsDto in mechanicalPartDtos)
            {
                extendedMechanicalPartDtoList.Add(new ExtendedMechanicalPartDto() { id = mechanicalPartsDto.id, category = mechanicalPartsDto.category, price = mechanicalPartsDto.price, sizeX = mechanicalPartsDto.sizeX, sizeY = mechanicalPartsDto.sizeY, sizeZ = mechanicalPartsDto.sizeZ, description = mechanicalPartsDto.description, counter = mechanicalPartsDto.counter });
            }
            return extendedMechanicalPartDtoList;
        }

        public List<ExtendedBodyPartDto> GetAllBodyParts()
        {
            CarPartsDataUSvcMockClient client = new CarPartsDataUSvcMockClient();
            List<BodyPartDto> bodyPartsList = new List<BodyPartDto>();
            bodyPartsList = client.GetAllBodyParts();
            List<ExtendedBodyPartDto> extendedBodyPartsList = new List<ExtendedBodyPartDto>();
            foreach (BodyPartDto bodyPartDto in bodyPartsList)
            {
                extendedBodyPartsList.Add(new ExtendedBodyPartDto() { id = bodyPartDto.id, bodyType = bodyPartDto.bodyType, material = bodyPartDto.material, price = bodyPartDto.price, colour = bodyPartDto.colour, counter = bodyPartDto.counter });
            }
            return extendedBodyPartsList;
        }

        public List<ExtendedLiquidDto> GetAllLiquids()
        {
            CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

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

        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts()
        {
            CarPartsDataUSvcMockClient carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();

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

        public ExtendedCarDto GetCarInformation(string vin)
        {
            CarsDataUSvc.RestClient.CarsDataUSvcMockClient carClient = new CarsDataUSvc.RestClient.CarsDataUSvcMockClient();
            ServicesDataUSvcMockClient servicesClient = new ServicesDataUSvcMockClient();
            CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient carPartsClient = new CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient();
            CarDto carDto = null;
            if (carClient.GetCarByVin(vin) != null)
            {
                carDto = carClient.GetCarByVin(vin);
            }
            if (carDto == null) return null;
            List<ExtendedInspectionDto> ExtendedInspections = new List<ExtendedInspectionDto>();
            List<ExtendedRepairDto> ExtendedRepairs = new List<ExtendedRepairDto>();
            if (carDto.servicesHistory != null && carDto.servicesHistory.Count != 0)
            {
                List<InspectionDto> inspectionsDto = servicesClient.GetInspectionsByVinNumber(vin);
                List<RepairDto> repairsDto = servicesClient.GetRepairByVinNumber(vin);
                foreach (string serviceId in carDto.servicesHistory)
                {
                    if (serviceId[0] == 'r')
                    {
                        foreach (RepairDto repairDto in repairsDto)
                        {
                            if (repairDto.Id == serviceId)
                            {

                                List<ExtendedRepairedPartDto> ExtendedRepairedParts = new List<ExtendedRepairedPartDto>();

                                foreach (RepairedPartDto ExtendedRepairedPartDto in servicesClient.GetRepairedPartsById(serviceId))
                                {
                                    ExtendedRepairedParts.Add((new ExtendedRepairedPartDto() { carPart = ExtendedRepairedPartDto.CarPart, causeOfRepair = ExtendedRepairedPartDto.CauseOfRepair }));
                                    ExtendedRepairs.Add(new ExtendedRepairDto() { id = repairDto.Id, dateOfService = repairDto.DateOfService, employeeId = repairDto.EmployeeId, vinNumber = repairDto.VinNumber, price = repairDto.Price, repairedParts = ExtendedRepairedParts });
                                    break;
                                }
                            }
                        }
                    }
                    else if (serviceId[0] == 'i')
                    {
                        foreach (InspectionDto inspectionDto in inspectionsDto)
                        {
                            if (inspectionDto.Id == serviceId)
                            {
                                ExtendedInspections.Add(new ExtendedInspectionDto() { id = inspectionDto.Id, dateOfService = inspectionDto.DateOfService, employeeId = inspectionDto.EmployeeId, vinNumber = inspectionDto.VinNumber, price = inspectionDto.Price, testsPassed = inspectionDto.TestsPassed, inspectionExpirationDate = inspectionDto.InspectionExpirationDate, comment = inspectionDto.Comment });
                                break;
                            }
                        }
                    }
                }
                List<string> inspectionsCars = new List<string>();
                List<string> repairsCars = new List<string>();

                foreach (ExtendedInspectionDto inspectionDto in ExtendedInspections)
                {
                    inspectionsCars.Add(inspectionDto.id);
                }
                foreach (ExtendedRepairDto repairDto in ExtendedRepairs)
                {
                    repairsCars.Add(repairDto.id);
                }
                return new ExtendedCarDto() { vin = vin, model = carDto.model, brand = carDto.brand, productionYear = carDto.productionYear, insurenceNumber = carDto.insurenceNumber, servicesHistoryInspections = inspectionsCars, servicesHistoryRepairs = repairsCars };
            }
            return null;
        }

        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin)
        {
            ServicesDataUSvcMockClient clientServices = new ServicesDataUSvcMockClient();
            List<ExtendedInspectionDto> extendedInspectionsDto = new List<ExtendedInspectionDto>();
            CarsDataUSvc.RestClient.CarsDataUSvcMockClient clientCars = new CarsDataUSvc.RestClient.CarsDataUSvcMockClient();

            List<String> t = clientCars.GetCarByVin(vin).servicesHistory;
            foreach (string s in t)
            {
                InspectionDto inspTemp = clientServices.FindInspectionById(s);
                if (s[0] == 'i')
                {
                    extendedInspectionsDto.Add(new ExtendedInspectionDto() { id = inspTemp.Id, dateOfService = inspTemp.DateOfService, employeeId = inspTemp.EmployeeId, vinNumber = inspTemp.VinNumber, price = inspTemp.Price, testsPassed = inspTemp.TestsPassed, inspectionExpirationDate = inspTemp.InspectionExpirationDate, comment = inspTemp.Comment });
                }
                else
                {
                    continue;
                }
            }
            return extendedInspectionsDto;
        }
        public List<ExtendedRepairDto> GetCarRepairHistory(string vin)
        {
            ServicesDataUSvc.RestClient.ServicesDataUSvcMockClient clientServices = new ServicesDataUSvc.RestClient.ServicesDataUSvcMockClient();
            List<ExtendedRepairDto> extendedRepairsDto = new List<ExtendedRepairDto>();
            CarsDataUSvc.RestClient.CarsDataUSvcMockClient clientCars = new CarsDataUSvc.RestClient.CarsDataUSvcMockClient();

            List<String> t = clientCars.GetCarByVin(vin).servicesHistory;

            foreach (string s in t)
            {
                RepairDto repairTemp = clientServices.FindRepairById(s);
                if (s[0] == 'r')
                {
                    List<RepairedPartDto> ExtendedRepairedPartsGot = clientServices.GetRepairedPartsById(s);
                    List<ExtendedRepairedPartDto> afterConvert = new List<ExtendedRepairedPartDto>();
                    foreach (RepairedPartDto tempRepDto in ExtendedRepairedPartsGot)
                    {
                        afterConvert.Add(new ExtendedRepairedPartDto() { carPart = tempRepDto.CarPart, causeOfRepair = tempRepDto.CauseOfRepair });
                    }
                    extendedRepairsDto.Add(new ExtendedRepairDto() { id = repairTemp.Id, dateOfService = repairTemp.DateOfService, employeeId = repairTemp.EmployeeId, vinNumber = repairTemp.VinNumber, price = repairTemp.Price, repairedParts = afterConvert });
                }
                else
                {
                    continue;
                }
            }
            return extendedRepairsDto;
        }

        public ExtendedClientDto GetPersonalInformation(string id)
        {
            ClientsDataUSvc.RestClient.ClientDataUSvcMockClient client = new ClientsDataUSvc.RestClient.ClientDataUSvcMockClient();
            ClientDto personalDataClientDto = client.FindClientByIdCard(id);
            return new ExtendedClientDto() { name = personalDataClientDto.Name, surname = personalDataClientDto.Surname, phoneNumber = personalDataClientDto.PhoneNumber, idCardNumber = personalDataClientDto.IdCardNumber, vinNumbers = personalDataClientDto.VinNumbers };
        }

        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber, List<string>? vinNumbers)
        {
            ClientsDataUSvc.RestClient.ClientDataUSvcMockClient client = new ClientsDataUSvc.RestClient.ClientDataUSvcMockClient();
            ClientDto clientBackup = client.FindClientByIdCard(clientId);
            ClientDto clientToSet = new ClientDto();

            if (newIdCard != null)
            {
                clientToSet.IdCardNumber = newIdCard;
            }
            else
            {
                clientToSet.IdCardNumber = clientBackup.IdCardNumber;
            }

            if (name == null)
            {
                clientToSet.Name = clientBackup.Name;
            }
            else
            {
                clientToSet.Name = name;
            }

            if (surname == null)
            {
                clientToSet.Surname = clientBackup.Surname;
            }
            else
            {
                clientToSet.Surname = surname;
            }

            if (phoneNumber == null)
            {
                clientToSet.PhoneNumber = clientBackup.PhoneNumber;
            }
            else
            {
                clientToSet.PhoneNumber = phoneNumber;
            }

            if (vinNumbers == null)
            {
                clientToSet.VinNumbers = clientBackup.VinNumbers;
            }
            else
            {
                clientToSet.VinNumbers = vinNumbers;
            }
            client.RemoveClientFromData(clientId);
            client.AddClientToData(new ClientDto() { Name = clientToSet.Name, Surname = clientToSet.Surname, PhoneNumber = clientToSet.PhoneNumber, IdCardNumber = clientToSet.IdCardNumber, VinNumbers = clientToSet.VinNumbers });
        }

        public void PurchaseCarPart(string id)
        {
            CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient client = new CarPartsDataUSvc.RestClient.CarPartsDataUSvcMockClient();
            client.RemoveCarPart(id);
        }

        public void RequestNewInspection(ExtendedInspectionDto extendedInspection)
        {
            ServicesDataUSvcMockClient clientServices = new ServicesDataUSvcMockClient();
            clientServices.AddInspection(new InspectionDto() { Id = extendedInspection.id, DateOfService = extendedInspection.dateOfService, EmployeeId = extendedInspection.employeeId, VinNumber = extendedInspection.vinNumber, Price = extendedInspection.price, TestsPassed = extendedInspection.testsPassed, InspectionExpirationDate = extendedInspection.inspectionExpirationDate, Comment = extendedInspection.comment });
            EmployeeDataUSvcMockClient clientEmployee = new EmployeeDataUSvcMockClient();
            string serviceID = clientServices.GetAllInspections().Last().Id;
            List<string> serviceList = new List<string>();
            serviceList.Add(serviceID);
            clientEmployee.AddServiceToEmployee(extendedInspection.employeeId, serviceList);
        }

        public void RequestNewRepair(ExtendedRepairDto extendedRepair)
        {
            List<RepairedPartDto> repairDtos = new List<RepairedPartDto>();

            foreach (var part in extendedRepair.repairedParts)
            {
                repairDtos.Add(new RepairedPartDto() { CarPart = part.carPart, CauseOfRepair = part.causeOfRepair });
            }

            ServicesDataUSvcMockClient clientServices = new ServicesDataUSvcMockClient();
            clientServices.AddRepair(new RepairDto() { Id = extendedRepair.id, DateOfService = extendedRepair.dateOfService, EmployeeId = extendedRepair.employeeId, VinNumber = extendedRepair.vinNumber, Price = extendedRepair.price, RepairedParts = repairDtos });
            EmployeeDataUSvcMockClient clientEmployee = new EmployeeDataUSvcMockClient();
            string serviceID = clientServices.GetAllInspections().Last().Id;
            List<string> serviceList = new List<string>();
            serviceList.Add(serviceID);
            clientEmployee.AddServiceToEmployee(extendedRepair.employeeId, serviceList);
        }

        public ExtendedPropertyDto ConvertToProperty(PropertyDto propertyDto)
        {
            return new ExtendedPropertyDto() { name = propertyDto.name, description = propertyDto.description };
        }

        public ExtendedOtherPropertiesDto ConvertToOtherProperties(OtherPropertiesDto otherProperties)
        {
            List<PropertyDto> propertiesDto = otherProperties.properties;
            List<ExtendedPropertyDto> properties = new List<ExtendedPropertyDto>();
            foreach (PropertyDto propertyDto in propertiesDto)
            {
                properties.Add(this.ConvertToProperty(propertyDto));
            }
            return new ExtendedOtherPropertiesDto() { properties = properties };
        }

        public List<ExtendedCarDto> GetAllClientCar(string idCardNumber)
        {
            ClientsDataUSvc.RestClient.ClientDataUSvcMockClient clientsClient = new ClientsDataUSvc.RestClient.ClientDataUSvcMockClient();
            CarsDataUSvc.RestClient.CarsDataUSvcMockClient carsClient = new CarsDataUSvc.RestClient.CarsDataUSvcMockClient();

            ClientDto extendedClient = clientsClient.FindClientByIdCard(idCardNumber);
            List<ExtendedCarDto> clientsCars = new List<ExtendedCarDto>();



            foreach (string vinNumber in extendedClient.VinNumbers)
            {
                List<string> inspections = new List<string>();
                List<string> repairs = new List<string>();
                CarDto carDto = carsClient.GetCarByVin(vinNumber);
                foreach (string serviceId in carDto.servicesHistory)
                {

                    if (serviceId[0] == 'i')
                    {
                        inspections.Add(serviceId);
                    }
                    else if (serviceId[0] == 'r')
                    {
                        repairs.Add(serviceId);
                    }
                }

                clientsCars.Add(new ExtendedCarDto
                {
                    vin = carDto.vin,
                    model = carDto.model,
                    brand = carDto.brand,
                    productionYear = carDto.productionYear,
                    insurenceNumber = carDto.insurenceNumber,
                    servicesHistoryInspections = inspections,
                    servicesHistoryRepairs = repairs,

                });
            }

            return clientsCars;
        }
        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber,
            List<string>? servicesHistory)
        {
            CarsDataUSvc.RestClient.CarsDataUSvcMockClient carsClient = new CarsDataUSvc.RestClient.CarsDataUSvcMockClient();

            CarDto clientBackup = carsClient.GetCarByVin(vin);
            CarDto modifiedCar = new CarDto { vin = clientBackup.vin };

            if (model != null)
            {
                modifiedCar.model = model;
            }
            else
            {
                modifiedCar.model = clientBackup.model;
            }

            if (brand != null)
            {
                modifiedCar.brand = brand;
            }
            else
            {
                modifiedCar.brand = clientBackup.brand;
            }

            if (productionYear != null)
            {
                modifiedCar.productionYear = (DateTime)productionYear;
            }
            else
            {
                modifiedCar.productionYear = clientBackup.productionYear;
            }

            if (insuranceNumber != null)
            {
                modifiedCar.insurenceNumber = insuranceNumber;
            }
            else
            {
                modifiedCar.insurenceNumber = clientBackup.insurenceNumber;
            }

            if (servicesHistory != null)
            {
                modifiedCar.servicesHistory = servicesHistory;
            }
            else
            {
                modifiedCar.servicesHistory = clientBackup.servicesHistory;
            }

            carsClient.RemoveCarByVin(vin);
            carsClient.AddCar(modifiedCar);
        }

        public List<ExtendedEmployeeDto> GetAvailableMechanics(DateTime date)
        {
            EmployeeDataUSvcMockClient employeesClient = new EmployeeDataUSvcMockClient();
            ServicesDataUSvcMockClient servicesClient = new ServicesDataUSvcMockClient();

            List<ExtendedEmployeeDto> spareEmployees = new List<ExtendedEmployeeDto>();
            foreach (EmployeeDto e in employeesClient.GetAllEmployees())
            {
                int servicesCount = 0;
                List<ExtendedRepairDto> repairs = new List<ExtendedRepairDto>();
                List<ExtendedInspectionDto> inspections = new List<ExtendedInspectionDto>();
                foreach (string s in e.services)
                {
                    if (s[0] == 'r')
                    {

                        RepairDto repair = servicesClient.FindRepairById(s);
                        List<ExtendedRepairedPartDto> repairedParts = new List<ExtendedRepairedPartDto>();
                        foreach (RepairedPartDto temp in repair.RepairedParts)
                        {
                            repairedParts.Add(new ExtendedRepairedPartDto() { carPart = temp.CarPart, causeOfRepair = temp.CauseOfRepair });
                        }
                        repairs.Add(new ExtendedRepairDto() { id = repair.Id, dateOfService = repair.DateOfService, employeeId = repair.EmployeeId, vinNumber = repair.VinNumber, price = repair.Price, repairedParts = repairedParts });
                        if (repair.DateOfService.DayOfYear == date.DayOfYear)
                        {
                            servicesCount++;
                        }
                    }
                    else if (s[0]=='i')
                    {
                        InspectionDto inspection = servicesClient.FindInspectionById(s);

                        inspections.Add(new ExtendedInspectionDto() { id = inspection.Id, dateOfService = inspection.DateOfService, employeeId = inspection.EmployeeId, vinNumber = inspection.VinNumber, price = inspection.Price, testsPassed = inspection.TestsPassed, inspectionExpirationDate = inspection.InspectionExpirationDate, comment = inspection.Comment });
                        if (inspection.DateOfService.DayOfYear == date.DayOfYear)
                        {
                            servicesCount++;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (servicesCount <= 3)
                {
                    List<string> inspectionsList = new List<string>();
                    List<string> repairslist = new List<string>();
                    foreach (string serviceId in e.services)
                    {

                        if (serviceId[0] == 'i')
                        {
                            inspectionsList.Add(serviceId);
                        }
                        else if (serviceId[0] == 'r')
                        {
                            repairslist.Add(serviceId);
                        }
                    }
                    spareEmployees.Add(new ExtendedEmployeeDto() { id = e.id, name = e.name, surname = e.surname, phoneNumber = e.phoneNumber, jobPosition = e.jobPosition, salary = e.salary, servicesInspection = inspectionsList, servicesRepair = repairslist });
                }
            }

            return spareEmployees;
        }
        public void AddNewClient(ExtendedClientDto client)
        {
            ClientsDataUSvc.RestClient.ClientDataUSvcMockClient clientsClient = new ClientsDataUSvc.RestClient.ClientDataUSvcMockClient();
            clientsClient.AddClientToData(new ClientDto()
            {
                Name = client.name,
                Surname = client.surname,
                PhoneNumber = client.phoneNumber,
                IdCardNumber = client.idCardNumber,
                VinNumbers = client.vinNumbers
            });
        }

		public void AddCar(ExtendedCarDto extendedCarDto, string idCardNumber)
		{
			List<string> services = new List<string>();

			foreach (string service in extendedCarDto.servicesHistoryInspections)
			{
				services.Add(service);
			}
			foreach (string service in extendedCarDto.servicesHistoryRepairs)
			{
				services.Add(service);
			}
			CarsDataUSvcMockClient carsClient = new CarsDataUSvcMockClient();
			carsClient.AddCar(new CarDto()
			{
				vin = extendedCarDto.vin,
				model = extendedCarDto.model,
				brand = extendedCarDto.brand,
				productionYear = extendedCarDto.productionYear,
				insurenceNumber = extendedCarDto.insurenceNumber,
				servicesHistory = services
			});

			ClientDataUSvcMockClient clientClient = new ClientDataUSvcMockClient();
			clientClient.AddCarToClient(idCardNumber, extendedCarDto.vin);
		}
	}
}