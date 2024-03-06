namespace Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    public interface IClientAppSvc
    {
        public List<ExtendedCarDto> GetAllClientCar(string idCardNumber);
        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber, List<string>? servicesHistory);
        public List<ExtendedEmployeeDto> GetAvailableMechanics(DateTime date);
        public void AddNewClient(ExtendedClientDto client);
        public ExtendedClientDto GetPersonalInformation(string id);
        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin);
        public List<ExtendedRepairDto> GetCarRepairHistory(string vin);
        public ExtendedCarDto GetCarInformation(string vin);
        public void RequestNewInspection(ExtendedInspectionDto extendedInspection);
        public void RequestNewRepair(ExtendedRepairDto extendedRepair);
        public void PurchaseCarPart(string id);
        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber, List<string>? vinNumbers);
        public List<ExtendedBodyPartDto> GetAllBodyParts();
        public List<ExtendedLiquidDto> GetAllLiquids();
        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts();
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType);
        public List<ExtendedBodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedLiquidDto> FindLiquidByCategory(string category);
        public List<ExtendedLiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category);
        public void AddCar(ExtendedCarDto extendedCarDto, string idCardNumber);
    }
}
