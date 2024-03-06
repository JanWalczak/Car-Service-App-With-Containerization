namespace Ssjw.EAutoService.ClientApplication.Controller
{
    using Ssjw.EAutoService.ClientApplication.Model;
    using Ssjw.EAutoService.ClientApplication.Utilities;
    using System.Windows.Input;

    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }

        public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;

            this.ShowCarListCommand = new ControllerCommand(this.ShowCarList);

            this.SearchRepairsCommand = new ControllerCommand(this.SearchRepairs);

            this.SearchInspectionsCommand = new ControllerCommand(this.SearchInspections);

            this.ShowLiquidsListCommand = new ControllerCommand(this.ShowLiquidsList);

            this.ShowBodyPartsListCommand = new ControllerCommand(this.ShowBodyPartsList);

            this.ShowMechanicalPartsListCommand = new ControllerCommand(this.ShowMechanicalPartsList);

            this.SearchMechanicsCommand = new ControllerCommand(this.SearchMechanics);

            this.RequestServiceCommand = new ControllerCommand(this.RequestService);

            this.ShowListCommand = new ControllerCommand(this.ShowList);

            this.ShowMapCommand = new ControllerCommand(this.ShowMap);

            this.RegisterNewClientCommand = new ControllerCommand(this.RegisterNewClient);

            this.RegisterNewCarCommand = new ControllerCommand(this.RegisterNewCar);

            this.ShowPersonalDataCommand = new ControllerCommand(this.ShowPersonalData);

            this.ChangePersonalDataCommand = new ControllerCommand(this.ChangePersonalData);

            this.SearchBodyPartsByPriceCommand = new ControllerCommand(this.SearchBodyPartsByPrice);

            this.SearchBodyPartsByBodyTypeCommand = new ControllerCommand(this.SearchBodyPartsByBodyType);

            this.SearchMechanicalPartsByPriceCommand = new ControllerCommand(this.SearchMechanicalPartsByPrice);

            this.SearchLiquidsByPriceCommand = new ControllerCommand(this.SearchLiquidsByPrice);

            this.SearchLiquidsByCategoryCommand = new ControllerCommand(this.SearchLiquidsByCategory);

            this.PurchaseCarPartCommand = new ControllerCommand(this.PurchaseCarPart);
        }
    }
}
