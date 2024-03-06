namespace Ssjw.EAutoService.MechanicApplication.Model.Service
{
    using Ssjw.EAutoService.MechanicAppUSvc.RestClient;
    using Ssjw.EAutoService.MechanicAppUSvc.ServiceFacadeModel.Services;

    public static class AppSvcMechanicFactory
    {
        public static IMechanicAppDto GetAppSvcClient(bool debug)
        {
            if (debug)
            {
                return new MechanicAppUSvcMockClient();
            }
            else
            {
                return new MechanicAppUSvcClient();
            }
        }
    }
}