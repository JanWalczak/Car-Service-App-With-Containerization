namespace Ssjw.EAutoService.CarPartsDataUSvc.RestClient.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services;

    public interface ICarPartsDataUSvcClient : IBodyPartDataDto, ILiquidDataDto, IMechanicalPartDataDto, ICarPartsDto
    {
    }
}