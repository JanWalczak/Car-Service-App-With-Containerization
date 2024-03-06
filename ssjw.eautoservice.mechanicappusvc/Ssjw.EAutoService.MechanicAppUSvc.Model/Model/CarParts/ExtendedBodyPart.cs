namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model.CarParts
{
    public class ExtendedBodyPart
    {
        public string Id { get; set; }
        public string BodyType { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public int Counter { get; set; }
        public ExtendedOtherProperties OtherProperties { get; set; }

        public ExtendedBodyPart(string id, string bodyType, string material, decimal price, string colour, int counter)
        {
            this.Id = id;
            this.BodyType = bodyType;
            this.Material = material;
            this.Price = price;
            this.Colour = colour;
            this.Counter = counter;
        }

        public ExtendedBodyPart(string id, string bodyType, string material, decimal price, string colour, int counter, ExtendedOtherProperties otherProperties) : this(id, bodyType, material, price, colour, counter)
        {
            this.OtherProperties = otherProperties;
        }

        public ExtendedBodyPart(string id)
        {
            this.Id = id;
        }

        public ExtendedBodyPart()
        { }

        public override bool Equals(object? obj)
        {
            return obj is ExtendedBodyPart bodyPart &&
                   Id == bodyPart.Id &&
                   BodyType == bodyPart.BodyType &&
                   Material == bodyPart.Material &&
                   Price == bodyPart.Price &&
                   Colour == bodyPart.Colour &&
                   EqualityComparer<ExtendedOtherProperties>.Default.Equals(OtherProperties, bodyPart.OtherProperties);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Id + " : " + BodyType + " : " + Material + " : " + Price + " : " + Colour + " : " + Counter + " : " + OtherProperties;
        }
    }
}
