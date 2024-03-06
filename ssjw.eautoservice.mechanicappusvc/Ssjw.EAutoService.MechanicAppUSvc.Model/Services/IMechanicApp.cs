namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Services
{
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services;
    using Ssjw.EAutoService.MechanicAppUSvc.Model.Model;
    using System.Collections.Generic;

    public interface IMechanicApp
    {
        public List<ExtendedCar> GetPersonalCars(string id);
        public ExtendedCar GetCarByVinNumber(string vin);
        public List<ExtendedInspection> GetCarInspectionHistory(string vin);
        public List<ExtendedRepair> GetCarRepairHistory(string vin);
        public List<ExtendedRepair> GetPersonalRepairSchedule(string id);
        public List<ExtendedInspection> GetPersonalInspectionSchedule(string id);
        public void FinishRepair(string idService, double price, List<ExtendedRepairedPart> repairedParts);
        public void FinishInspection(string idService, double price, bool testsPassed, string comment);
        public List<ExtendedClient> GetAllClients();
        public ExtendedClient GetClientInformation(string idCardNumber);
        public List<ExtendedMechanicalPart> GetAllMechanicalParts();
        public List<ExtendedBodyPart> GetAllBodyParts();
        public List<ExtendedLiquid> GetAllLiquids();
        public List<ExtendedBodyPart> FindBodyPartByMaterial(string material);
        public List<ExtendedBodyPart> FindBodyPartByBodyType(string bodyType);
        public void UseCarPart(string carPartId);
        public List<ExtendedMechanicalPart> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ);
        public List<ExtendedMechanicalPart> FindMechanicalPartByCategory(string category);
        public List<ExtendedLiquid> FindLiquidByDensity(int density);
        public List<ExtendedLiquid> FindLiquidByCategory(string category);
    }
}
