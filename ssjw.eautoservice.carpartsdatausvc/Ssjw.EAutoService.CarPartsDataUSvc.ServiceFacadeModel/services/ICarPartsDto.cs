namespace Ssjw.EAutoService.CarPartsDataUSvc.ServiceFacadeModel.Services
{
    public interface ICarPartsDto
    {
        void RemoveCarPart(string id);
        void DeleteCarPart(string id);
        void ChangeNumberOfAvailableParts(string id, int number);
        int GetNumberOfAvailableParts(string id);
    }
}
