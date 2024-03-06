namespace Ssjw.EAutoService.ClientApplication.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.CarPartsDto;
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model.ServicesDto;

    public interface IData : INotifyPropertyChanged
    {
        string SearchText { get; set; }

        int MinPrice { get; set; }

        int MaxPrice { get; set; }

        string IdCardNumber { get; set; }

        string SelectedServiceType { get; set; }

        DateTime SelectedDate { get; set; }

        ExtendedEmployeeDto SelectedMechanic { get; set; }

        List<ExtendedEmployeeDto> AvailableMechanics { get; }

        List<ExtendedInspectionDto> InspectionsList { get; }

        List<ExtendedCarDto> ExtendedCarList { get; }

        List<ExtendedBodyPartDto> BodyPartsList{ get;  }

        ExtendedBodyPartDto SelectedBodyPart { get; set; }

        ExtendedLiquidDto SelectedLiquid { get; set; }

        ExtendedMechanicalPartDto SelectedMechanicalPart { get; set; }

        List<ExtendedMechanicalPartDto> MechanicalPartsList { get; }

        List<ExtendedLiquidDto> LiquidsList { get; }

        ExtendedCarDto SelectedCar { get; set; }

        ExtendedInspectionDto SelectedInspection { get; set; }

        List<ExtendedRepairDto> RepairsList { get; }

        ExtendedRepairDto SelectedRepair { get; set; }

        ExtendedClientDto NewClient { get; set; }

        ExtendedCarDto NewCar { get; set; }

        ExtendedClientDto ChangedClient { get; set; }

        ExtendedClientDto LoggedClient { get; set; }
    }
}
