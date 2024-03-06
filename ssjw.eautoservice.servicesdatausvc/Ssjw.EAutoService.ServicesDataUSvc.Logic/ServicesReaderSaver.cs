namespace Ssjw.EAutoService.ServicesDataUSvc.Logic
{
    using Ssjw.EAutoService.ServicesDataUSvc.Model.Model;
    using System.Text.Json;

    public class ServicesReaderSaver
    {
        public ServicesReaderSaver()
        {
        }

        private static string inspectionsDataFileName = "StartupInspectionsData.json";
        private static string repairsDataFileName = "StartupRepairsData.json";

        public static void SaveInspectionsData()
        {
            File.WriteAllText(inspectionsDataFileName, JsonSerializer.Serialize(ServicesData.Inspections));
        }

        public static List<Inspection> ReadInspectionsFromFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            try
            {
                return JsonSerializer.Deserialize<List<Inspection>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static void SaveRepairsData()
        {
            File.WriteAllText(repairsDataFileName, JsonSerializer.Serialize(ServicesData.Repairs));
        }

        public static List<Repair> ReadRepairsFromFile(string fileName)
        {
            string jsonString = File.ReadAllText(fileName);
            try
            {
                return JsonSerializer.Deserialize<List<Repair>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
