namespace Ssjw.EAutoService.ClientsDataUSvc.ServiceFacadeModel.Model
{
    public class ClientDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdCardNumber { get; set; }
        public List<string> VinNumbers { get; set; }
    }
}
