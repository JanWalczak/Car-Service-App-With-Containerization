namespace Ssjw.EAutoService.ClientAppUSvc.Model.Model.CarParts
{
    public class ExtendedMechanicalPart
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public double SizeX { get; set; }
        public double SizeY { get; set; }
        public double SizeZ { get; set; }
        public string Description { get; set; }
        public int Counter { get; set; }
        public ExtendedOtherProperties OtherProperties { get; set; }
        public ExtendedMechanicalPart(string id, string category, decimal price, double sizeX, double sizeY, double sizeZ, string description, int counter)
        {
            this.Id = id;
            this.Counter = counter;
            this.Category = category;
            this.Price = price;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.SizeZ = sizeZ;
            this.Description = description;
        }
        public ExtendedMechanicalPart(string id, string category, decimal price, double sizeX, double sizeY, double sizeZ, string description, int counter ,ExtendedOtherProperties otherProperties) : this(id, category, price, sizeX, sizeY, sizeZ, description, counter)
        {
            this.OtherProperties = otherProperties;
        }
        public ExtendedMechanicalPart(string id)
        {
            this.Id = id;
        }
        public ExtendedMechanicalPart()
        { }
        public override bool Equals(object? obj)
        {
            return obj is ExtendedMechanicalPart mechanicalPart &&
                   Id == mechanicalPart.Id &&
                   Category == mechanicalPart.Category &&
                   Price == mechanicalPart.Price &&
                   SizeX == mechanicalPart.SizeX &&
                   SizeY == mechanicalPart.SizeY &&
                   SizeZ == mechanicalPart.SizeZ &&
                   Description == mechanicalPart.Description &&
                   EqualityComparer<ExtendedOtherProperties>.Default.Equals(OtherProperties, mechanicalPart.OtherProperties);
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
