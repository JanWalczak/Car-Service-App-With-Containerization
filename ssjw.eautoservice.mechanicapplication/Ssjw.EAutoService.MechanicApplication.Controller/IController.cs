namespace Ssjw.EAutoService.MechanicApplication.Controller
{
    using System.ComponentModel;
    using System.Windows.Input;
    using Ssjw.EAutoService.MechanicApplication.Model;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand GetPersonalCarsCommand { get; }

        ICommand SignInCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }

        ICommand LoadCarsHistoryCommand { get; }

        ICommand LoadPersonalScheduleCommand { get; }

        ICommand FinishInspectionCommand { get; }

        ICommand FinishRepairCommand { get; }

        ICommand AddRepairedPartCommand { get; }

        ICommand LoadRepairedPartsCommand { get; }

        ICommand LoadAllBodyPartsCommand { get; }

        ICommand UseCarPartCommand { get; }

        ICommand FindBodyPartByMaterialCommand { get; }

        ICommand FindBodyPartByBodyTypeCommand { get; }

        ICommand LoadAllMechanicalPartsCommand { get; }

        ICommand FindMechanicalPartByDimensionsCommand { get; }

        ICommand FindMechanicalPartByCategoryCommand { get; }

        ICommand LoadAllLiquidsCommand { get; }

        ICommand FindLiquidByDensityCommand { get; }

        ICommand FindLiquidByCategoryCommand { get; }

        ICommand LoadAllClientsCommand { get; }

        Task LoadAllClientsAsync();

        Task LoadAllLiquidsAsync();

        Task FindMechanicalPartByDimensionsAsync();

        Task LoadAllMechanicalPartsAsync();

        Task FindBodyPartByBodyTypeAsync();

        Task GetPersonalCarsAsync();

        Task SignInAsync();

        Task ShowListAsync();

        Task ShowMapAsync();

        Task LoadCarsHistoryAsync();

        Task LoadPersonalScheduleAsync();

        Task FinishInspectionAsync();

        Task FinishRepairAsync();

        Task AddRepairedPartAsync();

        Task LoadRepairedPartsAsync();

        Task LoadAllBodyPartsAsync();

        Task UseCarPartAsync();

        Task FindBodyPartByMaterialAsync();

        Task FindMechanicalPartByCategoryAsync();

        Task FindLiquidByDensityAsync();

        Task FindLiquidByCategoryAsync();
    }
}