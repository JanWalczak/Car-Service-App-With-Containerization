namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public class Liquid : Object
    {
        public string Category { get; set; }
        public int Density { get; set; }
        public bool ContainsPb { get; set; }
        public decimal Price { get; set; }
        public int Counter { get; set; }
        public OtherProperties OtherProperties { get; set; }

        public Liquid(string id, string category, int density, bool containsPb, decimal price, int counter) : base(id)
        {
            this.Category = category;
            this.Density = density;
            this.ContainsPb = containsPb;
            this.Price = price;
            this.Counter = counter;
        }

        public Liquid(string id, string category, int density, bool containsPb, decimal price, int counter, OtherProperties otherProperties) : this(id, category, density, containsPb, price, counter)
        {
            this.OtherProperties = otherProperties;
        }

        public Liquid(string id) : base(id)
        { }

        public Liquid()
        { }

        public override bool Equals(object? obj)
        {
            return obj is Liquid liquid &&
                   Id == liquid.Id &&
                   Category == liquid.Category &&
                   Density == liquid.Density &&
                   ContainsPb == liquid.ContainsPb &&
                   Price == liquid.Price &&
                   EqualityComparer<OtherProperties>.Default.Equals(OtherProperties, liquid.OtherProperties);
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
