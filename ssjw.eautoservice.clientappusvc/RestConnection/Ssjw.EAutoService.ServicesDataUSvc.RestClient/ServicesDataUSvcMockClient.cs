namespace Ssjw.EAutoService.ServicesDataUSvc.RestClient
{
    using Ssjw.EAutoService.ServicesDataUSvc.RestClient.Services;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.Services;

    public class ServicesDataUSvcMockClient : IServicesDataUSvcClient
    {
        List<RepairDto> repairDtos = new List<RepairDto>();
        List<InspectionDto> inspectionDtos = new List<InspectionDto>();
        private int inspectionsCount = 0;
        private int repairsCount = 0;


        public ServicesDataUSvcMockClient()
        {
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i1",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "1",
                VinNumber = "41414154",
                Price = 1200.5,
                TestsPassed = true,
                InspectionExpirationDate = new DateTime(2028, 01, 13),
                Comment = "Everything is fine"
            });
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i2",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "3",
                VinNumber = "131411414",
                Price = 2300.75,
                TestsPassed = false,
                InspectionExpirationDate = new DateTime(2023, 02, 12),
                Comment = "Worn brakes"
            });
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i3",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "2",
                VinNumber = "11111661",
                Price = 4000.1,
                TestsPassed = false,
                InspectionExpirationDate = new DateTime(2020, 12, 12),
                Comment = "Lights not working"
            });
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i4",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "2",
                VinNumber = "41414154",
                Price = 1000.5,
                TestsPassed = true,
                InspectionExpirationDate = new DateTime(2028, 01, 13),
                Comment = "Everything is fine"
            });
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i5",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "3",
                VinNumber = "11111661",
                Price = 8900.75,
                TestsPassed = false,
                InspectionExpirationDate = new DateTime(2023, 02, 12),
                Comment = "Worn tires"
            });
            inspectionDtos.Add(new InspectionDto
            {
                Id = "i6",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "3",
                VinNumber = "11111661",
                Price = 4000.1,
                TestsPassed = true,
                InspectionExpirationDate = new DateTime(2020, 12, 12),
                Comment = "Everything is fine"
            });

            repairDtos.Add(new RepairDto
            {
                Id = "r1",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "2",
                VinNumber = "41414154",
                Price = 5000,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto{ CarPart = "m0", CauseOfRepair = "Broken" },
                    new RepairedPartDto{ CarPart = "m1", CauseOfRepair = "Other" }}
            });
            repairDtos.Add(new RepairDto
            {
                Id = "r2",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "1",
                VinNumber = "131411414",
                Price = 400,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto{ CarPart = "l1", CauseOfRepair = "Finished" }}
            });
            repairDtos.Add(new RepairDto
            {
                Id = "r3",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "3",
                VinNumber = "11111661",
                Price = 2500,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto { CarPart = "l2", CauseOfRepair = "Too little" },
                    new RepairedPartDto { CarPart = "b9", CauseOfRepair = "Deformed" }}
            });
            repairDtos.Add(new RepairDto
            {
                Id = "r4",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "2",
                VinNumber = "131411414",
                Price = 6500,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto { CarPart = "b2", CauseOfRepair = "Scratched" },
                    new RepairedPartDto { CarPart = "m2", CauseOfRepair = "Broken" }}
            });
            repairDtos.Add(new RepairDto
            {
                Id = "r5",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "2",
                VinNumber = "131411414",
                Price = 10000,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto { CarPart = "b3", CauseOfRepair = "Rusty" }}
            });
            repairDtos.Add(new RepairDto
            {
                Id = "r6",
                DateOfService = new DateTime(2023, 04, 13),
                EmployeeId = "1",
                VinNumber = "11111661",
                Price = 87000,
                RepairedParts = new List<RepairedPartDto> {
                    new RepairedPartDto { CarPart = "l0", CauseOfRepair = "Finished" }}
            });


            bool isEmptyInspections = inspectionDtos.Count() == 0;
            if (!isEmptyInspections)
            {
                inspectionsCount = int.Parse(inspectionDtos.Last().Id.Remove(0, 1));
            }

            bool isEmptyRepairs = repairDtos.Count() == 0;
            if (!isEmptyRepairs)
            {
                repairsCount = int.Parse(repairDtos.Last().Id.Remove(0, 1));
            }
        }

        public void AddInspection(InspectionDto inspectionDto)
        {
            inspectionsCount++;
            inspectionDto.Id = "i" + inspectionsCount;

            inspectionDtos.Add(inspectionDto);
        }

        public void AddRepair(RepairDto repairDto)
        {
            repairsCount++;
            repairDto.Id = "r" + repairsCount;
            repairDtos.Add(repairDto);
        }

        public InspectionDto FindInspectionById(string id)
        {
            foreach (InspectionDto inspection in inspectionDtos)
            {
                if (inspection.Id.Equals(id))
                    return inspection;
            }

            return null;
        }
        public RepairDto FindRepairById(string id)
        {
            foreach (RepairDto repair in repairDtos)
            {
                if (repair.Id.Equals(id))
                    return repair;
            }

            return null;
        }
        public List<InspectionDto> GetAllByPassedFieldInspections(bool passed)
        {
            List<InspectionDto> inspectionsList = new List<InspectionDto>();

            foreach (InspectionDto inspection in inspectionDtos)
            {
                if (inspection.TestsPassed == passed)
                {
                    inspectionsList.Add(inspection);
                    printInspectionDto(inspection);
                }
            }

            return inspectionsList;
        }

        public List<InspectionDto> GetAllInspections()
        {
            foreach (InspectionDto inspection in inspectionDtos)
            {
                printInspectionDto(inspection);
            }

            return inspectionDtos;
        }

        public List<RepairDto> GetAllRepairs()
        {
            foreach (RepairDto repairDto in repairDtos)
            {
                printRepairDto(repairDto);
            }

            return repairDtos;
        }

        public List<InspectionDto> GetInspectionsByVinNumber(string vinNumber)
        {
            List<InspectionDto> inspectionList = new List<InspectionDto>();

            foreach (InspectionDto inspection in inspectionDtos)
            {
                if (inspection.VinNumber == vinNumber)
                {
                    inspectionList.Add(inspection);
                    printInspectionDto(inspection);
                }
            }

            return inspectionList;
        }

        public InspectionDto GetInspectionEmployeeIdVinNumber(string id)
        {
            InspectionDto foundInspection = FindInspectionById(id);

            bool isNull = foundInspection == null;
            if (!isNull)
            {
                InspectionDto returnedInspection = new InspectionDto()
                {
                    EmployeeId = foundInspection.EmployeeId,
                    VinNumber = foundInspection.VinNumber
                };

                printInspectionDto(returnedInspection);

                return returnedInspection;
            }

            return null;
        }

        public List<RepairDto> GetRepairByVinNumber(string vinNumber)
        {
            List<RepairDto> repairList = new List<RepairDto>();

            foreach (RepairDto repair in repairDtos)
            {
                if (repair.VinNumber == vinNumber)
                {
                    repairList.Add(repair);
                    printRepairDto(repair);
                }
            }

            return repairList;
        }

        public List<RepairedPartDto> GetRepairedPartsById(string id)
        {
            List<RepairedPartDto> repairedParts = new List<RepairedPartDto>();

            foreach (RepairDto repair in repairDtos)
            {
                if (repair.Id.Equals(id))
                {
                    repairedParts = repair.RepairedParts;
                }
            }

            foreach (RepairedPartDto repairedPartDto in repairedParts)
            {
                Console.WriteLine("\nCar part: " + repairedPartDto.CarPart + " Cause of repair: " +
                        repairedPartDto.CauseOfRepair);
            }

            return repairedParts;
        }

        public void RemoveInspection(string id)
        {
            InspectionDto removedInspection = new InspectionDto();

            foreach (InspectionDto inspection in inspectionDtos)
            {
                if (inspection.Id.Equals(id))
                    removedInspection = inspection;
            }

            bool isNull = removedInspection.Id == null;
            if (!isNull)
            {
                inspectionDtos.Remove(removedInspection);
            }
        }

        public void RemoveRepair(string id)
        {
            RepairDto removedRepair = new RepairDto();

            foreach (RepairDto repair in repairDtos)
            {
                if (repair.Id.Equals(id))
                    removedRepair = repair;
            }

            bool isNull = removedRepair.Id == null;
            if (!isNull)
            {
                repairDtos.Remove(removedRepair);
            }
        }

        public RepairDto GetRepairEmployeeIdVinNumber(string id)
        {
            RepairDto foundRepair = FindRepairById(id);

            bool isNull = foundRepair == null;
            if (!isNull)
            {
                return new RepairDto { EmployeeId = foundRepair.EmployeeId, VinNumber = foundRepair.VinNumber };
            }

            return null;
        }

        private void printInspectionDto(InspectionDto dto)
        {
            bool isNull = dto == null;
            if (!isNull)
            {
                string inspectionString = "Id: " + dto.Id + " Date of service: " + dto.DateOfService + " Employee id: " +
                    dto.EmployeeId + " Vin number: " + dto.VinNumber + " Price: " + dto.Price + "\nTests passed: " + dto.TestsPassed +
                    " Inspection expiration date: " + dto.InspectionExpirationDate + " Comment: " + dto.Comment;
                Console.WriteLine("\n" + inspectionString);
            }
        }

        private void printRepairDto(RepairDto dto)
        {
            bool isNull = dto == null;
            if (!isNull)
            {
                string repairString = "Id: " + dto.Id + " Date of service: " + dto.DateOfService + " Employee id: " + dto.EmployeeId +
                                    " Vin number: " + dto.VinNumber + " Price: " + dto.Price + " Repaired parts: ";
                foreach (RepairedPartDto repairedPartDto in dto.RepairedParts)
                {
                    repairString = repairString + "\nCar part: " + repairedPartDto.CarPart + " Cause of repair: "
                        + repairedPartDto.CauseOfRepair;
                }
                Console.WriteLine("\n" + repairString);
            }
        }

        public List<string> GetServicesByEmployeeId(string employeeId)
        {
            List<string> servicesIds = new List<string>();

            foreach (InspectionDto inspection in inspectionDtos)
            {
                string inspectionsEmployeeId = inspection.EmployeeId;
                if (inspectionsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(inspection.Id);
                    Console.WriteLine(inspection.Id);
                }
            }

            foreach (RepairDto repair in repairDtos)
            {
                string repairsEmployeeId = repair.EmployeeId;
                if (repairsEmployeeId.Equals(employeeId))
                {
                    servicesIds.Add(repair.Id);
                    Console.WriteLine(repair.Id);
                }
            }

            return servicesIds;
        }

        public void CompleteInspection(string id, double price, bool testsPassed, string comment)
        {
            InspectionDto completedInspection = FindInspectionById(id);

            bool isNull = completedInspection == null;
            if (!isNull)
            {
                completedInspection.Price = price;
                completedInspection.TestsPassed = testsPassed;
                completedInspection.Comment = comment;

                if (testsPassed == true)
                {
                    DateTime inspectionDateOfService = completedInspection.DateOfService;
                    DateTime expirationDate = inspectionDateOfService.AddYears(1);
                    completedInspection.InspectionExpirationDate = expirationDate;
                }
            }
        }

        public void CompleteRepair(string id, double price, List<RepairedPartDto> repairedParts)
        {
            RepairDto completedRepair = FindRepairById(id);

            bool isNull = completedRepair == null;
            if (!isNull)
            {
                completedRepair.Price = price;
                completedRepair.RepairedParts = repairedParts;
            }
        }

        public async Task AddInspectionTask(InspectionDto inspectionDto)
        {
            inspectionsCount++;
            inspectionDto.Id = "i" + inspectionsCount;
            inspectionDtos.Add(inspectionDto);
        }

        public async Task AddRepairTask(RepairDto repairDto)
        {
            repairsCount++;
            repairDto.Id = "r" + repairsCount;
            repairDtos.Add(repairDto);
        }


    }
}
