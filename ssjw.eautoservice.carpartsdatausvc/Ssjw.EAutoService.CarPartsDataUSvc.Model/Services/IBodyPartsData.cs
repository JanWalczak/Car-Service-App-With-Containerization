namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Services
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IBodyPartsData
    {
        public List<BodyPart> FindBodyPartByBodyType(string bodyType);
        public List<BodyPart> FindBodyPartByPrice(decimal minPrice, decimal maxPrice);
        public List<BodyPart> FindBodyPartByMaterial(string material);
        public List<BodyPart> GetAllBodyParts();
        public List<BodyPart> GetAvailableAndUnavailableBodyParts();
        public BodyPart GetBodyPartById(string id);
        public void AddBodyPart(BodyPart bodyPart);
    }
}
