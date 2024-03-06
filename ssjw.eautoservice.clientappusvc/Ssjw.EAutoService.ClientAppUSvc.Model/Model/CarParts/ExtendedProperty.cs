namespace Ssjw.EAutoService.ClientAppUSvc.Model.Model.CarParts
{
    public class ExtendedProperty
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ExtendedProperty(string key, string description)
        {
            this.Name = key;
            this.Description = description;
        }
        public ExtendedProperty()
        { }
        public override string? ToString()
        {
            return Name + ":" + Description;
        }
    }
}
