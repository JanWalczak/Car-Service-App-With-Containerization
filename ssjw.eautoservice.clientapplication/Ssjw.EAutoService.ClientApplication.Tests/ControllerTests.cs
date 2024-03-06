namespace Ssjw.EAutoService.ClientApplication.Tests;

using Ssjw.EAutoService.ClientApplication.Controller;
using Ssjw.EAutoService.ClientApplication.Model;
using Ssjw.EAutoService.ClientApplication.Utilities;
using Ssjw.EAutoService.ClientAppUSvc.RestClient;
using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;

[TestClass]
public class ControllerTests
{

    [TestMethod]
    public void LoadCarsByIdCardNumber_SearchInspectionBySelectedCar_ThereIsTwoInspectionMatched()
    {

        IModel model = new Model(new EmptyEventDispatcher());

        Model.debug = true;

        Controller controller = new Controller(new EmptyEventDispatcher(), model);

        controller.Model.IdCardNumber = "test1";
        controller.Model.LoadCarsByIdCardNumber();

        controller.Model.SelectedCar = controller.Model.ExtendedCarList.First();

        controller.SearchInspectionsAsync();

        Thread.Sleep(2000);

        int expectedInspectionCount = 2;
        int actualInspectionCount = controller.Model.InspectionsList.Count();

        Assert.AreEqual(expectedInspectionCount, actualInspectionCount, "Inspection count should be {0} and not {1}", expectedInspectionCount, actualInspectionCount);
    }
}