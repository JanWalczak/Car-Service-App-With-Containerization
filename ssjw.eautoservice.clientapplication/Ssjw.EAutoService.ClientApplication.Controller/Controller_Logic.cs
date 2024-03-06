namespace Ssjw.EAutoService.ClientApplication.Controller
{
    using System.Threading.Tasks;

    using System.Windows.Input;

    public partial class Controller : IController
    {
        public ApplicationState CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                this.RaisePropertyChanged("CurrentState");
            }
        }
        private ApplicationState currentState = ApplicationState.List;

        public ICommand SearchRepairsCommand { get; private set; }

        public ICommand ShowBodyPartsListCommand { get; private set; }

        public ICommand SearchBodyPartsByPriceCommand { get; private set; }


        public ICommand PurchaseCarPartCommand { get; private set; }

        public ICommand SearchMechanicalPartsByCategoryCommand { get; private set; }

        public ICommand SearchBodyPartsByBodyTypeCommand { get; private set; }

        public ICommand ShowLiquidsListCommand { get; private set; }

        public ICommand ShowMechanicalPartsListCommand { get; private set; }

        public ICommand SearchMechanicalPartsByPriceCommand { get; private set; }

        public ICommand SearchLiquidsByPriceCommand { get; private set; }

        public ICommand SearchLiquidsByCategoryCommand { get; private set; }

        public ICommand ShowCarListCommand { get; private set; }

        public ICommand SearchInspectionsCommand { get; private set; }

        public ICommand SearchMechanicsCommand { get; private set; }

        public ICommand RequestServiceCommand { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }

        public ICommand RegisterNewClientCommand { get; private set; }

        public ICommand ShowPersonalDataCommand { get; private set; }

        public ICommand RegisterNewCarCommand { get; private set; }

        public ICommand ChangePersonalDataCommand { get; private set; }

        public async Task SearchRepairsAsync()
        {
            await Task.Run(() => this.SearchRepairs());
        }

        public async Task ShowCarListAsync()
        {
            await Task.Run(() => this.ShowCarList());
        }

        public async Task SearchInspectionsAsync()
        {
            await Task.Run(() => this.SearchInspections());
        }

        public async Task ShowBodyPartsListAsync()
        {
            await Task.Run(() => this.ShowBodyPartsList());
        }

        public async Task SearchBodyPartsByPriceAsync()
        {
            await Task.Run(() => this.SearchBodyPartsByPrice());
        }

        public async Task SearchMechanicalPartsByPriceAsync()
        {
            await Task.Run(() => this.SearchMechanicalPartsByPrice());
        }

        public async Task SearchLiquidsByPriceAsync()
        {
            await Task.Run(() => this.SearchLiquidsByPrice());
        }

        public async Task SearchLiquidsByCategoryAsync()
        {
            await Task.Run(() => this.SearchLiquidsByCategory());
        }

        public async Task SearchMechanicalPartsByCategoryAsync()
        {
            await Task.Run(() => this.SearchMechanicalPartsByCategory());
        }

        public async Task PurchaseCarPartAsync()
        {
            await Task.Run(() => this.PurchaseCarPart());
        }

        public async Task SearchBodyPartsByBodyTypeAsync()
        {
            await Task.Run(() => this.SearchBodyPartsByBodyType());
        }

        public async Task ShowLiquidsListAsync()
        {
            await Task.Run(() => this.ShowLiquidsList());
        }

        public async Task ShowMechanicalPartsAsync()
        {
            await Task.Run(() => this.ShowMechanicalPartsList());
        }

        public async Task ShowListAsync()
        {
            await Task.Run(() => this.ShowList());
        }

        public async Task ShowMapAsync()
        {
            await Task.Run(() => this.ShowMap());
        }

        public async Task SearchMechanicsAsync()
        {
            await Task.Run(() => this.SearchMechanics());
        }

        public async Task RequestServiceAsync()
        {
            await Task.Run(() => this.RequestService());
        }

        public async Task RegisterNewClientAsync()
        {
            await Task.Run(() => this.RegisterNewClient());
        }

        public async Task ShowPersonalDataAsync()
        {
            await Task.Run(() => this.ShowPersonalData());
        }

        public async Task RegisterNewCarAsync()
        {
            await Task.Run(() => this.RegisterNewCar());
        }

        public async Task ChangePersonalDataAsync()
        {
            await Task.Run(() => this.ChangePersonalData());
        }

        private void SearchRepairs()
        {
            this.Model.LoadRepairsByVinList();
        }

        private void SearchInspections()
        {
            this.Model.LoadInspectionsByVinList();
        }

        private void ShowBodyPartsList()
        {
            this.Model.LoadBodyPartsList();
        }

        private void SearchBodyPartsByPrice()
        {
            this.Model.LoadBodyPartsByPrice();
        }

        private void SearchMechanicalPartsByPrice()
        {
            this.Model.LoadMechanicalPartsByPrice();
        }

        private void SearchLiquidsByPrice()
        {
            this.Model.LoadLiquidsByPrice();
        }

        private void SearchLiquidsByCategory()
        {
            this.Model.LoadLiquidsByCategory();
        }

        private void SearchMechanicalPartsByCategory()
        {
            this.Model.LoadMechanicalPartsByCategory();
        }

        private void PurchaseCarPart()
        {
            this.Model.PurchaseCarPart();
        }

        private void SearchBodyPartsByBodyType()
        {
            this.Model.LoadBodyPartsByBodyType();
        }

        private void ShowMechanicalPartsList()
        {
            this.Model.LoadMechanicalPartsList();
        }

        private void ShowLiquidsList()
        {
            this.Model.LoadLiquidsList();
        }

        private void ShowCarList()
        {
            this.Model.LoadCarsByIdCardNumber();
        }


        private void SearchMechanics()
        {
            this.Model.LoadMechanicsByDate();
        }

        private void RequestService()
        {
            this.Model.SaveRequestService();
        }

        private void RegisterNewClient()
        {
            this.Model.SaveNewClient();
        }

        private void RegisterNewCar()
        {
            this.Model.SaveNewCar();
        }

        private void ShowPersonalData()
        {
            this.Model.LoadPersonalData();
        }

        private void ChangePersonalData()
        {
            this.Model.SaveChangedPersonalData();
        }

        private void ShowList()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.List:
                    break;

                default:
                    this.CurrentState = ApplicationState.List;
                    break;
            }
        }

        private void ShowMap()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.Map:
                    break;

                default:
                    this.CurrentState = ApplicationState.Map;
                    break;
            }
        }
    }
}
