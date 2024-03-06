namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public interface ILiquidDataDto
    {
        public List<LiquidDto> FindLiquidByCategory(string category);
        public List<LiquidDto> FindLiquidByPrice(decimal minPrice, decimal maxPrice);
        public List<LiquidDto> FindLiquidByDensity(int density);
        public List<LiquidDto> GetAllLiquids();
        public List<LiquidDto> GetAvailableAndUnavailableLiquids();
        public LiquidDto GetLiquidById(string id);
        public void AddLiquid(LiquidDto liquidDto);
    }
}
