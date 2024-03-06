namespace Ssjw.EAutoService.MechanicApplication.Model
{
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;

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

        public string EmployeeId
        {
            get { return this.employeeId; }
            set
            {
                this.employeeId = value;

                this.RaisePropertyChanged("EmployeeId");
            }
        }
        private string employeeId;

        public string ServicesId
        {
            get { return this.servicesId; }
            set
            {
                this.servicesId = value;

                this.RaisePropertyChanged("ServicesId");
            }
        }
        private string servicesId;

        public List<ExtendedCarDto> CarsList
        {
            get { return this.carsList; }
            private set
            {
                this.carsList = value;

                this.RaisePropertyChanged("CarsList");
            }
        }
        private List<ExtendedCarDto> carsList = new List<ExtendedCarDto>();

        public List<ExtendedBodyPartDto> BodyPartList
        {
            get { return this.bodyPartList; }
            private set
            {
                this.bodyPartList = value;

                this.RaisePropertyChanged("BodyPartList");
            }
        }
        private List<ExtendedBodyPartDto> bodyPartList = new List<ExtendedBodyPartDto>();

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

        public string Material
        {
            get { return this.material; }
            set
            {
                this.material = value;

                this.RaisePropertyChanged("Material");
            }
        }
        private string material;

        public string BodyType
        {
            get { return this.bodyType; }
            set
            {
                this.bodyType = value;

                this.RaisePropertyChanged("BodyType");
            }
        }
        private string bodyType;

        public ExtendedBodyPartDto SelectedBodyPart
        {
            get { return this.selectedBodyPart; }
            set
            {
                this.selectedBodyPart = value;
                this.carPartId = selectedBodyPart.id;

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
                this.carPartId = selectedMechanicalPart.id;

                this.RaisePropertyChanged("SelectedMechanicalPart");
            }
        }
        private ExtendedMechanicalPartDto selectedMechanicalPart;

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

        public List<ExtendedMechanicalPartDto> MechanicalPartList
        {
            get { return this.mechanicalPartList; }
            private set
            {
                this.mechanicalPartList = value;

                this.RaisePropertyChanged("MechanicalPartList");
            }
        }
        private List<ExtendedMechanicalPartDto> mechanicalPartList = new List<ExtendedMechanicalPartDto>();

        public List<ExtendedInspectionDto> InspectionsList
        {
            get { return this.inspectionsList; }
            private set
            {
                this.inspectionsList = value;

                this.RaisePropertyChanged("InspectionsList");
            }
        }
        private List<ExtendedInspectionDto> inspectionsList = new List<ExtendedInspectionDto>();

        public List<ExtendedRepairedPartDto> RepairedPartsList
        {
            get { return this.repairedPartsList; }
            private set
            {
                this.repairedPartsList = value;

                this.RaisePropertyChanged("RepairedPartsList");
            }
        }
        private List<ExtendedRepairedPartDto> repairedPartsList = new List<ExtendedRepairedPartDto>();

        public ExtendedRepairDto SelectedRepair
        {
            get { return this.selectedRepair; }
            set
            {
                this.selectedRepair = value;
                this.repairId = selectedRepair.id;

                this.RaisePropertyChanged("SelectedRepair");
            }
        }
        private ExtendedRepairDto selectedRepair;

        public List<ExtendedLiquidDto> LiquidList
        {
            get { return this.liquidList; }
            private set
            {
                this.liquidList = value;

                this.RaisePropertyChanged("LiquidList");
            }
        }
        private List<ExtendedLiquidDto> liquidList = new List<ExtendedLiquidDto>();

        public ExtendedLiquidDto SelectedLiquid
        {
            get { return this.selectedLiquid; }
            set
            {
                this.selectedLiquid = value;
                this.carPartId = selectedLiquid.id;

                this.RaisePropertyChanged("SelectedLiquid");
            }
        }
        private ExtendedLiquidDto selectedLiquid;

        public List<ExtendedClientDto> ClientList
        {
            get { return this.clientList; }
            private set
            {
                this.clientList = value;

                this.RaisePropertyChanged("ClientList");
            }
        }
        private List<ExtendedClientDto> clientList = new List<ExtendedClientDto>();

        public ExtendedClientDto SelectedClient
        {
            get { return this.selectedClient; }
            set
            {
                this.selectedClient = value;

                this.RaisePropertyChanged("SelectedClient");
            }
        }
        private ExtendedClientDto selectedClient;

        public ExtendedInspectionDto SelectedInspection
        {
            get { return this.selectedInspection; }
            set
            {
                this.selectedInspection = value;
                this.inspectionId = selectedInspection.id;

                this.RaisePropertyChanged("SelectedInspection");
            }
        }
        private ExtendedInspectionDto selectedInspection;

        public string InspectionId
        {
            get { return this.inspectionId; }
            set
            {
                this.inspectionId = value;

                this.RaisePropertyChanged("InspectionId");
            }
        }
        private string inspectionId;

        public string RepairId
        {
            get { return this.repairId; }
            set
            {
                this.repairId = value;

                this.RaisePropertyChanged("RepairId");
            }
        }
        private string repairId;

        public string CarPartId
        {
            get { return this.carPartId; }
            set
            {
                this.carPartId = value;

                this.RaisePropertyChanged("CarPartId");
            }
        }
        private string carPartId;

        public double SizeX
        {
            get { return this.sizeX; }
            set
            {
                this.sizeX = value;

                this.RaisePropertyChanged("SizeX");
            }
        }
        private double sizeX;

        public double SizeY
        {
            get { return this.sizeY; }
            set
            {
                this.sizeY = value;

                this.RaisePropertyChanged("SizeY");
            }
        }
        private double sizeY;

        public double SizeZ
        {
            get { return this.sizeZ; }
            set
            {
                this.sizeZ = value;

                this.RaisePropertyChanged("SizeZ");
            }
        }
        private double sizeZ;

        public string CauseOfRepair
        {
            get { return this.causeOfRepair; }
            set
            {
                this.causeOfRepair = value;

                this.RaisePropertyChanged("CauseOfRepair");
            }
        }
        private string causeOfRepair;

        public string Category
        {
            get { return this.category; }
            set
            {
                this.category = value;

                this.RaisePropertyChanged("Category");
            }
        }
        private string category;

        public int Density
        {
            get { return this.density; }
            set
            {
                this.density = value;

                this.RaisePropertyChanged("Density");
            }
        }
        private int density;

        public double Price
        {
            get { return this.price; }
            set
            {
                this.price = value;

                this.RaisePropertyChanged("Price");
            }
        }
        private double price;

        public bool TestsPassed
        {
            get { return this.testsPassed; }
            set
            {
                this.testsPassed = value;

                this.RaisePropertyChanged("TestsPassed");
            }
        }
        private bool testsPassed;


        public string Comment
        {
            get { return this.comment; }
            set
            {
                this.comment = value;

                this.RaisePropertyChanged("Comment");
            }
        }
        private string comment;
    }
}