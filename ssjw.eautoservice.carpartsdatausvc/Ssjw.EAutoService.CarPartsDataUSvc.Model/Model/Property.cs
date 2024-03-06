namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public class Property
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Property(string key, string description)
        {
            this.Name = key;
            this.Description = description;
        }

        public Property()
        { }

        public override string? ToString()
        {
            return Name + ":" + Description;
        }
    }
}
