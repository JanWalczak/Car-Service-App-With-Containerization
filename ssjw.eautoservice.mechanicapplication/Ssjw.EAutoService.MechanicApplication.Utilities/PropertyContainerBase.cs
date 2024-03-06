namespace Ssjw.EAutoService.MechanicApplication.Utilities
{
    using System.ComponentModel;

    public class PropertyContainerBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly IEventDispatcher dispatcher;

        protected PropertyContainerBase(IEventDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;

            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                Action action = () => handler(this, args);

                this.dispatcher.Dispatch(action);
            }
        }
    }
}