namespace Ssjw.EAutoService.CarPartsDataUSvc.RestClient
{
    using Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services;
    public class CarPartsDataUSvcClientFactory
    {
        public static ICarPartsDataUSvcClient GetCarPartsDataUSvcClient(bool Debug)
        {
            Debug = false;

            if (Debug)
            {
                return new CarPartsDataUSvcMockClient();
            }
            else
            {
                return new CarPartsDataUSvcClient();
            }
        }
    }
}
