namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public interface ILiquidsData
    {
        public List<Liquid> FindLiquidByCategory(string category);
        public List<Liquid> FindLiquidByPrice(decimal minPrice, decimal maxPrice);
        public List<Liquid> FindLiquidByDensity(int density);
        public List<Liquid> GetAllLiquids();
        public List<Liquid> GetAvailableAndUnavailableLiquids();
        public Liquid GetLiquidById(string id);
        public void AddLiquid(Liquid liquid);
    }
}
