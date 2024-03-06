namespace Ssjw.EAutoService.MechanicApplication.Model
{
    using Ssjw.EAutoService.MechanicApplication.Utilities;

    public partial class Model : PropertyContainerBase, IModel
    {
        public static bool debug;

        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {

        }
    }
}