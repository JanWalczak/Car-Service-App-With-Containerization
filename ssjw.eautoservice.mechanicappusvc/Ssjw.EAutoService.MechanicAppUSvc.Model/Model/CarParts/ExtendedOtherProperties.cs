namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts
{
    public class ExtendedOtherProperties
    {
        public List<ExtendedProperty> Properties { get; set; }

        public ExtendedOtherProperties()
        {
        }

        public ExtendedOtherProperties(List<ExtendedProperty> properties)
        {
            this.Properties = properties;
        }
        public override bool Equals(object? obj)
        {
            return obj is ExtendedOtherProperties properties &&
                   EqualityComparer<List<ExtendedProperty>>.Default.Equals(this.Properties, properties.Properties);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Properties);
        }

        public override string? ToString()
        {
            string res = "";

            foreach (var attribute in Properties)
            {
                res += attribute.ToString() + " , ";
            }

            return res;
        }
    }
}
