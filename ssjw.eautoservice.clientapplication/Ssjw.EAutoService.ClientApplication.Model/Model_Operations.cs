namespace Ssjw.EAutoService.ClientApplication.Model
{
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ClientApplication.Model.Service;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using System.Runtime.CompilerServices;

    public partial class Model : IOperations
    {


        public void LoadInspectionsByVinList()
        {
            this.LoadInspectionsByVinTask();
        }

        public void LoadRepairsByVinList()
        {
            this.LoadRepairsByVinTask();
        }

        public void LoadCarsByIdCardNumber()
        {
            this.LoadCarsByIdCardNumberTask();
        }

        public void LoadMechanicsByDate()
        {
            this.LoadMechanicsByDateTask();
        }

        public void SaveRequestService()
        {
            this.SaveRequestServiceTask();
        }

        public void SaveNewClient()
        {
            this.SaveNewClientTask();
        }

        public void LoadBodyPartsList()
        {
            this.LoadBodyPartsListTask();
        }

        public void LoadBodyPartsByPrice()
        {
            this.LoadBodyPartsByPriceTask();
        }

        public void LoadMechanicalPartsByPrice()
        {
            this.LoadMechanicalPartsByPriceTask();
        }

        public void LoadLiquidsByPrice()
        {
            this.LoadLiquidsByPriceTask();
        }

        public void LoadLiquidsByCategory()
        {
            this.LoadLiquidsByCategoryTask();
        }



        public void LoadMechanicalPartsByCategory()
        {
            this.LoadMechanicalPartsByCategoryTask();
        }


        public void PurchaseCarPart()
        {
            this.PurchaseCarPartTask();
        }


        public void LoadBodyPartsByBodyType()
        {
            this.LoadBodyPartsByBodyTypeTask();
        }

        public void LoadMechanicalPartsList()
        {
            this.LoadMechanicalPartsListTask();
        }

        public void LoadLiquidsList()
        {
            this.LoadLiquidsListTask();
        }

        public void SaveNewCar()
        {
            this.SaveNewCarTask();
        }

        public void LoadPersonalData()
        {
            this.LoadPersonalDataTask();
        }

        public void SaveChangedPersonalData()
        {
            SaveChangedPersonalDataTask();
        }

        public void LoadLiquidsListTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.liquidsList = appSvcClient.GetAllLiquids();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadBodyPartsListTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.BodyPartsList = appSvcClient.GetAllBodyParts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadBodyPartsByPriceTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.BodyPartsList = appSvcClient.FindBodyPartByPrice(this.MinPrice, this.MaxPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadMechanicalPartsByPriceTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.MechanicalPartsList = appSvcClient.FindMechanicalPartByPrice(this.MinPrice, this.MaxPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void LoadLiquidsByPriceTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.LiquidsList = appSvcClient.FindLiquidByPrice(this.MinPrice, this.MaxPrice);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadLiquidsByCategoryTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.LiquidsList = appSvcClient.FindLiquidByCategory(this.searchText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void LoadMechanicalPartsByCategoryTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.MechanicalPartsList = appSvcClient.FindMechanicalPartByCategory(this.SearchText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }




        public void PurchaseCarPartTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                if (this.SelectedBodyPart != null)
                {
                    appSvcClient.PurchaseCarPart(this.SelectedBodyPart.id);
                }
                else if (this.SelectedMechanicalPart != null)
                {
                    appSvcClient.PurchaseCarPart(this.SelectedMechanicalPart.id);
                }
                else if (this.SelectedLiquid != null)
                {
                    appSvcClient.PurchaseCarPart(this.SelectedLiquid.id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadBodyPartsByBodyTypeTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.BodyPartsList = appSvcClient.FindBodyPartByBodyType(this.SearchText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadMechanicalPartsListTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.mechanicalPartsList = appSvcClient.GetAllMechanicalParts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadInspectionsByVinTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                List<ExtendedInspectionDto> inspections = appSvcClient.GetCarInspectionHistory(this.SelectedCar.vin);

                this.InspectionsList = inspections;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadCarsByIdCardNumberTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                List<ExtendedCarDto> cars = appSvcClient.GetAllClientCar(this.IdCardNumber);

                this.ExtendedCarList = cars;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadRepairsByVinTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                List<ExtendedRepairDto> repairs = appSvcClient.GetCarRepairHistory(this.selectedCar.vin);

                this.repairsList = repairs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadMechanicsByDateTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                List<ExtendedEmployeeDto> mechanics = appSvcClient.GetAvailableMechanics(this.SelectedDate);

                this.availableMechanics = mechanics;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveRequestServiceTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                if (this.SelectedServiceType == "Inspection")
                {
                    ExtendedInspectionDto inspectionDto = new ExtendedInspectionDto() { price = -1, comment = "", inspectionExpirationDate = new DateTime(), testsPassed = false, employeeId = this.SelectedMechanic.id, dateOfService = this.selectedDate, vinNumber = this.selectedCar.vin, id = "" };

                    appSvcClient.RequestNewInspection(inspectionDto);
                }
                else if (this.SelectedServiceType == "Repair")
                {
                    ExtendedRepairDto repairDto = new ExtendedRepairDto() { employeeId = this.SelectedMechanic.id, dateOfService = this.selectedDate, vinNumber = this.selectedCar.vin, repairedParts = new List<ExtendedRepairedPartDto>(), id = "", price = -1 };

                    appSvcClient.RequestNewRepair(repairDto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveNewClientTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.NewClient.vinNumbers = new List<string>();
                appSvcClient.AddNewClient(this.newClient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveNewCarTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.NewCar.servicesHistoryInspections = new List<string>();
                this.NewCar.servicesHistoryRepairs = new List<string>();

                appSvcClient.AddCar(this.NewCar, this.IdCardNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadPersonalDataTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                this.LoggedClient = appSvcClient.GetPersonalInformation(this.IdCardNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SaveChangedPersonalDataTask()
        {
            IClientAppSvc appSvcClient = AppSvcClientFactory.GetAppSvcClient(debug);

            try
            {
                appSvcClient.ModifyPersonalData(this.IdCardNumber, changedClient.idCardNumber, changedClient.name, changedClient.surname, changedClient.phoneNumber, changedClient.vinNumbers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
