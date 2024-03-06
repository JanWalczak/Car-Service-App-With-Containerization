namespace Ssjw.EAutoService.MechanicApplication.Model
{
    public interface IOperations
    {
        void GetPersonalCars();

        void SignIn();

        void LoadCarsHistory();

        void LoadPersonalSchedule();

        void LoadRepairedParts();

        void LoadAllBodyParts();

        void LoadAllMechanicalParts();

        void FinishInspection();

        void FinishRepair();

        void AddRepairedPart();

        void UseCarPart();

        void FindBodyPartByMaterial();

        void FindBodyPartByBodyType();

        void FindMechanicalPartByDimensions();

        void FindMechanicalPartByCategory();

        void LoadAllLiquids();

        void FindLiquidByDensity();

        void FindLiquidByCategory();

        void LoadAllClients();
    }
}
