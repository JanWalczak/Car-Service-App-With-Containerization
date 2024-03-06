namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public abstract class Object
    {
        public string Id { get; set; }

        public Object(string id)
        {
            this.Id = id;
        }

        public Object()
        { }
    }
}
