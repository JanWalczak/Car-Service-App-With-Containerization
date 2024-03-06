namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Model;

    public interface IBodyPartDataDto
    {
        public List<BodyPartDto> FindBodyPartByBodyType(string bodyType);
        public List<BodyPartDto> FindBodyPartByPrice(decimal minPrice, decimal maxPrice);
        public List<BodyPartDto> FindBodyPartByMaterial(string material);
        public List<BodyPartDto> GetAllBodyParts();
        public List<BodyPartDto> GetAvailableAndUnavailableBodyParts();
        public BodyPartDto GetBodyPartById(string id);
        public void AddBodyPart(BodyPartDto bodyPartDto);
    }
}
