namespace Ssjw.EAutoService.ClientApplication.Model
{

    using Ssjw.EAutoService.ClientApplication.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public static bool debug;

        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
            
        }
    }
}
