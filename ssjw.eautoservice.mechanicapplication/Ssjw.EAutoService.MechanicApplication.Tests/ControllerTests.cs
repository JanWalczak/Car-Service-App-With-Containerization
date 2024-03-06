namespace Ssjw.EAutoService.MechanicApplication.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ssjw.EAutoService.MechanicApplication.Controller;
using Ssjw.EAutoService.MechanicApplication.Model;
using Ssjw.EAutoService.MechanicApplication.Utilities;
using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Model;

[TestClass]
public class ControllerTests
{
    [TestMethod]
    public void GetPersonalCars_ThereAreThreeMatchingCars()
    {
        Model.debug = true;
        IModel model = new Model(new EmptyEventDispatcher());
        Controller controller = new Controller(new EmptyEventDispatcher(), model);
        string searchText = "2";

        model.EmployeeId = searchText;

        controller.Model.GetPersonalCars();

        int expectedCount = 3;

        int actualCount = model.CarsList.Count;

        Assert.AreEqual(expectedCount, actualCount, "Cars count should be {0} and not {1}", expectedCount, actualCount);
    }

    [TestMethod]
    public void LoadCarsHistory_ThereShouldBeOneRepairAndTwoInspections()
    {
        Model.debug = true;
        IModel model = new Model(new EmptyEventDispatcher());
        Controller controller = new Controller(new EmptyEventDispatcher(), model);
        ExtendedCarDto selectedCar = new ExtendedCarDto()
        {
            vin = "41414154",
            model = "astra",
            brand = "opel",
            productionYear = new DateTime(2005, 12, 12),
            insurenceNumber = "145716",
            servicesHistoryInspections = new List<string> { "i1" },
            servicesHistoryRepairs = new List<string> { "r1" }
        };

        model.SelectedCar = selectedCar;

        controller.Model.LoadCarsHistory();

        int expectedInspectionCount = 2;
        int expectedRepairCount = 1;

        int actualInspectionCount = model.InspectionsList.Count;
        int actualRepairCount = model.RepairsList.Count;

        Assert.AreEqual(expectedInspectionCount, actualInspectionCount, "Inspections count should be {0} and not {1}",
            expectedInspectionCount, actualInspectionCount);
        Assert.AreEqual(expectedRepairCount, actualRepairCount, "Repairs count should be {0} and not {1}",
            expectedRepairCount, actualRepairCount);
    }

    [TestMethod]
    public void LoadPersonalSchedule_ThereShouldBeOneRepairAndTwoInspections()
    {
        Model.debug = true;
        IModel model = new Model(new EmptyEventDispatcher());
        Controller controller = new Controller(new EmptyEventDispatcher(), model);
        string searchText = "2";

        model.EmployeeId = searchText;

        controller.Model.LoadPersonalSchedule();

        int expectedInspectionCount = 2;
        int expectedRepairCount = 1;

        int actualInspectionCount = model.InspectionsList.Count;
        int actualRepairCount = model.RepairsList.Count;

        Assert.AreEqual(expectedInspectionCount, actualInspectionCount, "Inspections count should be {0} and not {1}",
            expectedInspectionCount, actualInspectionCount);
        Assert.AreEqual(expectedRepairCount, actualRepairCount, "Repairs count should be {0} and not {1}",
            expectedRepairCount, actualRepairCount);
    }

    [TestMethod]
    public void FindBodyPartByMaterialTask_ThereShouldBeTwoBodyParts()
    {
        Model.debug = true;
        IModel model = new Model(new EmptyEventDispatcher());
        Controller controller = new Controller(new EmptyEventDispatcher(), model);
        string searchText = "steel";

        model.Material = searchText;

        controller.Model.LoadAllBodyParts();
        controller.Model.FindBodyPartByMaterial();

        int expectedBodyPartCount = 2;

        int acturalBodyPartCount = model.BodyPartList.Count;

        Assert.AreEqual(expectedBodyPartCount, acturalBodyPartCount, "Body Parts count should be {0} and not {1}",
            expectedBodyPartCount, acturalBodyPartCount);
    }

    [TestMethod]
    public void FindLiquidByCategoryTask_ThereShouldBeTwoLiquids()
    {
        Model.debug = true;
        IModel model = new Model(new EmptyEventDispatcher());
        Controller controller = new Controller(new EmptyEventDispatcher(), model);
        string searchText = "Fuel";

        model.Category = searchText;

        controller.Model.FindLiquidByCategory();

        int expectedLiquidCount = 2;

        int acturalLiquidCount = model.LiquidList.Count;

        Assert.AreEqual(expectedLiquidCount, acturalLiquidCount, "Liquids count should be {0} and not {1}",
            expectedLiquidCount, acturalLiquidCount);
    }
}