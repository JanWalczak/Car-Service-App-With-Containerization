namespace Ssjw.EAutoService.CarsDataUSvc.Logic
{
    using Ssjw.EAutoService.CarsDataUSvc.Model.Model;
    using System.Collections.Generic;
    using System.Text.Json;

    public class CarsDataReaderSaver
    {
        public static string carsFileName = "Cars.json";

        public void ReadFiles()
        {
            CarsData.cars = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(carsFileName));
        }

        public void WriteFiles()
        {
            File.WriteAllText(carsFileName, JsonSerializer.Serialize(CarsData.cars));
        }
    }
}
