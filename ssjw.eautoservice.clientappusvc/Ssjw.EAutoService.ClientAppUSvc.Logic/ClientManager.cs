namespace Ssjw.EAutoService.ClientAppUSvc.Logic
{
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Services;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    public class ClientManager : IClientApp
    {
        bool DEBUG = false;
        public List<ExtendedBodyPart> FindBodyPartByBodyType(string bodyType)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<BodyPartDto> foundBodyPartsDto = carPartsDataUSvcClient.FindBodyPartByBodyType(bodyType);
            List<ExtendedBodyPart> foundBodyParts = new List<ExtendedBodyPart>();

            foreach (BodyPartDto bodyPartDto in foundBodyPartsDto)
            {
                foundBodyParts.Add(new ExtendedBodyPart(bodyPartDto.id, bodyPartDto.bodyType, bodyPartDto.material, bodyPartDto.price, bodyPartDto.colour, bodyPartDto.counter));
            }
            return foundBodyParts;
        }
        public List<ExtendedBodyPart> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<BodyPartDto> foundBodyPartsDto = carPartsDataUSvcClient.FindBodyPartByPrice(minPrice, maxPrice);
            List<ExtendedBodyPart> foundBodyParts = new List<ExtendedBodyPart>();
            foreach (BodyPartDto bodyPartsDto in foundBodyPartsDto)
            {
                foundBodyParts.Add(new ExtendedBodyPart(bodyPartsDto.id, bodyPartsDto.bodyType, bodyPartsDto.material, bodyPartsDto.price, bodyPartsDto.colour, bodyPartsDto.counter));
            }
            return foundBodyParts;
        }
        public List<ExtendedLiquid> FindLiquidByCategory(string category)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<LiquidDto> foundLiquidDto = carPartsDataUSvcClient.FindLiquidByCategory(category);
            List<ExtendedLiquid> foundLiquid = new List<ExtendedLiquid>();
            foreach (LiquidDto liquidDto in foundLiquidDto)
            {
                foundLiquid.Add(new ExtendedLiquid(liquidDto.id, liquidDto.category, liquidDto.density, liquidDto.containsPb, liquidDto.price, liquidDto.counter));
            }
            return foundLiquid;
        }
        public List<ExtendedLiquid> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<LiquidDto> foundLiquidDto = carPartsDataUSvcClient.FindLiquidByPrice(minPrice, maxPrice);
            List<ExtendedLiquid> foundLiquid = new List<ExtendedLiquid>();
            foreach (LiquidDto liquidsDto in foundLiquidDto)
            {
                foundLiquid.Add(new ExtendedLiquid(liquidsDto.id, liquidsDto.category, liquidsDto.density, liquidsDto.containsPb, liquidsDto.price, liquidsDto.counter));
            }
            return foundLiquid;
        }
        public List<ExtendedMechanicalPart> FindMechanicalPartByCategory(string category)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<MechanicalPartDto> foundMechanicalPartsDto = carPartsDataUSvcClient.FindMechanicalPartByCategory(category);
            List<ExtendedMechanicalPart> foundMechanicalParts = new List<ExtendedMechanicalPart>();
            foreach (MechanicalPartDto mechanicalPartsDto in foundMechanicalPartsDto)
            {
                foundMechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartsDto.id, mechanicalPartsDto.category, mechanicalPartsDto.price, mechanicalPartsDto.sizeX, mechanicalPartsDto.sizeY, mechanicalPartsDto.sizeZ, mechanicalPartsDto.description, mechanicalPartsDto.counter));
            }
            return foundMechanicalParts;
        }
        public List<ExtendedMechanicalPart> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<MechanicalPartDto> foundMechanicalPartsDto = carPartsDataUSvcClient.FindMechanicalPartByPrice(minPrice, maxPrice);
            List<ExtendedMechanicalPart> foundMechanicalParts = new List<ExtendedMechanicalPart>();
            foreach (MechanicalPartDto mechanicalPartsDto in foundMechanicalPartsDto)
            {
                foundMechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartsDto.id, mechanicalPartsDto.category, mechanicalPartsDto.price, mechanicalPartsDto.sizeX, mechanicalPartsDto.sizeY, mechanicalPartsDto.sizeZ, mechanicalPartsDto.description, mechanicalPartsDto.counter));
            }
            return foundMechanicalParts;
        }
        public List<ExtendedBodyPart> GetAllBodyParts()
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<BodyPartDto> bodyPartsDto = carPartsDataUSvcClient.GetAllBodyParts();
            List<ExtendedBodyPart> bodyParts = new List<ExtendedBodyPart>();
            foreach (BodyPartDto bodyPartDto in bodyPartsDto)
            {
                bodyParts.Add(new ExtendedBodyPart(bodyPartDto.id, bodyPartDto.bodyType, bodyPartDto.material, bodyPartDto.price, bodyPartDto.colour, bodyPartDto.counter));
            }
            return bodyParts;
        }
        public List<ExtendedLiquid> GetAllLiquids()
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<LiquidDto> liquidsDto = carPartsDataUSvcClient.GetAllLiquids();
            List<ExtendedLiquid> liquids = new List<ExtendedLiquid>();
            foreach (LiquidDto liquidDto in liquidsDto)
            {
                liquids.Add(new ExtendedLiquid(liquidDto.id, liquidDto.category, liquidDto.density, liquidDto.containsPb, liquidDto.price, liquidDto.counter));
            }
            return liquids;
        }
        public List<ExtendedMechanicalPart> GetAllMechanicalParts()
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            List<MechanicalPartDto> mechanicalPartsDto = carPartsDataUSvcClient.GetAllMechanicalParts();
            List<ExtendedMechanicalPart> mechanicalParts = new List<ExtendedMechanicalPart>();
            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartsDto)
            {
                mechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartDto.id, mechanicalPartDto.category, mechanicalPartDto.price, mechanicalPartDto.sizeX, mechanicalPartDto.sizeY, mechanicalPartDto.sizeZ, mechanicalPartDto.description, mechanicalPartDto.counter));
            }
            return mechanicalParts;
        }
        public ExtendedCar GetCarInformation(string vin)
        {
            ICarsDataDto carsDataUSvcClient;
            IServicesDataUSvcClient servicesDataUSvcClient;

            if (DEBUG)
            {
                carsDataUSvcClient = new CarsDataUSvcMockClient();
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
            }
            else
            {
                carsDataUSvcClient = new CarsDataUSvcClient();
                servicesDataUSvcClient = new ServicesDataUSvcClient();
            }

            CarDto carDto = null;
            if (carsDataUSvcClient.GetCarByVin(vin) != null)
            {
                carDto = carsDataUSvcClient.GetCarByVin(vin);
            }
            if (carDto == null) return null;
            List<ExtendedInspection> ExtendedInspections = new List<ExtendedInspection>();
            List<ExtendedRepair> ExtendedRepairs = new List<ExtendedRepair>();
            if (carDto.servicesHistory != null && carDto.servicesHistory.Count != 0)
            {
                List<InspectionDto> inspectionsDto = servicesDataUSvcClient.GetInspectionsByVinNumber(vin);
                List<RepairDto> repairsDto = servicesDataUSvcClient.GetRepairByVinNumber(vin);
                foreach (string serviceId in carDto.servicesHistory)
                {
                    if (serviceId[0] == 'r')
                    {
                        foreach (RepairDto repairDto in repairsDto)
                        {
                            if (repairDto.Id == serviceId)
                            {
                                List<ExtendedRepairedPart> ExtendedRepairedParts = new List<ExtendedRepairedPart>();

                                foreach (RepairedPartDto ExtendedRepairedPartDto in servicesDataUSvcClient.GetRepairedPartsById(serviceId))
                                {
                                    ExtendedRepairedParts.Add(new ExtendedRepairedPart(ExtendedRepairedPartDto.CarPart, ExtendedRepairedPartDto.CauseOfRepair));
                                }
                                ExtendedRepair ExtendedRepair = new ExtendedRepair(serviceId, repairDto.DateOfService, repairDto.EmployeeId, repairDto.VinNumber, repairDto.Price,
                                    ExtendedRepairedParts);
                                ExtendedRepairs.Add(ExtendedRepair);
                                break;
                            }
                        }
                    }
                    else if (serviceId[0] == 'i')
                    {
                        foreach (InspectionDto inspectionDto in inspectionsDto)
                        {
                            if (inspectionDto.Id == serviceId)
                            {
                                ExtendedInspection ExtendedInspection = new ExtendedInspection(serviceId, inspectionDto.DateOfService, inspectionDto.EmployeeId, inspectionDto.VinNumber, inspectionDto.Price,
                                    inspectionDto.TestsPassed, inspectionDto.InspectionExpirationDate, inspectionDto.Comment);
                                ExtendedInspections.Add(ExtendedInspection);
                                break;
                            }
                        }
                    }
                }
            }
            ExtendedCar car = null;
            car = new ExtendedCar(vin, carDto.model, carDto.brand, carDto.productionYear, carDto.insurenceNumber, ExtendedInspections, ExtendedRepairs);
            return car;
        }
        public List<ExtendedInspection> GetCarInspectionHistory(string vin)
        {
            ICarsDataDto carsDataUSvcClient;
            IServicesDataUSvcClient servicesDataUSvcClient;

            if (DEBUG)
            {
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
                carsDataUSvcClient = new CarsDataUSvcMockClient();
            }
            else
            {
                servicesDataUSvcClient = new ServicesDataUSvcClient();
                carsDataUSvcClient = new CarsDataUSvcClient();
            }
            List<ExtendedInspection> carInspectionHistory = new List<ExtendedInspection>();
            List<String> servicesHistory = carsDataUSvcClient.GetCarByVin(vin).servicesHistory;
            foreach (string s in servicesHistory)
            {
                if (s[0] == 'i')
                {
                    InspectionDto inspTemp = servicesDataUSvcClient.FindInspectionById(s);

                    carInspectionHistory.Add(new ExtendedInspection(inspTemp.Id, inspTemp.DateOfService, inspTemp.EmployeeId, inspTemp.VinNumber, inspTemp.Price, inspTemp.TestsPassed, inspTemp.InspectionExpirationDate, inspTemp.Comment));
                }
                else
                {
                    continue;
                }
            }
            return carInspectionHistory;
        }
        public List<ExtendedRepair> GetCarRepairHistory(string vin)
        {
            IServicesDataUSvcClient servicesDataUSvcClient;
            ICarsDataDto carsDataUSvcClient;

            if (DEBUG)
            {
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
                carsDataUSvcClient = new CarsDataUSvcMockClient();
            }
            else
            {
                servicesDataUSvcClient = new ServicesDataUSvcClient();
                carsDataUSvcClient = new CarsDataUSvcClient();
            }
            List<ExtendedRepair> repairsHistory = new List<ExtendedRepair>();
            List<string> servicesHistory = carsDataUSvcClient.GetCarByVin(vin).servicesHistory;
            foreach (string s in servicesHistory)
            {
                if (s[0] == 'r')
                {
                    RepairDto repairTemp = servicesDataUSvcClient.FindRepairById(s);
                    List<RepairedPartDto> ExtendedRepairedPartsGot = servicesDataUSvcClient.GetRepairedPartsById(s);
                    List<ExtendedRepairedPart> afterConvert = new List<ExtendedRepairedPart>();
                    foreach (RepairedPartDto tempRepDto in ExtendedRepairedPartsGot)
                    {
                        afterConvert.Add(new ExtendedRepairedPart(tempRepDto.CarPart, tempRepDto.CauseOfRepair));
                    }
                    repairsHistory.Add(new ExtendedRepair(repairTemp.Id, repairTemp.DateOfService, repairTemp.EmployeeId, repairTemp.VinNumber, repairTemp.Price, afterConvert));
                }
                else
                {
                    continue;
                }
            }

            return repairsHistory;
        }
        public ExtendedClient GetPersonalInformation(string id)
        {
            IClientDataSvc clientDataUSvcClient;

            if (DEBUG)
            {
                clientDataUSvcClient = new ClientDataUSvcMockClient();
            }
            else
            {
                clientDataUSvcClient = new ClientDataUSvcClient();
            }
            ClientDto personalDataClientDto = clientDataUSvcClient.FindClientByIdCard(id);
            return new ExtendedClient(personalDataClientDto.Name, personalDataClientDto.Surname, personalDataClientDto.PhoneNumber, personalDataClientDto.IdCardNumber, personalDataClientDto.VinNumbers);
        }
        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber, List<string>? vinNumbers)
        {
            IClientDataSvc clientDataUSvcClient;

            if (DEBUG)
            {
                clientDataUSvcClient = new ClientDataUSvcMockClient();
            }
            else
            {
                clientDataUSvcClient = new ClientDataUSvcClient();
            }
            ClientDto clientBackup = clientDataUSvcClient.FindClientByIdCard(clientId);
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
            clientDataUSvcClient.RemoveClientFromData(clientId);
            clientDataUSvcClient.AddClientToData(new ClientDto() { Name = clientToSet.Name, Surname = clientToSet.Surname, PhoneNumber = clientToSet.PhoneNumber, IdCardNumber = clientToSet.IdCardNumber, VinNumbers = clientToSet.VinNumbers });
        }
        public void PurchaseCarPart(string id)
        {
            ICarPartsDataUSvcClient carPartsDataUSvcClient;

            if (DEBUG)
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcMockClient();
            }
            else
            {
                carPartsDataUSvcClient = new CarPartsDataUSvcClient();
            }
            carPartsDataUSvcClient.RemoveCarPart(id);
        }
        public async void RequestNewInspection(ExtendedInspection extendedInspection)
        {
            IServicesDataUSvcClient servicesDataUSvcClient;
            IEmployeeDataSvc employeeDataUSvcClient;

            if (DEBUG)
            {
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
                employeeDataUSvcClient = new EmployeeDataUSvcMockClient();
            }
            else
            {
                servicesDataUSvcClient = new ServicesDataUSvcClient();
                employeeDataUSvcClient = new EmployeeDataUSvcClient();
            }
            async Task waitForAdding()
            {
                await servicesDataUSvcClient.AddInspectionTask(new InspectionDto() { Id = extendedInspection.Id, DateOfService = extendedInspection.DateOfService, EmployeeId = extendedInspection.EmployeeId, VinNumber = extendedInspection.VinNumber, Price = extendedInspection.Price, TestsPassed = extendedInspection.TestsPassed, InspectionExpirationDate = extendedInspection.InspectionExpirationDate, Comment = extendedInspection.Comment });
            }
            await waitForAdding();
            string serviceID = servicesDataUSvcClient.GetAllInspections().Last().Id;
            List<string> serviceList = new List<string>
            {
                serviceID
            };
            employeeDataUSvcClient.AddServiceToEmployee(extendedInspection.EmployeeId, serviceList);
        }
        public async void RequestNewRepair(ExtendedRepair extendedRepair)
        {
            IServicesDataUSvcClient servicesDataUSvcClient;
            IEmployeeDataSvc employeeDataUSvcClient;
            if (DEBUG)
            {
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
                employeeDataUSvcClient = new EmployeeDataUSvcMockClient();
            }
            else
            {
                servicesDataUSvcClient = new ServicesDataUSvcClient();
                employeeDataUSvcClient = new EmployeeDataUSvcClient();
            }
            List<RepairedPartDto> repairDtos = new List<RepairedPartDto>();

            foreach (var part in extendedRepair.RepairedParts)
            {
                repairDtos.Add(new RepairedPartDto() { CarPart = part.CarPart, CauseOfRepair = part.CauseOfRepair });
            }
            async Task waitForAdding()
            {
                await servicesDataUSvcClient.AddRepairTask(new RepairDto() { Id = extendedRepair.Id, DateOfService = extendedRepair.DateOfService, EmployeeId = extendedRepair.EmployeeId, VinNumber = extendedRepair.VinNumber, Price = extendedRepair.Price, RepairedParts = repairDtos });
            }
            await waitForAdding();

            string serviceID = servicesDataUSvcClient.GetAllRepairs().Last().Id;
            List<string> serviceList = new List<string>
            {
                serviceID
            };
            employeeDataUSvcClient.AddServiceToEmployee(extendedRepair.EmployeeId, serviceList);
        }

        public ExtendedProperty ConvertToProperty(PropertyDto propertyDto)
        {
            return new ExtendedProperty(propertyDto.name, propertyDto.description);
        }
        public ExtendedOtherProperties ConvertToOtherProperties(OtherPropertiesDto otherProperties)
        {
            List<PropertyDto> propertiesDto = otherProperties.properties;
            List<ExtendedProperty> properties = new List<ExtendedProperty>();
            foreach (PropertyDto propertyDto in propertiesDto)
            {
                properties.Add(this.ConvertToProperty(propertyDto));
            }
            return new ExtendedOtherProperties(properties);
        }
        public List<ExtendedCar> GetAllClientCar(string idCardNumber)
        {
            IClientDataSvc clientDataUSvcClient;
            ICarsDataDto carsDataUSvcClient;

            if (DEBUG)
            {
                clientDataUSvcClient = new ClientDataUSvcMockClient();
                carsDataUSvcClient = new CarsDataUSvcMockClient();
            }
            else
            {
                clientDataUSvcClient = new ClientDataUSvcClient();
                carsDataUSvcClient = new CarsDataUSvcClient();
            }
            ClientDto extendedClient = clientDataUSvcClient.FindClientByIdCard(idCardNumber);
            List<ExtendedCar> clientsCars = new List<ExtendedCar>();
            foreach (string vinNumber in extendedClient.VinNumbers)
            {
                CarDto carDto = carsDataUSvcClient.GetCarByVin(vinNumber);
                clientsCars.Add(new ExtendedCar()
                {
                    Vin = carDto.vin,
                    Model = carDto.model,
                    Brand = carDto.brand,
                    ProductionYear = carDto.productionYear,
                    InsurenceNumber = carDto.insurenceNumber,
                    ServicesHistoryInspections = GetCarInspectionHistory(vinNumber),
                    ServicesHistoryRepairs = GetCarRepairHistory(vinNumber)
                });
            }
            return clientsCars;
        }
        public void AddCar(ExtendedCarDto extendedCar, string idCardNumber)
        {
            ICarsDataDto carsDataUSvcClient;
            IClientDataSvc clientDataSvcClient;

            if (DEBUG)
            {
                carsDataUSvcClient = new CarsDataUSvcMockClient();
                clientDataSvcClient = new ClientDataUSvcMockClient();
            }
            else
            {
                carsDataUSvcClient = new CarsDataUSvcClient();
                clientDataSvcClient = new ClientDataUSvcClient();
            }

            List<string> servicesIdsHistory = new List<string>();
            foreach (string extendedInspection in extendedCar.servicesHistoryInspections)
            {
                servicesIdsHistory.Add(extendedInspection);
            }
            foreach (string extendedRepair in extendedCar.servicesHistoryRepairs)
            {
                servicesIdsHistory.Add(extendedRepair);
            }
            CarDto newCar = new CarDto
            {
                vin = extendedCar.vin,
                model = extendedCar.model,
                brand = extendedCar.brand,
                productionYear = extendedCar.productionYear,
                insurenceNumber = extendedCar.insurenceNumber,
                servicesHistory = servicesIdsHistory
            };
            carsDataUSvcClient.AddCar(newCar);
            clientDataSvcClient.AddCarToClient(idCardNumber, newCar.vin);
        }

        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber, List<string>? servicesHistory)
        {
            ICarsDataDto carsDataUSvcClient;

            if (DEBUG)
            {
                carsDataUSvcClient = new CarsDataUSvcMockClient();
            }
            else
            {
                carsDataUSvcClient = new CarsDataUSvcClient();
            }
            CarDto clientBackup = carsDataUSvcClient.GetCarByVin(vin);
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

            carsDataUSvcClient.RemoveCarByVin(vin);
            carsDataUSvcClient.AddCar(modifiedCar);
        }
        public List<ExtendedEmployee> GetAvailableMechanics(DateTime date)
        {
            IServicesDataUSvcClient servicesDataUSvcClient;
            IEmployeeDataSvc employeeDataUSvcClient;

            if (DEBUG)
            {
                servicesDataUSvcClient = new ServicesDataUSvcMockClient();
                employeeDataUSvcClient = new EmployeeDataUSvcMockClient();
            }
            else
            {
                servicesDataUSvcClient = new ServicesDataUSvcClient();
                employeeDataUSvcClient = new EmployeeDataUSvcClient();
            }
            List<ExtendedEmployee> spareEmployees = new List<ExtendedEmployee>();
            foreach (EmployeeDto e in employeeDataUSvcClient.GetAllEmployees())
            {
                int servicesCount = 0;
                List<ExtendedRepair> repairs = new List<ExtendedRepair>();
                List<ExtendedInspection> inspections = new List<ExtendedInspection>();
                foreach (string s in e.services)
                {
                    if (s[0] == 'r')
                    {
                        RepairDto repair = servicesDataUSvcClient.FindRepairById(s);
                        List<ExtendedRepairedPart> repairedParts = new List<ExtendedRepairedPart>();
                        foreach (RepairedPartDto temp in repair.RepairedParts)
                        {
                            repairedParts.Add(new ExtendedRepairedPart(temp.CarPart, temp.CauseOfRepair));
                        }
                        repairs.Add(new ExtendedRepair(repair.Id, repair.DateOfService, repair.EmployeeId, repair.VinNumber, repair.Price, repairedParts));
                        if (repair.DateOfService.DayOfYear == date.DayOfYear)
                        {
                            servicesCount++;
                        }
                    }
                    else if (s[0] == 'i')
                    {
                        InspectionDto inspection = servicesDataUSvcClient.FindInspectionById(s);

                        inspections.Add(new ExtendedInspection(inspection.Id, inspection.DateOfService, inspection.EmployeeId, inspection.VinNumber, inspection.Price, inspection.TestsPassed, inspection.InspectionExpirationDate, inspection.Comment));
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
                    spareEmployees.Add(new ExtendedEmployee(e.id, e.name, e.surname, e.phoneNumber, e.jobPosition, e.salary, inspections, repairs));
                }
            }
            return spareEmployees;
        }

        public void AddNewClient(ExtendedClient client)
        {
            IClientDataSvc clientDataUSvcClient;

            if (DEBUG)
            {
                clientDataUSvcClient = new ClientDataUSvcMockClient();
            }
            else
            {
                clientDataUSvcClient = new ClientDataUSvcClient();
            }

            clientDataUSvcClient.AddClientToData(new ClientDto()
            {
                Name = client.Name,
                Surname = client.Surname,
                PhoneNumber = client.PhoneNumber,
                IdCardNumber = client.IdCardNumber,
                VinNumbers = client.VinNumbers
            });
        }
    }
}
