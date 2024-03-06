namespace Ssjw.EAutoService.MechanicApplication.Model
{
    using System.ComponentModel;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model.ServicesDto;

    public interface IData : INotifyPropertyChanged
    {
        string SearchText { get; set; }

        string EmployeeId { get; set; }

        string InspectionId { get; set; }

        string RepairId { get; set; }

        string CarPartId { get; set; }

        string CauseOfRepair { get; set; }

        string Material { get; set; }

        string BodyType { get; set; }

        string Category { get; set; }

        ExtendedBodyPartDto SelectedBodyPart { get; set; }

        ExtendedMechanicalPartDto SelectedMechanicalPart { get; set; }

        List<ExtendedMechanicalPartDto> MechanicalPartList { get; }

        List<ExtendedCarDto> CarsList { get; }

        List<ExtendedBodyPartDto> BodyPartList { get; }

        ExtendedCarDto SelectedCar { get; set; }

        List<ExtendedRepairDto> RepairsList { get; }

        List<ExtendedInspectionDto> InspectionsList { get; }

        List<ExtendedRepairedPartDto> RepairedPartsList { get; }

        ExtendedRepairDto SelectedRepair { get; set; }

        ExtendedInspectionDto SelectedInspection { get; set; }

        ExtendedLiquidDto SelectedLiquid { get; set; }

        ExtendedClientDto SelectedClient { get; set; }

        List<ExtendedClientDto> ClientList { get; }

        List<ExtendedLiquidDto> LiquidList { get; }

        double Price { get; set; }

        bool TestsPassed { get; set; }

        string Comment { get; set; }

        double SizeX { get; set; }

        double SizeY { get; set; }

        double SizeZ { get; set; }

        int Density { get; set; }
    }
}