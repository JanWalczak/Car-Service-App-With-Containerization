namespace Ssjw.EAutoService.ClientApplication.Utilities
{
    using System;

    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}
