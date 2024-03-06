namespace Ssjw.EAutoService.MechanicApplication.Utilities
{
    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}