namespace Ssjw.EAutoService.ClientApplication.Controller
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Ssjw.EAutoService.ClientApplication.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand SearchRepairsCommand { get; }

        ICommand SearchInspectionsCommand { get; }

        ICommand ShowLiquidsListCommand { get; }

        ICommand ShowBodyPartsListCommand { get; }

        ICommand SearchBodyPartsByPriceCommand { get; }

        ICommand SearchBodyPartsByBodyTypeCommand { get; }

        ICommand SearchMechanicalPartsByCategoryCommand { get; }

        ICommand ShowMechanicalPartsListCommand { get; }

        ICommand PurchaseCarPartCommand { get;  }

        ICommand SearchLiquidsByCategoryCommand { get; }
    
        ICommand SearchLiquidsByPriceCommand { get; }
       
        ICommand SearchMechanicalPartsByPriceCommand { get; }

        ICommand ShowCarListCommand { get; }

        ICommand SearchMechanicsCommand { get; }

        ICommand RequestServiceCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }

        ICommand RegisterNewClientCommand { get; }

        ICommand ShowPersonalDataCommand { get; }
        
        ICommand RegisterNewCarCommand { get; }

        ICommand ChangePersonalDataCommand { get;  }

        Task SearchRepairsAsync();

        Task SearchInspectionsAsync();

        Task ShowCarListAsync();

        Task ShowBodyPartsListAsync();

        Task SearchBodyPartsByPriceAsync();

        Task SearchMechanicalPartsByPriceAsync();

        Task SearchMechanicalPartsByCategoryAsync();

        Task SearchBodyPartsByBodyTypeAsync();

        Task SearchLiquidsByPriceAsync();

        Task SearchLiquidsByCategoryAsync();

        Task ShowLiquidsListAsync();

        Task ShowMechanicalPartsAsync();

        Task SearchMechanicsAsync();

        Task PurchaseCarPartAsync();

        Task RequestServiceAsync();

        Task ShowListAsync();

        Task ShowMapAsync();

        Task RegisterNewClientAsync();

        Task ShowPersonalDataAsync();

        Task RegisterNewCarAsync();

        Task ChangePersonalDataAsync ();
    }
}
