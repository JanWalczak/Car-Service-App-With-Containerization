namespace Ssjw.EAutoService.MechanicApplication.Controller
{
    using Ssjw.EAutoService.MechanicApplication.Utilities;
    using Ssjw.EAutoService.MechanicApplication.Model;
    using System.Windows.Input;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.GetPersonalCarsCommand = new ControllerCommand(this.GetPersonalCars);

            this.SignInCommand = new ControllerCommand(this.SignIn);

            this.LoadCarsHistoryCommand = new ControllerCommand(this.SignIn);

            this.ShowListCommand = new ControllerCommand(this.ShowList);

            this.ShowMapCommand = new ControllerCommand(this.ShowMap);

            this.LoadPersonalScheduleCommand = new ControllerCommand(this.LoadPersonalSchedule);

            this.FinishInspectionCommand = new ControllerCommand(this.FinishInspection);

            this.AddRepairedPartCommand = new ControllerCommand(this.AddRepairedPart);

            this.FinishRepairCommand = new ControllerCommand(this.FinishRepair);

            this.LoadAllBodyPartsCommand = new ControllerCommand(this.LoadAllBodyParts);

            this.UseCarPartCommand = new ControllerCommand(this.UseCarPart);

            this.FindBodyPartByMaterialCommand = new ControllerCommand(this.FindBodyPartByMaterial);

            this.FindBodyPartByBodyTypeCommand = new ControllerCommand(this.FindBodyPartByBodyType);

            this.LoadAllMechanicalPartsCommand = new ControllerCommand(this.LoadAllMechanicalParts);

            this.FindMechanicalPartByDimensionsCommand = new ControllerCommand(this.FindMechanicalPartByDimensions);

            this.FindMechanicalPartByCategoryCommand = new ControllerCommand(this.FindMechanicalPartByCategory);

            this.LoadAllLiquidsCommand = new ControllerCommand(this.LoadAllLiquids);

            this.FindLiquidByDensityCommand = new ControllerCommand(this.FindLiquidByDensity);

            this.FindLiquidByCategoryCommand = new ControllerCommand(this.FindLiquidByCategory);

            this.LoadAllClientsCommand = new ControllerCommand(this.LoadAllClients);
        }
    }
}