namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public class OtherProperties
    {
        public List<Property> Properties { get; set; }

        public OtherProperties(List<Property> properties)
        {
            this.Properties = properties;
        }
        public OtherProperties()
        { }

        public override bool Equals(object? obj)
        {
            return obj is OtherProperties properties &&
                   EqualityComparer<List<Property>>.Default.Equals(this.Properties, properties.Properties);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            string toString = "";

            foreach (Property property in Properties)
            {
                toString += property.ToString() + " , ";
            }

            return toString;
        }



    }
}
