namespace Ssjw.EAutoService.ClientApplication.Model.Service
{
    using Ssjw.EAutoService.ClientAppUSvc.ServiceFacadeModel.Services;
    using Ssjw.EAutoService.ClientAppUSvc.RestClient;

    public static class AppSvcClientFactory 
    {

        public static IClientAppSvc GetAppSvcClient(bool debug)
        {
			//debug = false;  
			//debug = true;  

			if (debug)
            {
                return new ClientAppUSvcMockClient();
            }
            else
            {
                return new ClientAppUSvcClient();
            }
        }
    }
}
