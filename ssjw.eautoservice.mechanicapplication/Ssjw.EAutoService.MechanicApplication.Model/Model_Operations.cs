namespace Ssjw.EAutoService.MechanicApplication.Model
{
    using Ssjw.EAutoService.MechanicApplication.Model.Service;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;

    public partial class Model : IOperations
    {
        public void GetPersonalCars()
        {
            this.GetPersonalCarsTask();
        }

        public void LoadPersonalSchedule()
        {
            this.LoadPersonalScheduleTask();
        }

        public void SignIn()
        {
            this.SignInTask();
        }

        public void LoadCarsHistory()
        {
            this.LoadCarsHistoryTask();
        }

        public void FinishInspection()
        {
            this.FinishInspectionTask();
        }

        public void FinishRepair()
        {
            this.FinishRepairTask();
        }

        public void AddRepairedPart()
        {
            this.AddRepairedPartTask();
        }

        public void LoadRepairedParts()
        {
            this.LoadRepairedPartsTask();
        }

        public void LoadAllBodyParts()
        {
            this.LoadAllBodyPartsTask();
        }

        public void UseCarPart()
        {
            this.UseCarPartTask();
        }

        public void FindBodyPartByMaterial()
        {
            this.FindBodyPartByMaterialTask();
        }

        public void FindBodyPartByBodyType()
        {
            this.FindBodyPartByBodyTypeTask();
        }

        public void LoadAllMechanicalParts()
        {
            this.LoadAllMechanicalPartsTask();
        }

        public void FindMechanicalPartByDimensions()
        {
            this.FindMechanicalPartByDimensionsTask();
        }

        public void FindMechanicalPartByCategory()
        {
            this.FindMechanicalPartByCategoryTask();
        }

        public void LoadAllLiquids()
        {
            this.LoadAllLiquidsTask();
        }

        public void FindLiquidByDensity()
        {
            this.FindLiquidByDensityTask();
        }

        public void FindLiquidByCategory()
        {
            this.FindLiquidByCategoryTask();
        }

        public void LoadAllClients()
        {
            this.LoadAllClientsTask();
        }

        private IMechanicAppDto appSvcMechanic = AppSvcMechanicFactory.GetAppSvcClient(debug);

        private void GetPersonalCarsTask()
        {
            try
            {
                List<ExtendedCarDto> cars = appSvcMechanic.GetPersonalCars(this.EmployeeId);

                bool isNull = cars == null;
                if (!isNull)
                {
                    this.CarsList = cars;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SignInTask()
        {
            this.EmployeeId = employeeId;

            bool isNull = EmployeeId == null;

            if (!isNull)
            {
                this.GetPersonalCarsTask();
            }
        }

        private void LoadCarsHistoryTask()
        {
            try
            {
                List<ExtendedRepairDto> repairs = appSvcMechanic.GetCarRepairHistory(this.SelectedCar.vin);

                bool isNull = repairs == null;
                if (!isNull)
                {
                    this.repairsList = repairs;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                List<ExtendedInspectionDto> inspections = appSvcMechanic.GetCarInspectionHistory(this.SelectedCar.vin);

                bool isNull = inspections == null;
                if (!isNull)
                {
                    this.inspectionsList = inspections;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadPersonalScheduleTask()
        {
            try
            {
                List<ExtendedRepairDto> repairs = appSvcMechanic.GetPersonalRepairSchedule(this.EmployeeId);

                bool isNull = repairs == null;
                if (!isNull)
                {
                    this.repairsList = repairs;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                List<ExtendedInspectionDto> inspections = appSvcMechanic.GetPersonalInspectionSchedule(this.EmployeeId);

                bool isNull = inspections == null;
                if (!isNull)
                {
                    this.inspectionsList = inspections;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FinishInspectionTask()
        {
            try
            {
                appSvcMechanic.FinishInspection(inspectionId, price, testsPassed, comment);
                LoadPersonalScheduleTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FinishRepairTask()
        {
            try
            {
                appSvcMechanic.FinishRepair(repairId, price, RepairedPartsList);
                LoadPersonalScheduleTask();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadAllBodyPartsTask()
        {
            try
            {
                List<ExtendedBodyPartDto> bodyParts = appSvcMechanic.GetAllBodyParts();

                bool isNull = bodyParts == null;
                if (!isNull)
                {
                    this.BodyPartList = bodyParts;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadAllClientsTask()
        {
            try
            {
                List<ExtendedClientDto> clients = appSvcMechanic.GetAllClients();

                bool isNull = clients == null;
                if (!isNull)
                {
                    ClientList = clients;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadAllMechanicalPartsTask()
        {
            try
            {
                List<ExtendedMechanicalPartDto> mechanicalParts = appSvcMechanic.GetAllMechanicalParts();

                bool isNull = mechanicalParts == null;
                if (!isNull)
                {
                    MechanicalPartList = mechanicalParts;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddRepairedPartTask()
        {
            try
            {
                RepairedPartsList.Add(new ExtendedRepairedPartDto() { carPart = carPartId, causeOfRepair = causeOfRepair });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async void UseCarPartTask()
        {
            try
            {
                appSvcMechanic.UseCarPart(carPartId);

                BodyPartList = appSvcMechanic.GetAllBodyParts();
                MechanicalPartList = appSvcMechanic.GetAllMechanicalParts();
                LiquidList = appSvcMechanic.GetAllLiquids();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadRepairedPartsTask()
        {
            this.RepairedPartsList = repairedPartsList;
        }

        private void FindBodyPartByMaterialTask()
        {
            try
            {
                BodyPartList = appSvcMechanic.FindBodyPartByMaterial(material);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FindBodyPartByBodyTypeTask()
        {
            try
            {
                BodyPartList = appSvcMechanic.FindBodyPartByBodyType(bodyType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FindMechanicalPartByDimensionsTask()
        {
            try
            {
                MechanicalPartList = appSvcMechanic.FindMechanicalPartByDimensions(sizeX, sizeY, sizeZ);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FindMechanicalPartByCategoryTask()
        {
            try
            {
                MechanicalPartList = appSvcMechanic.FindMechanicalPartByCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void LoadAllLiquidsTask()
        {
            try
            {
                List<ExtendedLiquidDto> liquids = appSvcMechanic.GetAllLiquids();

                bool isNull = liquids == null;
                if (!isNull)
                {
                    LiquidList = liquids;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FindLiquidByDensityTask()
        {
            try
            {
                LiquidList = appSvcMechanic.FindLiquidByDensity(density);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void FindLiquidByCategoryTask()
        {
            try
            {
                LiquidList = appSvcMechanic.FindLiquidByCategory(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}