namespace Ssjw.EAutoService.ServicesDataUSvc.Logic
{
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Model;
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Services;

    public class ServicesData : IInspectionsData, IRepairsData
    {
        private static string inspectionsDataFileName = "StartupInspectionsData.json";
        private static string repairsDataFileName = "StartupRepairsData.json";

        public static List<Inspection> Inspections = new List<Inspection>();
        public static List<Repair> Repairs = new List<Repair>();

        private static int inspectionsCounter = 0;
        private static int repairsCounter = 0;

        static ServicesData()
        {
            Inspections = ServicesReaderSaver.ReadInspectionsFromFile(inspectionsDataFileName);
            Repairs = ServicesReaderSaver.ReadRepairsFromFile(repairsDataFileName);

            bool isEmptyInspections = Inspections.Count() == 0;
            if (!isEmptyInspections)
            {
                inspectionsCounter = int.Parse(Inspections.Last().Id.Remove(0, 1));
            }

            bool isEmptyRepairs = Repairs.Count() == 0;
            if (!isEmptyRepairs)
            {
                repairsCounter = int.Parse(Repairs.Last().Id.Remove(0, 1));
            }
        }

        public void AddInspection(Inspection inspection)
        {
            inspectionsCounter++;
            inspection.Id = "i" + inspectionsCounter;

            Inspections.Add(inspection);
            ServicesReaderSaver.SaveInspectionsData();
        }

        public void AddRepair(Repair repair)
        {
            repairsCounter++;
            repair.Id = "r" + repairsCounter;
            Repairs.Add(repair);
            ServicesReaderSaver.SaveRepairsData();
        }

        public Inspection FindInspectionById(string id)
        {
            foreach (Inspection inspection in Inspections)
            {
                string inspectionsId = inspection.Id;
                if (inspectionsId.Equals(id))
                    return inspection;
            }
            return null;
        }

        public Repair FindRepairById(string id)
        {
            foreach (Repair repair in Repairs)
            {
                string repairsId = repair.Id;
                if (repairsId.Equals(id))
                    return repair;
            }
            return null;
        }

        public List<Inspection> GetAllByPassedFieldInspections(bool passed)
        {
            List<Inspection> passedInspections = new List<Inspection>();
            foreach (Inspection inspection in Inspections)
            {
                bool inspectionTestPassed = inspection.TestsPassed;
                if (inspectionTestPassed)
                    passedInspections.Add(inspection);
            }
            return passedInspections;
        }

        public List<Inspection> GetAllInspections()
        {
            return Inspections;
        }

        public List<Repair> GetAllRepairs()
        {
            return Repairs;
        }

        public List<Inspection> GetInspectionsByVinNumber(string vinNumber)
        {
            List<Inspection> inspectionList = new List<Inspection>();
            foreach (Inspection inspection in Inspections)
            {
                string inspectionsVinNumber = inspection.VinNumber;
                if (inspectionsVinNumber == vinNumber)
                    inspectionList.Add(inspection);
            }
            return inspectionList;
        }

        public Inspection GetInspectionEmployeeIdVinNumber(string id)
        {
            Inspection foundInspection = FindInspectionById(id);

            bool isNull = foundInspection == null;
            if (!isNull)
            {
                return new Inspection() { EmployeeId = foundInspection.EmployeeId, VinNumber = foundInspection.VinNumber };
            }

            return null;
        }

        public List<Repair> GetRepairByVinNumber(string vinNumber)
        {
            List<Repair> repairList = new List<Repair>();
            foreach (Repair repair in Repairs)
            {
                string repairsVinNumber = repair.VinNumber;
                if (repairsVinNumber == vinNumber)
                    repairList.Add(repair);
            }
            return repairList;
        }

        public List<RepairedPart> GetRepairedPartsById(string id)
        {
            List<RepairedPart> repairedParts = new List<RepairedPart>();
            foreach (Repair repair in Repairs)
            {
                string repairsId = repair.Id;
                if (repairsId.Equals(id))
                    repairedParts = repair.RepairedParts;
            }
            return repairedParts;
        }

        public void RemoveInspection(string id)
        {
            Inspection removedInspection = new Inspection();
            foreach (Inspection inspection in Inspections)
            {
                string inspectionsId = inspection.Id;
                if (inspectionsId.Equals(id))
                    removedInspection = inspection;
            }
            Inspections.Remove(removedInspection);
            ServicesReaderSaver.SaveInspectionsData();
        }

        public void RemoveRepair(string id)
        {
            Repair removedRepair = new Repair();
            foreach (Repair repair in Repairs)
            {
                string repairsId = repair.Id;
                if (repairsId.Equals(id))
                    removedRepair = repair;
            }
            Repairs.Remove(removedRepair);
            ServicesReaderSaver.SaveRepairsData();
        }

        public Repair GetRepairEmployeeIdVinNumber(string id)
        {
            Repair foundRepair = FindRepairById(id);

            bool isNull = foundRepair == null;
            if (!isNull)
            {
                return new Repair() { EmployeeId = foundRepair.EmployeeId, VinNumber = foundRepair.VinNumber };
            }

            return null;
        }

        public void CompleteInspection(string id, double price, bool testsPassed, string comment)
        {
            Inspection completedInspection = FindInspectionById(id);

            bool isNull = completedInspection == null;
            if (!isNull)
            {
                completedInspection.Price = price;
                completedInspection.TestsPassed = testsPassed;
                completedInspection.Comment = comment;

                bool passed = testsPassed == true;
                if (passed)
                {
                    DateTime inspectionDateOfService = completedInspection.DateOfService;
                    DateTime expirationDate = inspectionDateOfService.AddYears(1);
                    completedInspection.InspectionExpirationDate = expirationDate;
                }
            }
        }

        public void CompleteRepair(string id, double price, List<RepairedPart> repairedParts)
        {
            Repair completedRepair = FindRepairById(id);

            bool isNull = completedRepair == null;
            if (!isNull)
            {
                completedRepair.Price = price;
                completedRepair.RepairedParts = repairedParts;
            }
        }

        public List<string> GetServicesByEmployeeId(string employeeId)
        {
            List<string> servicesIds = new List<string>();

            foreach (Inspection inspection in Inspections)
            {
                string inspectionsEmployeeId = inspection.EmployeeId;
                if (inspectionsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(inspection.Id);
                }
            }

            foreach (Repair repair in Repairs)
            {
                string repairsEmployeeId = repair.EmployeeId;
                if (repairsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(repair.Id);
                }
            }

            return servicesIds;
        }
    }
}