namespace Ssjw.EAutoService.CarPartsDataUSvc.Model.Model
{
    public class BodyPart : Object
    {
        public string BodyType { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public int Counter { get; set; }
        public OtherProperties OtherProperties { get; set; }

        public BodyPart(string id, string bodyType, string material, decimal price, string colour, int counter) : base(id)
        {
            this.BodyType = bodyType;
            this.Material = material;
            this.Price = price;
            this.Colour = colour;
            this.Counter = counter;
        }

        public BodyPart(string id, string bodyType, string material, decimal price, string colour, int counter, OtherProperties otherProperties) : this(id, bodyType, material, price, colour, counter)
        {
            this.OtherProperties = otherProperties;
        }

        public BodyPart(string id) : base(id)
        { }

        public BodyPart()
        { }

        public override bool Equals(object? obj)
        {
            return obj is BodyPart bodyPart &&
                   Id == bodyPart.Id &&
                   BodyType == bodyPart.BodyType &&
                   Material == bodyPart.Material &&
                   Price == bodyPart.Price &&
                   Colour == bodyPart.Colour &&
                   EqualityComparer<OtherProperties>.Default.Equals(OtherProperties, bodyPart.OtherProperties);
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
