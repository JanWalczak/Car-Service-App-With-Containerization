namespace Ssjw.EAutoService.MechanicAppUSvc.Logic
{
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Services;
    using Ssjw.EAutoService.EmployeesDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.EmployeesDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient;
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public class MechanicManager : IMechanicApp
    {
        public List<ExtendedCar> GetPersonalCars(string id)
        {
            EmployeeDataUSvcClient employeeDataUSvcClient = new EmployeeDataUSvcClient();
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();

            List<string> vinList = new List<string>();
            List<ExtendedCar> foundCars = new List<ExtendedCar>();

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
                        List<ExtendedInspection> inspections = new List<ExtendedInspection>();
                        List<ExtendedRepair> repairs = new List<ExtendedRepair>();

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
                                        InspectionDto inspectionDto = servicesDataUSvcClient.FindInspectionById(serviceId);
                                        inspections.Add(new ExtendedInspection(inspectionDto.Id, inspectionDto.DateOfService, inspectionDto.EmployeeId, inspectionDto.VinNumber, inspectionDto.Price,
                                            inspectionDto.TestsPassed, inspectionDto.InspectionExpirationDate, inspectionDto.Comment));
                                    }
                                }
                                else if (serviceId[0] == 'r')
                                {
                                    bool repairIsNotNull = servicesDataUSvcClient.FindRepairById(serviceId) != null;
                                    if (repairIsNotNull)
                                    {
                                        RepairDto repairDto = servicesDataUSvcClient.FindRepairById(serviceId);
                                        List<ExtendedRepairedPart> repairedParts = new List<ExtendedRepairedPart>();
                                        foreach (RepairedPartDto part in repairDto.RepairedParts)
                                        {
                                            repairedParts.Add(new ExtendedRepairedPart(part.CarPart, part.CauseOfRepair));
                                        }
                                        repairs.Add(new ExtendedRepair(repairDto.Id, repairDto.DateOfService, repairDto.EmployeeId, repairDto.VinNumber, repairDto.Price, repairedParts));
                                    }
                                }
                            }
                        }
                        foundCars.Add(new ExtendedCar(carDto.vin, carDto.model, carDto.brand, carDto.productionYear, carDto.insurenceNumber, inspections, repairs));
                    }
                }
            }

            return foundCars;
        }

        public ExtendedCar GetCarByVinNumber(string vin)
        {
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();
            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);

            List<ExtendedInspection> completeInspections = GetCarInspectionHistory(vin);
            List<ExtendedRepair> completeRepairs = GetCarRepairHistory(vin);

            ExtendedCar completeCar = new ExtendedCar(carDto.vin, carDto.model, carDto.brand, carDto.productionYear, carDto.insurenceNumber, completeInspections, completeRepairs);
            return completeCar;
        }

        public List<ExtendedInspection> GetCarInspectionHistory(string vin)
        {
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();

            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);
            List<ExtendedInspection> completeInspections = new List<ExtendedInspection>();
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
                            completeInspections.Add(new ExtendedInspection(inspectionDto.Id, inspectionDto.DateOfService, inspectionDto.EmployeeId, inspectionDto.VinNumber,
                                inspectionDto.Price, inspectionDto.TestsPassed, inspectionDto.InspectionExpirationDate, inspectionDto.Comment));
                        }
                    }
                }
            }

            return completeInspections;
        }

        public List<ExtendedRepair> GetCarRepairHistory(string vin)
        {
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();

            CarDto carDto = carsDataUSvcClient.GetCarByVin(vin);
            List<ExtendedRepair> completeRepairs = new List<ExtendedRepair>();

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

                            List<ExtendedRepairedPart> repairedParts = new List<ExtendedRepairedPart>();

                            foreach (RepairedPartDto repairedPartDto in repairDto.RepairedParts)
                            {
                                repairedParts.Add(new ExtendedRepairedPart(repairedPartDto.CarPart, repairedPartDto.CauseOfRepair));
                            }

                            completeRepairs.Add(new ExtendedRepair(repairDto.Id, repairDto.DateOfService, repairDto.EmployeeId, repairDto.VinNumber,
                                repairDto.Price, repairedParts));
                        }
                    }
                }
            }
            return completeRepairs;
        }

        public List<ExtendedRepair> GetPersonalRepairSchedule(string id)
        {
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();
            EmployeeDataUSvcClient employeeDataUSvcClient = new EmployeeDataUSvcClient();

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

            List<ExtendedRepair> completeRepairs = new List<ExtendedRepair>();

            foreach (RepairDto repairDto in repairDtoList)
            {
                List<ExtendedRepairedPart> repairedPartsList = new List<ExtendedRepairedPart>();
                foreach (RepairedPartDto repairedPartDto in repairDto.RepairedParts)
                {
                    repairedPartsList.Add(new ExtendedRepairedPart(repairedPartDto.CarPart, repairedPartDto.CauseOfRepair));
                }

                completeRepairs.Add(new ExtendedRepair(repairDto.Id, repairDto.DateOfService, repairDto.EmployeeId, repairDto.VinNumber, repairDto.Price, repairedPartsList));
            }

            return completeRepairs;
        }

        public List<ExtendedInspection> GetPersonalInspectionSchedule(string id)
        {
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();
            EmployeeDataUSvcClient employeeDataUSvcClient = new EmployeeDataUSvcClient();

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

            List<ExtendedInspection> completeInspections = new List<ExtendedInspection>();

            foreach (InspectionDto inspectionDto in inspectionDtoList)
            {
                completeInspections.Add(new ExtendedInspection(inspectionDto.Id, inspectionDto.DateOfService, inspectionDto.EmployeeId, inspectionDto.VinNumber,
                    inspectionDto.Price, inspectionDto.TestsPassed, inspectionDto.InspectionExpirationDate, inspectionDto.Comment));
            }

            return completeInspections;
        }

        public void FinishRepair(string idService, double price, List<ExtendedRepairedPart> repairedParts)
        {
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();
            EmployeeDataUSvcClient employeeDataUSvcClient = new EmployeeDataUSvcClient();

            RepairDto repairDto = servicesDataUSvcClient.FindRepairById(idService);

            List<RepairedPartDto> repairedPartDtos = new List<RepairedPartDto>();

            foreach (ExtendedRepairedPart repairedPart in repairedParts)
            {
                repairedPartDtos.Add(new RepairedPartDto() { CarPart = repairedPart.CarPart, CauseOfRepair = repairedPart.CauseOfRepair });
            }

            servicesDataUSvcClient.CompleteRepair(idService, price, repairedPartDtos);
            carsDataUSvcClient.AddServiceToCarHistory(repairDto.VinNumber, repairDto.Id);
            employeeDataUSvcClient.RemoveEmployeeService(repairDto.Id);
        }

        public void FinishInspection(string idService, double price, bool testsPassed, string comment)
        {
            ServicesDataUSvcClient servicesDataUSvcClient = new ServicesDataUSvcClient();
            CarsDataUSvcClient carsDataUSvcClient = new CarsDataUSvcClient();
            EmployeeDataUSvcClient employeeDataUSvcClient = new EmployeeDataUSvcClient();

            InspectionDto inspectionDto = servicesDataUSvcClient.FindInspectionById(idService);

            servicesDataUSvcClient.CompleteInspection(inspectionDto.Id, price, testsPassed, comment);
            carsDataUSvcClient.AddServiceToCarHistory(inspectionDto.VinNumber, inspectionDto.Id);
            employeeDataUSvcClient.RemoveEmployeeService(inspectionDto.Id);
        }

        public List<ExtendedClient> GetAllClients()
        {
            ClientDataUSvcClient clientDataUSvcClient = new ClientDataUSvcClient();

            List<ClientDto> clientsDto = clientDataUSvcClient.GetAllClients();
            List<ExtendedClient> completeClients = new List<ExtendedClient>();
            foreach (ClientDto clientDto in clientsDto)
            {
                completeClients.Add(new ExtendedClient(clientDto.Name, clientDto.Surname, clientDto.PhoneNumber, clientDto.IdCardNumber, clientDto.VinNumbers));
            }
            return completeClients;
        }

        public ExtendedClient GetClientInformation(string idCardNumber)
        {
            ClientDataUSvcClient clientDataUSvcClient = new ClientDataUSvcClient();

            ClientDto clientDto = clientDataUSvcClient.FindClientByIdCard(idCardNumber);

            return new ExtendedClient(clientDto.Name, clientDto.Surname, clientDto.PhoneNumber, clientDto.IdCardNumber, clientDto.VinNumbers);
        }

        public List<ExtendedMechanicalPart> GetAllMechanicalParts()
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.GetAllMechanicalParts();

            List<ExtendedMechanicalPart> mechanicalParts = new List<ExtendedMechanicalPart>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                mechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartDto.id, mechanicalPartDto.category, mechanicalPartDto.price, mechanicalPartDto.sizeX, mechanicalPartDto.sizeY, mechanicalPartDto.sizeZ, mechanicalPartDto.description, mechanicalPartDto.counter, otherProperties));
            }
            return mechanicalParts;
        }

        public List<ExtendedBodyPart> GetAllBodyParts()
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.GetAllBodyParts();

            List<ExtendedBodyPart> bodyParts = new List<ExtendedBodyPart>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }
                bodyParts.Add(new ExtendedBodyPart(bodyPartDto.id, bodyPartDto.bodyType, bodyPartDto.material, bodyPartDto.price, bodyPartDto.colour, bodyPartDto.counter, otherProperties));
            }
            return bodyParts;
        }

        public List<ExtendedLiquid> GetAllLiquids()
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.GetAllLiquids();

            List<ExtendedLiquid> liquids = new List<ExtendedLiquid>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                liquids.Add(new ExtendedLiquid(liquidDto.id, liquidDto.category, liquidDto.density, liquidDto.containsPb, liquidDto.price, liquidDto.counter, otherProperties));
            }
            return liquids;
        }

        public List<ExtendedBodyPart> FindBodyPartByMaterial(string material)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.FindBodyPartByMaterial(material); ;
            List<ExtendedBodyPart> bodyParts = new List<ExtendedBodyPart>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                bodyParts.Add(new ExtendedBodyPart(bodyPartDto.id, bodyPartDto.bodyType, bodyPartDto.material, bodyPartDto.price, bodyPartDto.colour, bodyPartDto.counter, otherProperties));
            }
            return bodyParts;
        }

        public List<ExtendedBodyPart> FindBodyPartByBodyType(string bodyType)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<BodyPartDto> bodyPartsDtos = carPartsDataUSvcClient.FindBodyPartByBodyType(bodyType);
            List<ExtendedBodyPart> bodyParts = new List<ExtendedBodyPart>();

            foreach (BodyPartDto bodyPartDto in bodyPartsDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in bodyPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                bodyParts.Add(new ExtendedBodyPart(bodyPartDto.id, bodyPartDto.bodyType, bodyPartDto.material, bodyPartDto.price, bodyPartDto.colour, bodyPartDto.counter, otherProperties));
            }
            return bodyParts;
        }

        public void UseCarPart(string carPartId)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            if (carPartsDataUSvcClient.GetNumberOfAvailableParts(carPartId) != 0)
            {
                carPartsDataUSvcClient.RemoveCarPart(carPartId);
            }
        }

        public List<ExtendedMechanicalPart> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.FindMechanicalPartByDimensions(sizeX, sizeY, sizeZ);
            List<ExtendedMechanicalPart> mechanicalParts = new List<ExtendedMechanicalPart>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                mechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartDto.id, mechanicalPartDto.category, mechanicalPartDto.price, mechanicalPartDto.sizeX, mechanicalPartDto.sizeY, mechanicalPartDto.sizeZ, mechanicalPartDto.description, mechanicalPartDto.counter, otherProperties));
            }
            return mechanicalParts;
        }

        public List<ExtendedMechanicalPart> FindMechanicalPartByCategory(string category)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<MechanicalPartDto> mechanicalPartDtos = carPartsDataUSvcClient.FindMechanicalPartByCategory(category);
            List<ExtendedMechanicalPart> mechanicalParts = new List<ExtendedMechanicalPart>();

            foreach (MechanicalPartDto mechanicalPartDto in mechanicalPartDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in mechanicalPartDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                mechanicalParts.Add(new ExtendedMechanicalPart(mechanicalPartDto.id, mechanicalPartDto.category, mechanicalPartDto.price, mechanicalPartDto.sizeX, mechanicalPartDto.sizeY, mechanicalPartDto.sizeZ, mechanicalPartDto.description, mechanicalPartDto.counter, otherProperties));
            }
            return mechanicalParts;
        }

        public List<ExtendedLiquid> FindLiquidByDensity(int density)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.FindLiquidByDensity(density);
            List<ExtendedLiquid> liquids = new List<ExtendedLiquid>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();

                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                liquids.Add(new ExtendedLiquid(liquidDto.id, liquidDto.category, liquidDto.density, liquidDto.containsPb, liquidDto.price, liquidDto.counter, otherProperties));
            }
            return liquids;
        }

        public List<ExtendedLiquid> FindLiquidByCategory(string category)
        {
            CarPartsDataUSvcClient carPartsDataUSvcClient = new CarPartsDataUSvcClient();

            List<LiquidDto> liquidDtos = carPartsDataUSvcClient.FindLiquidByCategory(category);
            List<ExtendedLiquid> liquids = new List<ExtendedLiquid>();

            foreach (LiquidDto liquidDto in liquidDtos)
            {
                ExtendedOtherProperties otherProperties = new ExtendedOtherProperties();
                otherProperties.Properties = new List<ExtendedProperty>();

                foreach (PropertyDto property in liquidDto.otherPropertiesDto.properties)
                {
                    otherProperties.Properties.Add(new ExtendedProperty(property.name, property.description));
                }

                liquids.Add(new ExtendedLiquid(liquidDto.id, liquidDto.category, liquidDto.density, liquidDto.containsPb, liquidDto.price, liquidDto.counter, otherProperties));
            }
            return liquids;
        }
    }
}
