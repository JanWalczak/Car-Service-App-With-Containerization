namespace Ssjw.EAutoService.ClientAppUSvc.Model.Services
{
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.ClientAppUSvc.Model.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    public interface IClientApp
    {
        public List<ExtendedCar> GetAllClientCar(string idCardNumber);
        public void ModifyCarData(string vin, string? model, string? brand, DateTime? productionYear, string? insuranceNumber, List<string>? servicesHistory);
        public List<ExtendedEmployee> GetAvailableMechanics(DateTime date);
        public void AddNewClient(ExtendedClient client);
        public ExtendedClient GetPersonalInformation(string id);
        public List<ExtendedInspection> GetCarInspectionHistory(string vin); 
        public List<ExtendedRepair> GetCarRepairHistory(string vin); 
        public ExtendedCar GetCarInformation(string vin); 
        public void RequestNewInspection(ExtendedInspection extendedInspection);
        public void RequestNewRepair(ExtendedRepair extendedRepair); 
        public void PurchaseCarPart(string id);
        public void ModifyPersonalData(string clientId, string? newIdCard, string? name, string? surname, string? phoneNumber,  List<string>? vinNumbers); //
        public List<ExtendedBodyPart> GetAllBodyParts();
        public List<ExtendedLiquid> GetAllLiquids();
        public List<ExtendedMechanicalPart> GetAllMechanicalParts();
        public List<ExtendedBodyPart> FindBodyPartByBodyType(string bodyType);
        public List<ExtendedBodyPart> FindBodyPartByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedLiquid> FindLiquidByCategory(string category);
        public List<ExtendedLiquid> FindLiquidByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedMechanicalPart> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice);
        public List<ExtendedMechanicalPart> FindMechanicalPartByCategory(string category);
        public void AddCar(ExtendedCarDto carDto, string idCardNumber);
    }
}
