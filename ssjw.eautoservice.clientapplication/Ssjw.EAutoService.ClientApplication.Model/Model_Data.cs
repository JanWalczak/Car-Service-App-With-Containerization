using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;

namespace Ssjw.EAutoService.ClientApplication.Model
{
    public partial class Model : IData
    {
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;

                this.RaisePropertyChanged("SearchText");
            }
        }
        private string searchText;

        public int MinPrice
        {
            get { return this.minPrice; }
            set
            {
                this.minPrice = value;

                this.RaisePropertyChanged("MinPrice");
            }
        }
        private int minPrice;

        public int MaxPrice
        {
            get { return this.maxPrice; }
            set
            {
                this.maxPrice = value;

                this.RaisePropertyChanged("MaxPrice");
            }
        }
        private int maxPrice;

        public string IdCardNumber
        {
            get { return this.idCardNumber; }
            set
            {
                this.idCardNumber = value;

                this.RaisePropertyChanged("IdCardNumber");
            }
        }
        private string idCardNumber;

        public string SelectedServiceType
        {
            get { return this.selectedServiceType; }
            set
            {
                this.selectedServiceType = value;

                this.RaisePropertyChanged("SelectedServiceType");
            }
        }
        private string selectedServiceType;

        public DateTime SelectedDate
        {
            get { return this.selectedDate; }
            set
            {
                this.selectedDate = value;

                this.RaisePropertyChanged("SelectedDate");
            }
        }
        private DateTime selectedDate;

        public ExtendedEmployeeDto SelectedMechanic
        {
            get { return this.selectedMechanic; }
            set
            {
                this.selectedMechanic = value;

                this.RaisePropertyChanged("SelectedMechanic");
            }
        }
        private ExtendedEmployeeDto selectedMechanic;

        public List<ExtendedEmployeeDto> AvailableMechanics
        {
            get { return this.availableMechanics; }
            private set
            {
                this.availableMechanics = value;

                this.RaisePropertyChanged("AvailableMechanics");
            }
        }
        private List<ExtendedEmployeeDto> availableMechanics = new List<ExtendedEmployeeDto>();

        public List<ExtendedCarDto> ExtendedCarList
        {
            get { return this.extendedCarList; }
            private set
            {
                this.extendedCarList = value;

                this.RaisePropertyChanged("ExtendedCarList");
            }
        }
        private List<ExtendedCarDto> extendedCarList = new List<ExtendedCarDto>();

        public List<ExtendedInspectionDto> InspectionsList
        {
            get { return this.incpectionsList; }
            private set
            {
                this.incpectionsList = value;

                this.RaisePropertyChanged("InspectionsList");
            }
        }
        private List<ExtendedInspectionDto> incpectionsList = new List<ExtendedInspectionDto>();

        public ExtendedInspectionDto SelectedInspection
        {
            get { return this.selectedInspection; }
            set
            {
                this.selectedInspection = value;

                this.RaisePropertyChanged("SelectedInspection");
            }
        }
        private ExtendedInspectionDto selectedInspection;

        public ExtendedCarDto SelectedCar
        {
            get { return this.selectedCar; }
            set
            {
                this.selectedCar = value;

                this.RaisePropertyChanged("SelectedCar");
            }
        }
        private ExtendedCarDto selectedCar;

        public List<ExtendedRepairDto> RepairsList
        {
            get { return this.repairsList; }
            private set
            {
                this.repairsList = value;

                this.RaisePropertyChanged("RepairsList");
            }
        }
        private List<ExtendedRepairDto> repairsList = new List<ExtendedRepairDto>();

        public List<ExtendedBodyPartDto> BodyPartsList
        {
            get { return this.bodyPartsList; }
            private set
            {
                this.bodyPartsList = value;

                this.RaisePropertyChanged("BodyPartsList");
            }
        }
        private List<ExtendedBodyPartDto> bodyPartsList = new List<ExtendedBodyPartDto>();

        public ExtendedBodyPartDto SelectedBodyPart
        {
            get { return this.selectedBodyPart; }
            set
            {
                this.selectedBodyPart = value;

                this.RaisePropertyChanged("SelectedBodyPart");
            }
        }
        private ExtendedBodyPartDto selectedBodyPart;


        public ExtendedMechanicalPartDto SelectedMechanicalPart
        {
            get { return this.selectedMechanicalPart; }
            set
            {
                this.selectedMechanicalPart = value;

                this.RaisePropertyChanged("SelectedMechanicalPart");
            }
        }
        private ExtendedMechanicalPartDto selectedMechanicalPart;

        public ExtendedLiquidDto SelectedLiquid
        {
            get { return this.selectedLiquid; }
            set
            {
                this.selectedLiquid = value;

                this.RaisePropertyChanged("SelectedLiquid");
            }
        }
        private ExtendedLiquidDto selectedLiquid;


        

        public List<ExtendedMechanicalPartDto> MechanicalPartsList
        {
            get { return this.mechanicalPartsList; }
            private set
            {
                this.mechanicalPartsList = value;

                this.RaisePropertyChanged("MechanicalPartsList");
            }
        }
        private List<ExtendedMechanicalPartDto> mechanicalPartsList = new List<ExtendedMechanicalPartDto>();

        public List<ExtendedLiquidDto> LiquidsList
        {
            get { return this.liquidsList; }
            private set
            {
                this.liquidsList = value;

                this.RaisePropertyChanged("LiquidsList");
            }
        }
        private List<ExtendedLiquidDto> liquidsList = new List<ExtendedLiquidDto>();

        public ExtendedRepairDto SelectedRepair
        {
            get { return this.selectedRepair; }
            set
            {
                this.selectedRepair = value;

                this.RaisePropertyChanged("SelectedRepair");
            }
        }
        private ExtendedRepairDto selectedRepair;

        public ExtendedClientDto NewClient
        {
            get { return this.newClient; }
            set
            {
                this.newClient = value;

                this.RaisePropertyChanged("NewClient");
            }
        }
        private ExtendedClientDto newClient;

        public ExtendedClientDto ChangedClient
        {
            get { return this.changedClient; }
            set
            {
                this.changedClient = value;

                this.RaisePropertyChanged("ChangedClient");
            }
        }
        private ExtendedClientDto changedClient;

        public ExtendedCarDto NewCar
        {
            get { return this.newCar; }
            set
            {
                this.newCar = value;

                this.RaisePropertyChanged("NewCar");
            }
        }
        private ExtendedCarDto newCar;

        public ExtendedClientDto LoggedClient
        {
            get { return this.loggedClient; }
            set
            {
                this.loggedClient = value;

                this.RaisePropertyChanged("LoggedClient");
            }
        }
        private ExtendedClientDto loggedClient;
    }
}
