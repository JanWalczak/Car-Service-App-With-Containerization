namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public class MechanicalPart : Object
    {
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }
        public string Description { get; set; }
        public int Counter { get; set; }
        public OtherProperties OtherProperties { get; set; }

        public MechanicalPart(string id, string category, decimal price, double sizeX, double sizeY, double sizeZ, string description, int counter) : base(id)
        {
            this.Category = category;
            this.Price = price;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.SizeZ = sizeZ;
            this.Description = description;
            this.Counter = counter;
        }

        public MechanicalPart(string id, string category, decimal price, double sizeX, double sizeY, double sizeZ, string description, int counter, OtherProperties otherProperties) : this(id, category, price, sizeX, sizeY, sizeZ, description, counter)
        {
            this.OtherProperties = otherProperties;
        }

        public MechanicalPart(string id) : base(id)
        { }

        public MechanicalPart()
        { }

        public override bool Equals(object? obj)
        {
            return obj is MechanicalPart mechanicalPart &&
                   Id == mechanicalPart.Id &&
                   Category == mechanicalPart.Category &&
                   Price == mechanicalPart.Price &&
                   SizeX == mechanicalPart.SizeX &&
                   SizeY == mechanicalPart.SizeY &&
                   SizeZ == mechanicalPart.SizeZ &&
                   Description == mechanicalPart.Description &&
                   EqualityComparer<OtherProperties>.Default.Equals(OtherProperties, mechanicalPart.OtherProperties);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Id + " : " + Category + " : " + Price + " : " + SizeX + " : " + SizeY + " : " + SizeZ + " : " + Description + " : " + Counter + " : " + OtherProperties;
        }
    }
}