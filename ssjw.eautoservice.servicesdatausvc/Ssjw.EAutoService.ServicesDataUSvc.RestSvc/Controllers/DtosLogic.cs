namespace Ssjw.EAutoService.ServicesDataUSvc.WebSvc.Controllers
{
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Model;
    using Ssjw.EAutoService.ServicesDataUSvc.ServiceFacadeModel.DataTransferObjects;

    public class DtosLogic
    {
        public static List<Inspection> CreateInspectionsFromDto(List<InspectionDto> inspections)
        {
            return inspections.Select(inspection => new Inspection(inspection.Id, inspection.DateOfService, inspection.EmployeeId, inspection.VinNumber, inspection.Price,
                inspection.TestsPassed, inspection.InspectionExpirationDate, inspection.Comment)).ToList();
        }

        public static List<InspectionDto> CreateDtoFromInspections(List<Inspection> inspections)
        {
            List<InspectionDto> inspectionDtos = new List<InspectionDto>();

            for (int i = 0; i < inspections.Count; i++)
            {
                inspectionDtos.Add(new InspectionDto()
                {
                    Id = inspections[i].Id,
                    DateOfService = inspections[i].DateOfService,
                    EmployeeId = inspections[i].EmployeeId,
                    VinNumber = inspections[i].VinNumber,
                    Price = inspections[i].Price,
                    TestsPassed = inspections[i].TestsPassed,
                    InspectionExpirationDate = inspections[i].InspectionExpirationDate,
                    Comment = inspections[i].Comment,
                });
            }

            return inspectionDtos;
        }

        public static Inspection CreateInspectionFromOneDto(InspectionDto inspectionDto)
        {
            bool isNull = inspectionDto == null;
            if (!isNull)
            {
                return new Inspection(inspectionDto.Id, inspectionDto.DateOfService, inspectionDto.EmployeeId, inspectionDto.VinNumber,
                                inspectionDto.Price, inspectionDto.TestsPassed, inspectionDto.InspectionExpirationDate, inspectionDto.Comment);
            }

            return null;
        }

        public static InspectionDto CreateDtoFromOneInspection(Inspection inspection)
        {
            bool isNull = inspection == null;
            if (!isNull)
            {
                return new InspectionDto()
                {
                    Id = inspection.Id,
                    DateOfService = inspection.DateOfService,
                    EmployeeId = inspection.EmployeeId,
                    VinNumber = inspection.VinNumber,
                    Price = inspection.Price,
                    TestsPassed = inspection.TestsPassed,
                    InspectionExpirationDate = inspection.InspectionExpirationDate,
                    Comment = inspection.Comment
                };
            }

            return null;
        }

        public static List<Repair> CreateRepairsFromDto(List<RepairDto> repairs)
        {
            return repairs.Select(repair => new Repair(repair.Id, repair.DateOfService, repair.EmployeeId, repair.VinNumber, repair.Price,
                CreateRepairedPartsFromDto(repair.RepairedParts))).ToList();
        }

        public static List<RepairDto> CreateDtoFromRepairs(List<Repair> repairs)
        {
            List<RepairDto> repairDtos = new List<RepairDto>();

            for (int i = 0; i < repairs.Count; i++)
            {
                repairDtos.Add(new RepairDto()
                {
                    Id = repairs[i].Id,
                    DateOfService = repairs[i].DateOfService,
                    EmployeeId = repairs[i].EmployeeId,
                    VinNumber = repairs[i].VinNumber,
                    Price = repairs[i].Price,
                    RepairedParts = CreateDtoFromRepairedParts(repairs[i].RepairedParts)
                });
            }

            return repairDtos;
        }

        public static Repair CreateRepairFromOneDto(RepairDto repairDto)
        {
            bool isNull = repairDto == null;
            if (!isNull)
            {
                return new Repair(repairDto.Id, repairDto.DateOfService, repairDto.EmployeeId, repairDto.VinNumber, repairDto.Price,
                                CreateRepairedPartsFromDto(repairDto.RepairedParts));
            }

            return null;
        }

        public static RepairDto CreateDtoFromOneRepair(Repair repair)
        {
            bool isNull = repair == null;
            if (!isNull)
            {
                return new RepairDto()
                {
                    Id = repair.Id,
                    DateOfService = repair.DateOfService,
                    EmployeeId = repair.EmployeeId,
                    VinNumber = repair.VinNumber,
                    Price = repair.Price,
                    RepairedParts = CreateDtoFromRepairedParts(repair.RepairedParts)
                };
            }

            return null;
        }

        public static List<RepairedPart> CreateRepairedPartsFromDto(List<RepairedPartDto> repairedPartDtos)
        {
            return repairedPartDtos.Select(list => new RepairedPart(list.CarPart, list.CauseOfRepair)).ToList();
        }

        public static List<RepairedPartDto> CreateDtoFromRepairedParts(List<RepairedPart> repairedParts)
        {
            List<RepairedPartDto> repairedPartDtos = new List<RepairedPartDto>();

            if (repairedParts != null)
            {
                for (int i = 0; i < repairedParts.Count; i++)
                {
                    repairedPartDtos.Add(new RepairedPartDto()
                    {
                        CarPart = repairedParts[i].CarPart,
                        CauseOfRepair = repairedParts[i].CauseOfRepair
                    });
                }
            }
            return repairedPartDtos;
        }

        public static RepairedPart CreateRepairedPartFromOneDto(RepairedPartDto repairedPartDto)
        {
            bool isNull = repairedPartDto == null;
            if (!isNull)
            {
                return new RepairedPart(repairedPartDto.CarPart, repairedPartDto.CauseOfRepair);
            }

            return null;
        }

        public static RepairedPartDto CreateDtoFromOneRepairedPart(RepairedPart repairedPart)
        {
            bool isNull = repairedPart == null;
            if (!isNull)
            {
                return new RepairedPartDto()
                {
                    CarPart = repairedPart.CarPart,
                    CauseOfRepair = repairedPart.CauseOfRepair
                };
            }

            return null;
        }
    }
}
