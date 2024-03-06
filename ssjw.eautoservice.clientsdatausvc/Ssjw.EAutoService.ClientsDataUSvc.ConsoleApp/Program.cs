namespace Ssjw.EAutoService.ClientsDataUSvc.ConsoleApp
{
    using Ssjw.EAutoService.ClientsDataUSvc.RestClient;
    using Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            ClientDataUSvcClient clientDataUSvcClient = new ClientDataUSvcClient();

            Console.WriteLine("ClientDataUSvcClient");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcClient.GetAllClients();

            Console.WriteLine("\nAdding client");
            clientDataUSvcClient.AddClientToData(new ClientDto
            {
                Name = "Mariusz",
                Surname = "Poniatowski",
                PhoneNumber = "082385319",
                IdCardNumber = "test4",
                VinNumbers = new List<string> { "012837465" }
            });

            Console.WriteLine("\nGetting client's name and surname by id card number");
            clientDataUSvcClient.GetClientsNameSurname("test1");

            Console.WriteLine("\nGetting client's surname and phone number by id card number");
            clientDataUSvcClient.GetClientsSurnamePhoneNumber("test2");

            Console.WriteLine("\nSearching client by id card number");
            clientDataUSvcClient.FindClientByIdCard("test3");

            Console.WriteLine("\nAdding car to client test4");
            clientDataUSvcClient.AddCarToClient("test4", "1234567890");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcClient.GetAllClients();

            Console.WriteLine("\nGetting all id card numbers");
            clientDataUSvcClient.GetAllIds();

            Console.WriteLine("\nRemoving client by id card number");
            clientDataUSvcClient.RemoveClientFromData("test4");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcClient.GetAllClients();



            ClientDataUSvcMockClient clientDataUSvcMockClient = new ClientDataUSvcMockClient();

            Console.WriteLine("\n\n-------------------------------------------------------------------------------------------------" +
                "\nClientDataUSvcMockClient");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcMockClient.GetAllClients();

            Console.WriteLine("\nGetting all id card numbers");
            clientDataUSvcMockClient.GetAllIds();

            Console.WriteLine("\nAdding client");
            clientDataUSvcMockClient.AddClientToData(new ClientDto
            {
                Name = "Mariusz",
                Surname = "Poniatowski",
                PhoneNumber = "082385319",
                IdCardNumber = "test4",
                VinNumbers = new List<string> { "012837465" }
            });

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcMockClient.GetAllClients();

            Console.WriteLine("\nSearching client by id card number");
            clientDataUSvcMockClient.FindClientByIdCard("test2");

            Console.WriteLine("\nAdding car to client test4");
            clientDataUSvcMockClient.AddCarToClient("test4", "1234567890");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcMockClient.GetAllClients();

            Console.WriteLine("\nGetting client's name and surname by id card number");
            clientDataUSvcMockClient.GetClientsNameSurname("test1");

            Console.WriteLine("\nGetting client's surname and phone number by id card number");
            clientDataUSvcMockClient.GetClientsSurnamePhoneNumber("test3");

            Console.WriteLine("\nRemoving client by id card number");
            clientDataUSvcMockClient.RemoveClientFromData("test4");

            Console.WriteLine("\nPrinting all clients");
            clientDataUSvcMockClient.GetAllClients();
        }
    }
}