namespace Ssjw.EAutoService.ClientApplication.Tests;

using Ssjw.EAutoService.ClientApplication.Model;
using Ssjw.EAutoService.ClientApplication.Utilities;
using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Model;

[TestClass]
public class ModellTest
{
    [TestMethod]
    public void LoadCarsByIdCarNumber_ThereIsOnlyOneCarMatched()
    {
        IModel model = new Model(new EmptyEventDispatcher());

        Model.debug = true;

        string idCardNumber = "test1";

        model.IdCardNumber = idCardNumber;

        model.LoadCarsByIdCardNumber();

        int expectedCount = 1;

        int actualCount = model.ExtendedCarList.Count;

        Assert.AreEqual(expectedCount, actualCount, "Node count should be {0} and not {1}", expectedCount, actualCount);
    }

    [TestMethod]
    public void LoadCarsByIdCarNumber_ThereIsOnlyOneVolvo_ThereIsOnlyOneModelOfThisBrand()
    {
        IModel model = new Model(new EmptyEventDispatcher());

        Model.debug = true;

        model.IdCardNumber = "test2";
        model.LoadCarsByIdCardNumber();

        foreach (ExtendedCarDto car in model.ExtendedCarList)
        {
            if (car.brand == "volvo")
                model.SelectedCar = car;
        }

        string expectedModel = "s60";
        string actualModel = model.SelectedCar.model;


        Assert.AreEqual(expectedModel, actualModel, "Model should be {0} and not {1}", expectedModel, actualModel);
    }
}