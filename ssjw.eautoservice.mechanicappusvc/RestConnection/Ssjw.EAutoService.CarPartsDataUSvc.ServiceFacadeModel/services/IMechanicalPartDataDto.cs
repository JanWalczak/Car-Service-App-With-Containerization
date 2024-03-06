namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public interface IMechanicalPartDataDto
    {
        public List<MechanicalPartDto> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ);
        public List<MechanicalPartDto> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice);
        public List<MechanicalPartDto> FindMechanicalPartByCategory(string category);
        public List<MechanicalPartDto> GetAllMechanicalParts();
        public List<MechanicalPartDto> GetAvailableAndUnavailableMechanicalParts();
        public MechanicalPartDto GetMechanicalPartById(string id);
        public void AddMechanicalPart(MechanicalPartDto mechanicalPartDto);
    }
}
