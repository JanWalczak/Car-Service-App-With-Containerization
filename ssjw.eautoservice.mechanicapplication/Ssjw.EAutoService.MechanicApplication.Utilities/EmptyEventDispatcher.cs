namespace Ssjw.EAutoService.MechanicApplication.Utilities
{
    public class EmptyEventDispatcher : IEventDispatcher
    {
        public void Dispatch(Action eventAction)
        {
        }
    }
}