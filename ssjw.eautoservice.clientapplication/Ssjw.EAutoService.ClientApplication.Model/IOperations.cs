namespace Ssjw.EAutoService.ClientApplication.Model
{
    public interface IOperations
    {
        void LoadRepairsByVinList();

        void LoadBodyPartsList();

        void LoadBodyPartsByPrice();

        void LoadBodyPartsByBodyType();

        void LoadMechanicalPartsByPrice();

        void LoadMechanicalPartsByCategory();
        void LoadMechanicalPartsList();

        void LoadLiquidsByPrice();

        void PurchaseCarPart();

        void LoadLiquidsByCategory();

        void LoadLiquidsList();

        void LoadInspectionsByVinList();

        void LoadCarsByIdCardNumber();

        void LoadMechanicsByDate();

        void SaveRequestService();

        void SaveNewClient();

        void SaveNewCar();

        void LoadPersonalData();

        void SaveChangedPersonalData();
    }
}
