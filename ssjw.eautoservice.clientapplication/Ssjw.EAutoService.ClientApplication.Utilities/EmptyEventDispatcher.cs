namespace Ssjw.EAutoService.ClientApplication.Utilities
{
    public class EmptyEventDispatcher : IEventDispatcher
    {
        public void Dispatch(Action eventAction)
        {
        }
    }
}
