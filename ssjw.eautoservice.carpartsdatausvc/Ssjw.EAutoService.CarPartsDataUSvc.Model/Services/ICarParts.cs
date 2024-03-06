namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Services
{

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface ICarParts
    {
        void RemoveCarPart(string id);
        void DeleteCarPart(string id);
        void ChangeNumberOfAvailableParts(string id, int number);
        int GetNumberOfAvailableParts(string id);
    }
}
