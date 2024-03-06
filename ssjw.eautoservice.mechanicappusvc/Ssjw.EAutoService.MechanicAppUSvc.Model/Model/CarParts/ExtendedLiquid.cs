namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts
{
    public class ExtendedLiquid
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public int Density { get; set; }
        public bool ContainsPb { get; set; }
        public decimal Price { get; set; }
        public int Counter { get; set; }
        public ExtendedOtherProperties OtherProperties { get; set; }

        public ExtendedLiquid(string id, string category, int density, bool containsPb, decimal price, int counter)
        {
            this.Id = id;
            this.Category = category;
            this.Density = density;
            this.ContainsPb = containsPb;
            this.Price = price;
            this.Counter = counter;
        }

        public ExtendedLiquid(string id, string category, int density, bool containsPb, decimal price, int counter, ExtendedOtherProperties otherProperties) : this(id, category, density, containsPb, price, counter)
        {
            this.OtherProperties = otherProperties;
        }

        public ExtendedLiquid(string id)
        {
            this.Id = id;
        }

        public ExtendedLiquid()
        { }

        public override bool Equals(object? obj)
        {
            return obj is ExtendedLiquid liquid &&
                   Id == liquid.Id &&
                   Category == liquid.Category &&
                   Density == liquid.Density &&
                   ContainsPb == liquid.ContainsPb &&
                   Price == liquid.Price &&
                   EqualityComparer<ExtendedOtherProperties>.Default.Equals(OtherProperties, liquid.OtherProperties);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Id + " : " + Category + " : " + Density + " : " + Density + " : " + ContainsPb + " : " + Counter + " : " + OtherProperties;
        }
    }
}
