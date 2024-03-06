namespace Ssjw.EAutoService.MechanicApplication.Controller
{
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

        public ICommand GetPersonalCarsCommand { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }

        public ICommand SignInCommand { get; private set; }

        public ICommand LoadCarsHistoryCommand { get; private set; }

        public ICommand LoadPersonalScheduleCommand { get; private set; }

        public ICommand FinishInspectionCommand { get; private set; }

        public ICommand AddRepairedPartCommand { get; private set; }

        public ICommand FinishRepairCommand { get; private set; }

        public ICommand LoadRepairedPartsCommand { get; private set; }

        public ICommand LoadAllBodyPartsCommand { get; private set; }

        public ICommand UseCarPartCommand { get; private set; }

        public ICommand FindBodyPartByMaterialCommand { get; private set; }

        public ICommand FindBodyPartByBodyTypeCommand { get; private set; }

        public ICommand LoadAllMechanicalPartsCommand { get; private set; }

        public ICommand FindMechanicalPartByDimensionsCommand { get; private set; }

        public ICommand FindMechanicalPartByCategoryCommand { get; private set; }

        public ICommand LoadAllLiquidsCommand { get; private set; }

        public ICommand FindLiquidByDensityCommand { get; private set; }

        public ICommand FindLiquidByCategoryCommand { get; private set; }

        public ICommand LoadAllClientsCommand { get; private set; }


        public async Task LoadAllLiquidsAsync()
        {
            await Task.Run(() => this.LoadAllLiquids());
        }

        public async Task FindMechanicalPartByCategoryAsync()
        {
            await Task.Run(() => this.FindMechanicalPartByCategory());
        }

        public async Task LoadAllMechanicalPartsAsync()
        {
            await Task.Run(() => this.LoadAllMechanicalParts());
        }

        public async Task UseCarPartAsync()
        {
            await Task.Run(() => this.UseCarPart());
        }

        public async Task LoadCarsHistoryAsync()
        {
            await Task.Run(() => this.LoadCarsHistory());
        }

        public async Task LoadPersonalScheduleAsync()
        {
            await Task.Run(() => this.LoadPersonalSchedule());
        }

        public async Task GetPersonalCarsAsync()
        {
            await Task.Run(() => this.GetPersonalCars());
        }

        public async Task ShowListAsync()
        {
            await Task.Run(() => this.ShowList());
        }

        public async Task ShowMapAsync()
        {
            await Task.Run(() => this.ShowMap());
        }

        public async Task SignInAsync()
        {
            await Task.Run(() => this.SignIn()); ;
        }

        public async Task FinishInspectionAsync()
        {
            await Task.Run(() => this.FinishInspection());
        }

        public async Task AddRepairedPartAsync()
        {
            await Task.Run(() => this.AddRepairedPart());
        }

        public async Task FinishRepairAsync()
        {
            await Task.Run(() => this.FinishRepair());
        }

        public async Task LoadRepairedPartsAsync()
        {
            await Task.Run(() => this.LoadRepairedParts());
        }

        public async Task LoadAllBodyPartsAsync()
        {
            await Task.Run(() => this.LoadAllBodyParts());
        }

        public async Task FindBodyPartByMaterialAsync()
        {
            await Task.Run(() => this.FindBodyPartByMaterial());
        }

        public async Task FindBodyPartByBodyTypeAsync()
        {
            await Task.Run(() => this.FindBodyPartByBodyType());
        }

        public async Task FindMechanicalPartByDimensionsAsync()
        {
            await Task.Run(() => this.FindMechanicalPartByDimensions());
        }

        public async Task FindLiquidByDensityAsync()
        {
            await Task.Run(() => this.FindLiquidByDensity());
        }

        public async Task FindLiquidByCategoryAsync()
        {
            await Task.Run(() => this.FindLiquidByCategory());
        }

        public async Task LoadAllClientsAsync()
        {
            await Task.Run(() => this.LoadAllClients());
        }

        private void FinishInspection()
        {
            this.Model.FinishInspection();
        }

        private void GetPersonalCars()
        {
            this.Model.GetPersonalCars();
        }

        private void SignIn()
        {
            this.Model.SignIn();
        }

        private void LoadCarsHistory()
        {
            this.Model.LoadCarsHistory();
        }

        private void LoadAllLiquids()
        {
            this.Model.LoadAllLiquids();
        }

        private void LoadPersonalSchedule()
        {
            this.Model.LoadPersonalSchedule();
        }

        private void AddRepairedPart()
        {
            this.Model.AddRepairedPart();
        }

        private void FinishRepair()
        {
            this.Model.FinishRepair();
        }

        private void LoadRepairedParts()
        {
            this.Model.LoadRepairedParts();
        }

        private void LoadAllBodyParts()
        {
            this.Model.LoadAllBodyParts();
        }

        private void UseCarPart()
        {
            this.Model.UseCarPart();
        }

        private void FindBodyPartByMaterial()
        {
            this.Model.FindBodyPartByMaterial();
        }

        private void FindBodyPartByBodyType()
        {
            this.Model.FindBodyPartByBodyType();
        }

        private void LoadAllMechanicalParts()
        {
            this.Model.LoadAllMechanicalParts();
        }

        private void FindMechanicalPartByDimensions()
        {
            this.Model.FindMechanicalPartByDimensions();
        }

        private void FindMechanicalPartByCategory()
        {
            this.Model.FindMechanicalPartByCategory();
        }

        private void FindLiquidByDensity()
        {
            this.Model.FindLiquidByDensity();
        }

        private void FindLiquidByCategory()
        {
            this.Model.FindLiquidByCategory();
        }

        private void LoadAllClients()
        {
            this.Model.LoadAllClients();
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