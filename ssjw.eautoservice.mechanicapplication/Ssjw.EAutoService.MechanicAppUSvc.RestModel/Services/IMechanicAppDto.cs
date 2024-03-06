namespace Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;

    public interface IMechanicAppDto
    {
        public List<ExtendedCarDto> GetPersonalCars(string id);
        public ExtendedCarDto GetCarByVinNumber(string vinNumber);
        public List<ExtendedInspectionDto> GetCarInspectionHistory(string vin);
        public List<ExtendedRepairDto> GetCarRepairHistory(string vin);
        public List<ExtendedRepairDto> GetPersonalRepairSchedule(string id);
        public List<ExtendedInspectionDto> GetPersonalInspectionSchedule(string id);
        public void FinishRepair(string idService, double price, List<ExtendedRepairedPartDto> repairedParts);
        public void FinishInspection(string idService, double price, bool testsPassed, string comment);
        public List<ExtendedClientDto> GetAllClients();
        public ExtendedClientDto GetClientInformation(string id);
        public List<ExtendedMechanicalPartDto> GetAllMechanicalParts();
        public List<ExtendedBodyPartDto> GetAllBodyParts();
        public List<ExtendedLiquidDto> GetAllLiquids();
        public List<ExtendedBodyPartDto> FindBodyPartByMaterial(string material);
        public List<ExtendedBodyPartDto> FindBodyPartByBodyType(string bodyType);
        public void UseCarPart(string carPartId);
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ);
        public List<ExtendedMechanicalPartDto> FindMechanicalPartByCategory(string category);
        public List<ExtendedLiquidDto> FindLiquidByDensity(int density);
        public List<ExtendedLiquidDto> FindLiquidByCategory(string category);
    }
}
