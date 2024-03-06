namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public interface IMechanicalPartsData
    {
        public List<MechanicalPart> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ);
        public List<MechanicalPart> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice);
        public List<MechanicalPart> FindMechanicalPartByCategory(string category);
        public List<MechanicalPart> GetAllMechanicalParts();
        public List<MechanicalPart> GetAvailableAndUnavailableMechanicalParts();
        public MechanicalPart GetMechanicalPartById(string id);
        public void AddMechanicalPart(MechanicalPart mechanicalPart);
    }
}
