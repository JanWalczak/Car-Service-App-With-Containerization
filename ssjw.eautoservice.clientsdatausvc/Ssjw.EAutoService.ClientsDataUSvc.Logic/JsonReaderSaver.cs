namespace Ssjw.EAutoService.ClientsDataUSvc.Logic
{
    using System.Text.Json;
    using Ssjw.EAutoService.ClientsDataUSvc.Model.Model;

    public class JsonReaderSaver
    {
        public JsonReaderSaver()
        {
        }

        private static string clientDataFileName = "StartupData.json";

        public static void SaveClientData()
        {
            File.WriteAllText(clientDataFileName, JsonSerializer.Serialize(ClientData.Clients));
        }

        public static List<Client> ReadClientsFromFile(string fileName)
        {
            return JsonSerializer.Deserialize<List<Client>>(File.ReadAllText(clientDataFileName));
        }
    }
}